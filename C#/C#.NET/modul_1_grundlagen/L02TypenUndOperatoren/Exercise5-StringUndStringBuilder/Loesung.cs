using System.Diagnostics;
using System.Text;

static void Aufgabe1()
{
    string basisText = "Man sagt, C# ist eine langweilige Programmiersprache.";

    // 1. Initialisieren Sie den StringBuilder mit einem Teilstring (ab Index 10).
    // CRUD: C
    StringBuilder sb = new StringBuilder(basisText.Substring(10));
    Console.WriteLine($"1. Start: {sb}");

    // 2. Entfernen Sie das Wort "langweilige" (10 Zeichen lang, startet bei Index 14).
    sb.Remove(14, 10); // CRUD: D

    // 3. Fügen Sie an derselben Position das Wort "vielseitige" ein.
    sb.Insert(14, "vielseitige"); // CRUD: C

    // 4. Ersetzen Sie alle 'e' durch 'E'.
    sb.Replace('e', 'E'); // CRUD: U

    // 5. Ändern Sie das erste Zeichen ('C') auf ein kleines 'c'.
    sb[0] = 'c'; // CRUD: U

    // 6. Hängen Sie " und C# macht Spaß!" dreimal an.
    for (int i = 0; i < 3; i++)
    {
        sb.Append(" und C# macht Spaß!"); // CRUD: C
    }

    // 7. Entfernen Sie die letzten 10 Zeichen.
    sb.Remove(sb.Length - 10, 10); // CRUD: D

    Console.WriteLine($"\nEndgültiges Ergebnis:\n{sb}");
}

static void Aufgabe2()
{
    // mit dem Typ: StringBuilder
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    StringBuilder resultStringBuilder = new StringBuilder();

    for (int i = 0; i < 100000; i++)
    {
        resultStringBuilder.Append("Hello ");
    }

    stopwatch.Stop();
    Console.WriteLine("Mit StringBuilder: " + stopwatch.ElapsedMilliseconds + " ms");

    // mit dem Typ: string
    stopwatch = new Stopwatch();
    stopwatch.Start();

    string resultString = "";

    for (int i = 0; i < 100000; i++)
    {
        resultString += "Hello ";
    }

    stopwatch.Stop();
    Console.WriteLine("Mit string: " + stopwatch.ElapsedMilliseconds + " ms");
}

Aufgabe1();
Aufgabe2();