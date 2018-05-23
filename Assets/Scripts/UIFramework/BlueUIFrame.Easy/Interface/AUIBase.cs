//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// UI基础接口
    /// </summary>
    public abstract class AUIBase : MonoBehaviour
    {
        /// <summary>
        /// 当前UI的名称ID
        /// </summary>
        public string ID { get; protected set; }
        /// <summary>
        /// UI的状态：未初始化，初始化，显示，隐藏
        /// </summary>
        public UIStateEnum UIState
        {
            get { return GetUIState(); }
            set
            {
                SetUIState(value);
            }
        }
        /// <summary>
        /// 添加初始化函数的监听
        /// </summary>
        /// <param name="action"></param>
        public abstract void AddInitListener(Func<Object, bool> action);
        /// <summary>
        /// 添加对象显示或隐藏状态的监听
        /// </summary>
        /// <param name="action"></param>
        public abstract void AddActiveListener(Func<bool, bool> action);
        /// <summary>
        /// 获取UI层级
        /// </summary>
        /// <returns></returns>
        public abstract UILayer GetLayer();
        /// <summary>
        /// 获取数据管理器的对象
        /// </summary>
        /// <returns></returns>
        protected abstract IUIDataHandlerManager GetDataHandlerManager();
        /// <summary>
        /// 设置对象的显示或隐藏状态
        /// </summary>
        /// <param name="isShow"></param>
        protected abstract void SetActive(bool isShow);
        /// <summary>
        /// 设置UI的状态
        /// </summary>
        /// <param name="state"></param>
        protected abstract void SetUIState(UIStateEnum state);
        /// <summary>
        /// 获取UI的状态
        /// </summary>
        /// <returns></returns>
        protected abstract UIStateEnum GetUIState();
        /// <summary>
        /// UI状态改变的处理函数
        /// </summary>
        /// <param name="currentState"></param>
        /// <param name="targetState"></param>
        protected abstract void HandleState(UIStateEnum currentState, UIStateEnum targetState);
    }
}
