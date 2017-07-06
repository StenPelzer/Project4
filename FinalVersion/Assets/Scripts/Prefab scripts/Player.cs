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
        //removes all buffs and debuffs, then loads the gameover scene
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
        //checks if the powerup time is over and resets the score multiplier
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
        //check if the colliding object is an enemy, if so calls death on the player
        if(other.gameObject.name == "Enemy(Clone)")
        {
            this.onDeath();
        }
        //check if the colliding object is a powerup, if so multipies the score and sets the powerup duration
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
        //calls the move command
        visitor.onPlayer(this);
    }

    public Transform getTransform()
    {
        //returns the transform of the object
        return this.gameObject.transform;
    }

    public int getHealth()
    {
        //gets the health
        return GameController.player_health;
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
        GameController.player_health = health;
    }
}