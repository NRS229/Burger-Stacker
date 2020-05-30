using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Start the game when the burger touched the grill and the game has not started
        if((collision.gameObject.tag == "Bun")&&(!GameController.gameStarted)) {
            GameEvents.current.StartGame();
        }
        //Gameover when some part of the burger touches the floor
        if(((collision.gameObject.tag == "Bun")||(collision.gameObject.tag == "Topping"))&&(GameController.gameStarted)) {
            if(collision.gameObject.name != "LowerBun"){
                GameEvents.current.GameOver();
            }
        }        
    }
}
