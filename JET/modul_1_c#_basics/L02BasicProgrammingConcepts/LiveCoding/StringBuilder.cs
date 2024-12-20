using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder result = new StringBuilder();

        int upper = (int) Math.Pow(10, 5);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < upper; i++)
        {
            result.ToString();
            result.Insert(0, "d");
            result.Append("Hello ");  // Direktes Modifizieren des internen Arrays.
        }

        stopwatch.Stop();

        Console.WriteLine("Mit StringBuilder: " + stopwatch.ElapsedMilliseconds + " ms");
        string resultString = "";

        stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < upper; i++)
        {
            resultString += "Hello ";  // Bei jedem Schleifendurchlauf wird eine neue Instanz erzeugt.
        }

        stopwatch.Stop();
        Console.WriteLine("Mit string: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}