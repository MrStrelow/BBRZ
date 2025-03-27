using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder result = new StringBuilder();

        int upper = (int)Math.Pow(10, 5);

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


        // String to upper by yourself
        Console.WriteLine(ToUpper("bLLuEEh"));
    }

    //String to upper case mit chars    
    static string? ToUpper(string notUpperYet)
    {
        char[] charsToBeConverted = notUpperYet.ToCharArray();
        char a = 'a';

        for (int i = 0; i < charsToBeConverted.Length; i++)
        {
            if ('a' <= charsToBeConverted[i] && charsToBeConverted[i] <= 'z') // auch mit hashmap/dictionary möglich! a: A, b: B
            {
                charsToBeConverted[i] = (char)(charsToBeConverted[i] - 32); // 0041 -> 0061 !Achtung: 20 = 32 unicode sind (fast) immer hex.
            }
        }

        return new string(charsToBeConverted);
        //return Convert.ToString(charsToBeConverted);
    }
}