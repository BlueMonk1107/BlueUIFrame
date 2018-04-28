//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy
{
    public interface IProxy
    {
        string GetName();
        void InitData();
        IData GetData();
        void UpdataData(IData newData);
    }
}
