//=======================================================
// 作者：BlueMonk
// 描述：PureMVC-based UI framework. 
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy.Demo
{
    public class NormalInfoProxy : IProxy
    {
        public const string NAME = "NormalInfoProxy";
        private NormalInfoData data;
        public NormalInfoProxy()
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
        }

        public string GetName()
        {
            return NAME;
        }
    }
}
