//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// UI系统初始化类
    /// <para>
    /// 启动系统需要继承此类，并实现InitUISystem方法，在方法内初始化DataHandlerManager
    /// </para>
    /// <para>
    /// 脚本需要挂载在Canvas组件的物体上
    /// </para>
    /// </summary>
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
