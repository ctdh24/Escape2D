using System;
using UnityEngine;
using System.Collections;

public class teleporter_script : MonoBehaviour {
    public GameObject destination;
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.transform.position = destination.transform.position;
    }
}
