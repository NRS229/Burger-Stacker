using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //Play - pause button
    private Button pauseResumeButton;
    public Sprite pauseSprite;
    public Sprite playSprite;
    //Gameobject
    private GameObject mainMenu;
    private GameObject gameplay;
    private GameObject pauseMenu;
    private GameObject gameOverMenu;


    void Start()
    {
        //Subscribe to events
        GameEvents.current.onStartIntro += displayGameplay;
        GameEvents.current.onPauseGame += displayPauseMenu;
        //Set the GameObjects
        pauseResumeButton = gameObject.transform.Find("Gameplay").gameObject.transform.Find("PlayPause").gameObject.GetComponent<Button>();
        mainMenu = gameObject.transform.Find("MainMenu").gameObject;
        gameplay = gameObject.transform.Find("Gameplay").gameObject;
        pauseMenu = gameObject.transform.Find("PauseMenu").gameObject;
        gameOverMenu = gameObject.transform.Find("GameOverMenu").gameObject;
    }

    private void displayMainMenu(){
        mainMenu.SetActive(true);
        gameplay.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    private void displayGameplay(){
        mainMenu.SetActive(false);
        gameplay.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    private void displayPauseMenu(){
        mainMenu.SetActive(false);
        gameplay.SetActive(false);
        pauseMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }
    
    private void displayGameOverMenu(){
        mainMenu.SetActive(false);
        gameplay.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }

}
