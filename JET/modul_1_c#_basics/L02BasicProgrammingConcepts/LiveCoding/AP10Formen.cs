using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LiveCoding;

class AP10Formen
{
    static void Main(string[] args)
    {
        string[,] field = FillCanvas(new string[3, 3]);
        Print(field);

        MirrorX(field);
    }

    static string[,] FillCanvas(string[,] field)
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                field[y, x] = "_";
            }
        }

        return field;
    }

    static void Print(string[,] field)
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                Console.Write(field[y, x]);
            }

            Console.WriteLine();
        }
    }


    static string[,] DrawTriangle(string[,] field)
    {
        // 1.) zeichne 
        // ___
        // ___
        // ___
        //
        // #__
        // ##_
        // ###
        // in field rein.

        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (x <= y)
                {
                    field[y, x] = "#";
                }
            }
        }

        return field;

    }

    static string[,] MirrorX(string[,] field)
    {
        // 1.) besuche jedes Feld im Array (wie wird das in der Methode print gemacht?)
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++) 
            {
                // 2.) schiebe jedes Feld auf einen neuen Ort (field[length-1-y,x] = field[y,x]). 
                field[field.GetLength(0) - 1 - y, x] = field[y, x];
            }
        }

        return field;
    }

    static string[,] MirrorY(string[,] field)
    {
       // (field[y, x] = field[y, length - 1 - y]).
        return null;
    }
}
