using System;
using System.Reflection;
using UnityEngine;

public class BasicUI : AUIBase, IUIState
{
    private IPara paraCache;

    public void Init(IPara para)
    {
        uiState = UIStateEnum.INIT;
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

    public void Show(IPara para)
    {
        uiState = UIStateEnum.SHOW;
    }

    public void Hide(IPara para)
    {
        uiState = UIStateEnum.HIDE;
    }

    public void Complete(IPara para)
    {

    }
}
