//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy.Demo
{
    public class ProxyManager : UIProxyManager
    {
        protected override void RegisterProxy()
        {
            proxyDic.Add(NormalInfoProxy.NAME, new NormalInfoProxy());
        }
    }
}
