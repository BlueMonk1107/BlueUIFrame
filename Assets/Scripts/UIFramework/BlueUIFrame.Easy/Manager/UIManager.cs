//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using UnityEngine;
using System.Collections.Generic;
using System;
using BlueUIFrame.Easy.Utility;
using Object = UnityEngine.Object;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// UI管理类
    /// </summary>
    public class UIManager : IUIManager
    {
        private Func<string,Object, bool> UIInitAction;
        private Func<string,bool, bool> UIActiveAction;
        private Stack<UIHandler> uiStack;
        private Dictionary<EUiId, Transform> prefabPool;

        public UIManager()
        {
            uiStack = new Stack<UIHandler>();
            prefabPool = new Dictionary<EUiId, Transform>();
        }
        /// <summary>
        /// 添加UI初始化状态的监听
        /// </summary>
        /// <param name="action"></param>
        public void AddUIInitListener(Func<string,Object, bool> action)
        {
            UIInitAction = action;
        }
        /// <summary>
        /// 添加UI对象显示或隐藏状态的监听
        /// </summary>
        /// <param name="action"></param>
        public void AddUIActiveListener(Func<string,bool, bool> action)
        {
            UIActiveAction = action;
        }
        /// <summary>
        /// 根据UI的ID显示UI
        /// </summary>
        /// <param name="id"></param>
        public void ShowUI(EUiId id)
        {
            Transform uiTrans = SpawnUI(id);
            AUIBase ui = uiTrans.GetComponent<AUIBase>();
            if (ui == null)
                throw new Exception("Can't find AUIBase component");

            if (ui.GetLayer() == UILayer.BasicUI)
            {
                UIHandler newHandler = new UIHandler(ui);
                if (uiStack.Count > 0)
                {
                    uiStack.Peek().Hide(ui.GetLayer());
                }
                AddListener(ui,id, newHandler);
                newHandler.Show(ui);
                uiStack.Push(newHandler);
            }
            else
            {
                AddListener(ui,id, uiStack.Peek());
                uiStack.Peek().Show(ui);
            }
        }
        /// <summary>
        /// 通过UIHandler统一添加UI对UIInitAction及UIActiveAction的监听
        /// </summary>
        /// <param name="ui"></param>
        /// <param name="id"></param>
        /// <param name="handler"></param>
        private void AddListener(AUIBase ui, EUiId id,UIHandler handler)
        {
            handler.AddListener(ui, ob=>UIInitAction(id.ToString(),ob), isActive => UIActiveAction(id.ToString(), isActive));
        }
        /// <summary>
        /// 返回上一个UI界面
        /// </summary>
        public void Back()
        {
            if (!uiStack.Peek().Back() && uiStack.Count > 1)
            {
                uiStack.Pop().Hide(UILayer.BasicUI);
                UIHandler handler = uiStack.Peek();
                handler.BackToShow();
            }
        }
        /// <summary>
        /// 生成UI对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Transform SpawnUI(EUiId id)
        {
            string path = UIPathManager.GetPath(id);
            if (!string.IsNullOrEmpty(path))
            {
                if (!prefabPool.ContainsKey(id) || prefabPool[id] == null)
                {
                    prefabPool[id] = UITool.SpawnUI(path);
                }
                return prefabPool[id];
            }
            else
            {
                return null;
            }
        }
    }
    /// <summary>
    /// UI对象的存储数据类
    /// 每一个数据类只有一个BasicUI对象
    /// </summary>
    public struct UIData
    {
        public BasicUI BasicUI { get; private set; }
        public Stack<OverlayUI> OverlayUIStack { get; private set; }

        public Stack<TopUI> TopUIStack { get; private set; }

        public UIData(BasicUI basic)
        {
            BasicUI = basic;
            OverlayUIStack = new Stack<OverlayUI>();
            TopUIStack = new Stack<TopUI>();
        }
    }
    /// <summary>
    /// UI行为处理器
    /// </summary>
    public class UIHandler
    {
        private UIData data;
        public BasicUI BasicUI
        {
            get
            {
                return data.BasicUI;
            }
        }

        public UIHandler(AUIBase basicUI)
        {
            if (basicUI != null)
            {
                data = new UIData((BasicUI)basicUI);
            }
            else
            {
                throw new Exception("basicUI is null");
            }
        }

        /// <summary>
        /// 显示UI
        /// </summary>
        /// <param name="ui"></param>
        public void Show(AUIBase ui)
        {
            switch (ui.GetLayer())
            {
                case UILayer.BasicUI:
                    ShowUI<BasicUI>(ui);
                    break;
                case UILayer.OverlayUI:
                    ShowUI(ui, data.OverlayUIStack);
                    break;
                case UILayer.TopUI:
                    ShowUI(ui, data.TopUIStack);
                    break;
            }
        }
        /// <summary>
        /// 返回方法中UI的显示
        /// </summary>
        public void BackToShow()
        {
            ShowUI<BasicUI>(data.BasicUI);
            if (data.OverlayUIStack.Count > 0)
            {
                data.OverlayUIStack.Peek().UIState = UIStateEnum.SHOW;
            }
            if (data.TopUIStack.Count > 0)
            {
                data.TopUIStack.Peek().UIState = UIStateEnum.SHOW;
            }
        }
        /// <summary>
        /// 隐藏UI
        /// </summary>
        /// <param name="showLayer">当前即将显示的UI的层级</param>
        public void Hide(UILayer showLayer)
        {
            HideUI<BasicUI>(showLayer, UILayer.BasicUI);
            HideUI(showLayer, UILayer.OverlayUI, data.OverlayUIStack);
            HideUI(showLayer, UILayer.TopUI, data.TopUIStack);
        }
        /// <summary>
        /// 返回上一界面
        /// </summary>
        /// <returns>
        ///     true代表Overlay或Top层有界面返回成功，
        ///     若为false，代表需要返回的是当前数据类的BasicUI
        /// </returns>
        public bool Back()
        {
            if (CloseUI(data.TopUIStack))
            {
                return true;
            }
            else
            {
                if (CloseUI(data.OverlayUIStack))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 添加对UI的监听
        /// </summary>
        /// <param name="ui"></param>
        /// <param name="initAction"></param>
        /// <param name="activeAction"></param>
        public void AddListener(AUIBase ui,Func<Object, bool> initAction,Func<bool, bool> activeAction)
        {
            if (ui.UIState == UIStateEnum.NOTINIT)
            {
                ui.AddInitListener(initAction);
                ui.AddActiveListener(activeAction);
            }
        }
        /// <summary>
        /// 显示UI的处理方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ui"></param>
        /// <param name="stack"></param>
        private void ShowUI<T>(AUIBase ui, Stack<T> stack = null) where T : AUIBase
        {
            if (stack != null)
            {
                if (stack.Count > 0)
                {
                    stack.Peek().UIState = UIStateEnum.HIDE;
                }
                stack.Push((T)ui);
            }
            ui.UIState = UIStateEnum.SHOW;
        }
        /// <summary>
        /// 隐藏UI的处理方法
        /// 当其他高于此层级UI显示时，隐藏UI
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="showLayer"></param>
        /// <param name="targetLayer"></param>
        /// <param name="stack"></param>
        private void HideUI<T>(UILayer showLayer, UILayer targetLayer, Stack<T> stack = null) where T : AUIBase
        {
            if (showLayer <= targetLayer)
            {
                if (stack != null)
                {
                    if (stack.Count > 0)
                    {
                        stack.Peek().UIState = UIStateEnum.HIDE;
                    }
                }
                else
                {
                    data.BasicUI.UIState = UIStateEnum.HIDE;
                }
            }
        }
        /// <summary>
        /// 关闭UI界面
        /// 当从此界面返回，请处栈内数据并隐藏
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stack"></param>
        /// <returns></returns>
        private bool CloseUI<T>(Stack<T> stack) where T : AUIBase
        {
            if (stack.Count > 0)
            {
                stack.Pop().UIState = UIStateEnum.HIDE;
                return true;
            }

            return false;
        }
    }

}
