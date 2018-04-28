using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame.Easy.Utility;

namespace BlueUIFrame.Easy.Demo
{
    public class ViewTwo : BasicUI
    {
        public override void Init()
        {
            base.Init();
            InitUI(EUiId.VIEW_TWO, false);
            UITool.AddBtnListener(transform, () => { UIManager.Instance.Back(); }, "Back");
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_ONE); }, "One");
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.MAIN_UI); }, "Main");
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.DIALOG); }, "Dialog");
        }
    }
}
