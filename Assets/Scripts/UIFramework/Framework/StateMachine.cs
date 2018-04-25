using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using BlueUIFrame;

public sealed class StateMachine<T>
{
    private readonly Dictionary<T, IUIState> stateDic;
    private readonly Dictionary<T, AUIEffect> effectDic;
    public T CurrentUiId { get; private set; }


    public StateMachine()
    {
        stateDic = new Dictionary<T, IUIState>();
        effectDic = new Dictionary<T, AUIEffect>();
    }

    public void AddUI(T id, IUIState stateMethod, AUIEffect uiEffect)
    {
        if (stateMethod == null)
        {
            Debug.LogError("the prefab cannot find IUIState");
            return;
        }
        if (!stateDic.ContainsKey(id) || stateDic[id] == null)
        {
            stateDic[id] = stateMethod;
            effectDic[id] = uiEffect;
            if (uiEffect != null)
            {
                uiEffect.AddEnterListener(stateMethod.Show);
                uiEffect.AddEnterListener(stateMethod.Hide);
            }
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
        Hide(CurrentUiId);
        CurrentUiId = id;
        Show(CurrentUiId);
    }

    public void Show(T id)
    {
        IUIState ui = stateDic[id];
        UIStateEnum state = ((AUIBase)ui).uiState;
        if (state == UIStateEnum.UNINIT)
        {
            ui.Init();
        }
        else if (state == UIStateEnum.SHOW)
        {
            return;
        }

        if (effectDic[id] != null)
        {
            effectDic[id].Enter();
        }
        else
        {
            ui.Show();
        }
    }

    public void Hide(T id)
    {
        if (CurrentUiId != null)
        {
            IUIState ui = stateDic[id];
            if (((AUIBase)ui).uiState == UIStateEnum.UNINIT)
            {
                return;
            }
            if (effectDic[id] != null)
            {
                effectDic[id].Exit();
            }
            else
            {
                stateDic[id].Hide();
            }
        }
    }
}

public enum UIStateEnum
{
    UNINIT,
    INIT,
    SHOW,
    HIDE
}
