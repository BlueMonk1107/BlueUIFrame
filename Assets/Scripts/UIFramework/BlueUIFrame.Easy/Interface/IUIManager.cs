//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================

using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// 负责UI组件的控制
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// 添加UI初始化状态的监听
        /// </summary>
        /// <param name="action"></param>
        void AddUIInitListener(Func<string, Object, bool> action);
        /// <summary>
        /// 添加UI对象显示或隐藏状态的监听
        /// </summary>
        /// <param name="action"></param>
        void AddUIActiveListener(Func<string, bool, bool> action);
        /// <summary>
        /// 根据UI的ID显示UI
        /// </summary>
        /// <param name="id"></param>
        void ShowUI(EUiId id);
        /// <summary>
        /// 返回上一界面
        /// </summary>
        void Back();
    }
}
