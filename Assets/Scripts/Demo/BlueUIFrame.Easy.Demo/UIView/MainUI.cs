using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame.Easy.Utility;
using UnityEngine.UI;

namespace BlueUIFrame.Easy.Demo
{
    public class MainUI : BasicUI
    {
        protected override void Init()
        {
            base.Init();
            InitUI(EUiId.MAIN_UI, NormalInfoDataHandler.NAME);
            UITool.AddBtnListener(transform, () => { AppUIRoot.UIManager.ShowUI(EUiId.VIEW_ONE); }, "One");
            UITool.AddBtnListener(transform, () => { AppUIRoot.UIManager.ShowUI(EUiId.VIEW_TWO); }, "Two");
            UITool.AddBtnListener(transform, () => { AppUIRoot.UIManager.ShowUI(EUiId.SIDE_VIEW); }, "Side");
        }

        protected override void UpdateShow()
        {
            NormalInfoData data = (NormalInfoData)dataHandler.GetData();
            transform.Find("Name").GetComponent<Text>().text = data.Name;
            transform.Find("Age").GetComponent<Text>().text = data.Age.ToString();
            transform.Find("Count").GetComponent<Text>().text = data.Count.ToString();
        }
    }
}

