using System;
using UnityEngine;
using System.Collections;

public class groundCheck : MonoBehaviour {

    private playerController2D player;
    void Start()
    {
        player = gameObject.GetComponentInParent<playerController2D>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        player.p_grounded = true;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        player.p_grounded = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        player.p_grounded = false;
    }

}
