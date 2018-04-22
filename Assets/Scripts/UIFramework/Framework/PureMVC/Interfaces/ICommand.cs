//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// PureMVC Command的接口定义
    /// </summary>
    /// <seealso cref="INotification"/>
    public interface ICommand: INotifier
    {
        /// <summary>
        /// 执行ICommand的逻辑来执行给定的INotification.
        /// </summary>
        /// <param name="Notification">an <c>INotification</c> to handle.</param>
        void Execute(INotification Notification);
    }
}
