using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : OverlayUI {

    public override void Init(IPara para)
    {
        base.Init(para);
        UITool.AddBtnListener(transform, () => { UIManager.Instance.Back(); }, "Back");
        UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_ONE); }, "One");
    }
}
