using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame.Easy;

/// <summary>
/// 从右侧滑进屏幕
/// </summary>
public class SlideFromRight : SlideFullScreenUI
{
    public override void Enter()
    {
        base.Enter();
        switch (uiShowState)
        {
            case UIShowState.New:
                FromRight();
                break;
            case UIShowState.Old:
                FromLeft();
                break;
        }
    }

    public override void Exit()
    {
        base.Exit();
        switch (uiShowState)
        {
            case UIShowState.New:
                ToRight();
                break;
            case UIShowState.Old:
                ToLeft();
                break;
        }
    }
}
