using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMono<UIManager>, IUIManager
{
    private StateMachine<EUiId> stateMachine;
    private MsgManager msgManager;
    private List<AUIBase> childList;//放到池对象中管理 

    public MsgManager GetMsgManager { get { return msgManager; } }
    private void Awake()
    {
        InitSystem();
    }

    private void InitSystem()
    {
        stateMachine = new StateMachine<EUiId>();
        msgManager = new MsgManager();
        childList = new List<AUIBase>();
    }
    
    public void ShowUI(EUiId id, IPara para)
    {
        IUIState ui = null;
        stateMachine.AddUI(id, ui);
    }

    public void HideUI(EUiId id, IPara para)
    {
        throw new System.NotImplementedException();
    }

    public void Back()
    {
        throw new System.NotImplementedException();
    }
}
 