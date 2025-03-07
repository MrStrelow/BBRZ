using System.Runtime.InteropServices;
using System.Text;

public class Exercise
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        bool zufrieden;
        string promptForUser = "Größe des Spielfields eingeben: ";

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

        // 1Achtung! Nicht alle Emojis (16-32 Bit) haben in einem char platz (16 Bit) -
        // manche sind zwei uni codes welche ein string versteht, aber ein char nicht.
        // string blackSquare = '\u2B1B'.ToString(); // wir können aber weiße und schwarze kästchen mit 16bit chars verwenden.
        // Strings sind jeodch angenehmer.
        // string whiteSquare = "\u2B1C";

        string whiteSquare = "⬜";
        string blackSquare = "⬛";

        // Erstelle ein Schachbrettmuster beliebiger Größe welche vom User bestimmt wird.
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                //if ((j + i) % 2 == 0)
                if ((j % 2 == 0 && i % 2 == 0) || (j % 2 == 1 && i % 2 == 1))
                    field[i, j] = whiteSquare;
                else
                    field[i, j] = blackSquare;
            }
        }

        do {
            // Userinput - Wir verzichten hier auf Fehlerbehandlungen.
            Console.Write("Wähle die Figur... [x y]: ");
            string[] userinput = Console.ReadLine().Split(" ");

            int xStart = int.Parse(userinput[0]);
            int yStart = int.Parse(userinput[1]);

            Console.Write("... und wähle das Ziel [x y]: ");
            userinput = Console.ReadLine().Split(" ");

            int xZiel = int.Parse(userinput[0]);
            int yZiel = int.Parse(userinput[1]);

            field[yStart, xStart] = "🟡";
            field[yZiel, xZiel] = "❌";

            int deltaX = xZiel - xStart;
            int deltaY = yZiel - yStart;
            double steigung;
            int longerDelta;
            int shorterDelta;
            int startLonger;
            int startShorter;
            bool longerIsX;

            // Variante 1: Wir haben zwar nicht alle Fälle hier abgedeckt, es entstehen also Bugs und Fehler,
            // aber die Logik ist prinzipiell implementiert!
            // Die Variante 1 beinhaltet die essenziellen Teile fürs Verständnis.
            // Kommentiere diese aus, wenn die Version 2 bzw. 3 verwendet werden soll.

            // Die erwänten Fälle sind folgende:
            // - Was passiet wenn wir ein groesseres Delta y als Delta x haben? (Teste: 5 0 und 7 7)
            // - Was wenn wir einen Zug von rechts lach links machen? (Teste: 7 7 und 5 0)
            // - Was wenn wir einen Zug von unten nach oben machen? (Teste: 7 7 und 5 0)
            // - Was ist wenn wir einen geraden Zug machen? Eine Richtung hat dadurch keine Steigung. (0 7 und 0 0 und 0 7 und 5 7)

            // In all diesen Fällen haben wir zwar pinzipiell die richtige Logik, jedoch ändern sich Kleinigkeiten.
            // Versuche über diese Fälle nachzudenken indem du die oben genannten Tests ausführst und dir den Output/Fehler anschaust. 
            // Verwende dazu auch den DebugModus.

            // In der Variante 1 funktioniert:
            // - 0 5 und 7 7
            // aber nicht:
            // - 5 0 und 7 7
            // - 5 7 und 7 0
            // - 0 7 und 7 5
            // - 7 7 und 0 5
            // - 7 7 und 5 0
            // - 5 7 und 0 7
            // - 0 7 und 5 7
            // - 0 5 und 7 7
            // - 0 0 und 0 7
            // - 0 7 und 0 0

            //Console.WriteLine("++++++++++++++ version 1 ++++++++++++++");
            //steigung = Math.Abs(((double) deltaY) / deltaX);

            //for (int x = 1; x < deltaX; x++)
            //{
            //    int y = Convert.ToInt32(Math.Round(steigung * x));
            //    field[yStart + y, xStart + x] = ".";
            //}

            //// ausgabe
            //for (int i = 0; i < dimension; i++)
            //{
            //    for (int j = 0; j < dimension; j++)
            //    {
            //        Console.Write(field[i, j]);
            //    }
            //    Console.WriteLine();
            //}


            //Console.WriteLine("++++++++++++++ Version 2 ++++++++++++++");

            //// In der Variante 2 funktioniert:
            //// - 0 5 und 7 7
            //// - 5 0 und 7 7
            //// aber nicht:
            //// - 5 7 und 7 0
            //// - 0 7 und 7 5
            //// - 7 7 und 0 5
            //// - 7 7 und 5 0
            //// - 5 7 und 0 7
            //// - 0 7 und 5 7
            //// - 0 5 und 7 7
            //// - 0 0 und 0 7
            //// - 0 7 und 0 0

            //if (Math.Abs(deltaX) > Math.Abs(deltaY))
            //{
            //    steigung = ((double)deltaY) / deltaX;
            //    longerDelta = deltaX;
            //    longerIsX = true;

            //}
            //else
            //{
            //    steigung = ((double)deltaX) / deltaY;
            //    longerDelta = deltaY;
            //    longerIsX = false;
            //}

            //for (int i = 1; i < Math.Abs(longerDelta); i++)
            //{
            //    int neuePositionX;
            //    int neuePositionY;

            //    if (longerIsX)
            //    {
            //        neuePositionY = (int)Math.Round(yStart + i * steigung);
            //        neuePositionX = xStart + i;
            //    }
            //    else
            //    {
            //        neuePositionY = yStart + i;
            //        neuePositionX = (int)Math.Round(xStart + i * steigung);
            //    }

            //    field[neuePositionY, neuePositionX] = ".";
            //}

            //// ausgabe
            //for (int i = 0; i < dimension; i++)
            //{
            //    for (int j = 0; j < dimension; j++)
            //    {
            //        Console.Write(field[i, j]);
            //    }
            //    Console.WriteLine();
            //}


            //Console.WriteLine("++++++++++++++ Version 3 ++++++++++++++");
            // In dieser Variante sind alle Fälle abgedeckt.
            // Wir sehen hier einige "technische" anpassungen.
            // - wir drehen manchmal das Vorzeichen der Steigung um
            // - wir gehen mit der For-Loop in verschiedene Richtungen, je nachdem wie die Start und Endpunkte liegen.

            // Wir können nun Versuchen "smartere" Lösungsansätze zu finden.
            // Anreize dafür sind:
            // - Wir können uns Code sparen wenn wir vorher das Problem und "herrichten". Das beduetet,
            //      - ob wir beginnen vom Start zum Ziel zu zeichnen, oder vom Ziel zum Start ist eigentlich egal.
            //      - ob wir von [0 0] zu [7 7] fahren ist das gleiche wie [0 7] zu [7 0], wenn das Spielfeld vorher 90° nach links gedreht wird.

            // Tests:
            // - 0 5 und 7 7
            // - 5 0 und 7 7
            // - 5 7 und 7 0
            // - 0 7 und 7 5
            // - 7 7 und 0 5
            // - 7 7 und 5 0
            // - 5 7 und 0 7
            // - 0 7 und 5 7
            // - 0 5 und 7 7
            // - 0 0 und 0 7
            // - 0 7 und 0 0

            //if (Math.Abs(deltaX) > Math.Abs(deltaY))
            //{
            //    longerDelta = deltaX;
            //    shorterDelta = deltaY;
            //    startLonger = xStart;
            //    startShorter = yStart;
            //    longerIsX = true;

            //}
            //else
            //{
            //    longerDelta = deltaY;
            //    shorterDelta = deltaX;
            //    startLonger = yStart;
            //    startShorter = xStart;
            //    longerIsX = false;
            //}

            //for (int i = 1; i < Math.Abs(longerDelta); i++)
            //{
            //    int indexForShorter;
            //    int indexForLonger;

            //    if (shorterDelta < 0 && longerDelta < 0)
            //    {
            //        indexForLonger = startLonger - i;
            //        steigung = -((double)shorterDelta) / longerDelta;

            //    }
            //    else if (shorterDelta < 0 && longerDelta > 0)
            //    {
            //        indexForLonger = startLonger + i;
            //        steigung = ((double)shorterDelta) / longerDelta;

            //    }
            //    else if (shorterDelta > 0 && longerDelta < 0)
            //    {
            //        indexForLonger = startLonger - i;
            //        steigung = -((double)shorterDelta) / longerDelta;

            //    }
            //    else if (shorterDelta > 0 && longerDelta > 0)
            //    {
            //        indexForLonger = startLonger + i;
            //        steigung = ((double)shorterDelta) / longerDelta;

            //    }
            //    else if (shorterDelta == 0 && longerDelta > 0)
            //    {
            //        indexForLonger = startLonger + i;
            //        steigung = ((double)shorterDelta) / longerDelta;

            //    }
            //    else if (shorterDelta == 0 && longerDelta < 0)
            //    {
            //        indexForLonger = startLonger - i;
            //        steigung = ((double)shorterDelta) / longerDelta;

            //    }
            //    else
            //    {
            //        indexForLonger = -1;
            //        steigung = Double.MaxValue;
            //    }

            //    indexForShorter = (int)Math.Round(startShorter + i * steigung);

            //    if (longerIsX)
            //    {
            //        field[indexForShorter, indexForLonger] = "🔸";
            //    }
            //    else
            //    {
            //        field[indexForLonger, indexForShorter] = "🔸";
            //    }
            //}

            Console.WriteLine("++++++++++++++ Version 4 ++++++++++++++");
            // Tests:
            // - 0 5 und 7 7
            // - 5 0 und 7 7
            // - 5 7 und 7 0
            // - 0 7 und 7 5
            // - 7 7 und 0 5
            // - 7 7 und 5 0
            // - 5 7 und 0 7
            // - 0 7 und 5 7
            // - 0 5 und 7 7
            // - 0 0 und 0 7
            // - 0 7 und 0 0

            longerDelta = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));
            double stepX = (double)deltaX / longerDelta;
            double stepY = (double)deltaY / longerDelta;

            for (int i = 1; i < longerDelta; i++)
            {
                int x = xStart + (int)Math.Round(i * stepX);
                int y = yStart + (int)Math.Round(i * stepY);
                field[y,x] = "🔸";
            }
            

            // ausgabe
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("weiter? [true/false]");
            zufrieden = bool.Parse(Console.ReadLine());

        } while (zufrieden);
    }
}