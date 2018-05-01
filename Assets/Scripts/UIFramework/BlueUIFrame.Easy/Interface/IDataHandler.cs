//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================

using System;
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy
{
    public interface IDataHandler
    {
        Action UpdateShow { get; set; }
        string GetName();
        void InitData();
        IData GetData();
        void UpdataData(IData newData);
    }
}
