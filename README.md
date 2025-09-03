# Csharpproject

# MapReduce in C#

A simple MapReduce framework built in C# as a side project.  
Demonstrates concepts of parallel computing, delegates, async tasks, and binary file reading.

## Features
- `DataReader` class to load doubles from binary files
- `MapReduce<T>` class supporting:
  - `Map` (parallelized using `Parallel.For`)
  - `Reduce` (synchronous and async)
- Enumerator support for iterating over loaded data

## Example Usage
```csharp
var mr = new MapReduce<int>();
mr.Add(1);
mr.Add(2);
mr.Add(3);

// Map: square each value
mr.Map(x => x * x);

// Reduce: sum
int sum = mr.Reduce((a, b) => a + b);
Console.WriteLine(sum); // 14
