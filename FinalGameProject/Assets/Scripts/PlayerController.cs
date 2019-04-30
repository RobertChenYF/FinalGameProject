﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject _projectile;
    public float moveSpeed;
    private Rigidbody2D rb2d;
    [HideInInspector] public bool jump = false;
    public float jumpForce = 1000f;
    public string HorizontalControlName;
    public string VerticalControlName;
    public string ProjectileControlName;
    public string myName;
    public string enemyName;
    public Image healthBar;
    private float health = 1;
    public float flyTimer;
    private float tempFlyTimer;
    public float shootTimer;
    private float tempShootTimer;
    public Animator pigeon;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        tempFlyTimer = tempFlyTimer - Time.deltaTime;
        tempShootTimer = tempShootTimer - Time.deltaTime;
        //pigeon.SetBool("ifFly", false);
        if (Input.GetAxis(HorizontalControlName) > 0 )
        {

            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0);
            //animator.SetInteger("State",1);

        }
        else if (Input.GetAxis(HorizontalControlName) < 0 )
        {

            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0);
            //animator.SetInteger("State", 2);
        }
        else
        {
            //animator.SetInteger("State", 0);
        }

        if (Input.GetButtonDown(VerticalControlName) && tempFlyTimer <= 0)
        {
            
            jump = true;
            //animator.SetBool("Jump", true);
            tempFlyTimer = flyTimer;
        }

        if (Input.GetButtonDown(ProjectileControlName) && tempShootTimer <= 0)

       
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

            GameObject Bullet = Instantiate(_projectile, spawnPosition, Quaternion.identity);
            Bullet.GetComponent<ProjectileScript>().myName = myName;
            Bullet.GetComponent<ProjectileScript>().enemyName = enemyName;
            Bullet.GetComponent<ProjectileScript>().playerController = this;
            //Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 20);
            tempShootTimer = shootTimer;
        }
    }

    void FixedUpdate()
    {


        if (jump)
        {
            rb2d.velocity = Vector2.zero;
            float tempJumpForce = (health * jumpForce) * 0.25f + jumpForce * 0.75f; // damaged fly equation

            rb2d.AddForce(new Vector2(0f, tempJumpForce));
            jump = false;
            pigeon.SetBool("ifFly", true);
        }


    }

    public void DamagebyProjectile(string damagedPlayer)
    {
        if(damagedPlayer == myName)
        {
            Debug.Log(myName + " get damaged");
            health -= 0.2f;
            healthBar.fillAmount = health;
        }

    }

    public void Dead()
    {
        Debug.Log(enemyName + " win!");

        Destroy(gameObject);
    }

   // public void FaceEachOther()
   // {
     //   transform.lossyScale = 

   // }

    //public bool StartingSide()
    //{
      //
    //}
    public void flyAnimationEnd()
    {
        pigeon.SetBool("ifFly", false);
    }
}
