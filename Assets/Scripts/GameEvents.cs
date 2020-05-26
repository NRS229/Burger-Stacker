using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake(){
        current = this;
    }

    //Event onStartGame
    public event Action onStartGame;
    public void StartGame(){
        if(onStartGame != null){
            onStartGame();
        }
    }

}
