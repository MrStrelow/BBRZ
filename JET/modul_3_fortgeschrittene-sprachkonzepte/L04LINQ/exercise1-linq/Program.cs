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

// Finde alle Sci-Fi Bücher
var sciFiBuecher = bibliothek.Where(buch => buch.Seiten >= 500);
Console.WriteLine(string.Join("\n", sciFiBuecher));


// Finde alle Sci-Fi Bücher
sciFiBuecher = from buch in bibliothek
                   where buch.Seiten >= 500
                   select buch;


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