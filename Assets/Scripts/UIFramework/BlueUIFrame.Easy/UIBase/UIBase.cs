//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================

using System;
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy
{
    public class UIBase : AUIBase
    {
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

        public override UILayer GetLayer()
        {
            throw new System.NotImplementedException();
        }

        protected override IUIDataHandlerManager GetDataHandlerManager()
        {
            throw new System.NotImplementedException();
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
                    ObjectActiveAction(isShow);
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
