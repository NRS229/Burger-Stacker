using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buns : MonoBehaviour
{
    //Rigidbodies
    public Rigidbody2D rbBunUp;
    public Rigidbody2D rbMeat;
    public Rigidbody2D rbBunDown;
    //Bools
    private bool click;
    private bool jumpToGrill;
    private bool jump;
    private bool isAligned;
    private bool hasCollectedTopping;
    public static bool isUpperBunTouchingTopping;

    void Start()
    {
        //Subscribe to events
        GameEvents.current.onInstantiateTopping += OnInstantiateTopping;
        GameEvents.current.onClick += OnClick;
        //Initiate bools
        isAligned = false;
        hasCollectedTopping = false;
        click = false;
    }

    // Update is for input
    void Update(){
        //Detect a touch
        if (click || Input.GetKeyDown("space")){
            //First touch
            if(!GameController.introStarted){
                //Start the intro
                GameEvents.current.StartIntro();
                //Burger jumps to grill
                jumpToGrill = true;
                //Unpause game
                GameEvents.current.ResumeGame();
            }else{
                if(isUpperBunTouchingTopping && !GameController.pause){
                    jump = true;
                }
            }
            //Reset click
            click = false;
        }
    }

    //FixedUpdate is for applying physics
    void FixedUpdate()
    {
        if(jumpToGrill){
            //Burger jumps to grill
            rbBunUp.AddForce(new Vector2(-2f, 6f), ForceMode2D.Impulse);
            rbMeat.AddForce(new Vector2(-2.02f, 6f), ForceMode2D.Impulse);            
            rbBunDown.AddForce(new Vector2(-2.04f, 6f), ForceMode2D.Impulse);
            //Reset jumpToGrill
            jumpToGrill = false;
        }
        if(jump){
            // Add a vertical force (Jump)
            rbBunUp.AddForce(transform.up * 5f, ForceMode2D.Impulse);
            if(!hasCollectedTopping){
                rbMeat.AddForce(transform.up * 2.5f, ForceMode2D.Impulse);
                rbBunDown.AddForce(transform.up * 2f, ForceMode2D.Impulse);
            }
            //Reset jump
            jump = false;

            if(!isAligned){
                //Align burger
                transform.GetChild(0).transform.position = new Vector3(transform.GetChild(2).position.x, transform.GetChild(0).position.y, transform.GetChild(0).position.z);
                transform.GetChild(1).transform.position = new Vector3(transform.GetChild(2).position.x, transform.GetChild(1).position.y, transform.GetChild(1).position.z);
                isAligned = true;
            }
        }
    }

    private void OnInstantiateTopping(){
        hasCollectedTopping = true;
    }

    private void OnClick(){
        click = true;
    }

}
