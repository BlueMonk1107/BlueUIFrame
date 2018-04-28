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
    public abstract class UIProxyManager
    {
        protected Dictionary<string,IProxy> proxyDic;

        public UIProxyManager()
        {
            proxyDic = new Dictionary<string, IProxy>();
            RegisterProxy();
        }

        protected abstract void RegisterProxy();

        public void RemoveProxy(string proxyName)
        {
            proxyDic.Remove(proxyName);
        }

        public T GetProxy<T>(string proxyName) where T:IProxy
        {
            if (proxyDic.ContainsKey(proxyName))
            {
                return (T)proxyDic[proxyName];
            }
            else
            {
                throw new Exception("this proxy is not registered");
            }
        }
    }
}
