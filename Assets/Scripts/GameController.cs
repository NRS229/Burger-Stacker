using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Bool
    public static bool pause;
    public static bool gameStarted;
    //Rigidbodies
    public Rigidbody2D rbBunUp;
    public Rigidbody2D rbMeat;
    public Rigidbody2D rbBunDown;
    //GameObjects
    public GameObject userInterfaceItems;

    void Start()
    {
        pause = true;
    }

    void Update()
    {
        //Detect a touch
        if (Input.touchCount > 0 || Input.GetKeyDown("space")){
            if(!gameStarted){
                //Set the game to started
                gameStarted = true;
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
}
