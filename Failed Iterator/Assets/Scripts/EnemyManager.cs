using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static int enemyAmount = 0;
    private int nextWaveTime = 0;
    private int wavePeriod = 1;

    CustomList<GameObject> list = new CustomList<GameObject>();

    public void SpawnWave(EnemyFactory enemyFactory)
    {

        if (Time.time > nextWaveTime)
        {
            nextWaveTime += wavePeriod;
            int rng = Random.Range(1, 3);
            for (int i = 0; i < rng; i++)
            {
                list.Add(enemyFactory.Create(new Vector2(Random.Range(-5, 5), 5)));
                enemyAmount++;
            }
        }
    }

    public void Clean()
    {
        list.ResetMax();
        int count = 0;
        while(list.GetPrevious().Visit(() => false, _ => true))
        {
            // list.GetCurrent().Visit(() => { }, item => { });
            count++;
        }
        Debug.Log(count);
    }
    
}
