class Program
{
    static void Main(string[] args)
    {
        var calc = new Calculator();
        int ergebnis = calc.Add(2, 5);

        int a = 5;
        calc.Multiply(ref a, ref a);

        int b;
        calc.Initialize(out b);

        calc.Average(10, 10, 10);

        Console.WriteLine(calc.ergebnis);

        destroyAndInitObject(ref calc);
        Console.WriteLine(calc.ergebnis);

        calc.Add(a, a);
        pretendToDestroyAndInitObject(calc);
        Console.WriteLine(calc.ergebnis);

        fiddleWithNumber(calc);
        Console.WriteLine(calc.ergebnis);
    }

    static void destroyAndInitObject(ref Calculator obj)
    {
        obj = new Calculator();
    }

    static void pretendToDestroyAndInitObject(Calculator obj)
    {
        obj = new Calculator();
    }

    static void fiddleWithNumber(Calculator obj)
    {
        obj.ergebnis = 5;
    }
}