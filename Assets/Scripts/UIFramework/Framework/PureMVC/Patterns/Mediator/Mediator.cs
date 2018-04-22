//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Mediator
{
    /// <summary>
    /// IMediator的基础实现
    /// </summary>
    /// <seealso cref="PureMVC.Core.View"/>
    public class Mediator : Notifier, IMediator, INotifier
    {
        /// <summary>
        /// Mediator的名称
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Typically, a <c>Mediator</c> will be written to serve
        ///         one specific control or group controls and so,
        ///         will not have a need to be dynamically named.
        ///     </para>
        /// </remarks>
        public static string NAME = "Mediator";

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <param name="viewComponent"></param>
        public Mediator(string mediatorName, object viewComponent = null)
        {
            MediatorName = mediatorName ?? Mediator.NAME;
            ViewComponent = viewComponent;
        }

        /// <summary>
        /// 列出Mediator有兴趣收到通知的INotification名称。
        /// </summary>
        /// <returns>the list of <c>INotification</c> names</returns>
        public virtual string[] ListNotificationInterests()
        {
            return new string[0];
        }

        /// <summary>
        /// 处理INotification
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Typically this will be handled in a switch statement,
        ///         with one 'case' entry per <c>INotification</c>
        ///         the <c>Mediator</c> is interested in.
        ///     </para>
        /// </remarks>
        /// <param name="notification"></param>
        public virtual void HandleNotification(INotification notification)
        {
        }

        /// <summary>
        /// Mediator注册时被View调用
        /// </summary>
        public virtual void OnRegister()
        {
        }

        /// <summary>
        /// Mediator移除时被View调用
        /// </summary>
        public virtual void OnRemove()
        {
        }

        /// <summary>the mediator name</summary>
        public string MediatorName { get; protected set; }

        /// <summary>The view component</summary>
        public object ViewComponent { get; set; }
    }
}
