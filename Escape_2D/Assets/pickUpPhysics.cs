using UnityEngine;
using System.Collections;

public class pickUpPhysics : MonoBehaviour
{
    public bool coliding = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        coliding = true;
        if (other.tag == "Player")
        {
            scoreManager.gems++;
            Destroy(gameObject);
        }
        //else { gameObject.GetComponent<Rigidbody2D>().isKinematic = true; }

    }
}