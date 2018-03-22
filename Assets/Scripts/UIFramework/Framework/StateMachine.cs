using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public sealed class StateMachine<T>
{
    private readonly Dictionary<T, IUIState> stateDic;
    public T CurrentUiId { get; private set; }


    public StateMachine()
    {
        stateDic = new Dictionary<T, IUIState>();
    }
    
    public void AddUI(T id, IUIState stateMethod)
    {
        if (!stateDic.ContainsKey(id) || stateDic[id] == null)
        {
            stateDic[id] = stateMethod;
        }
    }

    public void Remove(T id)
    {
        if (stateDic.ContainsKey(id))
        {
            stateDic.Remove(id);
        }
    }
    
    public void ChangeUI(T id)
    {
        if (CurrentUiId != null)
        {
            if (CurrentUiId.Equals(id))
            {
                return;
            }
            stateDic[CurrentUiId].Hide();
        }

        IUIState ui = stateDic[id];
        if (((AUIBase)ui).uiState == UIStateEnum.INIT)
        {
            ui.Init();
        }
        ui.Show();
    }
}

public enum UIStateEnum
{
    INIT,
    SHOW,
    HIDE
}
