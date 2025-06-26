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


internal class Buch()
{
    // titel
    // autor
    // genre
    // seiten

    public override string ToString()
    {
        return $"'{Titel}' von {Autor} ({Seiten} Seiten)";
    }
}

