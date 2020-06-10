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
            //Increase score
            GameEvents.current.IncreaseScore();
            //Become part of burger
            gameObject.transform.SetParent(GameObject.Find("Burger").transform);
            partOfBurger = true;
            //Unfreeze y position
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            //Instantiate topping
            GameEvents.current.InstantiateTopping();
        }
    }

}
