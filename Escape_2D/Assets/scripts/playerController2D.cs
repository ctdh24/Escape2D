﻿using System;
using UnityEngine;
using System.Collections;

public class playerController2D : MonoBehaviour {
    public float maxSpeed = 1f;
    public float m_speed = 10f;
    public float jump_power = 150f;

    public bool p_grounded;            // Whether or not the player is grounded.
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    public bool p_shooting;
    private int num_bullets;
    public int health;
    
    void Start () {
        m_Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        m_Anim = gameObject.GetComponent<Animator>();
        p_shooting = false;
        num_bullets = 0;
        health = 6;
    }
	
	// Update is called once per frame
	void Update () {
        m_Anim.SetBool("grounded", p_grounded);
        m_Anim.SetBool("shooting", p_shooting);
        m_Anim.SetFloat("speed", Math.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetButtonDown("Fire1")){
            p_shooting = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            p_shooting = false;
        }


        if (Input.GetAxis("Horizontal") > 0.1){
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") < -0.1){
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetButtonDown("Jump") && p_grounded){
            m_Rigidbody2D.AddForce(Vector2.up*jump_power);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        m_Rigidbody2D.AddForce((Vector2.right*m_speed)*h);
        if (m_Rigidbody2D.velocity.x > maxSpeed)
        {
            m_Rigidbody2D.velocity = new Vector2(maxSpeed,m_Rigidbody2D.velocity.y);
        }
        if (m_Rigidbody2D.velocity.x < -maxSpeed)
        {
            m_Rigidbody2D.velocity = new Vector2(-maxSpeed, m_Rigidbody2D.velocity.y);
        }
    }
}