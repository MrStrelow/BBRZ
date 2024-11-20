
# Performance Comparison of Multidimensional vs Jagged Arrays (Varying Sizes)

This code compares the performance of multidimensional arrays and jagged arrays in C#. The jagged array has rows of varying lengths, while the multidimensional array is rectangular.

```csharp

using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        const int rows = 500;
        const int maxCols = 300;

        // Initialize multidimensional array (fixed size)
        int[,] multiDimArray = new int[rows, maxCols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < maxCols; j++)
                multiDimArray[i, j] = i + j;

        // Initialize jagged array (varying sizes)
        int[][] jaggedArray = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            jaggedArray[i] = new int[i + 1]; // Each row has a unique length
            for (int j = 0; j < jaggedArray[i].Length; j++)
                jaggedArray[i][j] = i + j;
        }

        // Measure time for multidimensional array
        Stopwatch stopwatch = Stopwatch.StartNew();
        long multiSum = 0;
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < maxCols; j++)
                multiSum += multiDimArray[i, j];
        stopwatch.Stop();
        Console.WriteLine($"Multidimensional Array Time: {stopwatch.ElapsedMilliseconds} ms");

        // Measure time for jagged array (explicit handling of lengths)
        stopwatch.Restart();
        long jaggedSum = 0;
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < jaggedArray[i].Length; j++) // Using the row's length explicitly
                jaggedSum += jaggedArray[i][j];
        stopwatch.Stop();
        Console.WriteLine($"Jagged Array Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}

```
