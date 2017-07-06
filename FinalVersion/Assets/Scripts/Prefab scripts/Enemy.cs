using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity {

    public float speed;
    public int health;
    public int dropchance = 15;

    void Start()
    {
        //Checks on enemy spawn if there are other settings
        if (GameController.enemy_boost)
        {
            speed *= 2.0f;
        }

        if (GameController.enemy_buff)
        {
            health *= 2;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Checks if the collision is with a projectile
        if (col.gameObject.name == "Projectile(Clone)")
        {
            ScoreScript.Add();
            health--;
            col.gameObject.GetComponent<Projectile>().onDeath();
            if (health == 0)
            {
                onDeath();
            }
        }
    }

    public void onDeath()
    {
        //Randomly generates a pickup and destroys the enemy on death
        int rng = UnityEngine.Random.Range(1, 100);
        if(rng < dropchance)
        {
            EntityManager.Entity_iterator.Add(GameController.factory.Create("powerup", transform.position));
        }
        EntityManager.Entity_iterator.Remove(this);
        Destroy(gameObject);
    }

    public Transform getTransform()
    {
        //returns the transform
        return this.gameObject.transform;
    }

    public void Visit(IEntityVisitor visitor)
    {
        //calls the visitor
        visitor.onEnemy(this);
    }

    public int getHealth()
    {
        //returns the health
        throw new NotImplementedException();
    }

    public float getSpeed()
    {
        //returns the speed
        return speed;
    }

    public void setSpeed(float speed)
    {
        //sets the speed
        this.speed = speed;
    }

    public void setHealth(int health)
    {
        //sets the health
        this.health = health;
    }
}
