using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //Gameover when anything passes certain imaginary wall
    void OnCollisionEnter2D(Collision2D other)
    {
        GameEvents.current.GameOver();
    }

}
