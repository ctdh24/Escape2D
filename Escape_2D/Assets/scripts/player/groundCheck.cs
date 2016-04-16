using System;
using UnityEngine;
using System.Collections;
using UnityEditorInternal;
using System.Reflection;

public class groundCheck : MonoBehaviour {

    private playerController2D player;
    void Start()
    {
        player = gameObject.GetComponentInParent<playerController2D>();
        GameObject p = GameObject.Find("Player");
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), p.GetComponent<Collider2D>());

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
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), camera.GetComponent<Collider2D>());
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
