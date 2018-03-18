using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AUIBase : MonoBehaviour {

    public EUiId ID { get; private set; }

    public abstract void Add(AUIBase ui);
    public abstract void Remove(AUIBase ui);

    protected void SetId(EUiId id)
    {
        ID = id;
    }
}
