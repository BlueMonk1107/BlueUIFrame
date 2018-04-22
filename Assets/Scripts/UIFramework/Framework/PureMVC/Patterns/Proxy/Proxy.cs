//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Proxy
{
    /// <summary>
    /// IProxy的基础实现
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         在PureMVC中，Proxy类用于管理应用程序数据模型的某些部分。
    ///     </para>
    ///     <para>
    ///          一个Proxy可以简单地管理对本地数据对象的引用，
    ///          在这种情况下，与它交互可能涉及以同步方式设置和获取其数据。
    ///     </para>
    ///     <para>
    ///         Proxy类还用于封装应用程序与远程服务的交互以保存或检索数据，在这种情况下，我们采用异步方式; 
    ///         在Proxy上设置数据（或调用方法）并侦听Notification在Proxy从服务中检索数据时发送。
    ///     </para>
    /// </remarks>
    /// <seealso cref="PureMVC.Core.Model"/>
    public class Proxy: Notifier, IProxy, INotifier
    {
        /// <summary>proxy的名称</summary>
        public static string NAME = "Proxy";

        /// <summary>
        /// 构造器.
        /// </summary>
        /// <param name="proxyName"></param>
        /// <param name="data"></param>
        public Proxy(string proxyName, object data=null)
        {
            ProxyName = proxyName ?? Proxy.NAME;
            if (data != null) Data = data;
        }

        /// <summary>
        /// 当Proxy注册时，由Model调用
        /// </summary>
        public virtual void OnRegister()
        { 
        }

        /// <summary>
        /// 当Proxy移除时，由Model调用
        /// </summary>
        public virtual void OnRemove()
        {
        }

        /// <summary>the proxy name</summary>
        public string ProxyName { get; protected set; }

        /// <summary>the proxy name</summary>
        public object Data { get; set; }
    }
}
