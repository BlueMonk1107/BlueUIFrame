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
            CheckRepetition();
        }

        private void CheckRepetition()
        {
            AUIBase[] uiList = FindObjectsOfType<AUIBase>();
            int count = 0;
            foreach (AUIBase item in uiList)
            {
                if (item.IsMainUI)
                {
                    count++;
                }
            }
            if (count > 1)
            {
                Debug.LogError("主界面UI只能存在一个，目前存在：" + count + "个");
            }
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
