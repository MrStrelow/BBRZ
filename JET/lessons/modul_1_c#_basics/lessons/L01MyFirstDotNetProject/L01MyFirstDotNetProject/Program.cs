// Wir versuchen hier in diesem Programm uns mit der Entwicklungsumgebung auseinanderzusetzen.
// In diesem Projekt schauen wir uns folgedes an:
// * Was ist.NET, .NET Core, .NET Framework, C#, und Visual Studio (VS)?
// * Was finden wir in der Ordnerstruktur welche von VS?
// * Was werden für Artefakte erzeugt, wenn wir ein .NET projekt builden?
// * Wie builden wir Projekte mit dem Terminal, wie mit VS?

// Nähere Infos dazu sind in der Datei "AufbauDotNet.md" zu finden. Diese kann mit einem "markdown" reader
// gelesen werden.
// Möglich mit VS Code -> öffnen -> CTRL + SHIFT + v

// Wie die Programme aufgebaut sind und ein praktisches Beispiel dazu ist hier dierekt im Code als
// Kommentare beschrieben.


// Wir wollen hier einen Generator für geometrische 2D-ASCII-Formen schreiben.
// Diese lassen Beispielsweise rechtwiklige Dreiecke, Rauten, Quadrate, usw. erzeugen.
// Mit diesen Beispiel werden wir die Basis Elemente (und auch später die Objektorientieren Elemente) 
// von C# erkunden.

// Jedoch beginnen wir hier zuerst mit folgendem Beispiel zum aufwärmen:
// Bubble - Sort:
// Wir wollen diesen Sortieralgorithmus anwenden um Integerzahlen zu sortieren:
// Diese ist folgendermaßen aufgebaut:
// (siehe gif hier: https://upload.wikimedia.org/wikipedia/commons/c/c8/Bubble-sort-example-300px.gif)

uint[] zahlen = { 28, 26, 6, 4, 2 };

uint platzhalter;

// Schritt 3: Wiederhole 2. solange bis alle Zahlen sortiert sind.
// Wir lassen also jede Zahl nach rechts "aufsteigen", bis diese an der richtigen Position ist.
// FRAGE: Wie oft müssen wir die innere und außere Schleife wiederholen um alle Zahlen sortiert zu haben, wenn wir 5 Zahlen zu sortiern haben?
for (int j = 0; j < zahlen.Length - 1; j++)
{
    //Console.WriteLine((j + 1) + " Durchlauf");
    //Console.WriteLine($"{j + 1} Durchlauf");
    Console.WriteLine($"{1} Durchlauf", j + 1);

    // Schritt 2: Wiederhole 1. für alle Paare mit Index 0 und 1, 1 und 2, 2 und 3, 3 und 4.
    for (int i = 0; i < zahlen.Length - 1 - j; i++)
    {
        // Schritt 1: Vergleiche die 1. (Index 0) und 2. (Index 1) Zahl im Array.
        // Falls die 1. größer ist wie die 2., dann vertausche diese, andernfalls mach nichts.
        if (zahlen[i] > zahlen[i + 1])
        {
            platzhalter = zahlen[i];
            zahlen[i] = zahlen[i + 1];
            zahlen[i + 1] = platzhalter;
        }

        Console.WriteLine($"{i + 1} Paar {zahlen}");
    }
}



