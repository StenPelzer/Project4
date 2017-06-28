using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private int nextWaveTime = 0;
    private int wavePeriod = 1;

    List<GameObject> list = new List<GameObject>();

    public void SpawnWave(EnemyFactory enemyFactory)
    {

        if (Time.time > nextWaveTime)
        {
            nextWaveTime += wavePeriod;
            int rng = Random.Range(1, 3);
            for (int i = 0; i < rng; i++)
            {
                list.Add(enemyFactory.Create(new Vector2(Random.Range(-5, 5), 5)));
            }
        }
    }

    
}
