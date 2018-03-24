using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 从左侧滑进屏幕
/// </summary>
public class SlideFromLeft : SlideFullScreenUI
{

    public override void Enter(IPara para)
    {
        base.Enter(para);
        switch (uiShowState)
        {
            case UIShowState.New:
                FromLeft(para);
                break;
            case UIShowState.Old:
                FromRight(para);
                break;
        }
    }

    public override void Exit(IPara para)
    {
        base.Exit(para);
        switch (uiShowState)
        {
            case UIShowState.New:
                ToLeft(para);
                break;
            case UIShowState.Old:
                ToRight(para);
                break;
        }
    }
}
