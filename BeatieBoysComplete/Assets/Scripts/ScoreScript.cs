using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public static int scoreValue = 0;
    public static int scoreMultiplier = 1;
    Text score;
    Text lives;

	// Use this for initialization
	void Start ()
    {
        GameObject scoreText = GameObject.Find("ScoreText");
        GameObject livesText = GameObject.Find("LivesText");
        score = scoreText.GetComponent<Text>();
        lives = livesText.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + scoreValue;
        lives.text = "Lives: " + GameController.player_health;
	}

    public static void Add()
    {
        scoreValue += 1 * scoreMultiplier;
    }
}
