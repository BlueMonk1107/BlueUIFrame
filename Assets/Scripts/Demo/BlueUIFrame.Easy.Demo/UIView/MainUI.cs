using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame.Easy.Utility;

namespace BlueUIFrame.Easy.Demo
{
    public class MainUI : BasicUI
    {
        public override void Init()
        {
            base.Init();
            InitUI(EUiId.MAIN_UI, true);
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_ONE); }, "One");
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_TWO); }, "Two");
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.SIDE_VIEW); }, "Side");
        }
    }
}

