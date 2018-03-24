using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTwo : BasicUI
{
    public override void Init(IPara para)
    {
        base.Init(para);
        UITool.AddBtnListener(transform, () => { UIManager.Instance.Back(); }, "Back");
        UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_ONE); }, "One");
        UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.MAIN_UI); }, "Main");
        UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.DIALOG); }, "Dialog");
    }
}
