using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEffetManager : SingletonMono<UIEffetManager>
{
    public void Init()
    {
        InitAll();
    }

    private void InitAll()
    {
        foreach (AUIEffect effect in transform.GetComponentsInChildren<AUIEffect>())
        {
            effect.Init();
        }
    }
}
