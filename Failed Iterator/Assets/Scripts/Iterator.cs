using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Option<T>
{
    U Visit<U>(Func<U> onNone, Func<T, U> onSome);
    void Visit(Action onNone, Action<T> onSome);
}

public class None<T> : Option<T>
{
    public U Visit<U>(Func<U> onNone, Func<T, U> onSome)
    {
        return onNone();
    }
    public void Visit(Action onNone, Action<T> onSome)
    {
        onNone();
    }
}

public class Some<T> : Option<T>
{
    T value;
    public Some(T value)
    {
        this.value = value;
    }
    public U Visit<U>(Func<U> onNone, Func<T, U> onSome)
    {
        return onSome(value);
    }
    public void Visit(Action onNone, Action<T> onSome)
    {
        onSome(value);
    }
}

public interface Iterator<T>
{
    Option<T> GetNext();
    Option<T> GetCurrent();
    void Reset();
    void Add(T item);
}

public class CustomList<T> : Iterator<T>
{
    private int size;
    private List<T> list;
    private int current;
    private int amount_of_items;

    public CustomList()
    {
        size = 10;
        amount_of_items = 0;
        current = 0;
        list = new List<T>();
        Reset();
    }
    public void Add(T item)
    {
        list.Add(item);
        amount_of_items++;
    }

    public Option<T> GetNext()
    {
        current++;
        if (current >= amount_of_items)
        {
            return new None<T>();
        }
        return new Some<T>(list[current]);
    }

    public Option<T> GetPrevious()
    {
        current--;
        if (current < amount_of_items - EnemyManager.enemyAmount)
        {
            return new None<T>();
        }
        return new Some<T>(list[current]);
    }

    public void Reset()
    {
        current = -1;
    }

    public void ResetMax()
    {
        current = amount_of_items;
    }

    public Option<T> GetCurrent()
    {
        if (current == -1) return new None<T>();
        return new Some<T>(list[current]);
    }

    
}