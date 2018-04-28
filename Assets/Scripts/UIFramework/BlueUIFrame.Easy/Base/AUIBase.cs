using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    public abstract class AUIBase : MonoBehaviour
    {

        public EUiId ID { get; private set; }

        public UIStateEnum uiState { get; protected set; }

        public bool IsMainUI { get; private set; }

        protected void InitUI(EUiId id, bool isMainUI = false)
        {
            ID = id;
            uiState = UIStateEnum.INIT;
            IsMainUI = isMainUI;
        }

        public abstract UILayer GetLayer();
    }
}
