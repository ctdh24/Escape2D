using UnityEngine;
using System.Collections;

public class boxSpawner : MonoBehaviour {
    public GameObject[] spawnPlaces;
    public GameObject box;
    public bool hasSpawned = false;
    public static bool destroyed;
    private int last_spawned = 3;
	// Use this for initialization
	void Awake () {
        destroyed = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if (destroyed == true)
        {
            int random_amount = Random.Range(0, spawnPlaces.Length-1);
            while (random_amount == last_spawned)
            {
                random_amount = Random.Range(0, spawnPlaces.Length - 1);
            }
            //Debug.Log(random_amount);
            GameObject tempBox = Instantiate(box, spawnPlaces[random_amount].transform.position, spawnPlaces[random_amount].transform.rotation) as GameObject;
            last_spawned = random_amount;
            destroyed = false;
        }
	}
}
