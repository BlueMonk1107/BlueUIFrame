using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BlueUIFrame;

/// <summary>
/// 界面在中心，从竖直一条线打开成界面
/// </summary>
public class FromMiddlePulled : AUIEffect
{
    public override void Enter()
    {
        RectTrans.localScale = new Vector3(0, 1, 1);
        RectTrans.DOScaleX(1, UIEffectTime.OPEN_FROM_MIDDLE);
    }

    public override void Exit()
    {
        RectTrans.DOScaleX(0, UIEffectTime.OPEN_FROM_MIDDLE).OnComplete(() =>
        {
            OnExitComplete();
            OnExitComplete -= OnExitComplete;
        });
    }
}
