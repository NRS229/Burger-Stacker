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
    //Burger parts transform
    private Transform UpperBun;
    private Transform FirstMeat;
    private Transform LowerBun;

    void Start()
    {
        //Subscribe to events
        GameEvents.current.onInstantiateTopping += OnInstantiateTopping;
        GameEvents.current.onClick += OnClick;
        GameEvents.current.onPlayAgainSetup += OnPlayAgainSetup;
        //Initiate bools
        isAligned = false;
        hasCollectedTopping = false;
        click = false;
        //Detect burger parts transform
        UpperBun = transform.GetChild(0);
        FirstMeat = transform.GetChild(1);
        LowerBun = transform.GetChild(2);

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
                GameController.pause = false;
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
                UpperBun.transform.position = new Vector3(LowerBun.position.x, UpperBun.position.y, 1f);
                FirstMeat.transform.position = new Vector3(LowerBun.position.x, FirstMeat.position.y, 1f);
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

    private void OnPlayAgainSetup(){
        UpperBun.transform.position = new Vector3(-2.4f, -2f, 1f);
        FirstMeat.transform.position = new Vector3(-2.4f, -2.5f, 1f);
        LowerBun.transform.position = new Vector3(-2.4f, -3f, 1f);
    }

}
