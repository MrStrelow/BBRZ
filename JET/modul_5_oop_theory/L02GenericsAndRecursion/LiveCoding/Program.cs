public class Test
{
    public static int Fakultaet(int n)
    {

        if (n == 1) // TODO: was ist der Unterschied zu n == 0? Warum ändert sich das Ergebnis nicht?
        {
            return 1;
        }

        return n * Fakultaet(n - 1);
    }

    public static int FakultaetTailRec(int n, int ergebnis = 1)
    {

        if (n == 1)
        {
            return ergebnis;
        }

        return FakultaetTailRec(n - 1, ergebnis * n);
    }

    public static int FakultaetTail(int n)
    {
        return FakultaetTailRec(n);
    }


    public static int Fib(int n, int a=0, int b=1)
    {
        if (n == 0) return a;
        if (n == 1) return b;

        return Fib(n-1, b, a+b);
    }

    public static int FibBad(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        return FibBad(n - 1) + FibBad(n - 2);
    }


    public static void Main(string[] args)
    {
        Console.WriteLine(Fakultaet(4));
        Console.WriteLine(FakultaetTail(4));
        Console.WriteLine(Fib(10));
        Console.WriteLine(FibBad(10));
    }
}
