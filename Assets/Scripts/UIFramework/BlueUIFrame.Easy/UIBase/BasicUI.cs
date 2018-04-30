using System;
using System.Reflection;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    public class BasicUI : UIBase
    {
        public override UILayer GetLayer()
        {
            return UILayer.BasicUI;
        }

        protected override IUIDataHandlerManager GetDataHandlerManager()
        {
            return UIManager.Instance.DataHandlerManager;
        }
    }
}
