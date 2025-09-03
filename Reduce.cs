using System.Threading.Tasks;

public partial class MapReduce<T>
{
    // takes two T values and returns a T
    public delegate T ReduceDelegate(T accumulator, T current);

    // reduces the data to a single value
    public T Reduce(ReduceDelegate reduceFunc)
    {
        if (data.Count == 0)
            throw new InvalidOperationException("No data to reduce.");

        T result = data[0];
        for (int i = 1; i < data.Count; i++)
        {
            result = reduceFunc(result, data[i]);
        }
        return result;
    }

    // Asynchronously reduces the data using TAP
    public async Task<T> ReduceAsync(ReduceDelegate reduceFunc)
    {
        return await Task.Run(() => Reduce(reduceFunc));
    }
}
