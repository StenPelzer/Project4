using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    public int health;
    public int dropchance = 1;
    
    public Powerup powerup;
    public PowerupFactory powerupFactory;

    // Use this for initialization
    void Start()
    {
        this.health = 3;
        //gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= speed;
        transform.position = pos;
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
        int rng = Random.Range(0, 100);
        if(rng < dropchance)
        {
            powerupFactory.Create(transform.position);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
