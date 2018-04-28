using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame.Easy.Utility;

namespace BlueUIFrame.Easy.Demo
{
    public class Dialog : TopUI
    {
        public override void Init()
        {
            base.Init();
            InitUI(EUiId.DIALOG, false);
            UITool.AddBtnListener(transform, () => { UIManager.Instance.Back(); }, "Back");
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_ONE); }, "One");
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.SIDE_VIEW); }, "Side");
        }
    }
}
