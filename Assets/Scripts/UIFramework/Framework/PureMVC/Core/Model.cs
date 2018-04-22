//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using PureMVC.Interfaces;

namespace PureMVC.Core
{
    /// <summary>
    /// 多例IModel的实现
    /// </summary>
    /// <remarks>
    ///     <para>在PureMVC中，Model类通过命名查找提供对模型对象（代理）的访问</para>
    ///     <para>Model承担一下责任:</para>
    ///     <list type="bullet">
    ///         <item>维护IProxy实例的缓存</item>
    ///         <item>提供注册，检索和删除IProxy实例的方法</item>
    ///     </list>
    ///     <para>
    ///         您的应用程序必须使用Model注册IProxy实例。 
    ///         通常，当Facade初始化Core参与者时，您可以使用ICommand创建并注册IProxy
    ///     </para>
    /// </remarks>
    /// <seealso cref="PureMVC.Patterns.Proxy.Proxy"/>
    /// <seealso cref="PureMVC.Interfaces.IProxy" />
    public class Model: IModel
    {
        /// <summary>
        /// 构建并初始化一个新model
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This <c>IModel</c> implementation is a Multiton, 
        ///         so you should not call the constructor 
        ///         directly, but instead call the static Multiton 
        ///         Factory method <c>Model.getInstance(multitonKey, () => new Model(multitonKey))</c>
        ///     </para>
        /// </remarks>
        /// <param name="key">Key of model</param>
        /// <exception cref="System.Exception">Thrown if instance for this Multiton key has already been constructed</exception>
        public Model(string key)
        {
            if (instanceMap.ContainsKey(key) && multitonKey != null) throw new Exception(MULTITON_MSG);
            multitonKey = key;
            instanceMap.Add(key, this);
            proxyMap = new Dictionary<string, IProxy>();
            InitializeModel();
        }

        /// <summary>
        /// 初始化多例model实例
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Called automatically by the constructor, this 
        ///         is your opportunity to initialize the Multiton 
        ///         instance in your subclass without overriding the 
        ///         constructor
        ///     </para>
        /// </remarks>
        protected virtual void InitializeModel()
        {
        }

        /// <summary>
        /// Model多例工厂方法 
        /// </summary>
        /// <param name="key">Key of model</param>
        /// <param name="modelClassRef">the <c>FuncDelegate</c> of the <c>IModel</c></param>
        /// <returns>the instance for this Multiton key </returns>
        public static IModel GetInstance(string key, Func<IModel> modelClassRef)
        {
            if (!instanceMap.ContainsKey(key))
            {
                instanceMap[key] = new Model(key);
            }

            return instanceMap[key];
        }

        /// <summary>
        /// 使用Model注册IProxy
        /// </summary>
        /// <param name="proxy">proxy an <c>IProxy</c> to be held by the <c>Model</c>.</param>
        public virtual void RegisterProxy(IProxy proxy)
        {
            proxy.InitializeNotifier(multitonKey);
            proxyMap[proxy.ProxyName] = proxy;
            proxy.OnRegister();
        }

        /// <summary>
        /// 在Model中检索IProxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns>the <c>IProxy</c> instance previously registered with the given <c>proxyName</c>.</returns>
        public virtual IProxy RetrieveProxy(string proxyName)
        {
            IProxy proxy;
            return proxyMap.TryGetValue(proxyName, out proxy) ? proxy : null;
        }

        /// <summary>
        /// 在Model中移除IProxy
        /// </summary>
        /// <param name="proxyName">proxyName name of the <c>IProxy</c> instance to be removed.</param>
        /// <returns>the <c>IProxy</c> that was removed from the <c>Model</c></returns>
        public virtual IProxy RemoveProxy(string proxyName)
        {
            IProxy proxy = null;
            if (proxyMap.ContainsKey(proxyName))
            {
                proxy = proxyMap[proxyName];
                proxy.OnRemove();
                proxyMap.Remove(proxyName);
            }
            return proxy;
        }

        /// <summary>
        /// 检查Proxy是否已经注册
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns>whether a Proxy is currently registered with the given <c>proxyName</c>.</returns>
        public virtual bool HasProxy(string proxyName)
        {
            return proxyMap.ContainsKey(proxyName);
        }

        /// <summary>
        /// 移除一个IModel实例
        /// </summary>
        /// <param name="key">multitonKey of IModel instance to remove</param>
        public static void RemoveModel(string key)
        {
            instanceMap.Remove(key);
        }

        /// <summary>此核心组件的多例键值</summary>
        protected string multitonKey;

        ///// <summary>Mapping of proxyNames to IProxy instances</summary>
        protected readonly Dictionary<string, IProxy> proxyMap;

        ///// <summary>The Multiton Model instanceMap.</summary>
        protected static readonly Dictionary<string, IModel> instanceMap = new Dictionary<string, IModel>();

        /// <summary>Message Constants</summary>
        protected const string MULTITON_MSG = "Model instance for this Multiton key already constructed!";
    }
}
