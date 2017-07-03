using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour {
    
    public void PlayGame()
    {
        EntityManager.Entity_iterator = new DefaultIterator();
        Application.LoadLevel(1);
    }

    public void Highscores()
    {
        Application.LoadLevel(3);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
}
