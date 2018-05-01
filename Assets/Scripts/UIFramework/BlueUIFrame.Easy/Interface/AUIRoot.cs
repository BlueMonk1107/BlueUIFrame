//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy
{
    public abstract class AUIRoot : MonoBehaviour
    {
        public static IUIManager UIManager { get; protected set; }
        public static IUIDataHandlerManager DataHandlerManager { get; protected set; }
        public static IUILayerManager LayerManager { get; protected set; }
        public static IUIEffectManager UIEffectManager { get; protected set; }
        protected abstract void InitUISystem();
    }
}
