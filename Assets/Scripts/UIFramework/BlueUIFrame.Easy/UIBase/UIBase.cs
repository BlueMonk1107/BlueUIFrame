//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================

using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

namespace BlueUIFrame.Easy
{
    public class UIBase : AUIBase
    {
        protected IDataHandler dataHandler;
        private UIStateEnum uiState;
        private Func<Object, bool> InitAction;
        private Func<bool, bool> ObjectActiveAction;

        protected void InitUI(EUiId id, string dataHandlerName = null)
        {
            ID = id;
            uiState = UIStateEnum.NOTINIT;
            if (!string.IsNullOrEmpty(dataHandlerName))
            {
                dataHandler = GetDataHandlerManager().GetHandler(dataHandlerName);
                dataHandler.UpdateShow += UpdateShow;
            }
        }

        protected override void SetUIState(UIStateEnum state)
        {
            HandleState(uiState, state);
            uiState = state;
        }

        protected override UIStateEnum GetUIState()
        {
            return uiState;
        }

        protected override void HandleState(UIStateEnum currentState, UIStateEnum targetState)
        {
            switch (targetState)
            {
                case UIStateEnum.SHOW:
                    if (currentState == UIStateEnum.NOTINIT)
                    {
                        Init();
                        Show();
                    }
                    else
                    {
                        Show();
                    }
                    break;
                case UIStateEnum.HIDE:
                    Hide();
                    break;
            }
        }

        protected virtual void Init()
        {
            if (InitAction != null)
            {
                InitAction(gameObject);
            }
        }

        protected virtual void Show()
        {
            UpdateShow();
            SetActive(true);
        }

        protected virtual void Hide()
        {
            SetActive(false);
        }

        protected virtual void UpdateShow()
        {
        }

        public override void AddInitListener(Func<Object, bool> action)
        {
            InitAction = action;
        }

        public override void AddActiveListener(Func<bool, bool> action)
        {
            ObjectActiveAction = action;
        }

        public override UILayer GetLayer()
        {
            throw new System.NotImplementedException();
        }

        protected override IUIDataHandlerManager GetDataHandlerManager()
        {
            return AUIRoot.DataHandlerManager;
        }

        protected override void SetActive(bool isShow)
        {
            try
            {
                if (ObjectActiveAction == null)
                {
                    gameObject.SetActive(isShow);
                }
                else
                {
                    if (!ObjectActiveAction(isShow))
                    {
                        gameObject.SetActive(isShow);
                    }
                }
            }
            catch (Exception)
            {
                Debug.LogError(gameObject.name+ " ObjectActiveAction has ERROR");
                gameObject.SetActive(isShow);
            }
            
        }

        protected virtual T GetData<T>() where T : IData
        {
            return (T)dataHandler.GetData();
        }
    }

    public enum UIStateEnum
    {
        NOTINIT,
        INIT,
        SHOW,
        HIDE
    }
}
