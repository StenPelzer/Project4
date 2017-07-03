using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {

    int nextWaveTime = 1;
    int wavePeriod = 1;

    public static Iterator Entity_iterator = new DefaultIterator();

    public IEntityVisitor visitor = new MoveVisitor();

    void Start()
    {
    }

    public void SpawnWave()
    {
        if (Time.time > nextWaveTime)
        {
            nextWaveTime += wavePeriod;
            int rng = Random.Range(1, 3);
            for (int i = 0; i < rng; i++)
            {
                Entity_iterator.Add(GameController.factory.Create("enemy", new Vector3(Random.Range(-5, 5), 5, 0)));
            }
        }
    }

    public void checkHealth()
    {
        while (Entity_iterator.HasNext())
        {
            IEntity enemy_obj = Entity_iterator.GetNext();
            if(enemy_obj.getHealth() <= 0)
            {
                
            }
        }
    }

    public void Move()
    {
        while (Entity_iterator.HasNext())
        {
            IEntity enemy_obj = Entity_iterator.GetNext();
            enemy_obj.Visit(visitor);
        }
        Entity_iterator.Reset();
    }
    
}
