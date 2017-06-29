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
            gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
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
        Destroy(gameObject);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
