using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 从右侧滑进屏幕
/// </summary>
public class SlideFromRight : SlideFullScreenUI
{
    public override void Enter(IPara para)
    {
        base.Enter();
        switch (uiShowState)
        {
            case UIShowState.New:
                FromRight(para);
                break;
            case UIShowState.Old:
                FromLeft(para);
                break;
        }
    }

    public override void Exit(IPara para)
    {
        base.Exit();
        switch (uiShowState)
        {
            case UIShowState.New:
                ToRight(para);
                break;
            case UIShowState.Old:
                ToLeft(para);
                break;
        }
    }
}
