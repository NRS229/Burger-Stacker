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

    //Event onDisableUI
    public event Action onDisableUI;
    public void DisableUI(){
        if(onDisableUI != null){
            onDisableUI();
        }
    }

    //Event onEnableUI
    public event Action onEnableUI;
    public void EnableUI(){
        if(onEnableUI != null){
            onEnableUI();
        }
    }

    //Event onPauseGame
    public event Action onPauseGame;
    public void PauseGame(){
        if(onPauseGame != null){
            onPauseGame();
        }
    }

    //Event onResumeGame
    public event Action onResumeGame;
    public void ResumeGame(){
        if(onResumeGame != null){
            onResumeGame();
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

}
