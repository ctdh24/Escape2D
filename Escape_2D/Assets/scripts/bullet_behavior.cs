using System;
using UnityEngine;
using System.Collections;

public class bullet_behavior : MonoBehaviour {
    // Use this for initialization
    public bool collision;
    void Start()
    {
        collision = false;
    }
	// Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
        collision = true;
    }
}
