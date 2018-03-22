using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIManager
{
    void ShowUI(EUiId id,IPara para);
    void HideUI(UILayer layer);
    bool Back();
}
