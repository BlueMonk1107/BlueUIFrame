using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    public abstract class AUIBase : MonoBehaviour
    {
        protected IDataHandler dataHandler;

        public EUiId ID { get; private set; }

        public UIStateEnum uiState { get; protected set; }

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

        public abstract UILayer GetLayer();
        protected abstract IUIDataHandlerManager GetDataHandlerManager();

        public virtual void Init()
        {
            uiState = UIStateEnum.INITIALIZED;
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
            uiState = UIStateEnum.SHOW;
            UpdateShow();
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
            uiState = UIStateEnum.HIDE;
        }

        protected virtual void UpdateShow()
        {
            
        }

        protected virtual T GetData<T>() where T:IData
        {
            return (T) dataHandler.GetData();
        }
    }

    public enum UIStateEnum
    {
        NOTINIT,
        INITIALIZED,
        SHOW,
        HIDE
    }
}
