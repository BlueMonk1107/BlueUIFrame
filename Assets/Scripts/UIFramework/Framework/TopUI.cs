using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame;

public class TopUI : AUIBase
{
    public override void Init()
    {
        layer = UILayer.TopUI;
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
