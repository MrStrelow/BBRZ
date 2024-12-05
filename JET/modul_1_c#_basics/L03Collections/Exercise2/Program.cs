using System;

public class SimpleArrayList
{
    private string[] array;
    private int count;

    public SimpleArrayList()
    {
        array = new string[4]; // Anfangsgröße
        count = 0;
    }

    public void Add(string item)
    {
        if (count == array.Length)
        {
            Resize();
        }
        array[count++] = item;
    }

    public bool Contains(string item)
    {
        for (int i = 0; i < count; i++)
        {
            if (array[i].Equals(item))
                return true;
        }
        return false;
    }

    public void Remove(string item)
    {
        int index = Array.IndexOf(array, item, 0, count);
        if (index >= 0)
        {
            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[--count] = default(string); // Entfernen des letzten Elements
        }
    }

    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    private void Resize()
    {
        string[] newArray = new string[array.Length * 2];
        Array.Copy(array, newArray, array.Length);
        array = newArray;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var list = new SimpleArrayList();
        list.Add("1");
        list.Add("2");
        list.Add("3");
        list.Print();

        list.Remove("2");
        list.Print();

        Console.WriteLine(list.Contains("2")); // True
        Console.WriteLine(list.Contains("2")); // False
    }
}
