using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Bun")&&(!GameController.gameStarted)) {
            GameEvents.current.StartGame();
        }        
    }
}
