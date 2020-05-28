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
    private bool jumpToGrill;
    private bool jump;
    private bool isAligned;
    private bool hasCollectedTopping;

    void Start()
    {
        //Subscribe to events
        GameEvents.current.onInstantiateTopping += OnInstantiateTopping;
        //Initiate bools
        isAligned = false;
        hasCollectedTopping = false;
    }

    // Update is for input
    void Update(){
        //Detect a touch
        if (Input.touchCount > 0 || Input.GetKeyDown("space")){
            //First touch
            if(!GameController.introStarted){
                //Start the intro
                GameEvents.current.StartIntro();
                //Burger jumps to grill
                jumpToGrill = true;
                //Disable UI
                GameEvents.current.DisableUI();
                //Unpause game
                GameEvents.current.ResumeGame();
            }else{
                //After first touch
                jump = true;
            }
        }
    }

    //FixedUpdate is for applying physics
    void FixedUpdate()
    {
        if(jumpToGrill){
            //Burger jumps to grill
            rbBunUp.AddForce(new Vector2(-100f, 300));
            rbMeat.AddForce(new Vector2(-101f, 300));            
            rbBunDown.AddForce(new Vector2(-102f, 300));
            //Reset jumpToGrill
            jumpToGrill = false;
        }
        if(jump){
            // Add a vertical force (Jump)
            rbBunUp.AddForce(new Vector2(0.0f, 220f));
            if(!hasCollectedTopping){
                rbMeat.AddForce(new Vector2(0.0f, 120f));
                rbBunDown.AddForce(new Vector2(0.0f, 100f));
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

}
