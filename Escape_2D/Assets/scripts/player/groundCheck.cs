using System;
using UnityEngine;
using System.Collections;

public class groundCheck : MonoBehaviour {

    private playerController2D player;
    void Start()
    {
        player = gameObject.GetComponentInParent<playerController2D>();
    }

    void Update()
    {
        GameObject[] bounds = GameObject.FindGameObjectsWithTag("BoundaryManager");
        foreach(GameObject b in bounds)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), b.GetComponent<Collider2D>());
            foreach(Transform child in b.transform)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), child.GetComponent<Collider2D>());
            }      
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player.p_grounded = true;
        Debug.Log("Landed");
    }
    void OnTriggerStay2D(Collider2D col)
    {
        player.p_grounded = true;
        Debug.Log("Stay: " + col.name);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        player.p_grounded = false;
        Debug.Log("Airborne");
    }

}
