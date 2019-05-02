using System.Collections;
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
    public string VerticalProjectileControlName;
    public string HorizontalProjectileControlName;
    public string myName;
    public string enemyName;
    public Image healthBar;
    private float health = 1;
    public float flyTimer;
    private float tempFlyTimer;
    public float shootTimer;
    private float tempShootTimer;
    public Animator pigeon;
    private GameObject enemyPlayer;
    private bool ifLeft;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyPlayer = GameObject.Find(enemyName);
    }

    // Update is called once per frame
    void Update()
    {
        FaceEachOther();
        tempFlyTimer = tempFlyTimer - Time.deltaTime;
        tempShootTimer = tempShootTimer - Time.deltaTime;
        //pigeon.SetBool("ifFly", false);


       // if (Input.GetAxis(HorizontalControlName) > 0.5f)
      //  {

            //transform.position += new Vector3(moveSpeed * Time.deltaTime, 0);
      //      rb2d.velocity = new Vector2(5, rb2d.velocity.y);
            //animator.SetInteger("State",1);

      //  }
      //  else if (Input.GetAxis(HorizontalControlName) < -0.5f)
      //  {

            //transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0);
       //     rb2d.velocity = new Vector2(-5, rb2d.velocity.y);
            //animator.SetInteger("State", 2);
     //   }
      //  else
      //  {
            //animator.SetInteger("State", 0);
      //  }

        rb2d.velocity = new Vector2((rb2d.velocity.x+ moveSpeed*Input.GetAxis(HorizontalControlName)*Time.deltaTime), rb2d.velocity.y);
        //Debug.Log(Input.GetAxis(HorizontalControlName));

        if (Input.GetButtonDown(VerticalControlName) && pigeon.GetBool("ifFly") == false)
        {

            pigeon.SetBool("ifFly", true);

            //jump = true;
            //animator.SetBool("Jump", true);
            //tempFlyTimer = flyTimer;
        }

        if (Input.GetButtonDown(VerticalProjectileControlName) && tempShootTimer <= 0 )

        {
            BottomProjectile();
           
        }
        else if (Input.GetButtonDown(HorizontalProjectileControlName) && tempShootTimer <= 0)
        {
            FrontProjectile(ifLeft);
        }
        //Debug.Log(Input.GetAxis(HorizontalControlName));

    }

    void FixedUpdate()
    {


       // if (jump)
        //{
        //    rb2d.velocity = Vector2.zero;
        //    float tempJumpForce = (health * jumpForce) * 0.25f + jumpForce * 0.75f; // damaged fly equation
        //
        //    rb2d.AddForce(new Vector2(0f, tempJumpForce));
         //   jump = false;
        //    pigeon.SetBool("ifFly", true);
       // }


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

    public void FaceEachOther()
    {
        if(transform.position.x < enemyPlayer.transform.position.x)
        {

            transform.rotation = Quaternion.Euler(0,0,0);
            transform.localScale = new Vector3(0.2f, 0.2f, 1 );
            ifLeft = true;

        }
        else if (transform.position.x > enemyPlayer.transform.position.x)
        {

            transform.rotation = Quaternion.Euler(0, 0, 180);
            transform.localScale = new Vector3(0.2f, -0.2f, 1);
            ifLeft = false;
        }


    }

    public void FlyAnimationEnd()
    {
        pigeon.SetBool("ifFly", false);
        
    }

    public void Fly()
    {
        rb2d.velocity = Vector2.zero;
        float tempJumpForce = (health * jumpForce) * 0.25f + jumpForce * 0.75f; // damaged fly equation

        rb2d.AddForce(new Vector2(0f, tempJumpForce));
        jump = false;
        pigeon.SetBool("ifFly", true);
    }

    public void BottomProjectile()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

        GameObject Bullet = Instantiate(_projectile, spawnPosition, Quaternion.identity);
        Bullet.GetComponent<ProjectileScript>().myName = myName;
        Bullet.GetComponent<ProjectileScript>().enemyName = enemyName;
        Bullet.GetComponent<ProjectileScript>().playerController = this;
        //Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 20);
        tempShootTimer = shootTimer;
    }

    public void FrontProjectile(bool ifLeft)
    {
        
        if (ifLeft == true) {
            Vector3 spawnPosition = new Vector3(transform.position.x + 1, transform.position.y + 0.5f, transform.position.z);

            GameObject Bullet = Instantiate(_projectile, spawnPosition, Quaternion.identity);
            Bullet.GetComponent<ProjectileScript>().myName = myName;
            Bullet.GetComponent<ProjectileScript>().enemyName = enemyName;
            Bullet.GetComponent<ProjectileScript>().playerController = this;
            Rigidbody2D rigidbody2D;

            rigidbody2D = Bullet.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(new Vector3(7, 3, 0), ForceMode2D.Impulse);
        }
        else if (ifLeft == false)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x - 1, transform.position.y + 0.5f, transform.position.z);

            GameObject Bullet = Instantiate(_projectile, spawnPosition, Quaternion.identity);
            Bullet.GetComponent<ProjectileScript>().myName = myName;
            Bullet.GetComponent<ProjectileScript>().enemyName = enemyName;
            Bullet.GetComponent<ProjectileScript>().playerController = this;
            Rigidbody2D rigidbody2D;

            rigidbody2D = Bullet.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(new Vector3(-7, 3, 0), ForceMode2D.Impulse);
        }



            
        //Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 20);
        tempShootTimer = shootTimer;
    }
}
