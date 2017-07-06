using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {
    

    void Start () {
        //creates a text to display the score
        GameObject yourScore = GameObject.Find("YourScoreText");
        Text Score = yourScore.GetComponent<Text>();

        Score.text = "Your score:\n" + ScoreScript.scoreValue;
    }

    public void Save()
    {
        //gets the score and name, then calls the database input command
        GameObject nickGo = GameObject.Find("NicknameInput");
        InputField nickCo = nickGo.GetComponent<InputField>();

        if(nickCo.text == "")
        {
            nickCo.text = "Anonymous";
        }
        
        StartCoroutine(ScoreToDatabase(ScoreScript.scoreValue, nickCo.text));
    }

    IEnumerator ScoreToDatabase(int score, string nickname)
    {
        //puts the data into the database, then loads the highscore scene
        string webadress = "http://unrehearsed-rowboat.000webhostapp.com/addscore2.php?&score=" + score + "&name=" + WWW.EscapeURL(nickname);
        print(webadress);
        WWW website = new WWW(webadress);
    
        print(website.isDone);
        yield return website;
        print(website.isDone);
        Application.LoadLevel(4);
        //Hoe de link er uit moet zien http://unrehearsed-rowboat.000webhostapp.com/addscore.php?&score=900000000&name=Rubenjeboi

    }
}
