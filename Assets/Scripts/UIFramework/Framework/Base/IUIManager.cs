using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIManager
{
    bool ShowUI(EUiId id);
    bool HideUI(UILayer layer);
    bool Back();
}
