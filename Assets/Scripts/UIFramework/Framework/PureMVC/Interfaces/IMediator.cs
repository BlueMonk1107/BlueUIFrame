//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// PureMVC Mediator的接口定义
    /// </summary>
    /// <remarks>
    ///     <para>
    ///        在PureMVC中, 实现了IMediator接口的类承担这些责任：
    ///         <list type="bullet">
    ///             <item>实现一个通用方法，返回IMediator关注的所有INotifications列表</item>
    ///             <item>实现一个notification回调方法.</item>
    ///             <item>实现当IMediator从View中注册或移除时调用的方法</item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///        另外IMediators通常：
    ///         <list type="bullet">
    ///             <item>充当一个或多个视图组件（如文本框或列表控件）之间的中介，保持引用并协调其行为.</item>
    ///             <item>在基于Flash的应用程序中，通常会添加事件侦听器来查看组件，并执行其处理程序</item>
    ///             <item>响应并生成INotification，与PureMVC应用程序的其余部分进行交互。</item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///         当IMediator向IView注册时，IView将调用IMediators listNotificationInterests方法。
    ///         IMediator将返回它希望被通知的一组INotification名称。
    ///     </para>
    ///     <para>
    ///         然后，IView将创建一个封装了IMediator（handleNotification）方法的Observer对象，
    ///         并将其注册为由listNotificationInterests返回的每个INotification名称的Observer。
    ///     </para>
    /// </remarks>
    /// <seealso cref="INotification"/>
    public interface IMediator: INotifier
    {
        /// <summary>
        /// 获取或设置IMediator对象名称
        /// </summary>
        string MediatorName { get; }

        /// <summary>
        /// 获取或设置IMediator的view组件.
        /// </summary>
        object ViewComponent { get; set; }

        /// <summary>
        /// List <c>INotification</c> interests.
        /// </summary>
        /// <returns> an <c>Array</c> of the <c>INotification</c> names this <c>IMediator</c> has an interest in.</returns>
        string[] ListNotificationInterests();

        /// <summary>
        /// 处理一个 an INotification
        /// </summary>
        /// <param name="notification">notification the <c>INotification</c> to be handled</param>
        void HandleNotification(INotification notification);

        /// <summary>
        /// 当Mediator被注册时这个函数由View调用
        /// </summary>
        void OnRegister();

        /// <summary>
        /// 当Mediator被移除时这个函数由View调用
        /// </summary>
        void OnRemove();
    }
}
