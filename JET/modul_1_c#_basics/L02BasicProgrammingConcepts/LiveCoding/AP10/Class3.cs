using System.Text;

namespace Schachbrett;

class LinienAufSchachbrett
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        string promptForUser = "Größe des Spielbretts eingeben: ";
        
        // user input -> System.Read
        Console.WriteLine(promptForUser);
        
        int dimension;
        while (!int.TryParse(Console.ReadLine(), out dimension))
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Input is not an integer. Please try again.");
            Console.ResetColor();

            Console.WriteLine(promptForUser);
        }

        Console.Clear();

        // multidimensionales array anlegen.
        string[,] field = new string[dimension, dimension];
        string whiteSquare = "⬜";
        string blackSquare = "⬛";

        // schachbrett generiern
        // - Konzepte: nested for loop, if bedingung, modulo

        for (int i = 0; i < field.GetLength(0); i++ )
        {
            for (int j = 0; j < field.GetLength(0); j++)
            {
                //if ( (j % 2 == 0 && i % 2 == 1) || (j % 2 == 1 && i % 2 == 0) )
                if ( (i + j) % 2 == 1 )
                {
                    field[i, j] = blackSquare;
                }
                else
                {
                    field[i, j] = whiteSquare;
                }
            }
        }

        int yStart = 0;
        int xStart = 0;
        field[yStart, xStart] = "💢";

        int yZiel = 2;
        int xZiel = 4;
        field[yZiel, xZiel] = "💥";


        int deltaX = xZiel - xStart;
        int deltaY = yZiel - yStart;

        double steigung = (double) deltaY / deltaX;

        for (int x = 1; x < deltaX; x++)
        {
            int y = Convert.ToInt32(Math.Round(steigung * x));
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