using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneLoader : MonoBehaviour
{
    string choice;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(GetCurrentScene());
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CheckButton()
    {
        choice = EventSystem.current.currentSelectedGameObject.name;
        //print(EventSystem.current.currentSelectedGameObject.name);
    }

    public string GetButtonName()
    {
        return choice;
    }

    public int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public int GetNextScene()
    {
        return SceneManager.GetActiveScene().buildIndex + 1;
    }
}