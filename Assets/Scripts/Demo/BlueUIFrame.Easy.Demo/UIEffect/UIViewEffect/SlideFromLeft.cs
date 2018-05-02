using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BlueUIFrame.Easy;

/// <summary>
/// 从左侧滑进屏幕
/// </summary>
public class SlideFromLeft : SlideFullScreenUI
{

    public override void Enter()
    {
        base.Enter();
        switch (uiShowState)
        {
            case UIShowState.New:
                FromLeft();
                break;
            case UIShowState.Old:
                FromRight();
                break;
        }
    }

    public override void Exit()
    {
        base.Exit();
        switch (uiShowState)
        {
            case UIShowState.New:
                ToLeft();
                break;
            case UIShowState.Old:
                ToRight();
                break;
        }
    }
}
