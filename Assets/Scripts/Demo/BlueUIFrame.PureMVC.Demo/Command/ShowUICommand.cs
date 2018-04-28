//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System;

namespace BlueUIFrame.PureMVC.Demo
{
    public class ShowUICommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
        }
    }
}
