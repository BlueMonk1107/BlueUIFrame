using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

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

    protected Action<IPara> OnEnterComplete;
    protected Action<IPara> OnExitComplete;
    public UIShowState uiShowState = UIShowState.Default;

    public virtual void Init()
    {
        AddMsgListener();
    }

    protected virtual void AddMsgListener()
    {
        AUIBase uiBase = GetComponent<AUIBase>();
        if (uiBase != null)
        {
            MsgManager.Instance.AddListener(uiBase.ID+ "OnEnterComplete", OnEnterComplete);
            MsgManager.Instance.AddListener(uiBase.ID + "OnExitComplete", OnExitComplete);
        }
    }

    protected abstract void Enter();

    protected abstract void Exit();
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
