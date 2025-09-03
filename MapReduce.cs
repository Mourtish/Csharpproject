using System;
using System.Collections.Generic;

public partial class MapReduce<T>
{
    private List<T> data;

    // Initializes the  container
    public MapReduce()
    {
        data = new List<T>();
    }

    // Adds an element to the container
    public void Add(T item)
    {
        data.Add(item);
    }

    // Returns the number of elements
    public int Count
    {
        get { return data.Count; }
    }

    //Allows access to elements by index
    public T this[int index]
    {
        get { return data[index]; }
    }
}
