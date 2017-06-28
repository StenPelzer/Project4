using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject projectile;
    public GameObject enemy;

    public PlayerFactory playerFactory;
    public EnemyFactory enemyFactory;
    public ProjectileFactory projectileFactory;

    public EnemyManager enemyManager;


    Player data;

    // Use this for initialization
    void Start () {

        player = playerFactory.Create(new Vector2(0, -4));

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
        enemyManager.Clean();

        data.Move();
    }
}


