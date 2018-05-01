using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame.Easy.Utility;

namespace BlueUIFrame.Easy.Demo
{
    public class SideView : OverlayUI
    {
        protected override void Init()
        {
            base.Init();
            InitUI(EUiId.SIDE_VIEW);
            UITool.AddBtnListener(transform, () => { AppUIRoot.UIManager.Back(); }, "Back");
            UITool.AddBtnListener(transform, () => { AppUIRoot.UIManager.ShowUI(EUiId.VIEW_TWO); }, "Two");
            UITool.AddBtnListener(transform, () => { AppUIRoot.UIManager.ShowUI(EUiId.VIEW_ONE); }, "One");
        }
    }
}