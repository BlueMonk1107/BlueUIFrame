//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections.Generic;
using System;
using BlueUIFrame.Easy.Utility;
using Object = UnityEngine.Object;

namespace BlueUIFrame.Easy
{
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

        public void AddUIInitListener(Func<string,Object, bool> action)
        {
            UIInitAction = action;
        }

        public void AddUIActiveListener(Func<string,bool, bool> action)
        {
            UIActiveAction = action;
        }

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

        private void AddListener(AUIBase ui, EUiId id,UIHandler handler)
        {
            handler.AddListener(ui, ob=>UIInitAction(id.ToString(),ob), isActive => UIActiveAction(id.ToString(), isActive));
        }

        public void Back()
        {
            if (!uiStack.Peek().Back() && uiStack.Count > 1)
            {
                uiStack.Pop().Hide(UILayer.BasicUI);
                UIHandler handler = uiStack.Peek();
                handler.BackToShow();
            }
        }

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

        public void Hide(UILayer showLayer)
        {
            HideUI<BasicUI>(showLayer, UILayer.BasicUI);
            HideUI(showLayer, UILayer.OverlayUI, data.OverlayUIStack);
            HideUI(showLayer, UILayer.TopUI, data.TopUIStack);
        }

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

        public void AddListener(AUIBase ui,Func<Object, bool> initAction,Func<bool, bool> activeAction)
        {
            if (ui.UIState == UIStateEnum.NOTINIT)
            {
                ui.AddInitListener(initAction);
                ui.AddActiveListener(activeAction);
            }
        }

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
