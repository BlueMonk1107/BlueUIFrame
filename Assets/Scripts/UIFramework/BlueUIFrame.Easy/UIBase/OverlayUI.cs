using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    public class OverlayUI : AUIBase
    {
        public override UILayer GetLayer()
        {
            return UILayer.OverlayUI;
        }
        protected override IUIDataHandlerManager GetDataHandlerManager()
        {
            return UIManager.Instance.DataHandlerManager;
        }
    }
}
