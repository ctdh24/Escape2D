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
            if (gameObject.name.Contains("Green"))
            {
                scoreManager.gems++;
            }
            if (gameObject.name.Contains("Blue"))
            {
                scoreManager.gems +=5;
            }
            if (gameObject.name.Contains("Yellow"))
            {
                scoreManager.gems += 10;
            }
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Pick-Up" || other.gameObject.tag == "Projectile")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
}