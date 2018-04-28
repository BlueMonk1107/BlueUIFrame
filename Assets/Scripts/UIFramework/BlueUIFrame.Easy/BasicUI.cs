using System;
using System.Reflection;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    public class BasicUI : AUIBase, IUIState
    {
        private IPara paraCache;

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

        }

        public override UILayer GetLayer()
        {
            return UILayer.BasicUI;
        }
    }
}
