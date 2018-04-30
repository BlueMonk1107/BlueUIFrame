//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy
{
    public interface IUIManager
    {
        IUIDataHandlerManager DataHandlerManager { get; }
        IUILayerManager LayerManager { get; }
        void InitUISystem();
        void ShowUI(EUiId id);
        void Back();
    }
}
