using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    public class TopUI : UIBase
    {
        public override UILayer GetLayer()
        {
            return UILayer.TopUI;
        }
        protected override IUIDataHandlerManager GetDataHandlerManager()
        {
            return UIManager.Instance.DataHandlerManager;
        }
    }
}
