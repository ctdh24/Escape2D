using System;
using UnityEngine;
using System.Collections;

public class playerController2D : MonoBehaviour {
    public float maxSpeed = 1f;
    public float m_speed = 10f;
    public float jump_power = 150f;

    public GameObject bulletProjection;
    public GameObject bullet;
    public GameObject shield;
    private static bool shield_on;

    public float bullet_force = 5f;

    public bool p_grounded;            // Whether or not the player is grounded.
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    public bool p_shooting;
    private int num_bullets;
    public static int health;

    public bool facingRight;
    
    void Start () {
        //create player always facing right like in old Megaman and Mario
        m_Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        facingRight = true;

        //set the players animator
        m_Anim = gameObject.GetComponent<Animator>();
        
        //set shooting to false
        p_shooting = false;
        
        //set shield to off
        //shield.SetActive(false);
        shield_on = false;
        num_bullets = 0;
        health = 6;
    }
	
	// Update is called once per frame
	void Update () {
        
        m_Anim.SetBool("shooting", p_shooting);
        m_Anim.SetFloat("speed", Math.Abs(Input.GetAxis("Horizontal")));
        /*=========================================================================================================================*/
        //shooting fire once per button press.
        //When Time.timeScale == 0, the game is paused, the the game still registers the button press which creates a fireball
        if (Input.GetButtonDown("Fire1") && Time.timeScale == 1)
        {
            p_shooting = true;
            //Instantiate the bullet
            GameObject temp_bullet;
            if (facingRight)
            {
                temp_bullet = Instantiate(bullet, bulletProjection.transform.position, bulletProjection.transform.rotation) as GameObject;
                temp_bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bullet_force, temp_bullet.GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                temp_bullet = Instantiate(bullet, bulletProjection.transform.position, bulletProjection.transform.rotation) as GameObject;
                temp_bullet.transform.localScale = new Vector3(-1, 1, 1);
                temp_bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bullet_force, temp_bullet.GetComponent<Rigidbody2D>().velocity.y);
            }

        }
        if (Input.GetButtonUp("Fire1") && Time.timeScale == 1)
        {
            p_shooting = false;
        }
        /*=========================================================================================================================*/
        if (Input.GetButtonDown("Fire1") && Input.GetKey("up") && (scoreManager.gems > 50) && !shield_on && Time.timeScale == 1)
        {
            shield_on = true;
            scoreManager.gems -= 50;
            GameObject tempShield = Instantiate(shield, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            tempShield.transform.parent = gameObject.transform;
            //shield.SetActive(true);
        }
        /*=========================================================================================================================*/
        //movement. flips player's strite depending on direction + jumping
        if (Input.GetAxis("Horizontal") > 0.1){
            facingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") < -0.1){
            facingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetButtonDown("Jump") && p_grounded && Time.timeScale == 1)
        {
            m_Rigidbody2D.AddForce(Vector2.up*jump_power);
        }
        /*=========================================================================================================================*/
    }
    
    //basic movement left and right
    void FixedUpdate()
    {
        m_Anim.SetBool("grounded", p_grounded);
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
    public bool is_facingRight()
    {
        return facingRight;
    }
    public static void set_shieldOff()
    {
        if (shield_on)
            shield_on = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Platform")
            transform.parent = col.transform;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Platform")
            transform.parent = null;
    }

}
