using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iterator
{
    void Add(IEntity entity);
    bool HasNext();
    IEntity GetNext();
    void Reset();
    void Remove(IEntity entity);
    void Wipe();
}

public class DefaultIterator : Iterator
{
    private List<IEntity> entities = new List<IEntity>();
    private int index = -1;

    public void Add(IEntity entity)
    {
        entities.Add(entity);
    }

    public bool HasNext()
    {
        return (entities.Count > 0 && index < entities.Count - 1);
    }

    public IEntity GetNext()
    {
        index++;
        return entities[index];
    }

    public void Reset()
    {
        index = -1;
    }

    public void Remove(IEntity entity)
    {
        entities.Remove(entity);
    }

    public void Wipe()
    {
        foreach(IEntity e in entities)
        {
            e.onDeath();
        }
    }
}

