using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BlueUIFrame.Easy
{
    public abstract class AUIBase : MonoBehaviour
    {
        public EUiId ID { get; protected set; }
        public UIStateEnum UIState
        {
            get { return GetUIState(); }
            set
            {
                SetUIState(value);
            }
        }

        public abstract void AddInitListener(Func<Object, bool> action);
        public abstract void AddActiveListener(Func<bool, bool> action);

        public abstract UILayer GetLayer();
        protected abstract IUIDataHandlerManager GetDataHandlerManager();
        protected abstract void SetActive(bool isShow);
        protected abstract void SetUIState(UIStateEnum state);
        protected abstract UIStateEnum GetUIState();
        protected abstract void HandleState(UIStateEnum currentState, UIStateEnum targetState);
    }
}
