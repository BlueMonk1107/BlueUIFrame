using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame;

public class Dialog : OverlayUI {

    public override void Init()
    {
        base.Init();
        UITool.AddBtnListener(transform, () => { UIManager.Instance.Back(); }, "Back");
        UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_ONE); }, "One");
    }
}
