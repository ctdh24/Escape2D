using System;
using UnityEngine;
using System.Collections;

public class bullet_behavior : MonoBehaviour {
    // Use this for initialization
    public float bullet_force = 200f;
    public Rigidbody2D bullet;
    public GameObject player;
    void Start () {
        if(player.GetComponent<playerController2D>().is_facingRight())
            bullet.velocity = new Vector2(bullet_force, bullet.velocity.y);
        else
            bullet.velocity = new Vector2(-bullet_force, bullet.velocity.y);
    }
	
	// Update is called once per frame
	void Update () {
        Destroy(bullet, 10);
    }
}
