
# Performance Comparison of Multidimensional vs Jagged Arrays

This code compares the performance of multidimensional arrays and jagged arrays in C#.

```csharp

using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        const int size = 10000;

        // Initialize multidimensional array
        int[,] multiDimArray = new int[size, size];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                multiDimArray[i, j] = i + j;

        // Initialize jagged array
        int[][] jaggedArray = new int[size][];
        for (int i = 0; i < size; i++)
        {
            jaggedArray[i] = new int[size];
            for (int j = 0; j < size; j++)
                jaggedArray[i][j] = i + j;
        }

        // Measure time for multidimensional array
        Stopwatch stopwatch = Stopwatch.StartNew();
        long multiSum = 0;
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                multiSum += multiDimArray[i, j];
        stopwatch.Stop();
        Console.WriteLine($"Multidimensional Array Time: {stopwatch.ElapsedMilliseconds} ms");

        // Measure time for jagged array
        stopwatch.Restart();
        long jaggedSum = 0;
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                jaggedSum += jaggedArray[i][j];
        stopwatch.Stop();
        Console.WriteLine($"Jagged Array Time: {stopwatch.ElapsedMilliseconds} ms");

        const int dim = 100;
        for(var passes = 0; passes < 10; passes++)
        {
            var timer = new Stopwatch();
            timer.Start();
            var single = new int[dim*dim*dim];
            for(var i = 0; i < dim; i++)
            {
                for(var j = 0; j < dim; j++)
                {
                    for(var k = 0; k < dim; k++)
                    {
                        single[i*dim*dim+j*dim+k] = i * j * k;
                    }
                }
            }
            timer.Stop();
            Console.Write((double)timer.ElapsedTicks/TimeSpan.TicksPerMillisecond);
        }
        Console.WriteLine();
    }
}

```
