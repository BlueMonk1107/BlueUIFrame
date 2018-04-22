//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// 基础INotifier实现.
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
    /// </remarks>
    /// <seealso cref="IFacade"/>
    /// <seealso cref="INotification"/>
    public interface INotifier
    {
        /// <summary>
        /// 发送一个INotification
        /// </summary>
        /// <remarks>
        ///     <para>
        ///     为了预防在实现接口的代码里构建新的实例而创建的便捷方法
        ///     </para>
        /// </remarks>
        /// <param name="notificationName">the name of the notification to send</param>
        /// <param name="body">the body of the notification (optional)</param>
        /// <param name="type">the type of the notification (optional)</param>
        void SendNotification(string notificationName, object body = null, string type = null);

        /// <summary>
        /// 初始化INotifier的实例
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         这就是Notifier获取其多键的方式
        ///         在调用此方法之前，调用sendNotification或访问Facade都会失败
        ///         This is how a Notifier gets its multitonKey. 
        ///         Calls to sendNotification or to access the
        ///         facade will fail until after this method 
        ///         has been called.
        ///     </para>
        /// </remarks>
        /// <param name="key">the multitonKey for this INotifier to use</param>
        void InitializeNotifier(string key);
    }
}
