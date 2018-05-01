using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BlueUIFrame.Easy.Utility;

namespace BlueUIFrame.Easy
{
    public class UILayerManager : SingletonMono<UILayerManager>, IUILayerManager
    {
        public Dictionary<UILayer, GameObject> UILayerObjDic { get; private set; }

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
