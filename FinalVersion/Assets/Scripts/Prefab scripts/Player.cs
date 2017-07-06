using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEntity {

    public float speed;
    bool powerup = false;
    float powerup_start;
    float powerup_duration;

    public void onDeath()
    {
        EntityManager.Entity_iterator.Remove(this);
        EntityManager.nextWaveTime = 0;
        GameController.enemy_boost = false;
        GameController.enemy_buff = false;
        GameController.instant_death = false;
        Application.LoadLevel(2);
        Debug.Log("The game has ended.");
    }

    public void powerupCheck()
    {
        if (powerup)
        {
            if (Time.time >= powerup_start + powerup_duration)
            {
                powerup = false;
                ScoreScript.scoreMultiplier = 1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Enemy(Clone)")
        {
            this.onDeath();
        }
        if (other.gameObject.name == "Powerup(Clone)")
        {
            powerup = true;
            ScoreScript.scoreMultiplier *= 3;
            powerup_start = Time.time;
            powerup_duration = 5;
            other.GetComponent<Powerup>().onDeath();
        }
    }

    public void Visit(IEntityVisitor visitor)
    {
        visitor.onPlayer(this);
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
        GameController.player_health = health;
    }
}