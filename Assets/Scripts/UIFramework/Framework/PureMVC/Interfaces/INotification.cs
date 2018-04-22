//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{
    /// <summary>
    /// 基础INotification实现.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         PureMVC不依赖于底层的事件模型，例如Flash提供的模型，而ActionScript 3没有固有的事件模型。
    ///     </para>
    ///     <para>
    ///         在PureMVC中观察者模式的存在，
    ///         是为了支持应用程序和MVC三元组的参与者之间的事件驱动的通信。
    ///     </para>
    ///     <para>
    ///         通知并不意味着替代Flex / Flash / Apollo中的事件。 
    ///         通常，IMediator实现者将事件侦听器放置在他们的视图组件上，然后按照通常的方式处理它们。
    ///         这可能导致Notification的广播触发ICommand或与其他IMediators通信。 
    ///         IProxy和ICommand实例通过广播INotification来相互通信并且与IMediator进行通信。
    ///     </para>
    ///     <para>
    ///         Flash Event 和PureMVC Notification之间的一个主要区别在于
    ///         Event遵循'责任链'模式，'冒泡' 显示层次结构，直到某个父组件处理<c>事件，
    ///         而PureMVC Notification遵循“发布/订阅”模式。 
    ///         PureMVC类不需要在父/子关系中彼此相关，以便使用Notification来彼此通信。
    ///     </para>
    /// </remarks>
    /// <seealso cref="IView"/>
    /// <seealso cref="IObserver"/>
    public interface INotification
    {
        /// <summary>
        /// 获取INotification实例的名称
        /// No setter, should be set by constructor only
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 设置或获取INotification实例的Body
        /// </summary>
        object Body { get; set; }

        /// <summary>
        /// 设置或获取INotification实例的Type
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Get the string representation of the <c>INotification</c> instance
        /// </summary>
        /// <returns>String representation</returns>
        string ToString();
    }
}
