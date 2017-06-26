using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject projectile;
    public GameObject enemy;
    Player data;

    // Use this for initialization
    void Start () {
        player = Instantiate(player, new Vector3(0, -4, 0), Quaternion.identity);

        data = player.GetComponent<Player>();
        int rng = Random.Range(1, 3);
        print(rng);
        for (int i = 0; i < rng; i++)
        {
            Instantiate(enemy, new Vector2(Random.Range(-5,5), 5), Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
        {
            Vector3 projectile_spawn = player.transform.position;
            projectile_spawn.y += 0.5f;
            Instantiate(projectile, projectile_spawn, Quaternion.identity);
        }


        data.Move();
        
    }
}


