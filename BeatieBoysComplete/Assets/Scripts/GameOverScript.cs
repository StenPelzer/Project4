using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class GameOverScript : MonoBehaviour {

    // Use this for initialization

    void Start () {
        GameObject yourScore = GameObject.Find("YourScoreText");
        Text Score = yourScore.GetComponent<Text>();

        Score.text = "Your score:\n" + ScoreScript.scoreValue;
    }

    public void Save()
    {
        GameObject nickGo = GameObject.Find("NicknameInput");
        InputField nickCo = nickGo.GetComponent<InputField>();

        if(nickCo.text == "")
        {
            nickCo.text = "Anonymous";
        }
           
        ScoreToDatabase(ScoreScript.scoreValue, nickCo.text);
        Application.LoadLevel(0);
    }

    public void ScoreToDatabase(int score, string nickname)
    {
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
        command.CommandText = String.Format("INSERT INTO Highscore VALUES({0}, '{1}')", score, nickname);
        MySqlDataReader reader = command.ExecuteReader();
        
        connection.Close();
    }
}
