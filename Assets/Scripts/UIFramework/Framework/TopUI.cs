using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopUI : AUIBase, IUIState
{
    public void Init(IPara para)
    {
        uiState = UIStateEnum.INIT;
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
        throw new System.NotImplementedException();
    }
}
