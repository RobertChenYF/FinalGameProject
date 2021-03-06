﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public string enemyName;
    public string myName;
    public string floor;
    public PlayerController playerController;
    public Animator animator;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
        GameObject enemy = GameObject.Find(enemyName);
        playerController= (PlayerController)enemy.GetComponent(typeof(PlayerController));
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == floor)
        {

            animator.SetTrigger("Hit");
            //Destroy(gameObject);
        }
        else if (col.gameObject.name == enemyName)
        {
            
            Debug.Log("hit enemy");
            animator.SetTrigger("Hit");
            playerController.DamagebyProjectile(enemyName, damage);
        }
}
    public void DestroyItSelf()
    {
        Destroy(gameObject);
    }

}
