using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Bool
    public static bool pause;

    void Start()
    {
        pause = true;
    }

    void Update()
    {
        //Detect a touch
        if (Input.touchCount > 0 || Input.GetKeyDown("space")){
            pause = false;
        }

        if(pause){
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
        }
    }
}
