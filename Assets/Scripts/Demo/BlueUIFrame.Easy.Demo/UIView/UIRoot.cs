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
            if (GetComponent<UIManager>() == null)
            {
                gameObject.AddComponent<UIManager>();
            }
            UIManager.Instance.InitUISystem();
            UIManager.Instance.ShowUI(EUiId.MAIN_UI);
        }
    }
}
