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
                effect.AddEnterListener(() =>
                {
                    effect.uiShowState = UIShowState.Old;
                });
                effect.AddExitListener(() =>
                {
                    effect.uiShowState = UIShowState.New;
                    SetActive(uiId, false);
                });
                return true;
            }
            return false;
        }

        public bool ActiveFun(string uiId, bool isActive)
        {
            if (effectDic.ContainsKey(uiId))
            {
                if (isActive)
                {
                    SetActive(uiId, true);
                    effectDic[uiId].Enter();
                }
                else
                {
                    effectDic[uiId].Exit();
                }
                
                return true;
            }

            return false;
        }

        private void SetActive(string uiId,bool isActive)
        {
            effectDic[uiId].gameObject.SetActive(isActive);
        }
    }
}
