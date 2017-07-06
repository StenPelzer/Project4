using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour, IEntity
{
    public float speed;

    public void Visit(IEntityVisitor visitor)
    {
        //calls the move command
        visitor.onPowerup(this);
    }

    public Transform getTransform()
    {
        //returns the transform
        return this.gameObject.transform;
    }

    public int getHealth()
    {
        //throws an error because powerup has no health
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
        //throws an error because powerup has no health
        throw new NotImplementedException();
    }

    public void onDeath()
    {
        //destroys the object and removes it from the list with entities
        EntityManager.Entity_iterator.Remove(this);
        Destroy(this.gameObject);
    }
}
