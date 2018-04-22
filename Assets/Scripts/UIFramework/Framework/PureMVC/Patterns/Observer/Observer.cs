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
    /// IObserver的基础实现
    /// </summary>
    /// <remarks>
    ///     <para>
    ///        Observer是一个对象，该对象使用在广播特定INotification时应该调用的方法来封装感兴趣对象的信息。
    ///     </para>
    ///     <para>
    ///         在PureMVC中, Observer承担一下责任:
    ///         <list type="bullet">
    ///             <item>封装对象的通知（回调）方法</item>
    ///             <item>封装对象的通知上下文（this）.</item>
    ///             <item>提供设置 method 和 context的方法.</item>
    ///             <item>提供方法通知对象.</item>
    ///         </list>
    ///     </para>
    /// </remarks>
    /// <seealso cref="PureMVC.Core.View"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Notification"/>
    public class Observer: IObserver
    {
        /// <summary>
        /// 构造器.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         The notification method on the interested object should take 
        ///         one parameter of type <c>INotification</c>
        ///     </para>
        /// </remarks>
        /// <param name="notifyMethod">the notification method of the interested object</param>
        /// <param name="notifyContext">the notification context of the interested object</param>
        public Observer(Action<INotification> notifyMethod, object notifyContext)
        {
            NotifyMethod = notifyMethod;
            NotifyContext = notifyContext;
        }

        /// <summary>
        /// 通知感兴趣的对象
        /// </summary>
        /// <param name="Notification">the <c>INotification</c> to pass to the interested object's notification method.</param>
        public virtual void NotifyObserver(INotification Notification)
        {
            NotifyMethod(Notification);
        }

        /// <summary>
        /// 将对象与NotifyContext进行比较
        /// </summary>
        /// <param name="obj">the object to compare</param>
        /// <returns>indicating if the object and the notification context are the same</returns>
        public virtual bool CompareNotifyContext(object obj)
        {
            return NotifyContext.Equals(obj);
        }

        /// <summary>回调函数</summary>
        public Action<INotification> NotifyMethod { get; set; }

        /// <summary>上下文对象</summary>
        public object NotifyContext { get; set; }
    }
}
