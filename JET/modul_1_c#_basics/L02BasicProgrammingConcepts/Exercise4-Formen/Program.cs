using System.Text;

public class FormenMitFunktionen
{
    public static void Main(string[] args)
    {
        string[,] field = new string[5, 5];
        string fillForm = "#";
        string fillBackgorund = "~";

        field = FillCanvas(field, fillBackgorund);
        string[,] triangle = DrawTriangle(field, fillForm);
        
        string[,] diamond = DrawDiamond(triangle);
        Print(diamond);
        Console.WriteLine();

        diamond = DrawPattern(diamond, 3, fillForm, "+");
        Print(diamond);
        Console.WriteLine();

        diamond = Rotate(DrawPattern(Rotate(diamond), 3, fillForm, "+"));
        Print(diamond);
        Console.WriteLine();

        var slopedTriangle = FillCanvas(field, fillBackgorund);
        slopedTriangle = DrawTriangle(slopedTriangle, fillForm, 0.25);
        Print(slopedTriangle);
        Console.WriteLine();

        var slopedDiamant = DrawDiamond(slopedTriangle);
        Print(slopedDiamant);
    }


    static void Print(string[,] field)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write(field[i, j]);
            }
            Console.WriteLine();
        }
    }

    static string[,] FillCanvas(string[,] field, string symbol)
    {
        string[,] ret = new string[field.GetLength(0), field.GetLength(1)];

        for (int i = 0; i < ret.GetLength(0); i++)
        {
            for (int j = 0; j < ret.GetLength(1); j++)
            {
                ret[i, j] = symbol;
            }
        }

        return ret;
    }

    static string[,] DrawTriangle(string[,] field, string symbol)
    {
        string[,] ret = Copy(field);

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

    static string[,] Copy(string[,] field)
    {
        string[,] ret = new string[field.GetLength(0), field.GetLength(1)];

        for (int i = 0; i < ret.GetLength(0); i++)
        {
            for (int j = 0; j < ret.GetLength(1); j++)
            {
                ret[i, j] = field[i, j];
            }
        }

        return ret;
    }

    static string[,] Rotate(string[,] field)
    {
        return Transpose(MirrorX(field));
    }

    static string[,] Transpose(string[,] field)
    {
        string[,] ret = new string[field.GetLength(0), field.GetLength(1)];

        var length = Math.Min(field.GetLength(0), field.GetLength(1));

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                ret[i, j] = field[j, i];
            }
        }

        return ret;
    }

    static string[,] MirrorX(string[,] field)
    {
        string[,] ret = new string[field.GetLength(0), field.GetLength(1)];

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                ret[i, j] = field[field.GetLength(0) - 1 - i, j];
            }
        }

        return ret;
    }

    static string[,] MirrorY(string[,] field)
    {
        string[,] ret = new string[field.GetLength(0), field.GetLength(1)];

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                ret[i, j] = field[i, field.GetLength(1) - 1 - j];
            }
        }

        return ret;
    }

    static string[,] CombineForm(String[,] container, String[,] part, Position position)
    {
        container = Copy(container);
        int iOffset = part.GetLength(0);
        int jOffset = part.GetLength(1);

        for (int i = 0; i < part.GetLength(0); i++)
        {
            for (int j = 0; j < part.GetLength(1); j++)
            {
                // wir fragen hier leider immer etwas ab (positon), das sich nicht ändern pro Schleife.
                // Es scheint aber so lesbar zu sein.
                // Wir lasses es deshalb so.
                switch (position)
                {
                    case Position.TOP_LEFT:  container[i,j] = part[i,j]; break;
                    case Position.BOT_RIGHT: container[i + iOffset, j + jOffset] = part[i,j]; break;
                    case Position.BOT_LEFT:  container[i + iOffset ,j] = part[i,j]; break;
                    case Position.TOP_RIGHT: container[i, j + jOffset] = part[i,j]; break;
                }
            }
        }

        return container;
    }

    static string[,] DrawDiamond(string[,] field)
    {
        string[,] topRight = Copy(field);
        string[,] botRight = MirrorX(field);
        string[,] botLeft  = MirrorY(botRight);
        string[,] topLeft  = MirrorX(botLeft);

        string[,] ret = new string[field.GetLength(0) * 2, field.GetLength(1) * 2];
        ret = CombineForm(ret, topRight, Position.TOP_RIGHT);
        ret = CombineForm(ret, botRight, Position.BOT_RIGHT);
        ret = CombineForm(ret, botLeft, Position.BOT_LEFT);
        ret = CombineForm(ret, topLeft, Position.TOP_LEFT);

        return ret;
    }

    static string[,] DrawPattern(string[,] field, int n, string fillForm, string newFillForm) 
    {
        field = Copy(field);

        for (int i = 0; i < field.GetLength(0); i++)
        {
            if (i % n == 0)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (fillForm == field[i, j])
                    {
                        field[i,j] = newFillForm;
                    }
                }
            }
        }

        return field;
    }

    static string[,] DrawTriangle(string[,] field, string symbol, double slope)
    {
        int xMax = Convert.ToInt32(Math.Ceiling((field.GetLength(0)-1) / slope)); 
        //TODO: cell vs value. cell is inbetween 1 and 2, so dont take 1 for cell 2, take 1.5=x instead
        string[,] ret = new string[field.GetLength(0), xMax];
        ret = FillCanvas(ret, field[0,0]);

        for (int x = 0; x < ret.GetLength(1); x++)
        {
            int y = x!=0 ? Convert.ToInt32(Math.Round(x * slope)) : 0;
            ret[y, x] = symbol;
        }

        for (int y = 0; y < ret.GetLength(0); y++)
        {
            for (int x = 0; x < ret.GetLength(1); x++)
            {
                if (ret[y,x] == symbol)
                {
                    break;
                } 
                else
                {
                    ret[y, x] = symbol;
                }
            }
        }

        return ret;
    }
}

enum Position
{
    TOP_RIGHT, TOP_LEFT, BOT_RIGHT, BOT_LEFT
}