using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {

    public static int nextWaveTime;
    public int wavePeriod;

    //creates a new iterator
    public static Iterator Entity_iterator = new DefaultIterator();

    //creates a new visitor
    public IEntityVisitor visitor = new MoveVisitor();

    public void SpawnWave()
    {
        //spawns a wave if enough time has passed
        if (Time.timeSinceLevelLoad > nextWaveTime)
        {
            nextWaveTime += wavePeriod;
            int rng = Random.Range(1, 4);
            //creates a random amount of enemies between 1 and 3
            for (int i = 0; i < rng; i++)
            {
                Entity_iterator.Add(GameController.factory.Create("enemy", new Vector3(Random.Range(-2, 3), 5, 0)));
            }
        }
    }

    public void Move()
    {
        //runs through the iterator and visits them(to move them), then resets them
        while (Entity_iterator.HasNext())
        {
            IEntity enemy_obj = Entity_iterator.GetNext();
            enemy_obj.Visit(visitor);
        }
        Entity_iterator.Reset();
    }

    public void Wipe()
    {
        //clears the entire list of entities
        Entity_iterator.Wipe();
    }
    
}
