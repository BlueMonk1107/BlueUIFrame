using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy.Demo
{
    public class UIRoot : AUIRoot
    {
        // Use this for initialization
        protected virtual void Start()
        {
            InitUISystem();
        }

        protected override void InitUISystem()
        {
            UIManager = new UIManager();
            DataHandlerManager = new DataHandlerManager();
            if (LayerManager == null)
            {
                LayerManager = gameObject.AddComponent<UILayerManager>();
                LayerManager.Init();
            }
            if (UIEffectManager == null)
            {
                UIEffectManager = gameObject.AddComponent<UIEffectManager>();
                UIManager.AddUIInitListener(UIEffectManager.InitFun);
                UIManager.AddUIActiveListener(UIEffectManager.ActiveFun);
            }
        }
    }
}
