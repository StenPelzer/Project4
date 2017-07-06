using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IEntity {

    public float speed;


    void Start ()
    {
        //changes the color of the sprite if the score is multiplied
        if(ScoreScript.scoreMultiplier > 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2));
        }
    }

    public void Visit(IEntityVisitor visitor)
    {
        //calls the move command
        visitor.onProjectile(this);
    }

    public Transform getTransform()
    {
        //returns the transform
        return this.gameObject.transform;
    }

    public int getHealth()
    {
        //throws exception because projectile has no health
        throw new Exception("projectile doesn't have health");
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
        //throws exception because projectile has no health
        throw new Exception("projectile doesn't have health");
    }

    public void onDeath()
    {
        //destroys the object and removes it from the list with entities
        EntityManager.Entity_iterator.Remove(this);
        Destroy(this.gameObject);
    }
}
