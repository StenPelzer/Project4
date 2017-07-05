using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityVisitor
{
    void onPlayer(IEntity player);
    void onEnemy(IEntity enemy);
    void onProjectile(IEntity projectile);
    void onPowerup(IEntity powerup);
}

public interface IEntity
{
    void Visit(IEntityVisitor visitor);
    Transform getTransform();
    int getHealth();
    void setHealth(int health);
    float getSpeed();
    void setSpeed(float speed);
    void onDeath();
}

public class MoveVisitor : MonoBehaviour, IEntityVisitor
{
    public static Vector3 playerposglobal;
    public bool timerOn = false;

    public void onEnemy(IEntity enemy)
    {
        enemy.getTransform().Translate(new Vector3(0, -enemy.getSpeed(), 0) * Time.deltaTime);
        if (enemy.getTransform().position.y < -5.5)
        {
            GameController.player_health--;
            enemy.onDeath();
        }
    }

    public void onPlayer(IEntity player)
    {
        //returns a float from -1.0 to 1.0
        Input.GetAxis("Horizontal"); //PC
        player.getTransform().Translate(new Vector3(Input.acceleration.x * player.getSpeed() * 2, 0 , 0) * Time.deltaTime); 
        player.getTransform().Translate(new Vector3(Input.GetAxis("Horizontal") * player.getSpeed(), 0, 0) * Time.deltaTime);     //PC

        if(player.getTransform().position.x < -2.2)
        {
            player.getTransform().Translate(new Vector3(-Input.acceleration.x *2*  player.getSpeed(), 0, 0) * Time.deltaTime);
            player.getTransform().Translate(new Vector3(-Input.GetAxis("Horizontal") * player.getSpeed(), 0, 0) * Time.deltaTime);
        }
        else if(player.getTransform().position.x > 2.2)
        {
            player.getTransform().Translate(new Vector3(-Input.acceleration.x * 2 *player.getSpeed(), 0, 0) * Time.deltaTime);
            player.getTransform().Translate(new Vector3(-Input.GetAxis("Horizontal") * player.getSpeed(), 0, 0) * Time.deltaTime);
        }
        
        playerposglobal = player.getTransform().position;
        
    }


    IEnumerator TapTimer()
    {
        yield return new WaitForSeconds(0.07f);
        timerOn = false;

    }

    public void onPowerup(IEntity powerup)
    {
        powerup.getTransform().Translate(new Vector3(0, -powerup.getSpeed(), 0) * Time.deltaTime);
        if (powerup.getTransform().position.y < -5.5)
        {
            powerup.onDeath();
        }
    }

    public void onProjectile(IEntity projectile)
    {
        projectile.getTransform().Translate(new Vector3(0, projectile.getSpeed(), 0) * Time.deltaTime);
        if (projectile.getTransform().position.y > 5.5)
        {
            projectile.onDeath();
        }
    }
    
}
