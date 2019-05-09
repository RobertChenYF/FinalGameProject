using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    static public bool IfPigeonDead = false;
    static public bool IfBattle = false;
    static public GameObject deadPigeon;
    int a = 1;
    void Start()
    {
       // player1 = GameObject.Find("Player 1");

       // player2 = GameObject.Find("Player 2");
    }

    // Update is called once per frame
    void Update()
    {

        if (IfBattle == false)
        {
            Debug.Log("slowlmove camera");

            
            if (transform.position.y > 23 || transform.position.y < 7)
            {
                a = a * -1;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y + a *Time.deltaTime, transform.position.z);

        }
        else
        {
            if (IfPigeonDead)
        {
            FollowDeadPigeon(deadPigeon);
        }
            else
            {
            FollowHigherPigeon();
            }
        }

        if (transform.position.y < -8)
        {
            transform.position = new Vector3(transform.position.x, -8, transform.position.z);
        }
        else if (transform.position.y > 122)
        {
            transform.position = new Vector3(transform.position.x, 122, transform.position.z);
        }
    }

    

    public void FollowDeadPigeon(GameObject DeadPigeon)
    {
        if (Mathf.Max(player1.transform.position.y, player2.transform.position.y) < -8)
        {
            transform.position = new Vector3(transform.position.x, -8, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, DeadPigeon.transform.position.y, transform.position.z);
        }
    }

    public void FollowHigherPigeon()
    {
        

            transform.position = new Vector3(transform.position.x, Mathf.Max(player1.transform.position.y, player2.transform.position.y), transform.position.z);
        
    }

    //public void
}
