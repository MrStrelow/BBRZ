using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise1.src.Domain.People.Entities;

namespace Exercise1;

internal class ListTest
{
    public static void RunTests<T>(IMyList<T> list, params T[] elements) where T : Human 
    {
        Console.WriteLine($"###################### Starting tests for {list.GetType()} ###################### ");

        // Test AddBeginning
        Console.WriteLine("\nTesting AddBeginning...");
        foreach (var item in elements)
        {
            list.AddBeginning(item);
        }
        Console.WriteLine(list);

        // Test AddEnd
        Console.WriteLine("\nTesting AddEnd...");
        foreach (var item in elements)
        {
            list.AddEnd(item);
        }
        Console.WriteLine(list);

        // Test Add at position
        int pos = 1;
        Console.WriteLine($"\nTesting Add at specific position: {pos} ...");
        list.Add(elements[0], pos);
        Console.WriteLine(list);

        // Test Get
        Console.WriteLine("\nTesting Get...");
        Console.WriteLine($"Element at position 0: {list.Get(0)}");
        Console.WriteLine($"Element at position {list.Length() - 1}: {list.Get(list.Length() - 1)}");

        // Test Update
        Console.WriteLine("\nTesting Update...");
        Console.WriteLine($"old:\n{list}");  
        list.Update(elements[0], 0);
        Console.WriteLine($"new:\n{list}");  

        // Test Find
        Console.WriteLine("\nTesting Find...");
        Console.WriteLine($"{elements[0]} is...");
        var (foundElement, index) = list.Find(elements[0]);
        Console.WriteLine($"found {foundElement} at index {index}");

        // Test Remove
        Console.WriteLine("\nTesting Remove...");
        Console.WriteLine($"Removing {elements[0]}...");
        Console.WriteLine($"old:\n{list}");
        list.Remove(elements[0]);
        Console.WriteLine($"new:\n{list}");

        Console.WriteLine();
    }
}
