using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class freezeChildPosition : MonoBehaviour {
    private Vector3 initialPosition;
	// Use this for initialization
	void Start () {
        initialPosition = gameObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
	    if (gameObject.transform.localPosition != initialPosition)
        {
            gameObject.transform.localPosition = initialPosition;
        }
	}
}
