using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupFactory : MonoBehaviour, IFactory
{
    public GameObject powerup;

    public GameObject Create(Vector2 position)
    {
        GameObject powerup_object = Instantiate(powerup, position, Quaternion.identity);
        return powerup_object;
    }
}
