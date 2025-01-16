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
        string[,] triangle = DrawTriangle(FillCanvas(new string[3,3]));
        Print(triangle);

        Console.WriteLine("ende");

        Print(triangle);
        Print(MirrorX(triangle));
        Print(MirrorY(triangle));
        Print(MirrorY(MirrorX(triangle)));
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
        string[,] ret = new string[field.GetLength(0), field.GetLength(1)];
        // 1.) besuche jedes Feld im Array (wie wird das in der Methode print gemacht?)
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++) 
            {
                // 2.) schiebe jedes Feld auf einen neuen Ort (field[length-1-y,x] = field[y,x]). 
                ret[field.GetLength(0) - 1 - y, x] = field[y, x];
            }
        }

        return ret;
    }

    static string[,] MirrorY(string[,] field)
    {
        string[,] ret = new string[field.GetLength(0), field.GetLength(1)];
        // 1.) besuche jedes Feld im Array (wie wird das in der Methode print gemacht?)
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                // 2.) schiebe jedes Feld auf einen neuen Ort (field[y,length-1-x] = field[y,x]). 
                ret[field.GetLength(0) - 1 - y, x] = field[y, x];
            }
        }

        return ret;
    }
}
