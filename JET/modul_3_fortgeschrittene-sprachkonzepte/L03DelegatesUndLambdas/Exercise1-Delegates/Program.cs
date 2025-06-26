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

// 1. Ansatz - so sind wir es gewohnt
static List<Buch> FiltereNachGenreSciFi(List<Buch> bücher)
{
    var gefilterteListe = new List<Buch>();
    foreach (var buch in bücher)
    {
        if (buch.Genre == "Sci-Fi")
        {
            gefilterteListe.Add(buch);
        }
    }
    return gefilterteListe;
}

static List<Buch> FiltereNachAutor(List<Buch> bücher, string autor)
{
    var gefilterteListe = new List<Buch>();
    foreach (var buch in bücher)
    {
        if (buch.Autor == autor)
        {
            gefilterteListe.Add(buch);
        }
    }
    return gefilterteListe;
}

static List<Buch> FiltereNachMindestseiten(List<Buch> bücher, int minSeiten)
{
    var gefilterteListe = new List<Buch>();
    foreach (var buch in bücher)
    {
        if (buch.Seiten >= minSeiten)
        {
            gefilterteListe.Add(buch);
        }
    }
    return gefilterteListe;
}

var res = FiltereNachMindestseiten(bibliothek, 500);
Console.WriteLine(string.Join("\n", res));
Console.WriteLine("-------------------------------");


// 2. Ansatz - Mittels Func und Action
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

static bool FilterMindestseiten(Buch buch) 
{
    return buch.Seiten >= 500;
}


res = FiltereBücher(bibliothek, FilterMindestseiten);
Console.WriteLine(string.Join("\n", res));
Console.WriteLine("-------------------------------");


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