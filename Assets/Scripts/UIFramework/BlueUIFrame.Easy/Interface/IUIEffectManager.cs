//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy
{
    public interface IUIEffectManager
    {
        bool InitFun(string uiId, Object uiBase);
        bool ActiveFun(string uiId, bool isActive);
    }
}
