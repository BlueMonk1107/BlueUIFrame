//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using UnityEngine;
using System.Collections;
using BlueUIFrame.Easy.Utility;
using System.Collections.Generic;
using System;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// 数据处理器对象管理类
    /// <para>使用时，需要继承此类，并实现RegisterHandler()方法，初始化所有自定义的数据处理器</para>
    /// </summary>
    public abstract class UIDataHandlerManager: IUIDataHandlerManager
    {
        protected Dictionary<string,IDataHandler> handlerDic;

        public UIDataHandlerManager()
        {
            handlerDic = new Dictionary<string, IDataHandler>();
            RegisterHandler();
        }
        /// <summary>
        /// 初始化所有自定义的数据处理器
        /// </summary>
        protected abstract void RegisterHandler();

        public void RemoveHandler(string handlerName)
        {
            handlerDic.Remove(handlerName);
        }

        public IDataHandler GetHandler(string handlerName)
        {
            if (handlerDic.ContainsKey(handlerName))
            {
                return handlerDic[handlerName];
            }
            else
            {
                throw new Exception("this proxy is not registered");
            }
        }
    }
}
