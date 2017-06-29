using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject projectile;
    public GameObject enemy;
    public GameObject powerup;

    public PlayerFactory playerFactory;
    public EnemyFactory enemyFactory;
    public ProjectileFactory projectileFactory;
    public PowerupFactory powerupFactory;

    public EnemyManager enemyManager;


    Player data;

    // Use this for initialization
    void Start ()
    {
        ScoreScript.scoreValue = 0;

        player = playerFactory.Create(new Vector2(0, -4));
        powerupFactory.Create(new Vector2(0, 0));

        data = player.GetComponent<Player>();

        enemyManager.SpawnWave(enemyFactory);
    }

    

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
        {
            Vector3 projectile_spawn = player.transform.position;
            projectile_spawn.y += 0.5f;
            projectileFactory.Create(projectile_spawn);
        }

        enemyManager.SpawnWave(enemyFactory);

        data.powerupCheck();

        data.Move();
    }
}


