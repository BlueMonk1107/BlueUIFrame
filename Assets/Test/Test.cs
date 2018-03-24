using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(Wait());
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject ob = transform.GetChild(0).gameObject;
        Destroy(ob);
        Debug.Log(ob == null);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
