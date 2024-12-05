// See https://aka.ms/new-console-template for more information

// Author: Benjamin Kranzl
class Programm
{
    private static int sleepTime1 = 50;
    private static int sleeptime2 = 500;
    static void Main(string[] args)
    {
        int[] arrayRand1 = { 8, 7, 6, 5, 4, 3, 2, 1 };
        int[] arrayRand2 = { 7, 6, 8, 4, 3, 2, 5, 1 };

        int[] arraySorted = sortArray(arrayRand2);
        Console.ForegroundColor = ConsoleColor.Red;
        printSlow("Finished Array:", true);
        Console.ForegroundColor = ConsoleColor.White;
        printSlow(arraySorted);

    }

    static void printSlow(int[] array)
    {
        string output = "[ " + string.Join(", ", array) + " ]";
        string[] stringArray = output.Split(' ');
        for (int i = 0; i < stringArray.Length; i++)
        {
            Console.Write(stringArray[i] + " ");
            Thread.Sleep(sleepTime1);
        }
        Console.WriteLine();
    }
    static void printSlowColor(int[] array, int index, bool fistTime)
    {

        string[] stringArray = array.Select(x => x.ToString()).ToArray();
        Console.Write("[ ");

        for (int i = 0; i < stringArray.Length; i++)
        {

            if (i == index)
            {

                if (fistTime)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.Write(stringArray[i]);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(sleepTime1);
            }
            else if (i == index + 1)
            {
                if (fistTime)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(stringArray[i]);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(sleepTime1);
            }
            else
            {
                Console.Write(stringArray[i]);
            }

            if (i < stringArray.Length - 1)
            {
                Console.Write(", ");
            }
            else
            {
                Console.Write(" ");
            }


        }
        Console.Write("]");
        Console.WriteLine();
    }
    static void printSlow(string output, bool breakAfter)
    {
        char[] charArray = output.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            Console.Write(charArray[i]);
            Thread.Sleep(sleepTime1);
        }
        if (breakAfter)
        {
            Console.WriteLine();
        }
    }
    static int[] sortArray(int[] arrayRandom)
    {
        int[] arraySorted = arrayRandom;
        int temp;
        for (int i = arraySorted.Length - 1; i >= 0; i--)
        {
            Console.WriteLine("-------");
            printSlow("Pass: " + (arraySorted.Length - i), true);
            Console.WriteLine("-------\n");
            for (int j = 0; j < i; j++)
            {

                temp = arraySorted[j];
                printSlow("Comparing Index ", false);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(j);
                Console.ForegroundColor = ConsoleColor.White;
                printSlow(" with Index ", false);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write((j + 1));
                Console.ForegroundColor = ConsoleColor.White;
                printSlow("...", true);
                printSlowColor(arraySorted, j, true);
                Thread.Sleep(sleeptime2);
                if (temp > arraySorted[j + 1])
                {
                    printSlow("swap Numbers...", true);
                    Thread.Sleep(sleeptime2);
                    arraySorted[j] = arraySorted[j + 1];
                    arraySorted[j + 1] = temp;
                    printSlowColor(arraySorted, j, false);
                    Console.WriteLine();
                }
                else
                {
                    printSlow("Checking next Number...", true);
                    Thread.Sleep(sleeptime2);
                    Console.WriteLine();
                }

            }
        }

        return arraySorted;
    }
}
