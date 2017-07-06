using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;
    public GameObject projectile;
    public GameObject powerup;

    public bool timerOn = false;

    public static IFactory factory;

    public EntityManager entityManager;

    Player player_data;

    public static int player_health = 3;

    public static bool instant_death = false;
    public static bool enemy_boost = false;
    public static bool enemy_buff = false;

    void Start ()
    {
        //resets the timer for waves
        EntityManager.nextWaveTime = 0;
        //creates a new factory
        factory = new DefaultFactory(enemy, player, projectile, powerup);

        //sets the score to 0
        ScoreScript.scoreValue = 0;

        //adds a player to the game+entity list
        EntityManager.Entity_iterator.Add(factory.Create("player", new Vector3(0, -4, 0)));

        //sets player health according to game settings
        player_health = 3;
        if (GameController.instant_death)
        {
            player_health = 1;
        }
        //gets the player script so methods can be called
        player_data = player.GetComponent<Player>();
        
        //spawns the first wave
        entityManager.SpawnWave();
    }

    // Update is called once per frame
    void Update () {

        //calls the death command on the player if the player health is lower than 0
        if (player_health <= 0)
        {
            player_data.onDeath();
        }
        
        //calls the spawn wave command 
        entityManager.SpawnWave();
        //moves all entities in the list
        entityManager.Move();

        //calls the powerup check command
        player_data.powerupCheck();

        //checks for input and spawns a projectile if there is input
        if (Input.GetKeyDown("space") || Input.touchCount > 0 && !timerOn)
        {
            Vector3 projectile_spawn = MoveVisitor.playerposglobal;
            projectile_spawn.y += 0.5f;
            EntityManager.Entity_iterator.Add(GameController.factory.Create("projectile", projectile_spawn));
            timerOn = true;
            StartCoroutine(TapTimer());
        }
    }

    IEnumerator TapTimer()
    {
        //checks screen tapping on android
        yield return new WaitForSeconds(0.05f);
        timerOn = false;
    }
}


