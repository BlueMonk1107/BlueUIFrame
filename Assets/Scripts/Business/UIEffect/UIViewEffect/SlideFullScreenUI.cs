using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 全屏UI滑动特效
/// </summary>
public class SlideFullScreenUI : AUIEffect
{
    protected void FromRight(IPara para)
    {
        offset = DefaultScreenWidth + RectTrans.sizeDelta.x;
        RectTrans.anchoredPosition = DefaultAnchorPos + Vector2.right * offset;
        RectTrans.DOAnchorPos(DefaultAnchorPos, UIEffectTime.SLIDE_FROM_Right).SetEase(Ease.Linear).OnComplete(() =>
        {
            onEnterComplete(para);
        });
    }

    protected void FromLeft(IPara para)
    {
        offset = DefaultScreenWidth + RectTrans.sizeDelta.x;
        RectTrans.anchoredPosition = DefaultAnchorPos - Vector2.right * offset;
        RectTrans.DOAnchorPos(DefaultAnchorPos, UIEffectTime.SLIDE_FROM_Right).SetEase(Ease.Linear).OnComplete(() =>
        {
            onEnterComplete(para);
        });
    }

    protected void ToRight(IPara para)
    {
        Vector2 targetAnchorPos = RectTrans.anchoredPosition + Vector2.right * offset;
        RectTrans.DOAnchorPos(targetAnchorPos, UIEffectTime.SLIDE_FROM_Right).SetEase(Ease.Linear).OnComplete(() =>
        {
            OnExitComplete(para);
        });
    }

    protected void ToLeft(IPara para)
    {
        Vector2 targetAnchorPos = RectTrans.anchoredPosition - Vector2.right * offset;
        RectTrans.DOAnchorPos(targetAnchorPos, UIEffectTime.SLIDE_FROM_Right).SetEase(Ease.Linear).OnComplete(() =>
        {
            OnExitComplete(para);
        });
    }

    private void FromRightButtonWaggle()
    {
        
    }

    public override void Enter(IPara para = null)
    {
    }

    public override void Exit(IPara para = null)
    {
    }
}
