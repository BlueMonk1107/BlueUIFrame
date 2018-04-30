using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    public abstract class AUIBase : MonoBehaviour
    {
        protected IDataHandler dataHandler;
        protected UIStateEnum uiState;

        public EUiId ID { get; protected set; }
        public UIStateEnum UIState
        {
            get { return uiState; }
            set
            {
                HandleState(uiState, value);
                uiState = value;
            }
        }

        public Action<bool> ObjectActiveAction;

        public abstract UILayer GetLayer();
        protected abstract IUIDataHandlerManager GetDataHandlerManager();
        protected abstract void SetActive(bool isShow);
        protected abstract void HandleState(UIStateEnum currentState, UIStateEnum targetState);
    }
}
