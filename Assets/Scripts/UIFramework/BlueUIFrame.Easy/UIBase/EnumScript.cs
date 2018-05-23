//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架 
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy
{
    public enum UILayer
    {
        BasicUI,
        OverlayUI,
        TopUI
    }

    public enum UIStateEnum
    {
        NOTINIT,
        INIT,
        SHOW,
        HIDE
    }
}
