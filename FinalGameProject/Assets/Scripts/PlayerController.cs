using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D rb2d;
    [HideInInspector] public bool jump = false;
    public float jumpForce = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal_1") > 0 && transform.position.x < -0.93f)
        {

            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0);
            //animator.SetInteger("State",1);

        }
        else if (Input.GetAxis("Horizontal_1") < 0 && transform.position.x > -2.91f)
        {

            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0);
            //animator.SetInteger("State", 2);
        }
        else
        {
            //animator.SetInteger("State", 0);
        }

        if (Input.GetButtonDown("Vertical_1"))
        {

           

            jump = true;
            //animator.SetBool("Jump", true);
        }
    }

    void FixedUpdate()
    {


        if (jump)
        {

            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
}
