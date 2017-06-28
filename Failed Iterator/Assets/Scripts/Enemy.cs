using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    public int health;



    // Use this for initialization
    void Start()
    {
        health = 3;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
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
        ScoreScript.scoreValue += 1;
        health--;
    }

    public void healthCheck()
    {
        if(health == 0)
        {
            Destroy(gameObject);
            EnemyManager.enemyAmount--;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        EnemyManager.enemyAmount--;
    }
}
