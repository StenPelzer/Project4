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
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
        {
            Vector3 projectile_spawn = player.transform.position;
            projectile_spawn.y += 0.5f;
            Instantiate(projectile, projectile_spawn, Quaternion.identity);
        }

        if (Input.GetKeyDown("return"))
        {
            Instantiate(enemy, new Vector3(0, 5, 0), Quaternion.identity);
        }
        data.Move();
        
    }
}
