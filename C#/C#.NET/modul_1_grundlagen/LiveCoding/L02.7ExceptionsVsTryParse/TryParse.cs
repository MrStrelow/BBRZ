class TryParse
{
    static void Main(string[] args)
    {
        string test = "0ss";

        try
        {
           int number = int.Parse(test);
           Console.WriteLine(number);
        }
        catch (FormatException ex)
        {
           Console.WriteLine(ex.Message);
           Console.WriteLine(ex.StackTrace);

           // logge den fehler, mit details von dem aufrufer, welches betriebssystem, wann war die anfrage an den server, ...
        }

        if (int.TryParse(Console.ReadLine(), out int resultIf))
        {
            Console.WriteLine($"hat nicht funktioniert {resultIf}");
        }
        else
        {
            Console.WriteLine("Fehler");
        }


        while (!int.TryParse(Console.ReadLine(), out int result))
        {
           Console.WriteLine($"hat nicht funktioniert {result}");
        }


        void CallByValue(int parameter)
        {
           ++parameter;
        }

        void CallByReference(ref int parameter)
        {
           ++parameter;
        }

        int input = 10;
        CallByValue(input);
        Console.WriteLine(input);

        CallByReference(ref input);
        Console.WriteLine(input);

        Console.WriteLine("###############################");

        while (true)
        {
           try
           {
               int verwendeConvert = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine(verwendeConvert);
               break;
           }
           catch (FormatException ex)
           {
               Console.WriteLine(ex.Message + ex.StackTrace);
           }
        }

        Console.WriteLine(Enum.GetValues<Direction>()[0] == Direction.UP);

        Enum.TryParse(
           result: out object? res,
           ignoreCase: true,
           enumType: typeof(Direction),
           value: Console.ReadLine()
        );
       
    }
    enum Direction
    {
        UP, Down
    }
}
