using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

// ################################### Main - Auswahl der Schritte ###################################
Console.OutputEncoding = Encoding.UTF8;
//Schritt1();
Schritt2();
//Schritt3();
//Schritt3_kurz();

// Funktionen für einzelne Schritte aus der Angabe 
// ################################### Schritt 1 ###################################
// Im Schritt 1 funktioniert:
// - 0 5 und 7 7

// Anmerkung:
// Wir haben zwar nicht alle Fälle hier abgedeckt, es entstehen also Bugs und Fehler,
// aber die Logik ist prinzipiell implementiert! Es beinhaltet die essenziellen Teile fürs Verständnis.

// folgendes funktioniert noch nicht:
// - Was passiet wenn wir ein groesseres Delta y als Delta x haben? (Teste: 5 0 und 7 7)
// - Was wenn wir einen Zug von rechts lach links machen? (Teste: 7 7 und 5 0)
// - Was wenn wir einen Zug von unten nach oben machen? (Teste: 7 7 und 5 0)
// - Was ist wenn wir einen geraden Zug machen? Eine Richtung hat dadurch keine Steigung. (0 7 und 0 0 und 0 7 und 5 7)

// In all diesen Fällen haben wir zwar pinzipiell die richtige Logik, jedoch ändern sich Kleinigkeiten.
// Versuche über diese Fälle nachzudenken indem du die oben genannten Tests ausführst und dir den Output/Fehler anschaust. 
// Verwende dazu auch den DebugModus.

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
// Im Schritt 2 funktioniert:
// - 0 5 und 7 7
// - 5 0 und 7 7
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

        int longerDelta;
        bool longerIsX;

        // TODO: BEGINN der Logik - implementiere hier!
        // Was ist die Längere Seite? Merke die diese und drehen deltaY / deltaX um.
        if (Math.Abs(deltaX) > Math.Abs(deltaY))
        {
            steigung = ((double)deltaY) / deltaX;
            longerDelta = deltaX;
            longerIsX = true;
        }
        else
        {
            steigung = ((double)deltaX) / deltaY;
            longerDelta = deltaY;
            longerIsX = false;
        }

        // Wie zuvor, aber wir gehen nun die längere Seite ab.
        for (int i = 1; i < Math.Abs(longerDelta); i++)
        {
            int neuePositionX;
            int neuePositionY;

            // Es gibt zwei Fälle: wenn y länger ist.
            if (longerIsX)
            {
                neuePositionY = yStart + Convert.ToInt32(Math.Round(i * steigung));
                neuePositionX = xStart + i;
            }
            // Es gibt zwei Fälle: wenn x länger ist.
            else
            {
                neuePositionY = yStart + i;
                neuePositionX = (int)Math.Round(xStart + i * steigung);
            }

            field[neuePositionY, neuePositionX] = lineSymbol;
            //Print(field, dimension);
        }

        // ENDE der Logik

        Print(field, dimension);
        zufrieden = HandleUserInputForRepeatingTheGame();

    } while (zufrieden);
}

// ################################### Schritt 3 ###################################
// Im Schritt 3 funktioniert:
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
        double steigung;

        int longerDelta;
        int shorterDelta;
        int startLonger;
        int startShorter;
        bool longerIsX;

        // TODO: BEGINN der Logik - implementiere hier!
        if (Math.Abs(deltaX) > Math.Abs(deltaY))
        {
            longerDelta = deltaX;
            shorterDelta = deltaY;
            startLonger = xStart;
            startShorter = yStart;
            longerIsX = true;

        }
        else
        {
            longerDelta = deltaY;
            shorterDelta = deltaX;
            startLonger = yStart;
            startShorter = xStart;
            longerIsX = false;
        }

        for (int i = 1; i < Math.Abs(longerDelta); i++)
        {
            int indexForShorter;
            int indexForLonger;

            if (shorterDelta < 0 && longerDelta < 0)
            {
                indexForLonger = startLonger - i;
                steigung = -((double)shorterDelta) / longerDelta;

            }
            else if (shorterDelta < 0 && longerDelta > 0)
            {
                indexForLonger = startLonger + i;
                steigung = ((double)shorterDelta) / longerDelta;

            }
            else if (shorterDelta > 0 && longerDelta < 0)
            {
                indexForLonger = startLonger - i;
                steigung = -((double)shorterDelta) / longerDelta;

            }
            else if (shorterDelta > 0 && longerDelta > 0)
            {
                indexForLonger = startLonger + i;
                steigung = ((double)shorterDelta) / longerDelta;

            }
            else if (shorterDelta == 0 && longerDelta > 0)
            {
                indexForLonger = startLonger + i;
                steigung = ((double)shorterDelta) / longerDelta;

            }
            else if (shorterDelta == 0 && longerDelta < 0)
            {
                indexForLonger = startLonger - i;
                steigung = ((double)shorterDelta) / longerDelta;

            }
            else
            {
                indexForLonger = -1;
                steigung = Double.MaxValue;
            }

            indexForShorter = (int)Math.Round(startShorter + i * steigung);

            if (longerIsX)
            {
                field[indexForShorter, indexForLonger] = lineSymbol;
            }
            else
            {
                field[indexForLonger, indexForShorter] = lineSymbol;
            }
        }

        // ENDE der Logik

        Print(field, dimension);
        zufrieden = HandleUserInputForRepeatingTheGame();

    } while (zufrieden);
}

// ################################### Schritt 3 - kurz ###################################
// Im Schritt 3 - kurz funktioniert:
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

void Schritt3_kurz()
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