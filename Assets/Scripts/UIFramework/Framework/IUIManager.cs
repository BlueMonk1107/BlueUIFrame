using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIManager {
    void ShowUI(EUiId id,IPara para);
    void HideUI(EUiId id,IPara para);
    void Back();
}
