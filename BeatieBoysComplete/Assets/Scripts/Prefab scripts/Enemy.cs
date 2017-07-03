using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity {

    public float speed;
    public int health;
    public int dropchance = 15;

    // Use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
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
        return this.gameObject.transform;
    }

    public void Visit(IEntityVisitor visitor)
    {
        visitor.onEnemy(this);
    }

    public int getHealth()
    {
        throw new NotImplementedException();
    }
    
    public float getSpeed()
    {
        return speed;
    }
}
