using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {
    
    public void PlayGame()
    {
        EntityManager.Entity_iterator = new DefaultIterator();
        Application.LoadLevel(1);
    }

    public void Highscores()
    {
        Application.LoadLevel(4);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    public void Settingsmenu()
    {
        Application.LoadLevel(3);
    }
}
