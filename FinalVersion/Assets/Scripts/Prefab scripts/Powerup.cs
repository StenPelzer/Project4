using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour, IEntity
{
    public float speed;

    public void Visit(IEntityVisitor visitor)
    {
        visitor.onPowerup(this);
    }

    public Transform getTransform()
    {
        return this.gameObject.transform;
    }

    public int getHealth()
    {
        throw new NotImplementedException();
    }

    public float getSpeed()
    {
        return speed;
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public void setHealth(int health)
    {
    }

    public void onDeath()
    {
        EntityManager.Entity_iterator.Remove(this);
        Destroy(this.gameObject);
    }
}
