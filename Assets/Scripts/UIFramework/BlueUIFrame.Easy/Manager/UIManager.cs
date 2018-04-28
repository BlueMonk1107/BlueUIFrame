//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections.Generic;
using System;
using BlueUIFrame.Easy.Utility;

namespace BlueUIFrame.Easy
{
    public class UIManager : SingletonMono<UIManager>
    {
        private Stack<UIHandler> uiStack;
        private Dictionary<EUiId, Transform> prefabPool;

        public void InitUISystem()
        {
            uiStack = new Stack<UIHandler>();
            prefabPool = new Dictionary<EUiId, Transform>();

            UILayerManager layerManager = AddManager<UILayerManager>(gameObject);
            layerManager.Init();
        }

        private T AddManager<T>(GameObject obj) where T : MonoBehaviour
        {
            if (GetComponent<T>() == null)
            {
                return obj.AddComponent<T>();
            }
            else
            {
                return obj.GetComponent<T>();
            }
        }

        public void ShowUI(EUiId id)
        {
            Transform uiTrans = SpawnUI(id);
            AUIBase ui = uiTrans.GetComponent<AUIBase>();
            if (ui == null)
                throw new Exception("Can't find AUIBase component");
            
            if(ui.GetLayer() == UILayer.BasicUI)
            {
                UIHandler newData = new UIHandler(ui);
                if(uiStack.Count > 0)
                {
                    uiStack.Peek().Hide(ui.GetLayer());
                }
                newData.Show(ui);
                uiStack.Push(newData);
            }
            else
            {
                uiStack.Peek().Show(ui);
            }
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
                    return Instantiate(Resources.Load<Transform>(path), transform);
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
        private BasicUI basicUI;
        public BasicUI BasicUI
        {
            get
            {
                return basicUI;
            }
        }
        private Stack<OverlayUI> overlayUIStack;
        public Stack<OverlayUI> OverlayUIStack
        {
            get
            {
                return overlayUIStack;
            }
        }
        private Stack<TopUI> topUIStack;
        public Stack<TopUI> TopUIStack
        {
            get
            {
                return topUIStack;
            }
        }

        public UIData(BasicUI basic)
        {
            basicUI = basic;
            overlayUIStack = new Stack<OverlayUI>();
            topUIStack = new Stack<TopUI>();
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
            if(basicUI != null)
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
            switch(ui.GetLayer())
            {
                case UILayer.BasicUI:
                    ShowUI<BasicUI>(ui);
                    break;
                case UILayer.OverlayUI:
                    ShowUI(ui,data.OverlayUIStack);
                    break;
                case UILayer.TopUI:
                    ShowUI(ui, data.TopUIStack);
                    break;
            }
        }

        public void BackToShow()
        {
            ShowUI<BasicUI>(data.BasicUI);
            if (data.OverlayUIStack.Count>0)
            {
                HandleState(data.OverlayUIStack.Peek());
            }
            if (data.TopUIStack.Count > 0)
            {
                HandleState(data.TopUIStack.Peek());
            }
        }

        public void Hide(UILayer showLayer)
        {
            HideUI<BasicUI>(showLayer,UILayer.BasicUI);
            HideUI(showLayer,UILayer.OverlayUI,data.OverlayUIStack);
            HideUI(showLayer, UILayer.TopUI, data.TopUIStack);
        }

        public bool Back()
        {
            if(CloseUI(data.TopUIStack))
            {
                return true;
            }
            else
            {
                if(CloseUI(data.OverlayUIStack))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void ShowUI<T>(AUIBase ui,Stack<T> stack = null) where T : AUIBase
        {
            if(stack != null)
            {
                if (stack.Count > 0)
                {
                    ((IUIState)stack.Peek()).Hide();
                }
                stack.Push((T)ui);
            }
            HandleState(ui);
        }

        private void HandleState<T>(T ui) where T:AUIBase
        {
            IUIState stateFunction = (IUIState)ui;
            switch (ui.uiState)
            {
                case UIStateEnum.INIT:
                    UILayerManager.Instance.SetUILayer(ui);
                    stateFunction.Init();
                    stateFunction.Show();
                    break;
                case UIStateEnum.HIDE:
                    stateFunction.Show();
                    break;
            }
        }

        private void HideUI<T>(UILayer showLayer,UILayer targetLayer, Stack<T> stack = null) where T : AUIBase
        {
            if (showLayer <= targetLayer)
            {
                if(stack != null)
                {
                    if (stack.Count > 0)
                    {
                        ((IUIState)stack.Peek()).Hide();
                    }
                }
                else
                {
                    data.BasicUI.Hide();
                }
            }
        }

        private bool CloseUI<T>(Stack<T> stack) where T:AUIBase
        {
            if (stack.Count > 0)
            {
                ((IUIState)stack.Pop()).Hide();
                return true;
            }

            return false;
        }
    }

}
