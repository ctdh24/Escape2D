using System;
using UnityEngine;
using System.Collections;

public class bullet_logic : MonoBehaviour {

    private Animator b_anim;
    // Use this for initialization
    void Start () {
        b_anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        b_anim.Play("FireAnimation");
	}
}
