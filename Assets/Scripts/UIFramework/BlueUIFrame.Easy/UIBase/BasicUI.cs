//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
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
    }
}
