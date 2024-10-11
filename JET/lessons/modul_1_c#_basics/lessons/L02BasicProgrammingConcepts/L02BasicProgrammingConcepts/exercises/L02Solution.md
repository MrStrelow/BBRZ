### Exercise 1:
```csharp
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
```

### Exercise 2:

```csharp
public class Converter
{
    // Zahl zu Zahl: Int zu Double
    public double ConvertIntToDouble(int number)
    {
        return (double)number;
    }

    // Zahl zu Zahl: Double zu Int
    public int ConvertDoubleToInt(double number)
    {
        return (int)number;
    }

    // String zu Zahl: String zu Int
    public int ParseStringToInt(string str)
    {
        if (int.TryParse(str, out int result))
        {
            return result;
        }
        else
        {
            throw new FormatException("Ungültige Zahl");
        }
    }

    // String zu Zahl: String zu Double
    public double ParseStringToDouble(string str)
    {
        if (double.TryParse(str, out double result))
        {
            return result;
        }
        else
        {
            throw new FormatException("Ungültige Zahl");
        }
    }

    // Zahl zu String: Int zu String
    public string ConvertIntToString(int number)
    {
        return number.ToString();
    }

    // Zahl zu String: Double zu String
    public string ConvertDoubleToString(double number)
    {
        return number.ToString();
    }

    // Zusätzliche Umwandlungen mit der Convert-Klasse
    public string ConvertBoolToString(bool value)
    {
        return Convert.ToString(value);
    }

    public double ConvertDecimalToDouble(decimal number)
    {
        return Convert.ToDouble(number);
    }
}
```

### Exercise 3:
```csharp
public class L09LinesOnChessBoard
{
    public static void Main(string[] args)
    {
        Console.Write("Größe des Spielbretts eingeben: ");
        int dimension = int.Parse(Console.ReadLine());

        string[][] brett = new string[dimension][];
        for (int i = 0; i < dimension; i++)
        {
            brett[i] = new string[dimension];
        }

        char whiteSquareCode = (char)0x2588;
        char blackSquareCode = (char)0x2591;

        string whiteSquare = new string(whiteSquareCode, 1);
        string blackSquare = new string(blackSquareCode, 1);

        // Erstelle ein Schachbrettmuster beliebiger Größe welche vom User bestimmt wird.
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                if ((j + i) % 2 == 0)
                    brett[i][j] = whiteSquare;
                else
                    brett[i][j] = blackSquare;
            }
        }

        // Userinput
        Console.Write("Wähle die Figur... [x y]: ");
        string[] userinput = Console.ReadLine().Split(" ");

        int xStart = int.Parse(userinput[0]);
        int yStart = int.Parse(userinput[1]);

        Console.Write("... und wähle das Ziel [x y]: ");
        userinput = Console.ReadLine().Split(" ");

        int xZiel = int.Parse(userinput[0]);
        int yZiel = int.Parse(userinput[1]);

        brett[yStart][xStart] = "o";
        brett[yZiel][xZiel] = "x";

        int deltaX = xZiel - xStart;
        int deltaY = yZiel - yStart;
        double steigung;
        int longerDelta;
        bool longerIsX;
        int chosenY;
        int chosenX;

        Console.WriteLine("++++++++++++++ Version 3 ++++++++++++++");

        if (Math.Abs(deltaX) > Math.Abs(deltaY))
        {
            steigung = (0.0 + deltaY) / deltaX;
            longerDelta = deltaX;
            longerIsX = true;
        }
        else
        {
            steigung = (0.0 + deltaX) / deltaY;
            longerDelta = deltaY;
            longerIsX = false;
        }

        chosenX = xStart;
        chosenY = yStart;

        for (int i = 1; i < Math.Abs(longerDelta); i++)
        {
            int neuePositionX;
            int neuePositionY;

            if (longerIsX)
            {
                if (deltaY < 0)
                {
                    neuePositionX = chosenX - i;
                    neuePositionY = (int)Math.Round(chosenY - i * steigung);
                }
                else
                {
                    neuePositionX = chosenX + i;
                    neuePositionY = (int)Math.Round(chosenY + i * steigung);
                }
            }
            else
            {
                if (deltaX < 0)
                {
                    neuePositionY = chosenY - i;
                    neuePositionX = (int)Math.Round(chosenX - i * steigung);
                }
                else
                {
                    neuePositionY = chosenY + i;
                    neuePositionX = (int)Math.Round(chosenX + i * steigung);
                }
            }

            brett[neuePositionY][neuePositionX] = ".";
        }

        // Ausgabe
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                Console.Write(brett[i][j]);
            }
            Console.WriteLine();
        }
    }
}
````

### Exercise 4:
```csharp
public class MusterMitFunktionen
{
    public static void Main(string[] args)
    {
        // Wir wollen einen Diamanten aus Dreiecken bauen.
        // #
        // ##
        // ###
        // ####

        // 2D-Array anlegen
        string[,] feld = new string[5, 5];

        feld = FillCanvas(feld, "~");
        string[,] triangle = DrawTriangle(feld, "#");
        string[,] diamond = DrawDiamond(triangle);
        Print(diamond);
    }

    static void Print(string[,] feld)
    {
        for (int i = 0; i < feld.GetLength(0); i++)
        {
            for (int j = 0; j < feld.GetLength(1); j++)
            {
                Console.Write(feld[i, j]);
            }
            Console.WriteLine();
        }
    }

    static string[,] FillCanvas(string[,] feld, string symbol)
    {
        string[,] ret = new string[feld.GetLength(0), feld.GetLength(1)];

        for (int i = 0; i < ret.GetLength(0); i++)
        {
            for (int j = 0; j < ret.GetLength(1); j++)
            {
                ret[i, j] = symbol;
            }
        }

        return ret;
    }

    static string[,] DrawTriangle(string[,] feld, string symbol)
    {
        string[,] ret = Copy(feld);

        for (int i = 0; i < ret.GetLength(0); i++)
        {
            for (int j = 0; j < ret.GetLength(1); j++)
            {
                if (j <= i)
                {
                    ret[i, j] = symbol;
                }
            }
        }

        return ret;
    }

    static string[,] Copy(string[,] feld)
    {
        string[,] ret = new string[feld.GetLength(0), feld.GetLength(1)];

        for (int i = 0; i < ret.GetLength(0); i++)
        {
            for (int j = 0; j < ret.GetLength(1); j++)
            {
                ret[i, j] = feld[i, j];
            }
        }

        return ret;
    }

    static string[,] Rotate(string[,] feld)
    {
        return Transpose(Mirror(feld));
    }

    static string[,] Transpose(string[,] feld)
    {
        string[,] ret = new string[feld.GetLength(0), feld.GetLength(1)];

        for (int i = 0; i < feld.GetLength(0); i++)
        {
            for (int j = 0; j < feld.GetLength(1); j++)
            {
                ret[i, j] = feld[j, i];
            }
        }

        return ret;
    }

    static string[,] Mirror(string[,] feld)
    {
        string[,] ret = new string[feld.GetLength(0), feld.GetLength(1)];

        for (int i = 0; i < feld.GetLength(0); i++)
        {
            for (int j = 0; j < feld.GetLength(1); j++)
            {
                ret[i, j] = feld[feld.GetLength(0) - 1 - i, j];
            }
        }

        return ret;
    }

    // Siehe Code unten: hier kann AssignLeftUpper, usw. zu einer Methode zusammengefasst werden,
    // welche die verschiedenen offsets der schleifen als Argumente bekommen
    static string[,] AssignLeftUpper(string[,] feld, string[,] leftUpper)
    {
        string[,] ret = Copy(feld);

        for (int i = 0; i < leftUpper.GetLength(0); i++)
        {
            for (int j = 0; j < leftUpper.GetLength(1); j++)
            {
                ret[i, j] = leftUpper[i, j];
            }
        }

        return ret;
    }

    static string[,] AssignLeftLower(string[,] feld, string[,] leftLower)
    {
        string[,] ret = Copy(feld);

        for (int i = leftLower.GetLength(0); i < feld.GetLength(0); i++)
        {
            for (int j = 0; j < leftLower.GetLength(1); j++)
            {
                ret[i, j] = leftLower[i - leftLower.GetLength(0), j];
            }
        }

        return ret;
    }

    static string[,] AssignRightLower(string[,] feld, string[,] rightLower)
    {
        string[,] ret = Copy(feld);

        for (int i = rightLower.GetLength(0); i < feld.GetLength(0); i++)
        {
            for (int j = rightLower.GetLength(1); j < feld.GetLength(1); j++)
            {
                ret[i, j] = rightLower[i - rightLower.GetLength(0), j - rightLower.GetLength(1)];
            }
        }

        return ret;
    }

    static string[,] AssignRightUpper(string[,] feld, string[,] rightUpper)
    {
        string[,] ret = Copy(feld);

        for (int i = 0; i < rightUpper.GetLength(0); i++)
        {
            for (int j = rightUpper.GetLength(1); j < feld.GetLength(1); j++)
            {
                ret[i, j] = rightUpper[i, j - rightUpper.GetLength(1)];
            }
        }

        return ret;
    }

    static string[,] DrawDiamond(string[,] feld)
    {
        string[,] rightUpper = Copy(feld);
        string[,] rightLower = Rotate(feld);
        string[,] leftLower = Rotate(Rotate(feld));
        string[,] leftUpper = Rotate(Rotate(Rotate(feld)));

        string[,] ret = new string[feld.GetLength(0) * 2, feld.GetLength(1) * 2];

        ret = AssignRightUpper(ret, rightUpper);
        ret = AssignRightLower(ret, rightLower);
        ret = AssignLeftUpper(ret, leftUpper);
        ret = AssignLeftLower(ret, leftLower);

        return ret;
    }


    // mit einer methode der Zuordnung:
    // static String[][] CombineTriangles(String[][] baseArray, String[][] triangle, int rowOffset, int colOffset) {
    //     for (int i = 0; i < triangle.Length; i++) {
    //         for (int j = 0; j < triangle[i].Length; j++) {
    //             if (i + rowOffset < baseArray.Length && j + colOffset < baseArray[i + rowOffset].Length) {
    //                 baseArray[i + rowOffset][j + colOffset] = triangle[i][j];
    //             }
    //         }
    //     }
    // }

    // static String[][] DrawStar(String[][] baseArray) {
    //     String[][] triangle = DrawTriangle(baseArray, "#");

    //     String[][] star = new String[2 * baseArray.Length][2 * baseArray.Length];
    //     star = CombineTriangles(star, triangle, 0, baseArray.Length); // Rechte obere Ecke
    //     star = CombineTriangles(star, Drehen(triangle), baseArray.Length, baseArray.Length); // Rechte untere Ecke
    //     star = CombineTriangles(star, Drehen(Drehen(triangle)), baseArray.Length, 0); // Linke untere Ecke
    //     star = CombineTriangles(star, Drehen(Drehen(Drehen(triangle))), 0, 0); // Linke obere Ecke

    //     return star;
    // }
}
```

