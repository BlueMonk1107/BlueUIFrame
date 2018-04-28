using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    public class TopUI : AUIBase, IUIState
    {
        public virtual void Init()
        {
            uiState = UIStateEnum.INIT;
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
            uiState = UIStateEnum.SHOW;
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
            uiState = UIStateEnum.HIDE;
        }

        public virtual void Complete()
        {
            throw new System.NotImplementedException();
        }

        public override UILayer GetLayer()
        {
            return UILayer.TopUI;
        }
    }
}
