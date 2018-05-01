//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy
{
    public class SideUIEffect : SlideFullScreenUI
    {
        public override void Enter()
        {
            base.Enter();
            FromLeft();
        }

        public override void Exit()
        {
            base.Exit();
            ToLeft();
        }
    }
}
