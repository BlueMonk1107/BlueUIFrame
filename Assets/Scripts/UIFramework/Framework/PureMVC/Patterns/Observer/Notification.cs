//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;

namespace PureMVC.Patterns.Observer
{
    /// <summary>
    /// INotification的基础实现
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
    /// <seealso cref="PureMVC.Patterns.Observer.Observer"/>
    public class Notification: INotification
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="name">name of the <c>Notification</c> instance. (required)</param>
        /// <param name="body">the <c>Notification</c> body. (optional)</param>
        /// <param name="type">the type of the <c>Notification</c> (optional)</param>
        public Notification(string name, object body=null, string type=null)
        {
            Name = name;
            Body = body;
            Type = type;
        }

        /// <summary>
        /// Get the string representation of the <c>Notification</c> instance.
        /// </summary>
        /// <returns>the string representation of the <c>Notification</c> instance.</returns>
        public override string ToString()
        {
            string msg = "Notification Name: " + Name;
            msg += "\nBody:" + ((Body == null) ? "null" : Body.ToString());
            msg += "\nType:" + ((Type == null) ? "null" : Type);
            return msg;
        }

        /// <summary>notification实例的名称</summary>
        public string Name { get; }

        /// <summary>notification实例的主体</summary>
        public object Body { get; set; }

        /// <summary>notification实例的类型</summary>
        public string Type { get; set; }
    }
}
