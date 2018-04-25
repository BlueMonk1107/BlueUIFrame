using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BlueUIFrame;

/// <summary>
/// 全屏UI滑动特效
/// </summary>
public class SlideFullScreenUI : AUIEffect
{
    protected void FromRight()
    {
        offset = DefaultScreenWidth + RectTrans.sizeDelta.x;
        RectTrans.anchoredPosition = DefaultAnchorPos + Vector2.right * offset;
        RectTrans.DOAnchorPos(DefaultAnchorPos, UIEffectTime.SLIDE_FROM_Right).SetEase(Ease.Linear).OnComplete(() =>
        {
            onEnterComplete();
        });
    }

    protected void FromLeft()
    {
        offset = DefaultScreenWidth + RectTrans.sizeDelta.x;
        RectTrans.anchoredPosition = DefaultAnchorPos - Vector2.right * offset;
        RectTrans.DOAnchorPos(DefaultAnchorPos, UIEffectTime.SLIDE_FROM_Right).SetEase(Ease.Linear).OnComplete(() =>
        {
            onEnterComplete();
        });
    }

    protected void ToRight()
    {
        Vector2 targetAnchorPos = RectTrans.anchoredPosition + Vector2.right * offset;
        RectTrans.DOAnchorPos(targetAnchorPos, UIEffectTime.SLIDE_FROM_Right).SetEase(Ease.Linear).OnComplete(() =>
        {
            OnExitComplete();
        });
    }

    protected void ToLeft()
    {
        Vector2 targetAnchorPos = RectTrans.anchoredPosition - Vector2.right * offset;
        RectTrans.DOAnchorPos(targetAnchorPos, UIEffectTime.SLIDE_FROM_Right).SetEase(Ease.Linear).OnComplete(() =>
        {
            OnExitComplete();
        });
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
