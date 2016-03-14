using UnityEngine;
using System.Collections;

public class platformUp : MonoBehaviour {

    // Use this for initialization
    void OnCollisionEnter2D(Collision2D p)
    {
        //if the contact of collision is equal to Vector3.up destroy the collided object
        Debug.Log("contact: " + p.contacts[0].point);
        if (p.contacts[0].point == Vector2.up)
        {
            Physics2D.IgnoreCollision(p.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), false);
        }
    }
    void OnCollisionExit2D(Collision2D p)
    {
        Physics2D.IgnoreCollision(p.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
    }
}
