using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class HighscoreScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
        GameObject highscores = GameObject.Find("Highscores");
        Text highscoresList = highscores.GetComponent<Text>();

        highscoresList.text = GetHighscores();
    }

    string GetHighscores()
    {
        string scoreList = "";
        MySqlConnection connection;
        connection = new MySqlConnection();
        connection.ConnectionString = "server=185.13.227.163; userid=stenpbm145_beast; password=beast; database=stenpbm145_beastieboys";

        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM `Highscore` ORDER BY Highscore DESC LIMIT 0,10;";

        using (MySqlDataReader reader = command.ExecuteReader())
        {
            int i = 1;
            while (reader.Read())
            {
                scoreList += String.Format(i + ": {0} - {1}\n",reader["Nickname"], reader["Highscore"]);
                i++;
            }
        }

        Debug.Log(scoreList);

        connection.Close();

        return scoreList;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
