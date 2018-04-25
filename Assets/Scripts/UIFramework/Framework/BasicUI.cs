using System;
using System.Reflection;
using UnityEngine;
using BlueUIFrame;

public class BasicUI : AUIBase
{
    public override void Init()
    {
        base.Init();
        layer = UILayer.BasicUI;
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
