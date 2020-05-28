using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topping : MonoBehaviour
{
    public float speed;
    bool partOfBurger;

    //FixedUpdate is for applying physics
    void FixedUpdate()
    {
        if(GameController.gameStarted){
            if(!partOfBurger){
                transform.Translate(-speed/500, 0, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bun" & !partOfBurger)
        {
            //Become part of burger
            gameObject.transform.SetParent(GameObject.Find("Burger").transform);
            partOfBurger = true;
            //Add Rigidbody
            gameObject.AddComponent<Rigidbody2D>();
            //Instantiate topping
            GameEvents.current.InstantiateTopping();
        }
    }

}
