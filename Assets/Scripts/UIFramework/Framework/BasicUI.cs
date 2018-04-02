using System;
using System.Reflection;
using UnityEngine;

public class BasicUI : AUIBase
{
    private IPara paraCache;

    public override void Init()
    {
        base.Init();
        layer = UILayer.BasicUI;
        CheckRepetition();
    }

    private void CheckRepetition()
    {
        AUIBase[] uiList = FindObjectsOfType<AUIBase>();
        int count = 0;
        foreach (AUIBase item in uiList)
        {
            if (item.IsMainUI)
            {
                count++;
            }
        }
        if (count > 1)
        {
            Debug.LogError("主界面UI只能存在一个，目前存在：" + count + "个");
        }
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
