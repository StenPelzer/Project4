using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    public int health;
    public int dropchance = 15;
    
    public PowerupFactory powerupFactory;

    // Use this for initialization
    void Start()
    {
        this.health = 3;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= speed;
        transform.position = pos;

        if(pos.y < -5.5)
        {
            Destroy(gameObject);
            GameController.player_health--;
            Debug.Log(GameController.player_health);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Projectile(Clone)")
        {
            ScoreScript.Add();
            health--;
            if(health == 0)
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
            powerupFactory.Create(transform.position);
        }
        Destroy(gameObject);
    }
}
