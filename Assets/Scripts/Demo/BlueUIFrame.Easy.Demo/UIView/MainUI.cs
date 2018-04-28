using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame.Easy.Utility;
using UnityEngine.UI;

namespace BlueUIFrame.Easy.Demo
{
    public class MainUI : BasicUI
    {
        private NormalInfoProxy normalInfo;
        public override void Init()
        {
            base.Init();
            InitUI(EUiId.MAIN_UI);
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_ONE); }, "One");
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.VIEW_TWO); }, "Two");
            UITool.AddBtnListener(transform, () => { UIManager.Instance.ShowUI(EUiId.SIDE_VIEW); }, "Side");
            normalInfo = UIManager.Instance.ProxyManager.GetProxy<NormalInfoProxy>(NormalInfoProxy.NAME);
        }

        public override void Show()
        {
            base.Show();
            UpdateShow();
        }

        private void UpdateShow()
        {
            NormalInfoData data = (NormalInfoData)normalInfo.GetData();
            transform.Find("Name").GetComponent<Text>().text = data.Name;
            transform.Find("Age").GetComponent<Text>().text = data.Age.ToString();
            transform.Find("Count").GetComponent<Text>().text = data.Count.ToString();
        }
    }
}

