using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public interface IUIState
{
    void Init();
    void Show();
    void Hide();
}