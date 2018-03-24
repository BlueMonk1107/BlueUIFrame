using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIManager
{
    bool ShowUI(EUiId id,IPara para);
    bool HideUI(UILayer layer);
    bool Back();
}
