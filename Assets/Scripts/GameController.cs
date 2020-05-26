using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Bool
    public static bool pause;
    public static bool introStarted;
    public static bool gameStarted;
    //Rigidbodies
    public Rigidbody2D rbBunUp;
    public Rigidbody2D rbMeat;
    public Rigidbody2D rbBunDown;
    //GameObjects
    public GameObject userInterfaceItems;
    //Cameras
    public GameObject menuCamera;
    public GameObject gameplayCamera;

    void Start()
    {
        GameEvents.current.onStartGame += OnStartGame;
        pause = true;
    }

    void Update()
    {
        //Detect a touch
        if (Input.touchCount > 0 || Input.GetKeyDown("space")){
            if(!introStarted){
                //Start the intro
                introStarted = true;
                Debug.Log("Starting the intro");
                //Burger jumps to grill
                rbBunUp.AddForce(new Vector2(-100f, 300));
                rbMeat.AddForce(new Vector2(-101f, 300));
                rbBunDown.AddForce(new Vector2(-102f, 300));
                //Deactivate UI
                userInterfaceItems.SetActive(false);
            }
            pause = false;
        }

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

    private void changeCamera(){
        //Change cameras
        menuCamera.SetActive(false);
        gameplayCamera.SetActive(true);
    }

}
