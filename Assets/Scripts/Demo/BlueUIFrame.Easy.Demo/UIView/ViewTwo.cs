using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame.Easy.Utility;
using UnityEngine.UI;

namespace BlueUIFrame.Easy.Demo
{
    public class ViewTwo : BasicUI
    {
        public override void Init()
        {
            base.Init();
            InitUI(EUiId.VIEW_TWO, NormalInfoDataHandler.NAME);
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.Back(); }, "Back");
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.ShowUI(EUiId.VIEW_ONE); }, "One");
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.ShowUI(EUiId.MAIN_UI); }, "Main");
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.ShowUI(EUiId.DIALOG); }, "Dialog");
        }

        protected override void UpdateShow()
        {
            NormalInfoData data = GetData<NormalInfoData>();
            transform.Find("Name").GetComponent<Text>().text = data.Name;
            transform.Find("Age").GetComponent<Text>().text = data.Age.ToString();
            transform.Find("Count").GetComponent<Text>().text = data.Count.ToString();
        }
    }
}
