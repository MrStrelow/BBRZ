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
        string[,] triangle = DrawTriangle(FillCanvas(new string[9,9]));
        string[,] container = FillCanvas(new string[2 * triangle.GetLength(0), 2 * triangle.GetLength(1)]);

        Print(CombineForm(container, triangle, Position.TOP_RIGHT));
        Console.WriteLine();

        Print(CombineForm(container, MirrorY(triangle), Position.TOP_LEFT));
        Console.WriteLine();

        Print(CombineForm(container, MirrorX(MirrorY(triangle)), Position.BOT_LEFT));
        Console.WriteLine();

        Print(CombineForm(container, MirrorX(triangle), Position.BOT_RIGHT));
        
        // Warum geht das?... denke an call by value und call by reference.
        //Print(CombineForm(container, MirrorY(triangle), Position.TOP_LEFT));
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
                ret[y, field.GetLength(1) - 1 - x] = field[y, x];
            }
        }

        return ret;
    }

    static string[,] CombineForm(string[,] container, string[,] part, Position position)
    {
        for (int y = 0; y < part.GetLength(0); y++)
        {
            for (int x = 0; x < part.GetLength(1); x++)
            {
                switch(position)
                {
                    case Position.TOP_RIGHT: container[y, x + part.GetLength(1)] = part[y, x]; break;
                    case Position.TOP_LEFT:  container[y, x] = part[y, x]; break;
                    case Position.BOT_RIGHT: container[y + part.GetLength(0), x + part.GetLength(1)] = part[y, x]; break;
                    case Position.BOT_LEFT:  container[y + part.GetLength(0), x] = part[y, x]; break;
                }
            }
        }

        return container;
    }
}

enum Position
{
    TOP_RIGHT, TOP_LEFT, BOT_RIGHT, BOT_LEFT
}
