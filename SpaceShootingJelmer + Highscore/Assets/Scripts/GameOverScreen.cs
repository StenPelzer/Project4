using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class GameOverScreen : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}

    public void Save()
    {
        GameObject nickGo = GameObject.Find("NicknameInput");
        InputField nickCo = nickGo.GetComponent<InputField>();
        Debug.Log(nickCo.text);

        ScoreToDatabase(193, nickCo.text);
        
        Application.LoadLevel(1);
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

        Debug.Log("test");

        connection.Close();
    }
    
	
	// Update is called once per frame
	void Update () {
		
	}
}