using System.Text;

// ################################### Main - Auswahl der Schritte ###################################
Console.OutputEncoding = Encoding.UTF8;
//Schritt1();
//Schritt2();
Schritt2_FaelleZusammengefasst();
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
        steigung = Convert.ToDouble(deltaY) / deltaX;

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
        // Bestimme die Anzahl der Schleifendurchläufe - flach vs. steil
        int longerDelta = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));
        int x, y;

        bool rechts = deltaX > 0;
        bool links = !rechts;

        bool unten = deltaY >= 0;
        bool oben = !unten;

        bool flach = Math.Abs(deltaX) >= Math.Abs(deltaY);
        bool steil = !flach;

        for (int i = 1; i < longerDelta; i++)
        {
            // In JEDEM Schritt wird geprüft, welcher der 8 Fälle zutrifft.
            // "Ineffizient", jedoch übersichtlichter als die 8 Mehrfachverzweigungen
            // und innerhalb dieser 8 For-Schleifen.

            // Fall a: Unten, Rechts, Flach
            if (unten && rechts && flach)
            {
                steigung = Convert.ToDouble(deltaY) / deltaX;
                x = i;
                y = Convert.ToInt32(Math.Round(i * steigung));

                field[yStart + y, xStart + x] = lineSymbol;
            }
            // Fall b: Unten, Rechts, Steil
            else if (unten && rechts && steil)
            {
                steigung = Convert.ToDouble(deltaX) / deltaY;
                x = Convert.ToInt32(Math.Round(i * steigung));
                y = i;

                field[yStart + i, xStart + x] = lineSymbol;
            }
            // Fall c: Unten, Links, Steil
            else if (unten && links && steil)
            {
                steigung = Convert.ToDouble(deltaX) / deltaY;
                x = Convert.ToInt32(Math.Round(i * steigung));
                y = i;

                field[yStart + i, xStart + x] = lineSymbol;
            }
            // Fall d: Unten, Links, Flach
            else if (unten && links && flach)
            {
                steigung = Convert.ToDouble(deltaY) / deltaX;
                x = i;
                y = Convert.ToInt32(Math.Round(i * steigung));

                field[yStart - y, xStart - x] = lineSymbol;
            }
            // Fall e: Oben, Links, Flach
            else if (oben && links && flach)
            {
                steigung = Convert.ToDouble(deltaY) / deltaX;
                x = i;
                y = Convert.ToInt32(Math.Round(i * steigung));

                field[yStart - y, xStart - x] = lineSymbol;
            }
            // Fall f: Oben, Links, Steil
            else if (oben && links && steil)
            {
                steigung = Convert.ToDouble(deltaX) / deltaY;
                x = Convert.ToInt32(Math.Round(i * steigung));
                y = i;

                field[yStart - i, xStart - x] = lineSymbol;
            }
            // Fall g: Oben, Rechts, Steil
            else if (oben && rechts && steil)
            {
                steigung = Convert.ToDouble(deltaX) / deltaY;
                x = Convert.ToInt32(Math.Round(i * steigung));
                y = i;

                field[yStart - y, xStart - x] = lineSymbol;
            }
            // Fall h: Oben, Rechts, Flach
            else if (oben && rechts && flach)
            {
                steigung = Convert.ToDouble(deltaY) / deltaX;
                x = i;
                y = Convert.ToInt32(Math.Round(i * steigung));

                field[yStart + y, xStart + i] = lineSymbol;
            }
            else
            {
                Console.WriteLine("Critical Failure: Ein unerwarteter Fall ist aufgetreten. " +
                    "Benutze den Debugger um die Beindungen der Verzweigungen zu Überprüfen!");
                return;
            }
        }

        // ENDE der Logik

        Print(field, dimension);
        zufrieden = HandleUserInputForRepeatingTheGame();

    } while (zufrieden);
}

// ################################### Schritt 2 - Faelle zusammengefasst ###################################
void Schritt2_FaelleZusammengefasst()
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

        // TODO: BEGINN der Logik - implementiere hier!
        double steigung = Convert.ToDouble(deltaY) / deltaX;
        double steigungVerkehrt = Convert.ToDouble(deltaX) / deltaY;

        // Bestimme die Anzahl der Schleifendurchläufe - flach vs. steil
        int longerDelta = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));
        int x, y;

        bool rechts = deltaX > 0;
        bool links = !rechts;

        bool unten = deltaY >= 0;
        bool oben = !unten;

        bool flach = Math.Abs(deltaX) >= Math.Abs(deltaY);
        bool steil = !flach;

        for (int i = 1; i < longerDelta; i++)
        {

            // Die Ersten zwei Verzweigungen gehen die x-Achse ab...

            // Fall a: Unten, Rechts, Flach ODER
            // Fall b: Oben, Rechts, Flach
            // Wir können also unten weglassen, denn beide Fälle der booleschen Variable landen hier.
            //if (unten && rechts && flach || oben && rechts && flach) // wird zu
            if (rechts && flach)
            {
                x = i;
                y = Convert.ToInt32(Math.Round(i * steigung));
            }
            // Fall c: Unten, Links, Flach ODER
            // Fall d: Oben, Links, Flach
            //if (unten && rechts && flach || oben && rechts && flach) // wird zu
            else if (links && flach)
            {
                x = -i;
                y = -Convert.ToInt32(Math.Round(i * steigung));
            }

            // Die letzten zwei Verzweigungen gehen die y-Achse ab...

            // Fall b: Unten, Rechts, Steil ODER
            // Fall c: Unten, Links, Steil
            //if (unten && rechts && steil || unten && links && steil) // wird zu
            else if (unten && steil)
            {
                x = Convert.ToInt32(Math.Round(i * steigungVerkehrt));
                y = i;
            }
            
            // Fall f: Oben, Links, Steil ODER
            // Fall g: Oben, Rechts, Steil
            //else if (oben && links && steil || oben && rechts && steil) // Wird zu
            else if (oben && steil) 
            {
                x = -Convert.ToInt32(Math.Round(i * steigungVerkehrt));
                y = -i;
            }
            else
            {
                Console.WriteLine("Critical Failure: Ein unerwarteter Fall ist aufgetreten. " +
                    "Benutze den Debugger um die Beindungen der Verzweigungen zu Überprüfen!");
                return;
            }

            field[yStart + y, xStart + x] = lineSymbol;
        }

        // ENDE der Logik

        Print(field, dimension);
        zufrieden = HandleUserInputForRepeatingTheGame();

    } while (zufrieden);
}

// ################################### Schritt 3 ###################################
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
        double steigung = Convert.ToDouble(deltaY) / longerDelta;
        double steigungVerkehrt = Convert.ToDouble(deltaX) / longerDelta;

        for (int i = 1; i < longerDelta; i++)
        {
            int x = Convert.ToInt32(Math.Round(i * steigungVerkehrt));
            int y = Convert.ToInt32(Math.Round(i * steigung));
            field[yStart + y, xStart + x] = "🔸";
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