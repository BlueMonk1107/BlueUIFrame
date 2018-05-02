//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// UI路径管理脚本
    /// <para>
    /// 类似与配置文件，需要手动在类的字典UIPathDic里配置路径
    /// </para>
    /// </summary>
    public static class UIPathManager
    {

        private static readonly Dictionary<EUiId, string> UIPathDic = new Dictionary<EUiId, string>()
        {
            {EUiId.MAIN_UI, "MainUI"},
            {EUiId.VIEW_ONE, "ViewOne"},
            {EUiId.VIEW_TWO, "ViewTwo"},
            {EUiId.SIDE_VIEW, "Side"},
            {EUiId.DIALOG, "Dialog"}
        };

        /// <summary>
        /// 根据ID获取层级
        /// 需要先在UIPathManager的字典UIPathDic中手动定义路径
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetPath(EUiId id)
        {
            if (UIPathDic.ContainsKey(id))
            {
                return UIPathDic[id];
            }
            else
            {
                Debug.LogError("未在UIPathManager初始化该UI");
                return null;
            }
        }
    }

    public enum EUiId
    {
        MAIN_UI,
        VIEW_ONE,
        VIEW_TWO,
        SIDE_VIEW,
        DIALOG
    }
}
