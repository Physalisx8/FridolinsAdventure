using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //Loads next Level -> with SceneManager (auch LevelName oder Index)
        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
