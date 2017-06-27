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

    Player data;

    // Use this for initialization
    void Start () {

        player = playerFactory.Create(new Vector2(0, -4));

        data = player.GetComponent<Player>();
        int rng = Random.Range(1, 3);
        for (int i = 0; i < rng; i++)
        {
            enemyFactory.Create(new Vector2(Random.Range(-5, 5), 5));
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
        {
            Vector3 projectile_spawn = player.transform.position;
            projectile_spawn.y += 0.5f;
            projectileFactory.Create(projectile_spawn);
        }


        data.Move();
        
    }
}


