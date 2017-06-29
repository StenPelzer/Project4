using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour {


    public void PlayGame()
    {
        Application.LoadLevel(1);
    }

    public void Highscores()
    {
        Application.LoadLevel(3);
        Debug.Log("Button highscores clicked");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        Application.UnloadLevel(1);
        Application.LoadLevel(0);
    }
}
