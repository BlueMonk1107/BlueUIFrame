//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;

namespace PureMVC.Interfaces
{
    /// <summary>
    /// PureMVC Facade的接口定义
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         外观模式建议提供一个类作为子系统的通信中心
    ///     </para>
    ///     <para>
    ///         在PureMVC中, Facade在MVC的核心部分(Model, View, Controller)和APP中其余部分之间充当接口 
    ///     </para>
    /// </remarks>
    /// <seealso cref="IModel"/>
    /// <seealso cref="IView"/>
    /// <seealso cref="IController"/>
    /// <seealso cref="ICommand"/>
    /// <seealso cref="INotification"/>
    public interface IFacade: INotifier
    {
        /// <summary>
        /// 利用name为Model注册一个IProxy对象
        /// </summary>
        /// <param name="proxy">the <c>IProxy</c> to be registered with the <c>Model</c>.</param>
        void RegisterProxy(IProxy proxy);

        /// <summary>
        /// 利用name在Model中检索一个IProxy对象
        /// </summary>
        /// <param name="proxyName">the name of the <c>IProxy</c> instance to be retrieved.</param>
        /// <returns>the <c>IProxy</c> previously regisetered by <c>proxyName</c> with the <c>Model</c>.</returns>
        IProxy RetrieveProxy(string proxyName);

        /// <summary>
        /// 利用name在Model中移除一个IProxy对象
        /// </summary>
        /// <param name="proxyName">the <c>IProxy</c> to remove from the <c>Model</c>.</param>
        /// <returns>the <c>IProxy</c> that was removed from the <c>Model</c></returns>
        IProxy RemoveProxy(string proxyName);

        /// <summary>
        /// 检查Proxy是否已经注册
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns>whether a Proxy is currently registered with the given <c>proxyName</c>.</returns>
        bool HasProxy(string proxyName);

        /// <summary>
        /// 在Controller中注册一个ICommand对象
        /// </summary>
        /// <param name="notificationName">the name of the <c>INotification</c> to associate the <c>ICommand</c> with.</param>
        /// <param name="commandClassRef">a reference to the <c>FuncDelegate</c> of the <c>ICommand</c></param>
        void RegisterCommand(string notificationName, Func<ICommand> commandClassRef);

        /// <summary>
        /// 从Controller中移除注册过的ICommand到INotification的映射
        /// </summary>
        /// <param name="notificationName">the name of the <c>INotification</c> to remove the <c>ICommand</c> mapping for</param>
        void RemoveCommand(string notificationName);

        /// <summary>
        /// 检查所给Notification是否已经注册过Command
        /// Check if a Command is registered for a given Notification 
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns>whether a Command is currently registered for the given <c>notificationName</c>.</returns>
        bool HasCommand(string notificationName);

        /// <summary>
        /// 在View中注册一个IMediator对象
        /// Register an <c>IMediator</c> instance with the <c>View</c>.
        /// </summary>
        /// <param name="mediator">a reference to the <c>IMediator</c> instance</param>
        void RegisterMediator(IMediator mediator);

        /// <summary>
        /// 在View中检索一个IMediator对象
        /// </summary>
        /// <param name="mediatorName">the name of the <c>IMediator</c> instance to retrievve</param>
        /// <returns>the <c>IMediator</c> previously registered with the given <c>mediatorName</c>.</returns>
        IMediator RetrieveMediator(string mediatorName);

        /// <summary>
        /// 在View中移除一个IMediator对象
        /// </summary>
        /// <param name="mediatorName">name of the <c>IMediator</c> instance to be removed</param>
        /// <returns>the <c>IMediator</c> instance previously registered with the given <c>mediatorName</c>.</returns>
        IMediator RemoveMediator(string mediatorName);

        /// <summary>
        /// 检查Mediator是否已经注册
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns>whether a Mediator is registered with the given <c>mediatorName</c>.</returns>
        bool HasMediator(string mediatorName);

        /// <summary>
        /// 通知 <c>Observer</c>s.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         此方法主要是为了向后兼容而公开的，并允许使用Facade发送自定义Notification类。
        ///     </para>
        ///     <para>
        ///         通常你应该调用sendNotification并传递参数，而不必自己构造通知。
        ///     </para>
        /// </remarks>
        /// <param name="notification">the <c>INotification</c> to have the <c>View</c> notify <c>Observers</c> of.</param>
        void NotifyObservers(INotification notification);
    }
}
