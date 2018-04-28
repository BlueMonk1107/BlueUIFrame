using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    public interface IUIState
    {
        void Init();
        void Show();
        void Hide();
        void Complete();
    }

    public enum UIStateEnum
    {
        INIT,
        SHOW,
        HIDE
    }
}