using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public static int sceneState = 0; //start Screen
    public GameObject startScreen;
    public GameObject battleUI;
    public GameObject player1;
    public GameObject player2;
    public GameObject instruction;
    public GameObject EndScreenUI;
    public Button Return;
    public Button Start;
    public static bool IfHitFloor;
    public Button Return2;
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script


        //Call the InitGame function to initialize the first level 
        StartScreen();
    }

    //Initializes the game for each level.

    



    //Update is called every frame.
    void Update()
    {


        EndScreen(IfHitFloor);
    }

    public void StartGame()
    {
        CameraManager.IfBattle = true;
        startScreen.SetActive(false);
        battleUI.SetActive(true);
        player1.SetActive(true);
        player2.SetActive(true);
        instruction.SetActive(false);
        EndScreenUI.SetActive(false);
    }

    public void Instruction()
    {
        CameraManager.IfBattle = false;
        startScreen.SetActive(false);
        battleUI.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        instruction.SetActive(true);
        Return.Select();
        EndScreenUI.SetActive(false);
    }
    public void StartScreen()
    {
       
        CameraManager.IfBattle = false;
        startScreen.SetActive(true);
        battleUI.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        instruction.SetActive(false);
        Start.Select();

        EndScreenUI.SetActive(false);
    }
    public void EndScreen(bool IfHitFloor)
    {

        if(IfHitFloor == true)
        {
        CameraManager.IfBattle = true;
        startScreen.SetActive(false);
        battleUI.SetActive(true);
        player1.SetActive(true);
        player2.SetActive(true);
        instruction.SetActive(false);
       EndScreenUI.SetActive(true);
            Return2.Select();

        }
        
    }

    public void ReloadScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        player1.transform.position = new Vector3(-7.7f, 17.4f, 0);
        player2.transform.position = new Vector3(8.3f, 17.4f, 0);
        player1.GetComponent<PlayerController>().health = 1;
        player2.GetComponent<PlayerController>().health = 1;
        player1.GetComponent<PlayerController>().ifDead = false;
        player2.GetComponent<PlayerController>().ifDead = false;
        IfHitFloor = false;

        StartScreen();
    }

}