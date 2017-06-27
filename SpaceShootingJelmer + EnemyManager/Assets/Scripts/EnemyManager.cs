using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private double nextWaveTime = 0;
    private double wavePeriod = 1;

    List<GameObject> list = new List<GameObject>();

    public void SpawnWave(EnemyFactory enemyFactory)
    {

        if (Time.time > nextWaveTime)
        {
            nextWaveTime += wavePeriod;
            int rng = Random.Range(1, 3);
            for (int i = 0; i < rng; i++)
            {
                //list.Add(enemyFactory.Create(new Vector2(Random.Range(-5, 5), 5))); //PC
                list.Add(enemyFactory.Create(new Vector2(Random.Range(-2, 3), 5))); //Android
            }
            if (wavePeriod > 0.3)
            {
                wavePeriod -= 0.01;

            }
        }
    }

    
}
