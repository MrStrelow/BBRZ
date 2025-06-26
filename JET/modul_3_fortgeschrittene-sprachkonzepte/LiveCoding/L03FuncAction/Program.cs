using System.Collections.Generic;

var bibliothek = new List<BuchDTO>
{
    new BuchDTO { Titel = "Der Herr der Ringe", Autor = "J.R.R. Tolkien", Genre = "Fantasy", Seiten = 1200 },
    new BuchDTO { Titel = "Der Hobbit", Autor = "J.R.R. Tolkien", Genre = "Fantasy", Seiten = 350 },
    new BuchDTO { Titel = "Stolz und Vorurteil", Autor = "Jane Austen", Genre = "Romanze", Seiten = 400 },
    new BuchDTO { Titel = "Emma", Autor = "Jane Austen", Genre = "Romanze", Seiten = 500 },
    new BuchDTO { Titel = "Dune - Der Wüstenplanet", Autor = "Frank Herbert", Genre = "Sci-Fi", Seiten = 800 },
    new BuchDTO { Titel = "Per Anhalter durch die Galaxis", Autor = "Douglas Adams", Genre = "Sci-Fi", Seiten = 250 },
    new BuchDTO { Titel = "Foundation", Autor = "Isaac Asimov", Genre = "Sci-Fi", Seiten = 255 },
    new BuchDTO { Titel = "1984", Autor = "George Orwell", Genre = "Dystopie", Seiten = 350 }
};

Console.WriteLine(string.Join("\n", bibliothek));
Console.WriteLine("---------------------");

//###################################################################
// Variante 1
//TODO: baue folgende filter.
static List<BuchDTO> FiltereNachGenreSciFi(List<BuchDTO> bücher)
{
    var nachSciFiGefilterteBuecher = new List<BuchDTO>();

    foreach (var buch in bücher)
    {
        if (buch.Genre == "Sci-Fi")
        {
            nachSciFiGefilterteBuecher.Add(buch);
        }
    }

    return nachSciFiGefilterteBuecher;
}

static List<BuchDTO> FiltereNachAutor(List<BuchDTO> bücher, string autor)
{
    var nachSciFiGefilterteBuecher = new List<BuchDTO>();

    foreach (var buch in bücher)
    {
        if (buch.Autor == autor)
        {
            nachSciFiGefilterteBuecher.Add(buch);
        }
    }

    return nachSciFiGefilterteBuecher;
}

static List<BuchDTO> FiltereNachMindestseiten(List<BuchDTO> bücher, int minSeiten)
{
    var nachSciFiGefilterteBuecher = new List<BuchDTO>();

    foreach (var buch in bücher)
    {
        if (buch.Seiten >= minSeiten)
        {
            nachSciFiGefilterteBuecher.Add(buch);
        }
    }

    return nachSciFiGefilterteBuecher;
}

// 3. Ausgabe
var result = FiltereNachMindestseiten(bibliothek, 500);

//result = FiltereNachGenreSciFi(bibliothek);
//result = FiltereNachAutor(bibliothek, "J.R.R. Tolkien");

Console.WriteLine(string.Join("\n", result));
Console.WriteLine("---------------------");

//###################################################################
// Variante 2
static List<BuchDTO> Filter(List<BuchDTO> bücher, Func<BuchDTO, bool> filterBedingung)
{
    var nachSciFiGefilterteBuecher = new List<BuchDTO>();

    foreach (var buch in bücher)
    {
        if (filterBedingung(buch))
        {
            nachSciFiGefilterteBuecher.Add(buch);
        }
    }

    return nachSciFiGefilterteBuecher;
}


static bool GreaterThan(BuchDTO buch)
{
    return buch.Seiten >= 500;
}

// TODO: genre filter erstellen
static bool GerneIs(BuchDTO buch)
{
    return buch.Genre == "Sci-Fi";
}

// TODO: author filter erstellen
static bool AuthorIs(BuchDTO buch)
{
    return buch.Autor == "J.R.R. Tolkien";
}

// Variante 3 - Lambdas




//TODO: filter für genre aufrufen 
var booksFilteredForPages = Filter(bibliothek, buch => buch.Seiten >= 500); 
//TODO: filter für author aufrufen
var booksFilteredForGenres = Filter(bibliothek,  buch => buch.Genre == "Sci-Fi");
var booksFilteredForAuthors = Filter(bibliothek, buch => buch.Autor == "J.R.R. Tolkien");

Console.WriteLine(string.Join("\n", booksFilteredForPages));
Console.WriteLine("---------------------");


// 1. Properties anlegen.
internal class BuchDTO()
{
    // titel
    public string Titel { get; set; }

    // autor
    public string Autor { get; set; }

    // genre
    public string Genre { get; set; }

    // seiten
    public int Seiten { get; set; }

    public override string ToString()
    {
        return $"'{Titel}' von {Autor} ({Seiten} Seiten - {Genre})";
    }
}

