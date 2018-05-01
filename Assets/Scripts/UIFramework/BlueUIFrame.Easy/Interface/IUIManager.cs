//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================

using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

namespace BlueUIFrame.Easy
{
    public interface IUIManager
    {
        void AddUIInitListener(Func<string, Object, bool> action);
        void AddUIActiveListener(Func<string, bool, bool> action);
        void ShowUI(EUiId id);
        void Back();
    }
}
