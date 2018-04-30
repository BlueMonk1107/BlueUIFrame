using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy.Demo
{
    public class UIRoot : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            if (GetComponent<UIManagerDemo>() == null)
            {
                gameObject.AddComponent<UIManagerDemo>();
            }
            UIManagerDemo.Instance.InitUISystem();
            UIManagerDemo.Instance.ShowUI(EUiId.MAIN_UI);
        }
    }
}
