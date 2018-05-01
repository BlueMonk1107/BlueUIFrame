//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace BlueUIFrame.Easy
{
    public class UIEffectManager : MonoBehaviour, IUIEffectManager
    {
        private Dictionary<string, AUIEffect> effectDic = new Dictionary<string, AUIEffect>(); 
        public bool InitFun(string uiId,Object uiBase)
        {
            AUIEffect effect = ((GameObject)uiBase).GetComponent<AUIEffect>();
            if (effect != null)
            {
                effectDic[uiId] = effect;
                return true;
            }
            return false;
        }

        public bool ActiveFun(string uiId, bool isActive)
        {
            if (effectDic.ContainsKey(uiId))
            {
                effectDic[uiId].gameObject.SetActive(isActive);
                return true;
            }

            return false;
        }
    }
}
