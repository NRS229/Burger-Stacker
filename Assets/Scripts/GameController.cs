using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Bool
    public static bool pause;
    public static bool introStarted;
    public static bool gameStarted;
    public static bool gameOver;
    //Cameras
    public GameObject menuCamera;
    public GameObject gameplayCamera;
    //Instantiation
    float instantiateY = -3.5f;
    private GameObject nextTopping;
    public GameObject newToppingPrefab;
    public Sprite[] toppingSprites;
    //Score
    public static int score = 0;


    void Start()
    {
        //Subscribe to events
        GameEvents.current.onStartGame  += OnStartGame;
        GameEvents.current.onStartIntro += OnStartIntro;
        GameEvents.current.onPauseGame  += OnPauseGame;
        GameEvents.current.onResumeGame += OnResumeGame;
        GameEvents.current.onInstantiateTopping += OnInstantiateTopping;
        GameEvents.current.onGameOver += OnGameOver;
        GameEvents.current.onIncreaseScore += OnIncreaseScore;
        //Initializing bools
        pause = true;
        introStarted = false;
        gameStarted = false;
    }

    void Update()
    {
        if(pause){
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
        }
    }

    private void OnStartGame(){
        if(!gameStarted){
            gameStarted = true;
            changeCamera();
        }else{
            Debug.Log("The game has already started");
        }
    }

    private void OnPauseGame(){
        pause=true;
    }

    private void OnResumeGame(){
        pause=false;
    }

    private void OnStartIntro(){
        introStarted = true;
    }

    private void OnInstantiateTopping(){
        //X and Y
        float instantiateX = Random.Range(3, 8);
        instantiateY +=0.283810716f; //Boxcollider y * Scale y
        //Instantiation
        nextTopping = Instantiate(newToppingPrefab, new Vector2(instantiateX, instantiateY), Quaternion.identity) as GameObject;
        //Randomize the topping sprite
        int nextToppingSpriteRandom = Random.Range(1, 5);
        switch (nextToppingSpriteRandom)
        {
            case 1:
                nextTopping.GetComponent<SpriteRenderer>().sprite = toppingSprites[0];
                nextTopping.name = "Meat";
                break;

            case 2:
                nextTopping.GetComponent<SpriteRenderer>().sprite = toppingSprites[1];
                nextTopping.name = "Cheese";
                break;

            case 3:
                nextTopping.GetComponent<SpriteRenderer>().sprite = toppingSprites[2];
                nextTopping.name = "Lettuce";
                break;

            case 4:
                nextTopping.GetComponent<SpriteRenderer>().sprite = toppingSprites[3];
                nextTopping.name = "Tomato";
                break;
        }
    }

    private void OnGameOver(){
        gameOver = true;
        GameEvents.current.PauseGame();
        if(score > PlayerPrefs.GetInt("Hishscore", 0)){
            //New Highscore
            PlayerPrefs.SetInt("Hishscore", score);
        }
    }

    private void OnIncreaseScore(){
        score += 1;
    }

    private void changeCamera(){
        //Change cameras
        menuCamera.SetActive(!menuCamera.activeSelf);
        gameplayCamera.SetActive(!gameplayCamera.activeSelf);
    }

}
