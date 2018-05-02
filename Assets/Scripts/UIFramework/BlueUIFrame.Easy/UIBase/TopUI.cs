//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
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
    }
}
