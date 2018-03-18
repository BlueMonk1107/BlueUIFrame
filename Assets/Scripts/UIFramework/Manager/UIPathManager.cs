using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIPathManager
{

    public static readonly Dictionary<EUiId, string> UIPathDic = new Dictionary<EUiId, string>()
    {
        {EUiId.MAIN_UI, ""}
    };

}

public enum EUiId
{
    MAIN_UI,
    SECOND_UI
}
