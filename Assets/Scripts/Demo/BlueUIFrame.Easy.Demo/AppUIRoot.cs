//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;
using System;

namespace BlueUIFrame.Easy.Demo
{
    public class AppUIRoot : UIRoot
    {
        protected override void Start()
        {
            if (GetComponent<Canvas>() != null)
            {
                base.Start();
                UIManager.ShowUI(EUiId.MAIN_UI);
            }
            else
            {
                throw new Exception("AppUIRoot script must be mounted on canvas");
            }
        }

        protected override void InitUISystem()
        {
            base.InitUISystem();
            DataHandlerManager = new DataHandlerManager();
        }
    }
}
