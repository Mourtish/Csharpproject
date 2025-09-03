using System;

class Example
{
    static void Main(string[] args)
    {
        // Create a MapReduce container
        var mr = new MapReduce<int>();

        // Add some numbers
        mr.Add(1);
        mr.Add(2);
        mr.Add(3);
        mr.Add(4);
        mr.Add(5);

        Console.WriteLine($"Initial data count: {mr.Count}");

        // Map: square each value
        mr.Map(x => x * x);

        Console.WriteLine("After Map (squaring each value):");
        for (int i = 0; i < mr.Count; i++)
        {
            Console.WriteLine($"Index {i}: {mr[i]}");
        }

        // Reduce: sum of all squares
        int sumSquares = mr.Reduce((a, b) => a + b);
        Console.WriteLine($"Sum of squares: {sumSquares}");

        // ReduceAsync: multiply all values (factorial-like)
        var productTask = mr.ReduceAsync((a, b) => a * b);
        productTask.Wait();
        int product = productTask.Result;

        Console.WriteLine($"Product of squares: {product}");
    }
}
