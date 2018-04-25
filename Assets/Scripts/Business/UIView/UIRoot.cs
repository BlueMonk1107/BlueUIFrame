using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlueUIFrame;

public class UIRoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    if (GetComponent<UIManager>() == null)
	    {
	        gameObject.AddComponent<UIManager>();
	    }

        UIManager.Instance.ShowUI(EUiId.MAIN_UI);
	}
}
