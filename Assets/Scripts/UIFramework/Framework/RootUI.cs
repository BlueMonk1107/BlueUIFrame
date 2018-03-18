using System;
using System.Reflection;
using UnityEngine;

public class RootUI : AUIBase, IUIState
{
    public UIStateEnum uiState { get; private set; }

    public void Init(IPara para)
    {
        uiState = UIStateEnum.INIT;
        CheckRepetition();
    }

    private void CheckRepetition()
    {
        int count = FindObjectsOfType<RootUI>().Length;
        if (count > 1)
        {
            Debug.LogError("RootUI为根节点UI，只能存在一个，目前存在："+ count + "个");
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

    public override void Add(AUIBase ui)
    {
       
    }

    public override void Remove(AUIBase ui)
    {
        Debug.Log("根节点UI无法移除");
    }
}
