using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player1;
    private GameObject player2;


    void Start()
    {
        player1 = GameObject.Find("Player 1");

        player2 = GameObject.Find("Player 2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Max(player1.transform.position.y, player2.transform.position.y), transform.position.z);
    }
}
