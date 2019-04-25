using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject _projectile;
    public float moveSpeed;
    private Rigidbody2D rb2d;
    [HideInInspector] public bool jump = false;
    public float jumpForce = 1000f;
    public string HorizontalControlName;
    public string VerticalControlName;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetButtonDown(VerticalControlName))
        {

           

            jump = true;
            //animator.SetBool("Jump", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject Bullet = Instantiate(_projectile, transform.position, Quaternion.identity);
            Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 20);
        }
    }

    void FixedUpdate()
    {


        if (jump)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
}
