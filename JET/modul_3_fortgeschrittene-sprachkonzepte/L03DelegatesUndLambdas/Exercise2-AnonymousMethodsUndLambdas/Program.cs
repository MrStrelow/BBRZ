var bibliothek = new List<Buch>
        {
            new Buch { Titel = "Der Herr der Ringe", Autor = "J.R.R. Tolkien", Genre = "Fantasy", Seiten = 1200 },
            new Buch { Titel = "Der Hobbit", Autor = "J.R.R. Tolkien", Genre = "Fantasy", Seiten = 350 },
            new Buch { Titel = "Stolz und Vorurteil", Autor = "Jane Austen", Genre = "Romanze", Seiten = 400 },
            new Buch { Titel = "Emma", Autor = "Jane Austen", Genre = "Romanze", Seiten = 500 },
            new Buch { Titel = "Dune - Der Wüstenplanet", Autor = "Frank Herbert", Genre = "Sci-Fi", Seiten = 800 },
            new Buch { Titel = "Per Anhalter durch die Galaxis", Autor = "Douglas Adams", Genre = "Sci-Fi", Seiten = 250 },
            new Buch { Titel = "Foundation", Autor = "Isaac Asimov", Genre = "Sci-Fi", Seiten = 255 },
            new Buch { Titel = "1984", Autor = "George Orwell", Genre = "Dystopie", Seiten = 350 }
        };

static List<Buch> FiltereBücher(List<Buch> bücher, Func<Buch, bool> filterBedingung)
{
    var gefilterteListe = new List<Buch>();
    foreach (var buch in bücher)
    {
        // Wir rufen die übergebene Bedingung auf. Ist sie wahr?
        if (filterBedingung(buch))
        {
            gefilterteListe.Add(buch);
        }
    }
    return gefilterteListe;
}

// 3. Ansatz
// 1. Filter: Alle Bücher mit mehr oder gleich als 500 Seiten
var langeBuecher = FiltereBücher(bibliothek, b => b.Seiten >= 500);
Console.WriteLine("\nBücher mit > 500 Seiten:\n" + string.Join("\n", langeBuecher));
Console.WriteLine("-------------------------------");




// 1. Filter: Alle Sci-Fi Bücher
// Der Lambda-Ausdruck 'b => b.Genre == "Sci-Fi"' ist unsere "filterBedingung"
var sciFiBuecher = FiltereBücher(bibliothek, b => b.Genre == "Sci-Fi");
Console.WriteLine("Sci-Fi Bücher:\n" + string.Join("\n", sciFiBuecher));


// 2. Filter: Alle Bücher von Jane Austen
var janeAustenBuecher = FiltereBücher(bibliothek, b => b.Autor == "Jane Austen");
Console.WriteLine("\nBücher von Jane Austen:\n" + string.Join("\n", janeAustenBuecher));


// 4. Filter: Eine komplexe, kombinierte Abfrage ohne neue Methode!
// Alle Sci-Fi Bücher mit weniger als 300 Seiten.
var kurzeSciFiBuecher = FiltereBücher(bibliothek, b => b.Genre == "Sci-Fi" && b.Seiten < 300);
Console.WriteLine("\nKurze Sci-Fi Bücher:\n" + string.Join("\n", kurzeSciFiBuecher));

public class Buch
{
    public string Titel { get; set; }
    public string Autor { get; set; }
    public string Genre { get; set; }
    public int Seiten { get; set; }

    public override string ToString()
    {
        return $"'{Titel}' von {Autor} ({Seiten} Seiten)";
    }
}