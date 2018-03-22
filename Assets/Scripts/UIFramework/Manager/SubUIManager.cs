using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubUIManager : MonoBehaviour, IUIManager
{
    private UILayer managerLayer;
    private StateMachine<EUiId> stateMachine;
    private Stack<IUIState> uiStack;
    private Dictionary<EUiId, Transform> objectPool; 

    public void Init(UILayer uiLayer)
    {
        managerLayer = uiLayer;
        stateMachine = new StateMachine<EUiId>();
        uiStack = new Stack<IUIState>();
    }

    public void ShowUI(EUiId id, IPara para)
    {
        Transform uiTrans = SpawnUI(id);
        if (uiTrans != null)
        {
            IUIState ui = uiTrans.GetComponent<IUIState>();
            if (ui != null)
            {
                stateMachine.AddUI(id, ui);
                objectPool[id] = uiTrans;
                uiStack.Push(ui);
                stateMachine.ChangeUI(id);
            }
            else
            {
                Debug.LogError("UI脚本未继承IUIState");
                return;
            }
        }
        else
        {
            Debug.LogError("UI对象生成失败");
        }
    }

    public void HideUI(UILayer layer)
    {
        if(layer > managerLayer)
            return;
        if (uiStack.Count > 0)
        {
            uiStack.Pop().Hide();
        }
    }

    private Transform SpawnUI(EUiId id)
    {
        string path = UIPathManager.GetPath(id);
        if (!string.IsNullOrEmpty(path))
        {
            if (!objectPool.ContainsKey(id) || objectPool[id] == null)
            {
                objectPool[id] = Instantiate(Resources.Load(path), transform) as Transform;
            }
            return objectPool[id];
        }
        else
        {
            return null;
        }
    }

    public bool Back()
    {
        if (uiStack.Count > 1)
        {
            uiStack.Pop().Hide();
            uiStack.Peek().Show();
            return true;
        }
        else
        {
            return false;
        }
    }
}
