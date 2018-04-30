//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy.Demo
{
    public class UIManagerDemo : Easy.UIManager
    {
        public override void InitUISystem()
        {
            base.InitUISystem();
            DataHandlerManager = new DataHandlerManager();
        }
    }
}
