using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : MonoBehaviour, IFactory
{
    public GameObject projectile;

    public GameObject Create(Vector2 position)
    {
        GameObject projectile_object = GameObject.Instantiate(projectile, position, Quaternion.identity);
        return projectile_object;
    }
}
