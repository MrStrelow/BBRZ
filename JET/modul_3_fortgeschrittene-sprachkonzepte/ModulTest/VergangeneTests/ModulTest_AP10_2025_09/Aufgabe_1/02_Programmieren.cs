Kunde Beinhaltet(List<Kunde> kunden, string filterart, int? mindestAlter = null, int? mindestPunkte = null)
{
    if (filterart == "ältesterSinnvollerKunde" && mindestAlter.HasValue)
    {
        Kunde? ret = null;

        for (int i = 0; i < kunden.Count; i++)
        {
            if (kunden[i].Alter > mindestAlter)
            {
                ret = kunden[i];
            }
        }

        if (ret is null) throw new Exception("Mindestalter nicht passend. Kein Kunde gefunden.");

        foreach (Kunde kunde in kunden)
        {
            if (kunde.Alter > mindestAlter && kunde.Alter > ret.Alter)
            {
                ret = kunde;
            }
        }

        return ret;
    }
    else if (filterart == "sinnvollerKundeMitWenigstenPunkten" && mindestPunkte.HasValue)
    {
        Kunde? ret = null;

        for (int i = 0; i < kunden.Count; i++)
        {
            if (kunden[i].Punkte > mindestPunkte)
            { 
                ret = kunden[i];
            }
        } 

        if (ret is null) throw new Exception("Mindestalter nicht passend. Kein Kunde gefunden.");

        foreach (Kunde kunde in kunden)
        {
            if (kunde.Punkte > mindestPunkte && kunde.Punkte < ret.Punkte)
            {
                ret = kunde;
            }
        }

        return ret ?? throw new Exception("Kunde ist Null - Berchnung fehlgeschlagen.");
    }
    else
    {
        throw new Exception("Ünbekannter Filterart angegeben");
    }
}

var kunden = new List<Kunde> {
    new Kunde(Name: "Andrea", Alter: 25, Punkte: 100),
    new Kunde(Name: "Landrea", Alter: 35, Punkte: 200),
    new Kunde(Name: "Valrea", Alter: 45, Punkte: 300),
    new Kunde(Name: "Balrea", Alter: 55, Punkte: 400),
    new Kunde(Name: "Madrea", Alter: 65, Punkte: 500),
};

var istAelterAlsX = Beinhaltet(kunden, filterart: "ältesterSinnvollerKunde", mindestAlter: 18);
var mehrPunkteAlsX = Beinhaltet(kunden, filterart: "sinnvollerKundeMitWenigstenPunkten", mindestPunkte: 150);

Console.WriteLine("~~~ ITERATIVE ~~~");
Console.WriteLine(istAelterAlsX);
Console.WriteLine(mehrPunkteAlsX);

// TODO: Hier direkt LINQ ausdrücke schreiben, ohne diese in eine Methode zu geben. 
var istAelterAlsX_LINQ = kunden.Where(kunde => kunde.Alter > 18).MaxBy(kunde => kunde.Alter); // LINQ ausdruck hier.
var mehrPunkteAlsX_LINQ = kunden.Where(kunde => kunde.Punkte > 150).MinBy(kunde => kunde.Punkte); // LINQ ausdruck hier.

Console.WriteLine("~~~ LINQ ~~~");
Console.WriteLine(istAelterAlsX_LINQ);
Console.WriteLine(mehrPunkteAlsX_LINQ);

public record Kunde(string Name, int Alter, double Punkte);