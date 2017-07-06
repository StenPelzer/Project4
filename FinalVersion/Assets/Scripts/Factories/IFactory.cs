using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory
{
    //interface for the factory
    IEntity Create(string which, Vector3 position);
}

public class DefaultFactory : IFactory
{
    //variables to assign prefabs to
    GameObject enemy;
    GameObject player;
    GameObject projectile;
    GameObject powerup;

    public DefaultFactory(GameObject enemy, GameObject player, GameObject projectile, GameObject powerup)
    {
        this.enemy = enemy;
        this.player = player;
        this.projectile = projectile;
        this.powerup = powerup;
    }

    //Creates the objects and returns them
    public IEntity Create(string which, Vector3 position)
    {
        switch (which)
        {
            case ("player"):
                return GameObject.Instantiate(player, position, Quaternion.identity).GetComponent<Player>();

            case ("enemy"):
                return GameObject.Instantiate(enemy, position, Quaternion.identity).GetComponent<Enemy>();

            case ("projectile"):
                return GameObject.Instantiate(projectile, position, Quaternion.identity).GetComponent<Projectile>();

            case ("powerup"):
                return GameObject.Instantiate(powerup, position, Quaternion.identity).GetComponent<Powerup>();

            default:
                Debug.Log("wrong entry");
                return null;
        }
    }
}