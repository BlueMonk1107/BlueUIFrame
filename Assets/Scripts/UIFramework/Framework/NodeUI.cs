using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : AUIBase, IUIState
{

    public override void Add(AUIBase ui)
    {
        throw new System.NotImplementedException();
    }

    public override void Remove(AUIBase ui)
    {
        throw new System.NotImplementedException();
    }

    public UIStateEnum uiState { get; }
    public void Init(IPara para)
    {
        throw new System.NotImplementedException();
    }

    public void Show(IPara para)
    {
        throw new System.NotImplementedException();
    }

    public void Hide(IPara para)
    {
        throw new System.NotImplementedException();
    }

    public void Complete(IPara para)
    {
        throw new System.NotImplementedException();
    }
}
