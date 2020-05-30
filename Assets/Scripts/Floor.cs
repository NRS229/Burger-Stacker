using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Gameover when some part of the burger touches the floor
        if((collision.gameObject.tag == "Bun"||collision.gameObject.tag == "Topping"||collision.gameObject.tag == "FirstMeat")&&(GameController.gameStarted)) {
            GameEvents.current.GameOver();
        }        
    }
}
