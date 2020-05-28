using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Bool
    public static bool pause;
    public static bool introStarted;
    public static bool gameStarted;
    //Cameras
    public GameObject menuCamera;
    public GameObject gameplayCamera;
    //Instantiation
    float instantiateY = -3.6f;
    private GameObject nextTopping;
    public GameObject newToppingPrefab;
    public Sprite[] toppingSprites;


    void Start()
    {
        //Subscribe to events
        GameEvents.current.onStartGame  += OnStartGame;
        GameEvents.current.onStartIntro += OnStartIntro;
        GameEvents.current.onPauseGame  += OnPauseGame;
        GameEvents.current.onResumeGame += OnResumeGame;
        GameEvents.current.onInstantiateTopping += OnInstantiateTopping;
        //Initializing bools
        pause = true;
        introStarted = false;
        gameStarted = false;
    }

    void Update()
    {
        if(pause){
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
        }
    }

    private void OnStartGame(){
        if(!gameStarted){
            gameStarted = true;
            changeCamera();
            Debug.Log("Starting the game");
        }else{
            Debug.Log("The game has already started");
        }
    }

    private void OnPauseGame(){
        pause=true;
        Debug.Log("Pause game");
    }

    private void OnResumeGame(){
        pause=false;
        Debug.Log("Resume game");
    }

    private void OnStartIntro(){
        introStarted = true;
        Debug.Log("Starting the intro");
    }

    private void OnInstantiateTopping(){
        Debug.Log("Instantiating topping");
        //X and Y
        float instantiateX = 10f;
        instantiateY +=0.283810716f; //Boxcollider y * Scale y
        //Instantiation
        nextTopping = Instantiate(newToppingPrefab, new Vector2(instantiateX, instantiateY), Quaternion.identity) as GameObject;
        
    }

    private void changeCamera(){
        //Change cameras
        menuCamera.SetActive(!menuCamera.activeSelf);
        gameplayCamera.SetActive(!gameplayCamera.activeSelf);
    }

}
