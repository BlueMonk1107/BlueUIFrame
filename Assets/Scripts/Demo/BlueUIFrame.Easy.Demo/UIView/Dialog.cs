using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame.Easy.Utility;
using UnityEngine.UI;

namespace BlueUIFrame.Easy.Demo
{
    public class Dialog : TopUI
    {
        protected override void Init()
        {
            base.Init();
            InitUI(EUiId.DIALOG, NormalInfoDataHandler.NAME);
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.Back(); }, "Back");
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.ShowUI(EUiId.VIEW_ONE); }, "One");
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.ShowUI(EUiId.SIDE_VIEW); }, "Side");
            UITool.AddBtnListener(transform, () =>
            {
                NormalInfoData data = GetData<NormalInfoData>();
                data.Count++;
                dataHandler.UpdataData(data);
            }, "Count");
        }

        protected override void UpdateShow()
        {
            NormalInfoData data = GetData<NormalInfoData>();
            transform.Find("Count").GetComponent<Text>().text = data.Count.ToString();
        }
    }
}
