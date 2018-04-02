using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AUIBase : MonoBehaviour, IUIState
{

    public EUiId ID { get; private set; }
    public UILayer layer { get; protected set; }

    public UIStateEnum uiState { get; protected set; }

    public bool IsMainUI { get; private set; }

    public virtual void Init()
    {
        uiState = UIStateEnum.INIT;
    }

    public virtual void Show()
    {
        uiState = UIStateEnum.SHOW;
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        uiState = UIStateEnum.HIDE;
        gameObject.SetActive(false);
    }

    protected void InitUI(EUiId id,bool isMainUI = false)
    {
        ID = id;
        uiState = UIStateEnum.UNINIT;
        IsMainUI = isMainUI;
    }
}
