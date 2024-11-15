using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCoding;

public class Formen
{
    static void Main(string[] args)
    {
        string triangleSymbol = "#";

        string[,] baseForm = FillCanvas(new string[5, 5], ".");
        string[,] rechtsOben = DrawTriangle(baseForm, triangleSymbol);
        Print(rechtsOben);
        string[,] rechtsUnten = MirrorX(rechtsOben);
        Print(rechtsUnten);
        string[,] linksOben = MirrorY(rechtsOben);
        Print(linksOben);
        string[,] linksUnten = MirrorY(rechtsUnten);
        Print(linksUnten);
    }

    static string[,] DrawTriangle(string[,] field, string symbol) 
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (j <= i)
                {
                    field[i, j] = symbol;
                }
            }
        }

        return field;
    }

    static string[,] MirrorX(string[,] field)
    {
        string[,] ret = Copy(field);

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
        string[,] ret = Copy(field);

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                ret[i, j] = field[i, field.GetLength(1) - 1 - j];
            }
        }

        return ret;
    }

    static void Print(string[,] field)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write(field[i,j]);
            }

            Console.WriteLine();
        }
    }

    static string[,] FillCanvas(string[,] field, string symbol)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                field[i,j] = symbol;
            }
        }

        return field;
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
}
