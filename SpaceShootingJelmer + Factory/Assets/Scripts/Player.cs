﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 20.5f;
    public GameObject bullet;
    public int health = 3;

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
    
}