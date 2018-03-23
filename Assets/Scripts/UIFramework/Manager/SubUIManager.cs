using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubUIManager : MonoBehaviour, IUIManager
{
    private UILayer managerLayer;
    private StateMachine<EUiId> stateMachine;
    private Stack<EUiId> uiStack;
    private Dictionary<EUiId, Transform> objectPool; 

    public void Init(UILayer uiLayer, StateMachine<EUiId> machine)
    {
        managerLayer = uiLayer;
       
        uiStack = new Stack<EUiId>();

        stateMachine = machine;
    }

    public void ShowUI(EUiId id, IPara para)
    {
        Transform uiTrans = SpawnUI(id);
        if (uiTrans != null)
        {
            IUIState ui = uiTrans.GetComponent<IUIState>();
            if (ui != null)
            {
                AUIEffect uIEffect = uiTrans.GetComponent<AUIEffect>();
                stateMachine.AddUI(id, ui, uIEffect);
                objectPool[id] = uiTrans;
                uiStack.Push(id);
                stateMachine.ChangeUI(id);
            }
            else
            {
                Debug.LogError("the prefab cannot find IUIState");
                return;
            }
        }
        else
        {
            Debug.LogError("UI Object Spawan False");
        }
    }

    public void HideUI(UILayer layer)
    {
        if(layer > managerLayer)
            return;
        if (uiStack.Count > 0)
        {
            stateMachine.Hide(uiStack.Pop());
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
            stateMachine.Hide(uiStack.Pop());
            stateMachine.Show(uiStack.Peek());
            return true;
        }
        else
        {
            return false;
        }
    }
}
