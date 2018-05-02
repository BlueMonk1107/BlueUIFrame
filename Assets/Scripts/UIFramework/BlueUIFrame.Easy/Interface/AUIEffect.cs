//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// UI动效的接口
    /// </summary>
    public abstract class AUIEffect : MonoBehaviour
    {
        private RectTransform rectTrans;

        /// <summary>
        /// 当前UI的RectTransform对象
        /// </summary>
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

        /// <summary>
        /// 默认屏幕宽度
        /// </summary>
        protected float DefaultScreenWidth
        {
            get { return FindObjectOfType<CanvasScaler>().referenceResolution.x; }
        }

        /// <summary>
        /// 正常显示时，UI的AnchorPosition
        /// </summary>
        protected Vector2 DefaultAnchorPos { get; set; }

        /// <summary>
        /// UI的AnchorPosition在X轴上的偏移量（即从偏移的位置移动到正常显示的位置）
        /// </summary>
        protected float offset;

        /// <summary>
        /// 入场动效播放完成的回调函数
        /// </summary>
        protected Action onEnterComplete;

        /// <summary>
        /// 退场动效播放完成的回调函数
        /// </summary>
        protected Action OnExitComplete;

        /// <summary>
        /// 用于循环UI动效的动效状态标记
        /// </summary>
        public UIShowState uiShowState = UIShowState.Default;

        /// <summary>
        /// 入场动效函数
        /// </summary>
        public abstract void Enter();

        /// <summary>
        /// 退场动效函数
        /// </summary>
        public abstract void Exit();

        /// <summary>
        /// 添加入场动效播放完成的回调函数的监听
        /// </summary>
        /// <param name="action"></param>
        public virtual void AddEnterListener(Action action)
        {
            onEnterComplete = action;
        }

        /// <summary>
        /// 添加退场动效播放完成的回调函数的监听
        /// </summary>
        /// <param name="action"></param>
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