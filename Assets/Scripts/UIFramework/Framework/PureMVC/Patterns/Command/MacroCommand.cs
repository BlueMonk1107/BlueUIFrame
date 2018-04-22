//
//  PureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Command
{
    /// <summary>
    /// 执行其他ICommand的基础ICommand的实现。
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         一个MacroCommand维护一个名为SubCommands的ICommand类引用的列表
    ///     </para>
    ///     <para>
    ///         当调用execute时，MacroCommand实例化并调用每个SubCommand的execute方法。 
    ///         MacroCommand将传递进execute方法的INotification的原始引用传递给每个SubCommand
    ///     </para>
    ///     <para>
    ///         与SimpleCommand不同，你的子类不应该重写execute，
    ///         而应该重载initializeMacroCommand方法，调用一次addSubCommand为每个SubCommand执行。
    ///     </para>
    /// </remarks>
    /// <seealso cref="PureMVC.Core.Controller"/>
    /// <seealso cref="PureMVC.Patterns.Observer.Notification"/>
    /// <seealso cref="PureMVC.Patterns.Command.SimpleCommand"/>
    public class MacroCommand : Notifier, ICommand, INotifier
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         You should not need to define a constructor, 
        ///         instead, override the <c>initializeMacroCommand</c>
        ///         method.
        ///     </para>
        ///     <para>
        ///         If your subclass does define a constructor, be 
        ///         sure to call <c>super()</c>.
        ///     </para>
        /// </remarks>
        public MacroCommand()
        {
            subcommands = new List<Func<ICommand>>();
            InitializeMacroCommand();
        }

        /// <summary>
        /// 初始化MacroCommand
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         In your subclass, override this method to 
        ///         initialize the <c>MacroCommand</c>'s <i>SubCommand</i>  
        ///         list with <c>ICommand</c> class references like
        ///         this:
        ///     </para>
        ///     <example>
        ///         <code>
        ///             override void InitializeMacroCommand() 
        ///             {
        ///                 AddSubCommand(() => new com.me.myapp.controller.FirstCommand());
        ///                 AddSubCommand(() => new com.me.myapp.controller.SecondCommand());
        ///                 AddSubCommand(() => new com.me.myapp.controller.ThirdCommand());
        ///             }
        ///         </code>
        ///     </example>
        ///     <para>
        ///         Note that <i>SubCommand</i>s may be any <c>ICommand</c> implementor,
        ///         <c>MacroCommand</c>s or <c>SimpleCommands</c> are both acceptable.
        ///     </para>
        /// </remarks>
        protected virtual void InitializeMacroCommand()
        {
        }

        /// <summary>
        /// 添加SubCommand
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         The <i>SubCommands</i> will be called in First In/First Out (FIFO)
        ///         order.
        ///     </para>
        /// </remarks>
        /// <param name="commandClassRef">a reference to the <c>FuncDelegate</c> of the <c>ICommand</c>.</param>
        protected void AddSubCommand(Func<ICommand> commandClassRef)
        {
            subcommands.Add(commandClassRef);
        }

        /// <summary>
        /// 执行MacroCommand的SubCommands
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         The <i>SubCommands</i> will be called in First In/First Out (FIFO)
        ///         order.
        ///     </para>
        /// </remarks>
        /// <param name="notification">the <c>INotification</c> object to be passsed to each <i>SubCommand</i>.</param>
        public virtual void Execute(INotification notification)
        {
            while(subcommands.Count > 0)
            {
                Func<ICommand> commandClassRef = subcommands[0];
                ICommand commandInstance = commandClassRef();
                commandInstance.InitializeNotifier(MultitonKey);
                commandInstance.Execute(notification);
                subcommands.RemoveAt(0);
            }
        }

        /// <summary>List of subcommands</summary>
        public IList<Func<ICommand>> subcommands;
    }
}
