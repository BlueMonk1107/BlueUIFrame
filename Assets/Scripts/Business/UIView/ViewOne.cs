using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewOne : BasicUI
{
    public override void Init(IPara para)
    {
        base.Init(para);
        UITool.AddBtnListener(transform, () => { UIManager.Instance.Back(); }, "Back");
        UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_TWO); }, "Two");
        UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.MAIN_UI); }, "Main");
    }
}
