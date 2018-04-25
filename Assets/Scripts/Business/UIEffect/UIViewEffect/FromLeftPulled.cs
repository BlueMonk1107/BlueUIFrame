using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using BlueUIFrame;

/// <summary>
/// 界面在左侧从竖直一条线打开成界面
/// </summary>
public class FromLeftPulled : AUIEffect {

    private DateTime showTime;

    public override void Enter()
    {
        showTime = DateTime.Now;
        RectTrans.localScale = new Vector3(0, 1, 1);
        RectTrans.anchoredPosition = Vector3.zero;
        RectTrans.DOScaleX(1, UIEffectTime.FROM_LEFT_PULLED);
        RectTrans.DOAnchorPosX(RectTrans.sizeDelta.x / 2, UIEffectTime.FROM_LEFT_PULLED);
    }

    public override void Exit()
    {
        RectTrans.DOScaleX(0, UIEffectTime.FROM_LEFT_PULLED);
        RectTrans.DOAnchorPosX(0 / 2, UIEffectTime.FROM_LEFT_PULLED).OnComplete(() =>
        {
            OnExitComplete();
            OnExitComplete -= OnExitComplete;
        });

    }
}
