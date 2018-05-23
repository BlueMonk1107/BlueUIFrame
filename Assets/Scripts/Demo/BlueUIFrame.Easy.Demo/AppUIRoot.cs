//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
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
                UIManager.ShowUI(EUiId.MAIN_UI.ToString());
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
            new UIPathManager();
        }
    }
}
