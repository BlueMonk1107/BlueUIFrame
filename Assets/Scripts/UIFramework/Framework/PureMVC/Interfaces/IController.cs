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
    /// PureMVC Controller的接口定义
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         在PureMVC中, 实现了IController接口的类遵循'Command and Controller'策略，
    ///         并承担这些责任：
    ///         <list type="bullet">
    ///             <item>
    ///             记住哪一个ICommand应该处理哪个一个INotifications.
    ///             </item>
    ///             <item>
    ///             将自己注册为IObserver并且每个INotification的View都有一个ICommand映射
    ///             </item>
    ///             <item>
    ///             创建正确的ICommand的新实例，在View通知时处理给定的INotification
    ///             </item>
    ///             <item>执行ICommand的execute方法, 传入INotification.
    ///             </item>
    ///         </list>
    ///     </para>
    /// </remarks>
    /// <seealso cref="INotification"/>
    /// <seealso cref="ICommand"/>
    public interface IController
    {
        /// <summary>
        /// 注册一个特定的ICommand类来处理特定的INotification.
        /// </summary>
        /// <param name="notificationName">the name of the <c>INotification</c></param>
        /// <param name="commandClassRef">the FuncDelegate of the <c>ICommand</c></param>
        void RegisterCommand(string notificationName, Func<ICommand> commandClassRef);

        /// <summary>
        /// 执行注册过的ICommand来处理通过给定notification名称定义的INotification
        /// </summary>
        /// <param name="notification">the <c>INotification</c> to execute the associated <c>ICommand</c> for</param>
        void ExecuteCommand(INotification notification);

        /// <summary>
        /// 移除注册的ICommand与INotification的映射.
        /// </summary>
        /// <param name="notificationName">the name of the <c>INotification</c> to remove the <c>ICommand</c> mapping for</param>
        void RemoveCommand(string notificationName);

        /// <summary>
        /// 检查对应Notification的command是否已经注册
        /// </summary>
        /// <param name="notificationName">whether a Command is currently registered for the given <c>notificationName</c>.</param>
        /// <returns></returns>
        bool HasCommand(string notificationName);
    }
}
