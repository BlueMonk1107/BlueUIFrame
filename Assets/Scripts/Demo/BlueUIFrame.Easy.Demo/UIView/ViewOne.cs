using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame.Easy.Utility;
using UnityEngine.UI;

namespace BlueUIFrame.Easy.Demo
{
    public class ViewOne : BasicUI
    {
        protected override void Init()
        {
            base.Init();
            InitUI(EUiId.VIEW_ONE, NormalInfoDataHandler.NAME);
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.Back(); }, "Back");
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.ShowUI(EUiId.VIEW_TWO); }, "Two");
            UITool.AddBtnListener(transform, () => { UIManagerDemo.Instance.ShowUI(EUiId.MAIN_UI); }, "Main");
            UITool.AddBtnListener(transform, () =>
            {
                NormalInfoData data = GetData<NormalInfoData>();
                data.Count ++;
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
