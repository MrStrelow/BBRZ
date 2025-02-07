class Spontan
{
    static void Main(string[] args)
    {
        //string test = "0ss";
        //try
        //{
        //    int number = int.Parse(test);
        //    Console.WriteLine(number);
        //}
        //catch (FormatException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    Console.WriteLine(ex.StackTrace);

        //    // logge den fehler, mit details von dem aufrufer, welches betriebssystem, wann war die anfrage an den server, ...
        //}

        //while (!int.TryParse(Console.ReadLine(), out int result))
        //{
        //    Console.WriteLine($"hat nicht funktioniert {result}");
        //}

        ////if (int.TryParse(Console.ReadLine(), out int result))
        ////{
        ////    Console.WriteLine($"hat nicht funktioniert {result}");
        ////}
        ////else
        ////{
        ////    Console.WriteLine("Fehler");
        ////}


        //void CallByValue(int parameter)
        //{
        //    ++parameter;
        //}

        //void CallByReference(ref int parameter)
        //{
        //    ++parameter;
        //}

        //int input = 10;
        //CallByValue(input);
        //Console.WriteLine(input);

        //CallByReference(ref input);
        //Console.WriteLine(input);

        //Console.WriteLine("###############################");

        //while (true)
        //{
        //    try
        //    {
        //        int verwendeConvert = Convert.ToInt32(Console.ReadLine());
        //        Console.WriteLine(verwendeConvert);
        //        break;
        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine(ex.Message + ex.StackTrace);
        //    }
        //}

        //Console.WriteLine(Enum.GetValues<Direction>()[0] == Direction.UP);

        //Enum.TryParse(
        //    result: out object? result,
        //    ignoreCase: true,
        //    enumType: typeof(Direction),
        //    value: Console.ReadLine()
        //);


        //Console.WriteLine(5 + 8);

        Console.WriteLine(ToUpper("bLLuEEh"));
    }
    enum Direction
    {
        UP, Down
    }

    static string? ToUpper(string notUpperYet)
    {
        char[] charsToBeConverted = notUpperYet.ToCharArray();
        char a = 'a';

        for (int i = 0; i < charsToBeConverted.Length; i++)
        {
            if ('a' <= charsToBeConverted[i] && charsToBeConverted[i] <= 'z') // auch mit hashmap/dictionary möglich! a: A, b: B
            {
                charsToBeConverted[i] = (char) (charsToBeConverted[i] - 32); // 0041 -> 0061 !Achtung: 20 = 32 unicode sind (fast) immer hex.
            }
        }

        return new string(charsToBeConverted);
        //return Convert.ToString(charsToBeConverted);
    }
}
