//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;
using BlueUIFrame.Easy.Utility;
using System.Collections.Generic;
using System;

namespace BlueUIFrame.Easy
{
    public abstract class UIDataHandlerManager: IUIDataHandlerManager
    {
        protected Dictionary<string,IDataHandler> handlerDic;

        public UIDataHandlerManager()
        {
            handlerDic = new Dictionary<string, IDataHandler>();
            RegisterHandler();
        }

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
