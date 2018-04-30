//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
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
