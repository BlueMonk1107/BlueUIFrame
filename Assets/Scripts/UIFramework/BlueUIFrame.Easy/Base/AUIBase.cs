using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    public abstract class AUIBase : MonoBehaviour
    {

        public EUiId ID { get; private set; }

        public UIStateEnum uiState { get; protected set; }

        protected void InitUI(EUiId id)
        {
            ID = id;
            uiState = UIStateEnum.INIT;
        }

        public abstract UILayer GetLayer();
    }
}
