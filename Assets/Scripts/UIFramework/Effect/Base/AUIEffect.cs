//=======================================================
// 作者：BlueMonk
// 描述：A simple UI framework For Unity . 
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace BlueUIFrame
{
    public abstract class AUIEffect : MonoBehaviour
    {
        private RectTransform rectTrans;

        protected RectTransform RectTrans
        {
            get
            {
                if (rectTrans == null)
                {
                    rectTrans = GetComponent<RectTransform>();
                }
                return rectTrans;
            }
        }

        protected float DefaultScreenWidth
        {
            get { return FindObjectOfType<CanvasScaler>().referenceResolution.x; }
        }

        protected Vector2 DefaultAnchorPos
        {
            get { return rectTrans.anchoredPosition; }
        }
        protected float offset;

        protected Action onEnterComplete;
        protected Action OnExitComplete;
        public UIShowState uiShowState = UIShowState.Default;

        public abstract void Enter();

        public abstract void Exit();

        public virtual void AddEnterListener(Action action)
        {
            onEnterComplete = action;
        }

        public virtual void AddExitListener(Action action)
        {
            OnExitComplete = action;
        }
    }

    public static class UIEffectTime
    {
        public const float SLIDE_FROM_LEFT = 0.5f;
        public const float SLIDE_FROM_Right = 0.5f;
        public const float OPEN_FROM_MIDDLE = 0.5f;
        public const float FROM_LEFT_PULLED = 1f;
        public const float POP_FROM_UI = 0.6f;
    }

    public enum UIShowState
    {
        Default,
        New,
        Old
    }
}
