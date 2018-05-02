//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================

using System;
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy.Demo
{
    public class  NormalInfoDataHandler : IDataHandler
    {
        public const string NAME = "NormalInfoProxy";
        private NormalInfoData data;

        public Action UpdateShow { get; set; }

        public NormalInfoDataHandler()
        {
            InitData();
        }

        public void InitData()
        {
            data = new NormalInfoData("BlueMonk", 28, 1);
        }

        public IData GetData()
        {
            return data;
        }

        public void UpdataData(IData newData)
        {
            data = (NormalInfoData)newData;
            if (UpdateShow != null)
            {
                UpdateShow();
            }
        }

        public string GetName()
        {
            return NAME;
        }
    }
}
