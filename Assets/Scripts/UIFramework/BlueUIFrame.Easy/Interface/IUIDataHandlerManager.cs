//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy
{
    public interface IUIDataHandlerManager
    {
        void RemoveHandler(string handlerName);
        IDataHandler GetHandler(string handlerName);
    }
}
