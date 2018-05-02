//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy.Demo
{
    public class DataHandlerManager : UIDataHandlerManager
    {
        protected override void RegisterHandler()
        {
            handlerDic.Add(NormalInfoDataHandler.NAME, new NormalInfoDataHandler());
        }
    }
}
