using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {
    
    public void PlayGame()
    {
        //Loads the game scene
        EntityManager.Entity_iterator = new DefaultIterator();
        Application.LoadLevel(1);
    }

    public void Highscores()
    {
        //Loads the highscore scene
        Application.LoadLevel(4);
    }

    public void ExitGame()
    {
        // Exit the game
        Application.Quit();
    }

    public void MainMenu()
    {
        //Loads the main menu
        Application.LoadLevel(0);
    }

    public void Settingsmenu()
    {
        //Loads the settings menu
        Application.LoadLevel(3);
    }
}
