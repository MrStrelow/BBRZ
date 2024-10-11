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