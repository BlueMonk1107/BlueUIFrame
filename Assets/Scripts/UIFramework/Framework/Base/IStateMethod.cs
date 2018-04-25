//=======================================================
// 作者：BlueMonk
// 描述：A simple UI framework For Unity . 
//=======================================================
using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

namespace BlueUIFrame
{
    public interface IUIState
    {
        void Init();
        void Show();
        void Hide();
    }
}