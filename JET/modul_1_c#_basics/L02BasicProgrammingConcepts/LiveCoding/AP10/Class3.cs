using System.Text;

namespace Schachbrett;

class LinienAufSchachbrett
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        string promtForUser = "Größe des Spielbretts eingeben: ";
        // user input -> System.Read

        while (!int.TryParse(Console.ReadLine(), out int dimension))
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Input is not an integer. Please try again.");
            Console.ResetColor();

            Console.WriteLine(promptForUser);
        }

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