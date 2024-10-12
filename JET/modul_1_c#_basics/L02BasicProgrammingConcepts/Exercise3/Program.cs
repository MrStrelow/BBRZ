public class Exercise
{
    public static void Main(string[] args)
    {
        bool zufrieden;

        Console.Write("Größe des Spielbretts eingeben: ");
        int dimension = int.Parse(Console.ReadLine());

        string[,] brett = new string[dimension, dimension];

        string whiteSquare = "\u2588";
        // Oder
        string blackSquare = '\u2591'.ToString();

        // Erstelle ein Schachbrettmuster beliebiger Größe welche vom User bestimmt wird.
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                if ((j + i) % 2 == 0)
                    brett[i, j] = whiteSquare;
                else
                    brett[i, j] = blackSquare;
            }
        }


        do { 
            // Userinput
            Console.Write("Wähle die Figur... [x y]: ");
            string[] userinput = Console.ReadLine().Split(" ");

            int xStart = int.Parse(userinput[0]);
            int yStart = int.Parse(userinput[1]);

            Console.Write("... und wähle das Ziel [x y]: ");
            userinput = Console.ReadLine().Split(" ");

            int xZiel = int.Parse(userinput[0]);
            int yZiel = int.Parse(userinput[1]);

            brett[yStart, xStart] = "o";
            brett[yZiel, xZiel] = "x";

            int deltaX = xZiel - xStart;
            int deltaY = yZiel - yStart;
            double steigung;
            int longerDelta;
            bool longerIsX;
            int chosenY;
            int chosenX;

            Console.WriteLine("++++++++++++++ Version 3 ++++++++++++++");

            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                steigung = (0.0 + deltaY) / deltaX;
                longerDelta = deltaX;
                longerIsX = true;
            }
            else
            {
                steigung = (0.0 + deltaX) / deltaY;
                longerDelta = deltaY;
                longerIsX = false;
            }

            chosenX = xStart;
            chosenY = yStart;

            for (int i = 1; i < Math.Abs(longerDelta); i++)
            {
                int neuePositionX;
                int neuePositionY;

                if (longerIsX)
                {
                    if (deltaY < 0)
                    {
                        neuePositionX = chosenX - i;
                        neuePositionY = (int)Math.Round(chosenY - i * steigung);
                    }
                    else
                    {
                        neuePositionX = chosenX + i;
                        neuePositionY = (int)Math.Round(chosenY + i * steigung);
                    }
                }
                else
                {
                    if (deltaX < 0)
                    {
                        neuePositionY = chosenY - i;
                        neuePositionX = (int)Math.Round(chosenX - i * steigung);
                    }
                    else
                    {
                        neuePositionY = chosenY + i;
                        neuePositionX = (int)Math.Round(chosenX + i * steigung);
                    }
                }

                brett[neuePositionY, neuePositionX] = ".";
            }

            // Ausgabe
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(brett[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("weiter? [true/false]");
            zufrieden = bool.Parse(Console.ReadLine());

        } while(zufrieden);
    }
}