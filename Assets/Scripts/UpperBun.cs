using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBun : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Topping" || collision.gameObject.tag == "FirstMeat"){
            Buns.isUpperBunTouchingTopping = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Topping" || collision.gameObject.tag == "FirstMeat"){
            Buns.isUpperBunTouchingTopping = false;
        }
    }
}
