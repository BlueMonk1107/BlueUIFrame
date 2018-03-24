using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopUI : AUIBase, IUIState
{
    public virtual void Init(IPara para)
    {
        layer = UILayer.BasicUI;
        uiState = UIStateEnum.INIT;
    }

    public virtual void Show(IPara para)
    {
        gameObject.SetActive(true);
        uiState = UIStateEnum.SHOW;
    }

    public virtual void Hide(IPara para)
    {
        gameObject.SetActive(false);
        uiState = UIStateEnum.HIDE;
    }

    public virtual void Complete(IPara para)
    {
        throw new System.NotImplementedException();
    }
}
