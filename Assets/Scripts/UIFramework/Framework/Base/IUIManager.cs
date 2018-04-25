//=======================================================
// 作者：BlueMonk
// 描述：A simple UI framework For Unity . 
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame
{
    public interface IUIManager
    {
        bool ShowUI(EUiId id);
        bool HideUI(UILayer layer);
        bool Back();
    }
}
