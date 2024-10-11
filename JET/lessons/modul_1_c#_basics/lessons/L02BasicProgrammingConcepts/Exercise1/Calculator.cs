using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Calculator
{
    public int ergebnis = 0;

    public int Add(int a, int b)
    {
        ergebnis = a + b;
        return ergebnis;
    }

    public void Multiply(ref int a, ref int b)
    {
        a *= b;
        ergebnis = a;
    }

    public void Initialize(out int result)
    {
        result = 100;
        ergebnis = result;
    }

    public double Average(params int[] numbers)
    {
        ergebnis = (int)numbers.Average();
        return ergebnis;
    }
}
