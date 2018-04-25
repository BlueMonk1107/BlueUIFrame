using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame;

public class OverlayUI : AUIBase
{
    public override void Init()
    {
        layer = UILayer.OverlayUI;
        base.Init();
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }
}
