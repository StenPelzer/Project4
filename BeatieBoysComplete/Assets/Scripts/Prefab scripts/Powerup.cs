using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float speed = 0.02f;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= speed;
        transform.position = pos;
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
