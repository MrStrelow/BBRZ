using System.Text;

namespace Schachfield;

class LinienAufSchachfield
{
   static void Main(string[] args)
   {
       Console.OutputEncoding = Encoding.UTF8;
       string promptForUser = "Größe des Spielfields eingeben (gib 20 ein): ";

       // user input -> System.Read
       Console.WriteLine(promptForUser);

       int dimension;
       while (!int.TryParse(Console.ReadLine(), out dimension))
       {
           Console.Clear();
           Console.ForegroundColor = ConsoleColor.Red;
           Console.WriteLine("Input is not an integer. Please try again.");
           Console.ResetColor();

           Console.Write(promptForUser);
       }

       Console.Clear();

       // multidimensionales array anlegen.
       string[,] field = new string[dimension, dimension];
       string whiteSquare = "⬜";
       string blackSquare = "⬛";

       // schachfield generiern
       // - Konzepte: nested for loop, if bedingung, modulo
       //for (int y = 0; y < field.GetLength(0); y++)
       //{
       //    for (int x = 0; x < field.GetLength(1); x++)
       //    {
       //        if (x % 2 == 0)
       //        {
       //            if (y % 2 == 0)
       //            {
       //                field[y, x] = blackSquare;
       //            }
       //            else
       //            {
       //                field[y, x] = whiteSquare;
       //            }
       //        } 
       //        else
       //        {
       //            if (y % 2 == 0)
       //            {
       //                field[y, x] = whiteSquare;
       //            }
       //            else
       //            {
       //                field[y, x] = blackSquare;
       //            }
       //        }
       //    }
       //}

       for (int i = 0; i < field.GetLength(0); i++)
       {
           for (int j = 0; j < field.GetLength(0); j++)
           {
               //if ( (j % 2 == 0 && i % 2 == 1) || (j % 2 == 1 && i % 2 == 0) )
               if ((i + j) % 2 == 1)
               {
                   field[i, j] = blackSquare;
               }
               else
               {
                   field[i, j] = whiteSquare;
               }
           }
       }

       //Console.WriteLine("Bitte Start Koordinaten angeben [y x]: ");
       //string[] userinput = Console.ReadLine().Split(" ");
       //int yStart = int.Parse(userinput[0]);
       //int xStart = int.Parse(userinput[1]);

       //Console.WriteLine("Bitte Ziel Koordinaten angeben [y x]: ");
       //userinput = Console.ReadLine().Split(" ");
       //int yEnd = int.Parse(userinput[0]);
       //int xEnd = int.Parse(userinput[1]);

       int yStart = 0;
       int xStart = 3;
       field[yStart, xStart] = "💢";

       int yZiel = 12;
       int xZiel = 15;
       field[yZiel, xZiel] = "💥";


       int deltaX = xZiel - xStart;
       int deltaY = yZiel - yStart;

       double steigung = (double)deltaY / deltaX;

       for (int x = xStart + 1; x < xStart + deltaX; x++)
       {
           int y = Convert.ToInt32(Math.Round(steigung * x));
           field[y, x] = "🟡";
       }


       // output
       for (int i = 0; i < field.GetLength(0); i++)
       {
           for (int j = 0; j < field.GetLength(0); j++)
           {
               Console.Write(field[i, j]);
           }
           Console.WriteLine();
       }
   }
}