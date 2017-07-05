using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreScript : MonoBehaviour {
    string scoreList;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(GetScores());
    }
    
    IEnumerator GetScores()
    {
        scoreList = "Loading..";
        SetField(scoreList);
        WWW hs_get = new WWW("http://unrehearsed-rowboat.000webhostapp.com/display.php");
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            Debug.Log(hs_get.text.ToString());
            scoreList = hs_get.text.ToString(); // this is a GUIText that will display the scores in game.
            SetField(scoreList);
        }
    }

    void SetField(string scoreList)
    {
        GameObject highscores = GameObject.Find("Highscores");
        Text highscoresList = highscores.GetComponent<Text>();
        highscoresList.text = scoreList;
    }
}
