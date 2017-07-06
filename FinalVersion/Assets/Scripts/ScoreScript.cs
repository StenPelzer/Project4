using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public static int scoreValue = 0;
    public static int scoreMultiplier = 1;
    Text score;
    Text lives;
    
	void Start ()
    {
        //sets the text on the screen for score and lives
        GameObject scoreText = GameObject.Find("ScoreText");
        GameObject livesText = GameObject.Find("LivesText");
        score = scoreText.GetComponent<Text>();
        lives = livesText.GetComponent<Text>();
	}
	
	void Update () {
        //adds the score and health values to the screen
        score.text = "Score: " + scoreValue;
        lives.text = "Lives: " + GameController.player_health;
	}

    public static void Add()
    {
        //adds score
        scoreValue += 1 * scoreMultiplier;
    }
}
