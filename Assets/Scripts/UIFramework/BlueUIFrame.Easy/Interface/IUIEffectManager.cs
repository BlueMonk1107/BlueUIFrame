//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// 负责UI动效的控制
    /// </summary>
    public interface IUIEffectManager
    {
        /// <summary>
        /// 对象初始化时的回调函数
        /// </summary>
        /// <param name="uiId"></param>
        /// <param name="uiBase"></param>
        /// <returns></returns>
        bool InitFun(string uiId, Object uiBase);
        /// <summary>
        /// 控制对象显示或隐藏的回调函数
        /// </summary>
        /// <param name="uiId"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        bool ActiveFun(string uiId, bool isActive);
    }
}
