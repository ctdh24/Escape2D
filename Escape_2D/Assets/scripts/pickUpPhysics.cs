using UnityEngine;
using System.Collections;

public class pickUpPhysics : MonoBehaviour
{
    public bool coliding = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        
        //else { gameObject.GetComponent<Rigidbody2D>().isKinematic = true; }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        coliding = true;
        if (other.gameObject.tag == "Player")
        {
            scoreManager.gems++;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Pick-Up")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
}