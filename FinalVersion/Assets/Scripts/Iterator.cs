using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iterator
{
    //interface for the iterator
    void Add(IEntity entity);
    bool HasNext();
    IEntity GetNext();
    void Reset();
    void Remove(IEntity entity);
    void Wipe();
}

public class DefaultIterator : Iterator
{
    //implementation of the iterator with a List class
    private List<IEntity> entities = new List<IEntity>();
    private int index = -1;

    public void Add(IEntity entity)
    {
        //adds entities to the list
        entities.Add(entity);
    }

    public bool HasNext()
    {
        //checks if there are still entities in the list
        return (entities.Count > 0 && index < entities.Count - 1);
    }

    public IEntity GetNext()
    {
        //returns the next entity in the list
        index++;
        return entities[index];
    }

    public void Reset()
    {
        //resets the list
        index = -1;
    }

    public void Remove(IEntity entity)
    {
        //removes the entity from the list
        entities.Remove(entity);
    }

    public void Wipe()
    {
        //kills off every entity and calls their specific death command
        foreach(IEntity e in entities)
        {
            e.onDeath();
        }
    }
}

