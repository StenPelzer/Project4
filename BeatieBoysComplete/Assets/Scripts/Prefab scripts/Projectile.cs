using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

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
	void Update () {
        Vector3 pos = transform.position;
        pos.y += speed;
        transform.position = pos;
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Enemy(Clone)")
        {
            Destroy(gameObject);
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
