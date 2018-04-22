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
    /// PureMVC Observer的接口定义
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         在PureMVC中, Observer承担以下责任:
    ///         <list type="bullet">
    ///             <item>封装对象的通知（回调）方法</item>
    ///             <item>封装对象的通知上下文（this）.</item>
    ///             <item>提供设置 method 和 context的方法.</item>
    ///             <item>提供方法通知对象.</item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///         PureMVC不依赖于底层的事件模型，例如Flash提供的模型，而ActionScript 3没有固有的事件模型。
    ///     </para>
    ///     <para>
    ///         在PureMVC中观察者模式的存在，是为了支持应用程序和MVC三元组的actor之间的事件驱动的通信.
    ///     </para>
    ///     <para>
    ///        Observer是一个对象，它利用在广播INotification时应该调用的通知方法来封装对象的信息。 
    ///        观察者然后作为通知对象的代理。
    ///     </para>
    ///     <para>
    ///         观察者可以通过调用其notifyObserver方法来接收 Notification，
    ///         并传入实现INotification接口的对象，例如Notification。
    ///     </para>
    /// </remarks>
    /// <seealso cref="IView"/>
    /// <seealso cref="INotification"/>
    public interface IObserver
    {
        /// <summary>
        /// 设置对象的通知(回调)方法
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         The notification method should take one parameter of type <c>INotification</c>
        ///     </para>
        /// </remarks>
        Action<INotification> NotifyMethod { set; }

        /// <summary>
        /// 设置对象的通信上下文(this)
        /// </summary>
        object NotifyContext { set; }

        /// <summary>
        /// 通知对象
        /// </summary>
        /// <param name="notification">the <c>INotification</c> to pass to the interested object's notification method</param>
        void NotifyObserver(INotification notification);

        /// <summary>
        /// 将给定对象与通知上下文对象进行比较
        /// </summary>
        /// <param name="obj">the object to compare.</param>
        /// <returns>indicating if the notification context and the object are the same.</returns>
        bool CompareNotifyContext(object obj);
    }
}
