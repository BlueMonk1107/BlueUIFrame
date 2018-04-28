using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame.Easy.Utility;

namespace BlueUIFrame.Easy.Demo
{
    public class SideView : OverlayUI
    {
        public override void Init()
        {
            base.Init();
            InitUI(EUiId.SIDE_VIEW, false);
            UITool.AddBtnListener(transform, () => { UIManager.Instance.Back(); }, "Back");
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_TWO); }, "Two");
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_ONE); }, "One");
        }
    }
}