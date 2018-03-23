using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UIManager : SingletonMono<UIManager>, IUIManager
{
    private Dictionary<UILayer, IUIManager> subUiManagers;
    private void Awake()
    {
        InitSystem();
    }

    private void InitSystem()
    {
        StateMachine<EUiId> stateMachine = new StateMachine<EUiId>();
        subUiManagers = new Dictionary<UILayer, IUIManager>();
        //添加消息系统
        AddManager<MsgManager>(gameObject);
        //添加层级系统
        UILayerManager layerManager = AddManager<UILayerManager>(gameObject);
        layerManager.Init();
        SpawnSubUIManager(layerManager,stateMachine);
    }

    private T AddManager<T>(GameObject obj) where T : MonoBehaviour
    {
        if (GetComponent<T>() == null)
        {
            return obj.AddComponent<T>();
        }
        else
        {
            return obj.GetComponent<T>();
        }
    }

    private void SpawnSubUIManager(UILayerManager layerMgr, StateMachine<EUiId> stateMachine)
    {
        GameObject layerParent = null;
        SubUIManager subUiManager = null;
        foreach (UILayer item in Enum.GetValues(typeof(UILayer)))
        {
            layerParent = layerMgr.UILayerObjDic[item];
            subUiManager = AddManager<SubUIManager>(layerParent);
            subUiManager.Init(item, stateMachine);
            subUiManagers[item] = subUiManager;
        }
    }

    public void ShowUI(EUiId id, IPara para)
    {
        Transform uiTrans = SpawnUI(id);
        if (uiTrans != null)
        {
            AUIBase uiBase = uiTrans.GetComponent<AUIBase>();
            UILayer showLayer = uiBase.layer;
            subUiManagers[showLayer].ShowUI(id, para);
            HideUI(showLayer);
        }
        else
        {
            Debug.LogError("UI对象生成失败");
        }
    }

    public void HideUI(UILayer layer)
    {
        foreach (KeyValuePair<UILayer, IUIManager> pair in subUiManagers)
        {
            pair.Value.HideUI(layer);
        }
    }

    private Transform SpawnUI(EUiId id)
    {
        string path = UIPathManager.GetPath(id);
        if (!string.IsNullOrEmpty(path))
        {
            return Instantiate(Resources.Load(path), transform) as Transform;
        }
        else
        {
            return null;
        }
    }

    public bool Back()
    {
        Array layers = Enum.GetValues(typeof(UILayer));
        Array.Reverse(layers);
        foreach (UILayer item in layers)
        {
            if (subUiManagers[item].Back())
            {
                return true;
            }
        }
        return false;
    }
}
