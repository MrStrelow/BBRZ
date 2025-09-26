using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

// ################################### Main - Auswahl der Schritte ###################################
Console.OutputEncoding = Encoding.UTF8;
//Schritt1();
Schritt2();
//Schritt3();

// Funktionen für einzelne Schritte aus der Angabe 
// ################################### Schritt 1 ###################################
void Schritt1()
{
    bool zufrieden;
    int dimension = HandleUserInputOfSetup();

    Console.Clear();

    // multidimensionales array anlegen.
    string whiteSquare = "🔲";
    string blackSquare = "🔳";
    string startSymbol = "🏌🏻";
    string destSymbol = "⛳"; // dest ist die abküzrung für destination -> das Ziel.
    string lineSymbol = "🔸";

    string[,] field = GenerateSchessBoard(dimension, whiteSquare, blackSquare);

    do
    {
        int[] positions = HandleUserInputDuringGame(); 
        // Wem das nicht gefällt, bitte Tuple anschauen. Wir machen es in Modul 2. Dann geht es in einer Zeile.
        int xStart = positions[0];
        int yStart = positions[1];
        int xDest  = positions[2];
        int yDest  = positions[3];

        field[yStart, xStart] = startSymbol;
        field[yDest, xDest] = destSymbol;

        int deltaX = xDest - xStart;
        int deltaY = yDest - yStart;
        double steigung;

        // TODO: BEGINN der Logik - implementiere hier!
        steigung = Math.Abs(((double)deltaY) / deltaX);

        for (int x = 1; x < deltaX; x++)
        {
            int y = Convert.ToInt32(Math.Round(steigung * x));
            field[yStart + y, xStart + x] = lineSymbol;
        }

        // ENDE der Logik

        Print(field, dimension);
        zufrieden = HandleUserInputForRepeatingTheGame();

    } while (zufrieden);
}

// ################################### Schritt 2 ###################################
void Schritt2()
{
    bool zufrieden;
    int dimension = HandleUserInputOfSetup();

    Console.Clear();

    // multidimensionales array anlegen.
    string whiteSquare = "🔲";
    string blackSquare = "🔳";
    string startSymbol = "🏌🏻";
    string destSymbol = "⛳"; // dest ist die abküzrung für destination -> das Ziel.
    string lineSymbol = "🔸";

    string[,] field = GenerateSchessBoard(dimension, whiteSquare, blackSquare);

    do
    {
        int[] positions = HandleUserInputDuringGame();
        // Wem das nicht gefällt, bitte Tuple anschauen. Wir machen es in Modul 2. Dann geht es in einer Zeile.
        int xStart = positions[0];
        int yStart = positions[1];
        int xDest = positions[2];
        int yDest = positions[3];

        field[yStart, xStart] = startSymbol;
        field[yDest, xDest] = destSymbol;

        int deltaX = xDest - xStart;
        int deltaY = yDest - yStart;
        double steigung;

        // TODO: BEGINN der Logik - implementiere hier!
        // 1) Bestimme die Schleifenlänge - flach vs. steil
        int loopLength = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));
        int currentX, currentY;

        // 2.) Eine einzige Schleife, die für jeden Schritt der Linie einmal durchläuft.
        for (int i = 1; i < loopLength; i++)
        {
            // 3. In JEDEM Schritt wird geprüft, welcher der 8 Fälle zutrifft, um die aktuellen Koordinaten zu berechnen.

            // Fall 1: Rechts, Unten, Flach
            if (deltaX > 0 && deltaY >= 0 && Math.Abs(deltaX) >= Math.Abs(deltaY))
            {
                steigung = (double)deltaY / deltaX;
                currentX = xStart + i;
                currentY = (int)Math.Round(yStart + i * steigung);
                field[currentY, currentX] = lineSymbol;
            }
            // Fall 2: Rechts, Unten, Steil
            else if (deltaX > 0 && deltaY > 0 && Math.Abs(deltaX) < Math.Abs(deltaY))
            {
                steigung = (double)deltaX / deltaY;
                currentY = yStart + i;
                currentX = (int)Math.Round(xStart + i * steigung);
                field[currentY, currentX] = lineSymbol;
            }
            // Fall 3: Links, Unten, Steil
            else if (deltaX <= 0 && deltaY > 0 && Math.Abs(deltaX) <= Math.Abs(deltaY))
            {
                steigung = (double)deltaX / deltaY;
                currentY = yStart + i;
                currentX = (int)Math.Round(xStart + i * steigung);
                field[currentY, currentX] = lineSymbol;
            }
            // Fall 4: Links, Unten, Flach
            else if (deltaX < 0 && deltaY >= 0 && Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                steigung = (double)deltaY / deltaX;
                currentX = xStart - i;
                currentY = (int)Math.Round(yStart - i * steigung);
                field[currentY, currentX] = lineSymbol;
            }
            // Fall 5: Links, Oben, Flach
            else if (deltaX < 0 && deltaY <= 0 && Math.Abs(deltaX) >= Math.Abs(deltaY))
            {
                steigung = (double)deltaY / deltaX;
                currentX = xStart - i;
                currentY = (int)Math.Round(yStart - i * steigung);
                field[currentY, currentX] = lineSymbol;
            }
            // Fall 6: Links, Oben, Steil
            else if (deltaX < 0 && deltaY < 0 && Math.Abs(deltaX) < Math.Abs(deltaY))
            {
                steigung = (double)deltaX / deltaY;
                currentY = yStart - i;
                currentX = (int)Math.Round(xStart - i * steigung);
                field[currentY, currentX] = lineSymbol;
            }
            // Fall 7: Rechts, Oben, Steil
            else if (deltaX >= 0 && deltaY < 0 && Math.Abs(deltaX) <= Math.Abs(deltaY))
            {
                steigung = (double)deltaX / deltaY;
                currentY = yStart - i;
                currentX = (int)Math.Round(xStart - i * steigung);
                field[currentY, currentX] = lineSymbol;
            }
            // Fall 8: Rechts, Oben, Flach
            else if (deltaX > 0 && deltaY < 0 && Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                steigung = (double)deltaY / deltaX;
                currentX = xStart + i;
                currentY = (int)Math.Round(yStart + i * steigung);
                field[currentY, currentX] = lineSymbol;
            }
        }

        // ENDE der Logik

        Print(field, dimension);
        zufrieden = HandleUserInputForRepeatingTheGame();

    } while (zufrieden);
}

// ################################### Schritt 3 - kurz ###################################
void Schritt3()
{
    bool zufrieden;
    int dimension = HandleUserInputOfSetup();

    Console.Clear();

    // multidimensionales array anlegen.
    string whiteSquare = "🔲";
    string blackSquare = "🔳";
    string startSymbol = "🏌🏻";
    string destSymbol = "⛳"; // dest ist die abküzrung für destination -> das Ziel.
    string lineSymbol = "🔸";

    string[,] field = GenerateSchessBoard(dimension, whiteSquare, blackSquare);

    do
    {
        int[] positions = HandleUserInputDuringGame();
        // Wem das nicht gefällt, bitte Tuple anschauen. Wir machen es in Modul 2. Dann geht es in einer Zeile.
        int xStart = positions[0];
        int yStart = positions[1];
        int xDest = positions[2];
        int yDest = positions[3];

        field[yStart, xStart] = startSymbol;
        field[yDest, xDest] = destSymbol;

        int deltaX = xDest - xStart;
        int deltaY = yDest - yStart;

        int longerDelta;

        // TODO: BEGINN der Logik - implementiere hier!
        longerDelta = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));
        double steigungVerkehrt = (double)deltaX / longerDelta;
        double steigung = (double)deltaY / longerDelta;

        for (int i = 1; i < longerDelta; i++)
        {
            int x = xStart + (int)Math.Round(i * steigungVerkehrt);
            int y = yStart + (int)Math.Round(i * steigung);
            field[y, x] = "🔸";
        }

        // ENDE der Logik

        Print(field, dimension);
        zufrieden = HandleUserInputForRepeatingTheGame();

    } while (zufrieden);
}

// #################### Hilfsfunktionen ####################
int HandleUserInputOfSetup()
{
    string prompt = "Größe des Spielfields eingeben:";
    Console.Write($"{prompt} ");

    int dimension;
    string userinput = Console.ReadLine();
    while (!int.TryParse(userinput, out dimension))
    {
        PrepareConsoleFormatAndPrintErrorPrompt("Bitte eine positive Zahl ohne Komma eingeben.", userinput);
        Console.Write($"{prompt} ");
        userinput = Console.ReadLine();
    }

    return dimension;
}

int[] HandleUserInputDuringGame()
{
    int[] startPos = HandleUserInputOfBoardPositions("Wähle die Figur... [x y]:");
    int[] endPos = HandleUserInputOfBoardPositions("... und wähle das Ziel [x y]:");
    return [startPos[0], startPos[1], endPos[0], endPos[1]];
}

int[] HandleUserInputOfBoardPositions(string prompt)
{
    int x, y; // Abgekürzte Schreibeweise, anstatt zwei Zeilen für Definition zu verwenden.

    Console.Write($"{prompt} ");
    string[] userinput = Console.ReadLine().Split(" ");

    while (!(userinput.Length == 2 &&
        int.TryParse(userinput[0], out x) &&
        int.TryParse(userinput[1], out y)))
    {
        PrepareConsoleFormatAndPrintErrorPrompt("Bitte geben Sie ZWEI ganze Zahlen, getrennt durch ein Leerzeichen, ein.", string.Join(" ", userinput));
        Console.Write($"{prompt} ");
        userinput = Console.ReadLine().Split(" ");
    }

    return [x, y];
}

bool HandleUserInputForRepeatingTheGame()
{
    string prompt = "weiter? [true/false]:";
    Console.Write($"{prompt} ");
    bool choice;
    string userinput = Console.ReadLine();

    while (!bool.TryParse(userinput, out choice))
    {
        PrepareConsoleFormatAndPrintErrorPrompt("Bitte geben Sie das Wort true oder false ein.", userinput);
        Console.Write($"{prompt} ");
        userinput = Console.ReadLine();
    }

    return choice;
}

void PrepareConsoleFormatAndPrintErrorPrompt(string prompt, string erronousInput) {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Ungültige Eingabe: { string.Join(" ", erronousInput)} - {prompt}");
    Console.ResetColor();
}

string[,] GenerateSchessBoard(int dimension, string whiteSquare, string blackSquare)
{
    string[,] field = new string[dimension, dimension];
    // Erstelle ein Schachbrettmuster beliebiger Größe welche vom User bestimmt wird.
    for (int i = 0; i < dimension; i++)
    {
        for (int j = 0; j < dimension; j++)
        {
            if ((j + i) % 2 == 0)
            {
                field[i, j] = whiteSquare;
            }
            else
            {
                field[i, j] = blackSquare;
            }
        }
    }

    return field;
}

void Print(string[,] field, int dimension)
{
    for (int i = 0; i < dimension; i++)
    {
        for (int j = 0; j < dimension; j++)
        {
            Console.Write(field[i, j]);
        }
        Console.WriteLine();
    }
}