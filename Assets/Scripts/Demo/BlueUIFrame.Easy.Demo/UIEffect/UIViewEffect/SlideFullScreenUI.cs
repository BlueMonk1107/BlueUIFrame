using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 全屏UI滑动特效
/// </summary>
public class SlideFullScreenUI : AUIEffect
{
    protected void FromRight()
    {
        InitPos();
        offset = DefaultScreenWidth + RectTrans.sizeDelta.x;
        RectTrans.anchoredPosition = DefaultAnchorPos + Vector2.right * offset;
        RectTrans.DOAnchorPos(DefaultAnchorPos, UIEffectTime.SLIDE_FROM_Right).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (onEnterComplete != null)
            {
                onEnterComplete();
            }
           
        });
    }

    protected void FromLeft()
    {
        InitPos();
        offset = DefaultScreenWidth + RectTrans.sizeDelta.x;
        RectTrans.anchoredPosition = DefaultAnchorPos - Vector2.right * offset;
        RectTrans.DOAnchorPos(DefaultAnchorPos, UIEffectTime.SLIDE_FROM_Right).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (onEnterComplete != null)
            {
                onEnterComplete();
            }
        });
    }

    protected void ToRight()
    {
        Vector2 targetAnchorPos = RectTrans.anchoredPosition + Vector2.right * offset;
        RectTrans.DOAnchorPos(targetAnchorPos, UIEffectTime.SLIDE_FROM_Right).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (OnExitComplete != null)
            {
                OnExitComplete();
            }
        });
    }

    protected void ToLeft()
    {
        Vector2 targetAnchorPos = RectTrans.anchoredPosition - Vector2.right * offset;
        RectTrans.DOAnchorPos(targetAnchorPos, UIEffectTime.SLIDE_FROM_Right).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (OnExitComplete != null)
            {
                OnExitComplete();
            }
        });
    }

    private void InitPos()
    {
        DefaultAnchorPos = Vector2.zero;
    }

    private void FromRightButtonWaggle()
    {

    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }
}
