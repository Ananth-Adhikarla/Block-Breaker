using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    // config params
    [Range(0.1f, 10f)] [SerializeField]public float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 25;
    [SerializeField] TextMeshProUGUI scoreText = null;
    [SerializeField] public TextMeshProUGUI lifeText = null;
    [SerializeField] bool isAutoPlayEnabled = false;

    // state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] public int currentLife = 5;

    SceneLoader sceneLoader;
    string difficulty;
    bool isDifficultySelected = false;

    [SerializeField] GameObject gameCanvas = null;
    [SerializeField]public GameObject playSpace = null;

    public int mode;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
        lifeText.text = currentLife.ToString();
        sceneLoader = FindObjectOfType<SceneLoader>() ;
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

        if (isDifficultySelected == false)
        {
            SelectDifficulty();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            LevelChanger();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Invoke("GameQuitter", 0.25f);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        sceneLoader.ReloadScene();
    }

    private void GameQuitter()
    {
        playSpace.SetActive(false);
        sceneLoader.GameOver();
    }

    private void LevelChanger()
    {
        if (sceneLoader.GetCurrentScene() == 0 || sceneLoader.GetCurrentScene() == 1 || sceneLoader.GetCurrentScene() == 8)
        {
            return;
        }
        else if (sceneLoader.GetNextScene() == 0 || sceneLoader.GetNextScene() == 1 || sceneLoader.GetNextScene() == 8)
        {
            return;
        }
        else
        {
            sceneLoader.LoadNextScene();
        }
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed + (int)(pointsPerBlockDestroyed * 0.25);
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    private void SelectDifficulty()
    {
        
        difficulty = sceneLoader.GetButtonName();
            
        if (difficulty == "easy")
        {
            isDifficultySelected = true;
            sceneLoader.LoadNextScene();
            mode = 1;
            gameSpeed = 0.85f;
            gameCanvas.SetActive(true);
            playSpace.SetActive(true);
        }
        else if (difficulty == "medium")
        {
            isDifficultySelected = true;
            sceneLoader.LoadNextScene();
            mode = 2;
            gameSpeed = 0.95f;
            gameCanvas.SetActive(true);
            playSpace.SetActive(true);
        }
        else if (difficulty == "hard")
        {
            isDifficultySelected = true;
            sceneLoader.LoadNextScene();
            mode = 3;
            gameSpeed = 1.05f;
            gameCanvas.SetActive(true);
            playSpace.SetActive(true);
        }



    }


}