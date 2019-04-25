using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public string enemyName;
    public string myName;
    public string floor;
    public PlayerController playerController;

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
            Destroy(gameObject);
        }
        else if (col.gameObject.name == enemyName)
        {
            Destroy(gameObject);
            Debug.Log("hit enemy");
            playerController.DamagebyProjectile(enemyName);
        }


        
    }
}
