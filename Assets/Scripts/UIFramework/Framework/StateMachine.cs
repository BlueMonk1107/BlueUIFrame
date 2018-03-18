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
        stateDic[id] = stateMethod;
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
        //if (CurrentUiId != null)
        //{
        //    stateDic[CurrentUiId].Hide();
        //}

        //IUIFrame ui = stateDic[id];
        //switch (ui.uiState)
        //{
        //    case UIStateEnum.INIT:
        //        ui.Init();
        //        break;
        //    case UIStateEnum.HIDE:
        //        ui.Show();
        //        break;
        //}
    }
}

public enum UIStateEnum
{
    INIT,
    SHOW,
    HIDE
}
