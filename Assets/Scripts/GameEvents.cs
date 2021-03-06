﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake(){
        current = this;
    }

    //Event onClick
    public event Action onClick;
    public void Click(){
        if(onClick != null){
            onClick();
        }
    }

    //Event onStartGame
    public event Action onStartGame;
    public void StartGame(){
        if(onStartGame != null){
            onStartGame();
        }
    }

    //Event onStartIntro
    public event Action onStartIntro;
    public void StartIntro(){
        if(onStartIntro != null){
            onStartIntro();
        }
    }

    //Event onInstantiateTopping
    public event Action onInstantiateTopping;
    public void InstantiateTopping(){
        if(onInstantiateTopping != null){
            onInstantiateTopping();
        }
    }

    //Event onGameOver
    public event Action onGameOver;
    public void GameOver(){
        if(onGameOver != null){
            onGameOver();
        }
    }

    //Event onIncreaseScore
    public event Action onIncreaseScore;
    public void IncreaseScore(){
        if(onIncreaseScore != null){
            onIncreaseScore();
        }
    }

    //Event onNewHighscore
    public event Action<int> onNewHighscore;
    public void NewHighscore(int number){
        if(onNewHighscore != null){
            onNewHighscore(number);
        }
    }

    //Event onGoToMenu
    public event Action onGoToMenu;
    public void GoToMenu(){
        if(onGoToMenu != null){
            onGoToMenu();
        }
    }

    //Event onPlayAgain
    public event Action onPlayAgain;
    public void PlayAgain(){
        if(onPlayAgain != null){
            onPlayAgain();
        }
    }

    //Event onPlayAgainSetup
    public event Action onPlayAgainSetup;
    public void PlayAgainSetup(){
        if(onPlayAgainSetup != null){
            onPlayAgainSetup();
        }
    }

}
