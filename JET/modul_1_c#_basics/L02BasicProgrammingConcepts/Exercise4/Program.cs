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

        var slopedDiamant = DrawDiamondSlope(slopedTriangle);
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

    // Siehe Code unten: hier kann AssignLeftUpper, usw. zu einer Methode zusammengefasst werden,
    // welche die verschiedenen offsets der schleifen als Argumente bekommen
    static string[,] AssignLeftUpper(string[,] field, string[,] leftUpper)
    {
        string[,] ret = Copy(field);

        for (int i = 0; i < leftUpper.GetLength(0); i++)
        {
            for (int j = 0; j < leftUpper.GetLength(1); j++)
            {
                ret[i, j] = leftUpper[i, j];
            }
        }

        return ret;
    }

    static string[,] AssignLeftLower(string[,] field, string[,] leftLower)
    {
        string[,] ret = Copy(field);

        for (int i = leftLower.GetLength(0); i < field.GetLength(0); i++)
        {
            for (int j = 0; j < leftLower.GetLength(1); j++)
            {
                ret[i, j] = leftLower[i - leftLower.GetLength(0), j];
            }
        }

        return ret;
    }

    static string[,] AssignRightLower(string[,] field, string[,] rightLower)
    {
        string[,] ret = Copy(field);

        for (int i = rightLower.GetLength(0); i < field.GetLength(0); i++)
        {
            for (int j = rightLower.GetLength(1); j < field.GetLength(1); j++)
            {
                ret[i, j] = rightLower[i - rightLower.GetLength(0), j - rightLower.GetLength(1)];
            }
        }

        return ret;
    }

    static string[,] AssignRightUpper(string[,] field, string[,] rightUpper)
    {
        string[,] ret = Copy(field);

        for (int i = 0; i < rightUpper.GetLength(0); i++)
        {
            for (int j = rightUpper.GetLength(1); j < field.GetLength(1); j++)
            {
                ret[i, j] = rightUpper[i, j - rightUpper.GetLength(1)];
            }
        }

        return ret;
    }

    static string[,] DrawDiamond(string[,] field)
    {
        string[,] rightUpper = Copy(field);
        string[,] rightLower = Rotate(field);
        string[,] leftLower = Rotate(Rotate(field));
        string[,] leftUpper = Rotate(Rotate(Rotate(field)));

        string[,] ret = new string[field.GetLength(0) * 2, field.GetLength(1) * 2];

        ret = AssignRightUpper(ret, rightUpper);
        ret = AssignRightLower(ret, rightLower);
        ret = AssignLeftUpper(ret, leftUpper);
        ret = AssignLeftLower(ret, leftLower);

        return ret;
    }

    static string[,] DrawDiamondSlope(string[,] field)
    {
        string[,] rightUpper = Copy(field);
        string[,] rightLower = MirrorX(field);
        string[,] leftLower = MirrorX(MirrorY(field));
        string[,] leftUpper = MirrorY(field);

        string[,] ret = new string[field.GetLength(0) * 2, field.GetLength(1) * 2];

        ret = AssignRightUpper(ret, rightUpper);
        ret = AssignRightLower(ret, rightLower);
        ret = AssignLeftUpper(ret, leftUpper);
        ret = AssignLeftLower(ret, leftLower);

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