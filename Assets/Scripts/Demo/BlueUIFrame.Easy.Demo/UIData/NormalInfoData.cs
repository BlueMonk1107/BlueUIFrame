//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using UnityEngine;
using System.Collections;

namespace BlueUIFrame.Easy.Demo
{
    public class NormalInfoData : IData
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Count { get; set; }

        public NormalInfoData(string name,int age,int count)
        {
            Name = name;
            Age = age;
            Count = count;
        }
    }
}
