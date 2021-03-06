﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;
    public GameObject projectile;
    public GameObject powerup;

    public static IFactory factory;

    public EntityManager entityManager;

    Player player_data;

    public static int player_health = 3;

    public static bool instant_death = false;
    public static bool enemy_boost = false;
    public static bool enemy_buff = false;

    // Use this for initialization
    void Start ()
    {
        EntityManager.nextWaveTime = 0;
        factory = new DefaultFactory(enemy, player, projectile, powerup);

        ScoreScript.scoreValue = 0;

        EntityManager.Entity_iterator.Add(factory.Create("player", new Vector3(0, -4, 0)));

        player_health = 3;
        if (GameController.instant_death)
        {
            player_health = 1;
        }
        player_data = player.GetComponent<Player>();
        
        entityManager.SpawnWave();
    }

    // Update is called once per frame
    void Update () {

        if (player_health <= 0)
        {
            player_data.onDeath();
        }
        
        entityManager.SpawnWave();
        entityManager.Move();

        player_data.powerupCheck();
    }
}


