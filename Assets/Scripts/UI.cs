using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //Gameobject
    public GameObject logo;
    private GameObject mainMenu;
    private GameObject gameplay;
    private GameObject pauseMenu;
    private GameObject gameOverMenu;
    //Score
    public Text scoreTextGameplay;
    public Text scoreTextPause;
    public Text highScoreText;


    void Start()
    {
        //Subscribe to events
        GameEvents.current.onStartIntro += displayGameplay;
        GameEvents.current.onPauseGame += displayPauseMenu;
        GameEvents.current.onResumeGame += displayGameplay;
        GameEvents.current.onGameOver += displayGameOverMenu;
        //Set the GameObjects
        mainMenu = gameObject.transform.Find("MainMenu").gameObject;
        gameplay = gameObject.transform.Find("Gameplay").gameObject;
        pauseMenu = gameObject.transform.Find("PauseMenu").gameObject;
        gameOverMenu = gameObject.transform.Find("GameOverMenu").gameObject;
        //Set the highscore
        highScoreText.text = PlayerPrefs.GetInt("Hishscore", 0).ToString();
    }

    void Update(){
        scoreTextGameplay.text = GameController.score.ToString();
        scoreTextPause.text = GameController.score.ToString();
    }

    private void displayMainMenu(){
        logo.SetActive(true);
        mainMenu.SetActive(true);
        gameplay.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    private void displayGameplay(){
        logo.SetActive(false);
        mainMenu.SetActive(false);
        gameplay.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    private void displayPauseMenu(){
        if(!GameController.gameOver){
            logo.SetActive(false);
            mainMenu.SetActive(false);
            gameplay.SetActive(false);
            pauseMenu.SetActive(true);
            gameOverMenu.SetActive(false);
        }
    }
    
    private void displayGameOverMenu(){
        logo.SetActive(false);
        mainMenu.SetActive(false);
        gameplay.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void playBtn(){
        if(!GameController.gameOver){
            GameEvents.current.ResumeGame();
        }
    }

    public void pauseBtn(){
        GameEvents.current.PauseGame();
    }

    public void clickAnywhereImage(){
        GameEvents.current.Click();
    }

}
