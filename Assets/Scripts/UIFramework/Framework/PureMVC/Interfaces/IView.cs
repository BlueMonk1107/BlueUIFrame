//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// PureMVC View的接口定义
    /// </summary>
    /// <remarks>
    ///     <para>在PureMVC中, View承担以下责任:</para>
    ///     <list type="bullet">
    ///         <item>维护IMediator实例的缓存</item>
    ///         <item>提供 注册, 检索, 和 移除 IMediators的方法</item>
    ///         <item>管理应用程序中每个INotification的observer列表</item>
    ///         <item>提供将IObservers附加到INotification的observer列表的方法</item>
    ///         <item>提供广播INotification的方法 </item>
    ///         <item>广播时通知IObservers给定的INotification</item>
    ///     </list>
    /// </remarks>
    /// <seealso cref="IMediator"/>
    /// <seealso cref="IObserver"/>
    /// <seealso cref="INotification"/>
    public interface IView
    {
        /// <summary>
        /// 注册一个IObserver用来通知
        /// of <c>INotifications</c> with a given name.
        /// </summary>
        /// <param name="notificationName">the name of the <c>INotifications</c> to notify this <c>IObserver</c> of</param>
        /// <param name="observer">the <c>IObserver</c> to register</param>
        void RegisterObserver(string notificationName, IObserver observer);

        /// <summary>
        /// 从observer列表中移除给定通知名称的一组observers。
        /// </summary>
        /// <param name="notificationName">which observer list to remove from </param>
        /// <param name="notifyContext">removed the observers with this object as their notifyContext</param>
        void RemoveObserver(string notificationName, object notifyContext);

        /// <summary>
        /// 使用特定的INotification通知IObservers。
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         All previously attached <c>IObservers</c> for this <c>INotification</c>'s
        ///         list are notified and are passed a reference to the <c>INotification</c> in 
        ///         the order in which they were registered.
        ///     </para>
        /// </remarks>
        /// <param name="notification">the <c>INotification</c> to notify <c>IObservers</c> of.</param>
        void NotifyObservers(INotification notification);

        /// <summary>
        /// 使用View注册IMediator实例
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Registers the <c>IMediator</c> so that it can be retrieved by name,
        ///         and further interrogates the <c>IMediator</c> for its 
        ///         <c>INotification</c> interests.
        ///     </para>
        ///     <para>
        ///         If the <c>IMediator</c> returns any <c>INotification</c> 
        ///         names to be notified about, an <c>Observer</c> is created encapsulating 
        ///         the <c>IMediator</c> instance's <c>handleNotification</c> method 
        ///         and registering it as an <c>Observer</c> for all <c>INotifications</c> the 
        ///         <c>IMediator</c> is interested in.
        ///     </para>
        /// </remarks>
        /// <param name="mediator">a reference to the <c>IMediator</c> instance</param>
        void RegisterMediator(IMediator mediator);

        /// <summary>
        /// 从View中检索IMediator
        /// </summary>
        /// <param name="mediatorName">the name of the <c>IMediator</c> instance to retrieve.</param>
        /// <returns>the <c>IMediator</c> instance previously registered with the given <c>mediatorName</c>.</returns>
        IMediator RetrieveMediator(string mediatorName);

        /// <summary>
        /// 从View中移除IMediator
        /// </summary>
        /// <param name="mediatorName">name of the <c>IMediator</c> instance to be removed.</param>
        /// <returns>the <c>IMediator</c> that was removed from the <c>View</c></returns>
        IMediator RemoveMediator(string mediatorName);

        /// <summary>
        /// 检查Mediator是否已经注册过了
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns>whether a Mediator is registered with the given <c>mediatorName</c>.</returns>
        bool HasMediator(string mediatorName);
    }
}
