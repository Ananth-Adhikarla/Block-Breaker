using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    GameSession mySession;
    //Ball myBall;
    public bool isOver = false;
    public bool restartGame = false;

    int lifeCount;
    [SerializeField] GameObject playSpace = null;

    private void Start()
    {
        mySession = GameObject.Find("Game Session").GetComponent<GameSession>();
        //myBall = GameObject.Find("Ball").GetComponent<Ball>();
        lifeCount = mySession.currentLife;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CalculateLife();
        if (isOver)
        {
            mySession.playSpace.SetActive(false);
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            RestartGame();
        }

    }

    private void RestartGame()
    {
        restartGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void CalculateLife()
    {
        if (lifeCount > 0)
        {
            lifeCount--;
            mySession.lifeText.text = lifeCount.ToString();
            //print(lifeCount);
            //print(isOver);
        }
        else
        {
            isOver = true;
            playSpace.SetActive(false);
        }

    }
}
