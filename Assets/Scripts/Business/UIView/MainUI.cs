using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame;

public class MainUI : BasicUI {
    public override void Init()
    {
        base.Init();
        InitUI(EUiId.MAIN_UI);
        UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_ONE);},"One");
        UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_TWO); }, "Two");
        UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.SIDE_VIEW); }, "Side");
    }
}
