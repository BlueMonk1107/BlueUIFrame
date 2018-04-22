//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using PureMVC.Interfaces;

namespace PureMVC.Patterns.Observer
{
    /// <summary>
    /// A Base <c>INotifier</c> implementation.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         MacroCommand，Command，Mediator 和 Proxy都需要发送Notifications
    ///     </para>
    ///     <para>
    ///         INotifier接口提供了一个通用方法调用sendNotification
    ///         这减轻了实际构建Notifications的必要代码
    ///     </para>
    ///     <para>
    ///         上面提到的所有类都扩展的Notifier类，提供了对Facade Multiton的初始化引用
    ///         这是用于发送Notifications
    ///         但也简化了实现，因为这些类有频繁的Facade交互，并且通常需要访问facade
    ///     </para>
    ///     <para>
    ///         注意：在框架的MultiCore版本中，通知程序有一个警告，
    ///         它们无法发送通知或直到它们具有有效的multitonKey才能到达Facade。
    ///         multitonKey设置为：
    ///         <list type="bullet">
    ///             <item>当一个Command被Controller执行时 </item>
    ///             <item>当一个Mediator被View注册时</item>
    ///             <item>当一个Proxy被Model注册时</item>
    ///         </list>
    ///     </para>
    /// </remarks>
    /// <seealso cref="PureMVC.Patterns.Proxy.Proxy"/>
    /// <seealso cref="PureMVC.Patterns.Facade.Facade"/>
    /// <seealso cref="PureMVC.Patterns.Mediator.Mediator"/>
    /// <seealso cref="PureMVC.Patterns.Command.MacroCommand"/>
    /// <seealso cref="PureMVC.Patterns.Command.SimpleCommand"/>
    public class Notifier: INotifier
    {
        /// <summary>
        /// 创建并发送INotification
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Keeps us from having to construct new INotification 
        ///         instances in our implementation code.
        ///     </para>
        /// </remarks>
        /// <param name="notificationName">the name of the notiification to send</param>
        /// <param name="body">the body of the notification (optional)</param>
        /// <param name="type">the type of the notification (optional)</param>
        public virtual void SendNotification(string notificationName, object body, string type)
        {
            Facade.SendNotification(notificationName, body, type);
        }

        /// <summary>
        /// 初始化INotifier实例
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This is how a Notifier gets its multitonKey. 
        ///         Calls to sendNotification or to access the
        ///         facade will fail until after this method 
        ///         has been called.
        ///     </para>
        ///     <para>
        ///         Mediators, Commands or Proxies may override 
        ///         this method in order to send notifications
        ///         or access the Multiton Facade instance as
        ///         soon as possible. They CANNOT access the facade
        ///         in their constructors, since this method will not
        ///         yet have been called.
        ///     </para>
        /// </remarks>
        /// <param name="key">the multitonKey for this INotifier to use</param>
        public void InitializeNotifier(string key)
        {
            MultitonKey = key;
        }

        /// <summary> Return the Multiton Facade instance</summary>
        protected IFacade Facade
        {
            get {
                if (MultitonKey == null) throw new Exception(MULTITON_MSG);
                return Patterns.Facade.Facade.GetInstance(MultitonKey, () => new Facade.Facade(MultitonKey));
            }
        }

        /// <summary>The Multiton Key for this app</summary>
        public string MultitonKey { get; protected set; }

        /// <summary>Message Constants</summary>
        protected string MULTITON_MSG = "multitonKey for this Notifier not yet initialized!";
    }
}
