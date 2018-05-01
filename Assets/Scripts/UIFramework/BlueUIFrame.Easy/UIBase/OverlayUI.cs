using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    public class OverlayUI : UIBase
    {
        public override UILayer GetLayer()
        {
            return UILayer.OverlayUI;
        }
    }
}
