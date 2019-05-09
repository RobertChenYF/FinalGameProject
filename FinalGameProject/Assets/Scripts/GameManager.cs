using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using UnityEngine.UI;

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

    }
    public void EndScreen()
    {
        CameraManager.IfBattle = true;
        startScreen.SetActive(false);
        battleUI.SetActive(true);
        player1.SetActive(true);
        player2.SetActive(true);
        instruction.SetActive(false);

    }
}