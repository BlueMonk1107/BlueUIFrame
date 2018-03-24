using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

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
        if(stateMethod == null)
        {
            Debug.LogError("the prefab cannot find IUIState");
            return;
        }
        if (!stateDic.ContainsKey(id) || stateDic[id] == null)
        {
            stateDic[id] = stateMethod;
            effectDic[id] = uiEffect;
            if(uiEffect != null)
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
    
    public void ChangeUI(T id, IPara para = null)
    {
        Hide(CurrentUiId, para);
        CurrentUiId = id;
        Show(CurrentUiId, para);
    }

    public void Show(T id, IPara para = null)
    {
        IUIState ui = stateDic[id];
        if (((AUIBase)ui).uiState == UIStateEnum.INIT)
        {
            ui.Init();
        }

        if (effectDic[id] != null)
        {
            effectDic[id].Enter(para);
        }
        else
        {
            ui.Show(para);
        }
    }

    public void Hide(T id, IPara para = null)
    {
        if (CurrentUiId != null)
        {
            IUIState ui = stateDic[id];
            if (((AUIBase)ui).uiState == UIStateEnum.INIT)
            {
                return;
            }
            if (effectDic[id] != null)
            {
                effectDic[id].Exit(para);
            }
            else
            {
                stateDic[id].Hide(para);
            }
        }
    }
}

public enum UIStateEnum
{
    INIT,
    SHOW,
    HIDE
}
