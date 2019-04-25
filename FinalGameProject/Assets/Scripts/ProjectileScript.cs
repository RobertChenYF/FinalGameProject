using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject _projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject Bullet = Instantiate(_projectile,transform.position,Quaternion.identity);
            Bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * 5);
        }
    }
}
