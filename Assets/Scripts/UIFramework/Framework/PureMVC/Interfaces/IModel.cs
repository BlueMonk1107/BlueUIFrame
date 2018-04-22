//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// PureMVC Model的接口定义
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         在PureMVC中，IModel实现者通过命名查找来访问IProxy对象。
    ///     </para>
    ///     <para>
    ///         IModel</c> 承担这些责任:
    ///         <list type="bullet">
    ///             <item>维护IProxy实例的缓存</item>
    ///             <item>提供注册，检索和删除IProxy实例的方法</item>
    ///         </list>
    ///     </para>
    /// </remarks>
    public interface IModel
    {
        /// <summary>
        /// 使用Model注册一个IProxy实例
        /// </summary>
        /// <param name="proxy">an object reference to be held by the <c>Model</c>.</param>
        void RegisterProxy(IProxy proxy);

        /// <summary>
        /// 从Model中检索IProxy实例
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns>the <c>IProxy</c> instance previously registered with the given <c>proxyName</c>.</returns>
        IProxy RetrieveProxy(string proxyName);

        /// <summary>
        /// 从Model中移除一个IProxy实例
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns>the <c>IProxy</c> that was removed from the <c>Model</c></returns>
        IProxy RemoveProxy(string proxyName);

        /// <summary>
        /// 检查Proxy是否已被注册
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns>whether a Proxy is currently registered with the given <c>proxyName</c>.</returns>
        bool HasProxy(string proxyName);
    }
}
