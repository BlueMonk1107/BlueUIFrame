using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public interface IUIState
{
    void Init(IPara para = null);
    void Show(IPara para = null);
    void Hide(IPara para = null);
    void Complete(IPara para = null);
}