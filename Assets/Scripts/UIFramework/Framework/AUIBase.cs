using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AUIBase : MonoBehaviour {

    public EUiId ID { get; private set; }
    public UILayer layer { get; private set; }

    public UIStateEnum uiState { get; protected set; }

    public bool IsMainUI { get; private set; }

    protected void InitUI(EUiId id, UILayer uiLayer,bool isMainUI = false)
    {
        ID = id;
        layer = uiLayer;
        uiState = UIStateEnum.INIT;
        IsMainUI = isMainUI;
    }
}
