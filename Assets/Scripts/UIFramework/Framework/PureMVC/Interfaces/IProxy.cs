//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// PureMVC Proxy的接口定义 .
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         在PureMVC中, IProxy承担以下责任:
    ///         <list type="bullet">
    ///             <item>实现一个返回Proxy名称的通用方法</item>
    ///             <item>提供设置或获取data对象的通用方法</item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///         另外, IProxy 通常:
    ///         <list type="bullet">
    ///             <item>保持对一个或多个model数据的引用</item>
    ///             <item>提供操作该数据的方法</item>
    ///             <item>当model数据发生变化时生成INotifications</item>
    ///             <item>如果它们没有多次实例化，则将它们的Name暴露出来设为public static const以供调用</item>
    ///             <item>封装与用于提取和保存model数据的本地或远程服务的交互。</item>
    ///         </list>
    ///     </para>
    /// </remarks>
    public interface IProxy: INotifier
    {
        /// <summary>
        /// 获取Proxy的name
        /// </summary>
        string ProxyName { get; }

        /// <summary>
        /// 获取或设置data对象
        /// </summary>
        object Data { get; set; }

        /// <summary>
        /// 当Proxy被注册时由Model调用
        /// </summary>
        void OnRegister();

        /// <summary>
        /// 当Proxy被移除时由Model调用
        /// </summary>
        void OnRemove();
    }
}
