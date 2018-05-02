//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// UI动效管理类
    /// </summary>
    public class UIEffectManager : MonoBehaviour, IUIEffectManager
    {
        private Dictionary<string, AUIEffect> effectDic = new Dictionary<string, AUIEffect>();
        /// <summary>
        /// UI初始化的回调函数
        /// </summary>
        /// <param name="uiId">UI的ID</param>
        /// <param name="uiBase">UI对象</param>
        /// <returns></returns>
        public bool InitFun(string uiId,Object uiBase)
        {
            try
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
            catch (Exception)
            {
                Debug.LogError("UIEffectManager.cs InitFun has ERROR");
                return false;
            }
            
        }
        /// <summary>
        /// UI对象显示或隐藏状态的回调函数
        /// </summary>
        /// <param name="uiId">UI的ID</param>
        /// <param name="isActive">为true表示对象显示，false表示对象隐藏</param>
        /// <returns></returns>
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
