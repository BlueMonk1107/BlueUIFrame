//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame.Easy;

namespace BlueUIFrame.Easy.Demo
{
    /// <summary>
    /// UI路径管理脚本
    /// <para>
    /// 类似与配置文件，需要手动在类的字典UIPathDic里配置路径
    /// </para>
    /// </summary>
    public class UIPathManager:AUIPathManager
    {
        protected override void InitPathDic()
        {
            UIPathDic[EUiId.MAIN_UI.ToString()] = "MainUI";
            UIPathDic[EUiId.VIEW_ONE.ToString()] = "ViewOne";
            UIPathDic[EUiId.VIEW_TWO.ToString()] = "ViewTwo";
            UIPathDic[EUiId.SIDE_VIEW.ToString()] = "Side";
            UIPathDic[EUiId.DIALOG.ToString()] = "Dialog";
        }
    }
}
