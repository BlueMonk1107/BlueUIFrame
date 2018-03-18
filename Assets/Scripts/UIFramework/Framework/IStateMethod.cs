using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public interface IUIState
{
    UIStateEnum uiState { get;}
    void Init(IPara para);
    void Show(IPara para);
    void Hide(IPara para);
    void Complete(IPara para);
}