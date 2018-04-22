//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Command
{
    /// <summary>
    /// PureMVC ICommand的接口定义
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         您的子类应该覆盖execute方法，以便您的业务逻辑将处理INotification。
    ///     </para>
    /// </remarks>
    /// <seealso cref="PureMVC.Core.Controller"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Notification"/>
    /// <seealso cref="PureMVC.Patterns.Command.MacroCommand"/>
    public class SimpleCommand : Notifier, ICommand, INotifier
    {
        /// <summary>
        /// 实现由给定的INotification启动的用例
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         In the Command Pattern, an application use-case typically
        ///         begins with some user action, which results in an <c>INotification</c> being broadcast, which 
        ///         is handled by business logic in the <c>execute</c> method of an
        ///         <c>ICommand</c>.
        ///     </para>
        /// </remarks>
        /// <param name="notification">the <c>INotification</c> to handle.</param>
        public virtual void Execute(INotification notification)
        {
        }
    }
}
