bool beinhaltet(List<Kunde> kunden, string filterart, int? älterAls = null, int? grenzePunkte = null)
{
    bool ret = false;

    if (filterart == "istAelterAlsX" && älterAls.HasValue) {
        foreach (Kunde kunde in kunden)
        {
            if (kunde.Alter > älterAls)
            {
                ret = true;
                break;
            }
        }
    }
    else if (filterart == "mehrPunkteAlsX" && grenzePunkte.HasValue) 
    {
        foreach (Kunde kunde in kunden)
        {
            if (kunde.Punkte > grenzePunkte)
            {
                ret = true;
                break;
            }
        }
    }
    else
    {
        Console.WriteLine("Ünbekannter Filterart angegeben");
    }

    return ret;
}

var kunden = new List<Kunde> {
    new Kunde(Name: "Andrea", Alter: 25, Punkte: 100),
    new Kunde(Name: "Landrea", Alter: 35, Punkte: 200),
    new Kunde(Name: "Valrea", Alter: 45, Punkte: 300),
    new Kunde(Name: "Balrea", Alter: 55, Punkte: 400),
    new Kunde(Name: "Madrea", Alter: 65, Punkte: 500),
};

var istAelterAlsX = beinhaltet(kunden, filterart: "istAelterAlsX", älterAls: 18);
var mehrPunkteAlsX = beinhaltet(kunden, filterart: "mehrPunkteAlsX", grenzePunkte: 300);

Console.WriteLine("~~~ ITERATIVE ~~~");
Console.WriteLine(istAelterAlsX);
Console.WriteLine(mehrPunkteAlsX);

// TODO: Hier direkt LINQ ausdrücke schreiben, ohne diese in eine Methode zu geben. 
var istAelterAlsX_LINQ = kunden.Any( kunde => kunde.Alter > 18); // LINQ ausdruck hier.
var mehrPunkteAlsX_LINQ = kunden.Any(kunde => kunde.Punkte > 300); // LINQ ausdruck hier.

Console.WriteLine("~~~ LINQ ~~~");
Console.WriteLine(istAelterAlsX_LINQ);
Console.WriteLine(mehrPunkteAlsX_LINQ);

public record Kunde(string Name, int Alter, double Punkte);