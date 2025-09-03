using System;
using System.Threading.Tasks;

public partial class MapReduce<T>
{
    public delegate T MapDelegate(T input);

    public void Map(MapDelegate mapFunc)
    {
        Parallel.For(0, data.Count, i =>
        {
            data[i] = mapFunc(data[i]);
        });
    }
}
