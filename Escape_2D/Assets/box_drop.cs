using UnityEngine;
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
                int randDrop = Random.Range(0, drop.Length - 1);
                GameObject tempDrop = Instantiate(drop[randDrop], gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                //tempDrop.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1.0f, 1.0f), 0f);
            }
            Destroy(gameObject);
        }
    }
	
}
