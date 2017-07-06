using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settingsmenu : MonoBehaviour
{

    // Use this for initialization
    public void EnemySpeed()
    {

        GameController.enemy_boost = true;
    }

    public void EnemyHealth()
    {
        GameController.enemy_buff = true;
    }

    public void InstantHealth()
    {
        GameController.instant_death = true;
    }
}
