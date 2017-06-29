using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 20.5f;
    bool powerup = false;
    float powerup_start;
    float powerup_duration;

    public void Move()
    {
        //returns a float from -1.0 to 1.0
        Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + 0.5f > widthOrtho)
        {
            pos.x = widthOrtho - 0.5f;
        }
        if (pos.x - 0.5f < -widthOrtho)
        {
            pos.x = -widthOrtho + 0.5f;
        }
        
        transform.position = pos;
    }

    public void SelfDestruct()
    {
        Destroy(this);
        Application.LoadLevel(2);
        Debug.Log("The game has ended.");
    }

    public void powerupCheck()
    {
        if (powerup)
        {
            if (Time.time >= powerup_start + powerup_duration)
            {
                powerup = false;
                ScoreScript.scoreMultiplier = 1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Enemy(Clone)")
        {
            this.SelfDestruct();
        }
        if (other.gameObject.name == "Powerup(Clone)")
        {
            Destroy(other.gameObject);
            powerup = true;
            ScoreScript.scoreMultiplier *= 20;
            powerup_start = Time.time;
            powerup_duration = 5;
        }
    }
}