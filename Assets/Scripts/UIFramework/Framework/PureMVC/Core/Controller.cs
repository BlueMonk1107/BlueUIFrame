//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Core
{
    /// <summary>
    /// 多例IController的实现
    /// </summary>
    /// <remarks>
    /// 	<para>在PureMVC中, Controller类遵循'Command and Controller'策略，
    ///         并承担这些责任：</para>
    /// 	<list type="bullet">
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
    /// 	</list>
    /// 	<para>
    ///         程序必须利用Controller注册ICommands
    /// 	</para>
    /// 	<para>
    /// 	    最简单的方法是继承Facade，并使用它的initializeController方法添加注册。
    /// 	</para>
    /// </remarks>
    /// <seealso cref="PureMVC.Core.View"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Observer"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Notification"/>
    /// <seealso cref="PureMVC.Patterns.Command.SimpleCommand"/>
    /// <seealso cref="PureMVC.Patterns.Command.MacroCommand"/>
    public class Controller: IController
    {
        /// <summary>
        /// 构造并初始化一个新的controller
        /// </summary>
        /// <remarks>
        /// 当前IController的实现是一个多例，因此您不应该直接调用构造函数，
        /// 而应该调用静态多例工厂方法 
        /// Controller.getInstance（multitonKey，（）=> new Controller（multitonKey））
        /// </remarks>
        /// <param name="key">Key of controller</param>
        /// <exception cref="System.Exception">Thrown if instance for this Multiton key has already been constructed</exception>
        public Controller(string key)
        {
            IController temp;
            if (instanceMap.TryGetValue(key, out temp) && multitonKey != null) throw new Exception(MULTITON_MSG);
            multitonKey = key;
            instanceMap.Add(multitonKey, this);
            commandMap = new Dictionary<string, Func<ICommand>>();
            InitializeController();
        }

        /// <summary>
        /// 初始化多例Controller的实例
        /// </summary>
        /// <remarks>
        ///     <para>Called automatically by the constructor</para>
        ///     <para>
        ///         Please aware that if you are using a subclass of <c>View</c>
        ///         in your application, you should also subclass <c>Controller</c>
        ///         and override the <c>initializeController</c> method in the following way:
        ///     </para>
        ///     <example>
        ///         <code>
        ///             // ensure that the Controller is talking to my IView implementation
        ///             public override void initializeController()
        ///             {
        ///                 view = MyView.getInstance(multitonKey, () => new MyView(multitonKey));
        ///             }
        ///         </code>
        ///     </example>
        /// </remarks>
        protected virtual void InitializeController()
        {
            view = View.GetInstance(multitonKey, () => new View(multitonKey));
        }

        /// <summary>
        /// Controller的多例工厂方法
        /// </summary>
        /// <param name="key">Key of controller</param>
        /// <param name="controllerClassRef">the <c>FuncDelegate</c> of the <c>IController</c></param>
        /// <returns>the Multiton instance of <c>Controller</c></returns>
        public static IController GetInstance(string key, Func<IController> controllerClassRef)
        {
            if (!instanceMap.ContainsKey(key))
            {
                instanceMap[key] = new Controller(key);
            }

            return instanceMap[key];
        }

        /// <summary>
        /// 如果ICommand先前已被注册为处理给定的INotification，那么它将被执行。
        /// </summary>
        /// <param name="notification">note an <c>INotification</c></param>
        public virtual void ExecuteCommand(INotification notification)
        {
            Func<ICommand> temp;
            if (commandMap.TryGetValue(notification.Name, out temp))
            {
                ICommand commandInstance = temp();
                commandInstance.InitializeNotifier(multitonKey);
                commandInstance.Execute(notification);
            }
        }

        /// <summary>
        /// 将特定的ICommand类注册为特定INotification的处理程序。
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         If a <c>ICommand</c> has already been registered to 
        ///         handle <c>INotification</c>s with this name, it is no longer
        ///         used, the new <c>Func</c> is used instead.
        ///     </para>
        ///     <para>
        ///         The Observer for the new ICommand is only created if this the
        ///         first time an ICommand has been regisered for this Notification name.
        ///     </para>
        /// </remarks>
        /// <param name="notificationName">the name of the <c>INotification</c></param>
        /// <param name="commandClassRef">the <c>Func Delegate</c> of the <c>ICommand</c></param>
        public virtual void RegisterCommand(string notificationName, Func<ICommand> commandClassRef)
        {
            Func<ICommand> temp;
            if (commandMap.TryGetValue(notificationName, out temp) == false)
            {
                view.RegisterObserver(notificationName, new Observer(ExecuteCommand, this));
            }
            commandMap[notificationName] = commandClassRef;
        }

        /// <summary>
        /// 移除注册过的ICommand和INotification的映射
        /// </summary>
        /// <param name="notificationName">the name of the <c>INotification</c> to remove the <c>ICommand</c> mapping for</param>
        public virtual void RemoveCommand(string notificationName)
        {
            if (commandMap.Remove(notificationName))
            {
                view.RemoveObserver(notificationName, this);
            }
        }

        /// <summary>
        /// 检查是否已经为给定的Notification注册命令
        /// Check if a Command is registered for a given Notification 
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns>whether a Command is currently registered for the given <c>notificationName</c>.</returns>
        public virtual bool HasCommand(string notificationName)
        {
            return commandMap.ContainsKey(notificationName);
        }

        /// <summary>
        /// 移除IController实例
        /// </summary>
        /// <param name="key">multitonKey of IController instance to remove</param>
        public static void RemoveController(string key)
        {
            instanceMap.Remove(key);
        }

        /// <summary>View的本地引用</summary>
        protected IView view;

        /// <summary>这个核心组件的多例键值</summary>
        protected string multitonKey;

        /// <summary>Mapping of Notification names to Command Class references</summary>
        protected Dictionary<string, Func<ICommand>> commandMap;
        
        ///// <summary>The Multiton Controller instanceMap.</summary>
        protected static Dictionary<string, IController> instanceMap = new Dictionary<string, IController>();

        /// <summary>Message Constants</summary>
        protected const string MULTITON_MSG = "Controller instance for this Multiton key already constructed!";
    }
}
