//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BlueUIFrame.Easy.Utility;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// UI层级管理器
    /// <para>
    /// 此系统使用的是unity的自然层级
    /// 即在此脚本挂载的父物体下，自动创建层级父物体
    /// UI对象通过SetUILayer方法，会被设置成对应层级父物体的子物体
    /// </para>
    /// </summary>
    public class UILayerManager : SingletonMono<UILayerManager>, IUILayerManager
    {
        public Dictionary<UILayer, GameObject> UILayerObjDic { get; private set; }
        /// <summary>
        /// 初始化层级管理器
        /// </summary>
        public void Init()
        {
            UILayerObjDic = new Dictionary<UILayer, GameObject>();
            RectTransform rect;
            foreach (UILayer item in Enum.GetValues(typeof(UILayer)))
            {
                UILayerObjDic[item] = new GameObject(item.ToString());
                rect = UILayerObjDic[item].AddComponent<RectTransform>();
                InitLayerObj(rect);
            }
        }
        /// <summary>
        /// 设置UI到其对应的层级父物体下
        /// </summary>
        /// <param name="ui"></param>
        public void SetUILayer(AUIBase ui)
        {
            ui.transform.SetParent(UILayerObjDic[ui.GetLayer()].transform);
        }

        private void InitLayerObj(RectTransform rect)
        {
            rect.SetParent(transform);
            rect.anchorMax = Vector2.one;
            rect.anchorMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            rect.offsetMin = Vector2.zero;
            rect.sizeDelta = Vector2.zero;
            rect.localScale = Vector3.one;
            rect.localPosition = Vector3.zero;
        }
    }

    public enum UILayer
    {
        BasicUI,
        OverlayUI,
        TopUI
    }
}
