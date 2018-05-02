//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================

using System;
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// 数据处理器接口
    /// </summary>
    public interface IDataHandler
    {
        /// <summary>
        /// 更新UI显示
        /// </summary>
        Action UpdateShow { get; set; }
        /// <summary>
        /// 获取处理器名称
        /// </summary>
        /// <returns></returns>
        string GetName();
        /// <summary>
        /// 初始化数据对象
        /// </summary>
        void InitData();
        /// <summary>
        /// 获取数据对象
        /// </summary>
        /// <returns></returns>
        IData GetData();
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="newData"></param>
        void UpdataData(IData newData);
    }
}
