using UnityEngine;
using System.Collections;

public class ghostScript : MonoBehaviour {

    // Use this for initialization
    private GameObject targetPlayer;
    void Start() {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        if(Time.timeScale ==1)
            transform.position = Vector2.Lerp(transform.position, targetPlayer.transform.position, 0.5f * Time.fixedDeltaTime);
        else
            transform.position = Vector2.Lerp(transform.position, targetPlayer.transform.position, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            playerController2D.health = 0;
        }
        if (col.tag == "Projectile")
            Destroy(gameObject);
    }
}
