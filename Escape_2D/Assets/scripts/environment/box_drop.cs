
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class box_drop : MonoBehaviour {
    public GameObject[] drop;

    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Projectile")
        {
            int random_amount = Random.Range(3, 5);
            for (int i = 0; i < random_amount; ++i)
            {
                int randDrop = Random.Range(0, drop.Length);
                //Debug.Log(randDrop);
                GameObject tempDrop = Instantiate(drop[randDrop], gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                //Debug.Log(tempDrop.gameObject.name);
                tempDrop.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(0.0f, 1.0f));
            }
            Destroy(gameObject);
            boxSpawner.destroyed = true;
        }

        else if (Col.gameObject.tag == "Player" || Col.gameObject.tag == "Pick-Up")
        {
            /*GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in playerList)
            {
                Physics2D.IgnoreCollision(p.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());

            }*/
            Physics2D.IgnoreCollision(Col.gameObject.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        
    }
	
}
