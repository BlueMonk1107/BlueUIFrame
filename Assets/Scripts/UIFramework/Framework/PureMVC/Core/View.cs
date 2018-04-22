//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Core
{
    /// <summary>
    /// 多例IView的实现
    /// </summary>
    /// <remarks>
    ///     <para>在PureMVC中, View承担以下责任:</para>
    ///     <list type="bullet">
    ///         <item>维护IMediator实例的缓存</item>
    ///         <item>提供 注册, 检索, 和 移除 IMediators的方法</item>
    ///         <item>管理应用程序中每个INotification的observer列表</item>
    ///         <item>提供将IObservers附加到INotification的observer列表的方法</item>
    ///         <item>提供广播INotification的方法 </item>
    ///         <item>广播时通知IObservers给定的INotification</item>
    ///     </list>
    /// </remarks>
    /// <seealso cref="PureMVC.Patterns.Mediator.Mediator"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Observer"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Notification"/>
    public class View: IView
    {
        /// <summary>
        /// 构建并初始化View
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This <c>IView</c> implementation is a Multiton, 
        ///         so you should not call the constructor 
        ///         directly, but instead call the static Multiton 
        ///         Factory method <c>View.getInstance(multitonKey, () => new View(multitonKey))</c>
        ///     </para>
        /// </remarks>
        /// <param name="key">Key of view</param>
        /// <exception cref="System.Exception">Thrown if instance for this Multiton key has already been constructed</exception>
        public View(string key)
        {
            if (instanceMap.ContainsKey(key) && multitonKey != null) throw new Exception(MULTITON_MSG);
            multitonKey = key;
            instanceMap.Add(key, this);
            mediatorMap = new Dictionary<string, IMediator>();
            observerMap = new Dictionary<string, IList<IObserver>>();
            InitializeView();
        }

        /// <summary>
        /// 初始化多例View实例
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Called automatically by the constructor, this
        ///         is your opportunity to initialize the Multiton
        ///         instance in your subclass without overriding the
        ///         constructor.
        ///     </para>
        /// </remarks>
        protected virtual void InitializeView()
        {
        }

        /// <summary>
        /// View多例工厂方法 
        /// </summary>
        /// <param name="key">Key of view</param>
        /// <param name="viewClassRef">the <c>FuncDelegate</c> of the <c>IView</c></param>
        /// <returns>the instance for this Multiton key </returns>
        public static IView GetInstance(string key, Func<IView> viewClassRef)
        {
            if (!instanceMap.ContainsKey(key))
            {
                instanceMap[key] = new View(key);
            }

            return instanceMap[key];
        }

        /// <summary>
        ///   使用提供的名称注册一个IObserver以通知INotifications
        /// </summary>
        /// <param name="notificationName">the name of the <c>INotifications</c> to notify this <c>IObserver</c> of</param>
        /// <param name="observer">the <c>IObserver</c> to register</param>
        public virtual void RegisterObserver(string notificationName, IObserver observer)
        {
            if (observerMap.ContainsKey(notificationName))
            {
                observerMap[notificationName].Add(observer);
            }
            else
            {
                observerMap.Add(notificationName, new List<IObserver> { observer });
            }
        }

        /// <summary>
        /// 通知IObservers特定的INotification
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         All previously attached <c>IObservers</c> for this <c>INotification</c>'s
        ///         list are notified and are passed a reference to the <c>INotification</c> in
        ///         the order in which they were registered.
        ///     </para>
        /// </remarks>
        /// <param name="notification"></param>
        public virtual void NotifyObservers(INotification notification)
        {
            // Get a reference to the observers list for this notification name
            if (observerMap.ContainsKey(notification.Name))
            {
                // Copy observers from reference array to working array, 
                // since the reference array may change during the notification loop
                var observers = new List<IObserver>(observerMap[notification.Name]);
                foreach (IObserver observer in observers)
                {
                    observer.NotifyObserver(notification);
                }
            }
        }

        /// <summary>
        /// 从给定notificationName的观察者列表中删除给定notifyContext的观察者。
        /// </summary>
        /// <param name="notificationName">which observer list to remove from </param>
        /// <param name="notifyContext">remove the observer with this object as its notifyContext</param>
        public virtual void RemoveObserver(string notificationName, object notifyContext)
        {
            if (observerMap.ContainsKey(notificationName))
            {
                int count = observerMap.Count;
                for (int i = 0; i < count; i++)
                {
                    if (observerMap[notificationName][i].CompareNotifyContext(notifyContext))
                    {
                        observerMap[notificationName].RemoveAt(i);
                        break;
                    }
                }

                // Also, when a Notification's Observer list length falls to
                // zero, delete the notification key from the observer map
                if (observerMap[notificationName].Count == 0)
                    observerMap.Remove(notificationName);
            }
        }

        /// <summary>
        /// 使用View注册IMediator实例
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Registers the <c>IMediator</c> so that it can be retrieved by name,
        ///         and further interrogates the <c>IMediator</c> for its 
        ///         <c>INotification</c> interests.
        ///     </para>
        ///     <para>
        ///         If the <c>IMediator</c> returns any <c>INotification</c>
        ///         names to be notified about, an <c>Observer</c> is created encapsulating 
        ///         the <c>IMediator</c> instance's <c>handleNotification</c> method 
        ///         and registering it as an <c>Observer</c> for all <c>INotifications</c> the
        ///         <c>IMediator</c> is interested in.
        ///     </para>
        /// </remarks>
        /// <param name="mediator">the name to associate with this <c>IMediator</c> instance</param>
        public virtual void RegisterMediator(IMediator mediator)
        {
            if (!mediatorMap.ContainsKey(mediator.MediatorName))
            {
                mediatorMap[mediator.MediatorName] = mediator;

                mediator.InitializeNotifier(multitonKey);

                string[] interests = mediator.ListNotificationInterests();

                if (interests.Length > 0)
                {
                    IObserver observer = new Observer(mediator.HandleNotification, mediator);
                    for (int i = 0; i < interests.Length; i++)
                    {
                        RegisterObserver(interests[i], observer);
                    }
                }
                // alert the mediator that it has been registered
                mediator.OnRegister();
            }
        }

        /// <summary>
        /// 在View中检索IMediator
        /// </summary>
        /// <param name="mediatorName">the name of the <c>IMediator</c> instance to retrieve.</param>
        /// <returns>the <c>IMediator</c> instance previously registered with the given <c>mediatorName</c>.</returns>
        public virtual IMediator RetrieveMediator(string mediatorName)
        {
            IMediator mediator;
            return mediatorMap.TryGetValue(mediatorName, out mediator) ? mediator : null;
        }

        /// <summary>
        /// 在View中移除IMediator
        /// </summary>
        /// <param name="mediatorName">name of the <c>IMediator</c> instance to be removed.</param>
        /// <returns>the <c>IMediator</c> that was removed from the <c>View</c></returns>
        public virtual IMediator RemoveMediator(string mediatorName)
        {
            IMediator mediator = null;
            if (mediatorMap.ContainsKey(mediatorName))
            {
                mediator = mediatorMap[mediatorName];
                string[] interests = mediator.ListNotificationInterests();
                for (int i = 0; i < interests.Length; i++)
                {
                    RemoveObserver(interests[i], mediator);
                }
                mediator.OnRemove();
                mediatorMap.Remove(mediatorName);
            }
            return mediator;
        }

        /// <summary>
        /// 检查Mediator是否已被注册
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns>whether a Mediator is registered with the given <c>mediatorName</c>.</returns>
        public virtual bool HasMediator(string mediatorName)
        {
            return mediatorMap.ContainsKey(mediatorName);
        }

        /// <summary>
        /// 移除IView实例
        /// </summary>
        /// <param name="key">multitonKey of IView instance to remove</param>
        public static void RemoveView(string key)
        {
            instanceMap.Remove(key);
        }

        /// <summary>The Multiton Key for this Core</summary>
        protected string multitonKey;

        ///// <summary>Mapping of Mediator names to Mediator instances</summary>
        protected Dictionary<string, IMediator> mediatorMap;

        ///// <summary>Mapping of Notification names to Observer lists</summary>
        protected Dictionary<string, IList<IObserver>> observerMap;

        ///// <summary>The Multiton View instanceMap.</summary>
        protected static Dictionary<string, IView> instanceMap = new Dictionary<string, IView>();

        /// <summary>Message Constants</summary>
        protected const string MULTITON_MSG = "View instance for this Multiton key already constructed!";
    }
}
