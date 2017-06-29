using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float speed = 0.02f;

    // Use this for initialization
    void Start()
    {
        speed = 0.02f;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        speed += Random.Range(0.001f, 0.002f);
        pos.y -= speed;
        transform.position = pos;
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
