using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settingsmenu : MonoBehaviour
{

    // Use this for initialization
    public void EnemySpeed()
    {
        //sets the enemy boost check to true
        GameController.enemy_boost = true;
    }

    public void EnemyHealth()
    {
        //sets the increased enemy health check to true
        GameController.enemy_buff = true;
    }

    public void InstantHealth()
    {
        //sets the player health check to true
        GameController.instant_death = true;
    }
}
