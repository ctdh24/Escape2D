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

    void Update()
    {
        Destroy(gameObject, 2f);
    }

	// Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        else {
            Destroy(gameObject);
            collision = true;
        }
    }
}
