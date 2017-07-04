using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IEntity {

    public float speed;

    // Use this for initialization
    void Start ()
    {
        if(ScoreScript.scoreMultiplier > 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2));
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void Visit(IEntityVisitor visitor)
    {
        visitor.onProjectile(this);
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
