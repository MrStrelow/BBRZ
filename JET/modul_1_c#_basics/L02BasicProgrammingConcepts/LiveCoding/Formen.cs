//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LiveCoding;

//public class Formen
//{
//    static void Main(string[] args)
//    {
//        string triangleSymbol = "#";

//        string[,] baseForm = FillCanvas(new string[5, 5], ".");
//        string[,] triangle = DrawTriangle(baseForm, triangleSymbol);
//        string[,] diamond = DrawDiamond(triangle);
//        Print(diamond);
//    }

//    static string[,] DrawDiamond(string[,] field)
//    {
//        string[,] topRight = Copy(field);
//        string[,] botRight = MirrorX(field);
//        string[,] botLeft = MirrorY(botRight);
//        string[,] topLeft = MirrorX(botLeft);

//        string[,] diamond = new string[field.GetLength(0) * 2, field.GetLength(1) * 2];
//        diamond = CombineForm(diamond, topRight, Position.TOP_RIGHT);
//        diamond = CombineForm(diamond, botRight, Position.BOT_RIGHT);
//        diamond = CombineForm(diamond, botLeft, Position.BOT_LEFT);
//        diamond = CombineForm(diamond, topLeft, Position.TOP_LEFT);

//        return diamond;
//    }

//    static string[,] CombineForm(String[,] container, String[,] part, Position position)
//    {
//        container = Copy(container);
//        int iOffset = part.GetLength(0);
//        int jOffset = part.GetLength(1);

//        for (int i = 0; i < part.GetLength(0); i++)
//        {
//            for (int j = 0; j < part.GetLength(1); j++)
//            {
//                // wir fragen hier leider immer etwas ab (positon), das sich nicht ändern pro Schleife.
//                // Es scheint aber so lesbar zu sein.
//                // Wir lasses es deshalb so.
//                switch (position)
//                {
//                    case Position.TOP_LEFT: container[i, j] = part[i, j]; break;
//                    case Position.BOT_RIGHT: container[i + iOffset, j + jOffset] = part[i, j]; break;
//                    case Position.BOT_LEFT: container[i + iOffset, j] = part[i, j]; break;
//                    case Position.TOP_RIGHT: container[i, j + jOffset] = part[i, j]; break;
//                }
//            }
//        }

//        return container;
//    }

//    enum Position
//    {
//        TOP_RIGHT, TOP_LEFT, BOT_RIGHT, BOT_LEFT
//    }

//    static string[,] DrawTriangle(string[,] field, string symbol)
//    {
//        for (int i = 0; i < field.GetLength(0); i++)
//        {
//            for (int j = 0; j < field.GetLength(1); j++)
//            {
//                if (j <= i)
//                {
//                    field[i, j] = symbol;
//                }
//            }
//        }

//        return field;
//    }

//    static string[,] MirrorX(string[,] field)
//    {
//        string[,] ret = Copy(field);

//        for (int i = 0; i < field.GetLength(0); i++)
//        {
//            for (int j = 0; j < field.GetLength(1); j++)
//            {
//                ret[i, j] = field[field.GetLength(0) - 1 - i, j];
//            }
//        }

//        return ret;
//    }

//    static string[,] MirrorY(string[,] field)
//    {
//        string[,] ret = Copy(field);

//        for (int i = 0; i < field.GetLength(0); i++)
//        {
//            for (int j = 0; j < field.GetLength(1); j++)
//            {
//                ret[i, j] = field[i, field.GetLength(1) - 1 - j];
//            }
//        }

//        return ret;
//    }

//    static void Print(string[,] field)
//    {
//        for (int i = 0; i < field.GetLength(0); i++)
//        {
//            for (int j = 0; j < field.GetLength(1); j++)
//            {
//                Console.Write(field[i, j]);
//            }

//            Console.WriteLine();
//        }
//    }

//    static string[,] FillCanvas(string[,] field, string symbol)
//    {
//        for (int i = 0; i < field.GetLength(0); i++)
//        {
//            for (int j = 0; j < field.GetLength(1); j++)
//            {
//                field[i, j] = symbol;
//            }
//        }

//        return field;
//    }

//    static string[,] Copy(string[,] field)
//    {
//        string[,] ret = new string[field.GetLength(0), field.GetLength(1)];

//        for (int i = 0; i < ret.GetLength(0); i++)
//        {
//            for (int j = 0; j < ret.GetLength(1); j++)
//            {
//                ret[i, j] = field[i, j];
//            }
//        }

//        return ret;
//    }
//}
