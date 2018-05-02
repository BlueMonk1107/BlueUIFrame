//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// 负责UI层级的控制
    /// </summary>
    public interface IUILayerManager
    {
        /// <summary>
        /// 初始化此层级管理器
        /// </summary>
        void Init();
        /// <summary>
        /// 设置UI到其对应的层级父物体下
        /// </summary>
        /// <param name="ui"></param>
        void SetUILayer(AUIBase ui);
    }
}
