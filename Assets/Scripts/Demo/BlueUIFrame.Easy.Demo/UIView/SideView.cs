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
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.Back(); }, "Back");
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.ShowUI(EUiId.VIEW_TWO); }, "Two");
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.ShowUI(EUiId.VIEW_ONE); }, "One");
        }
    }
}