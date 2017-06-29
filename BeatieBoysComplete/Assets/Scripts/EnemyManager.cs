using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private int nextWaveTime = 0;
    private int wavePeriod = 1;

    public void SpawnWave(EnemyFactory enemyFactory)
    {

        if (Time.time > nextWaveTime)
        {
            nextWaveTime += wavePeriod;
            int rng = Random.Range(1, 3);
            for (int i = 0; i < rng; i++)
            {
                enemyFactory.Create(new Vector2(Random.Range(-5, 5), 5));
            }
        }
    } 
}
