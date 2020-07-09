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
    private GameObject gameOver_NoHighscore;
    private GameObject gameOver_Highscore;
    //Score
    public Text scoreTextGameplay;
    public Text scoreTextPause;
    public Text scoreTextGameOver;
    public Text highScoreTextMainMenu;
    public Text highScoreTextGameOver;

    void Start()
    {
        //Subscribe to events
        GameEvents.current.onStartIntro += displayGameplay;
        GameEvents.current.onGameOver += displayGameOverMenu;
        GameEvents.current.onNewHighscore+= OnNewHighscore;
        GameEvents.current.onPlayAgainSetup += displayGameplay;
        //Set the GameObjects
        mainMenu = gameObject.transform.Find("MainMenu").gameObject;
        gameplay = gameObject.transform.Find("Gameplay").gameObject;
        pauseMenu = gameObject.transform.Find("PauseMenu").gameObject;
        gameOverMenu = gameObject.transform.Find("GameOverMenu").gameObject;
        gameOver_NoHighscore = gameOverMenu.transform.Find("NoNewHighscore").gameObject;
        gameOver_Highscore = gameOverMenu.transform.Find("NewHighscore").gameObject;
        //Set the highscore
        highScoreTextMainMenu.text = PlayerPrefs.GetInt("Hishscore", 0).ToString();
    }

    void Update(){
        scoreTextGameplay.text = GameController.score.ToString();
        scoreTextPause.text = GameController.score.ToString();
        scoreTextGameOver.text = GameController.score.ToString();
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
        logo.SetActive(false);
        mainMenu.SetActive(false);
        gameplay.SetActive(false);
        pauseMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }
    
    private void displayGameOverMenu(){
        //Pause the game first
        GameController.pause = true;
        logo.SetActive(false);
        mainMenu.SetActive(false);
        gameplay.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        gameOver_NoHighscore.SetActive(true);
        gameOver_Highscore.SetActive(false);
    }

    private void OnNewHighscore(int number){
        //Update the highscore
        highScoreTextGameOver.text = PlayerPrefs.GetInt("Hishscore", 0).ToString();
        highScoreTextMainMenu.text = PlayerPrefs.GetInt("Hishscore", 0).ToString();
        //Show the new highscore UI
        gameOver_NoHighscore.SetActive(false);
        gameOver_Highscore.SetActive(true);
    }

    public void playBtn(){
        if(!GameController.gameOver){
            GameController.pause = false;
            displayGameplay();
        }
    }

    public void pauseBtn(){
        GameController.pause = true;
        displayPauseMenu();
    }

    public void playAgainBtn(){
        GameEvents.current.PlayAgain();
    }

    public void menuBtn(){
        GameEvents.current.GoToMenu();
    }

    public void resetHighscoreBtn(){
        PlayerPrefs.DeleteKey("Hishscore");
        highScoreTextGameOver.text = PlayerPrefs.GetInt("Hishscore", 0).ToString();
        highScoreTextMainMenu.text = PlayerPrefs.GetInt("Hishscore", 0).ToString();
    }

    public void clickAnywhereImage(){
        GameEvents.current.Click();
    }

}
