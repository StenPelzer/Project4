using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{
    public GameObject enemy;

    public GameObject Create(Vector2 position)
    {
        GameObject enemy_object = GameObject.Instantiate(enemy, position, Quaternion.identity);
        return enemy_object;
    }
}
