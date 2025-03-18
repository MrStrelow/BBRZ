using System;
using System.Text;

public class Produkt
{
    public bool IstPremium { get; set; }
    public decimal Preis { get; set; }
}

public class Kunde
{
    // Eigenschaften / Felder
    public bool IstAktiv { get; set; }
    public int Alter { get; set; }
    public string Kundenkarte { get; set; }
    public DateTime MitgliedschaftGueltigBis { get; set; }
    public int Bestellhistorie { get; set; }
    public decimal Budget { get; set; }
    public bool IstKreditwürdig { get; set; }

    // Hat-Beziehungen
    public Produkt Produkt { get; set; }

    public void ValidateKunde()
    {
        if (IstAktiv)
        {
            if (Alter >= 21)
            {
                if (!string.IsNullOrEmpty(Kundenkarte))
                {
                    if (MitgliedschaftGueltigBis > DateTime.Now)
                    {
                        if (Produkt.IstPremium)
                        {
                            if (Bestellhistorie > 20)
                            {
                                if (Produkt.Preis > Budget)
                                {
                                    if (IstKreditwürdig)
                                    {
                                        Console.WriteLine("✅ Kunde hat mehr als 20 Bestellungen und hat einen Kredit. Dieser Kunde darf Premium-Produkte kaufen.");
                                    }
                                    else
                                    {
                                        throw new InvalidOperationException("❗ Kunde benötigt einen Kredit, da das Produkt zu teuer ist.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("✅ Kunde hat mehr als 20 Bestellungen. Dieser Kunde darf Premium-Produkte kaufen.");
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("❗ Kunde hat zu wenig Bestellungen für Premium-Produkte.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("✅ Kunde darf das Produkt kaufen.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("❗ Die Mitgliedschaft des Kunden ist abgelaufen.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("❗ Kunde wird gefragt ob eine Kundenkarte erwünscht ist. Diese:r ist generft und geht aus dem Geschäft.");
                }
            }
            else
            {
                throw new InvalidOperationException("❗ Kunde muss mindestens 21 Jahre alt sein.");
            }
        }
        else
        {
            throw new InvalidOperationException("❗ Kunde ist nicht aktiv.");
        }
    }

    public void ValidateKundeGuardClause()
    {
        // Guards: ungewünschte Zustände 
        if (!IstAktiv)
            throw new InvalidOperationException("❗ Kunde ist nicht aktiv.");

        if (Alter < 21)
            throw new InvalidOperationException("❗ Kunde muss mindestens 21 Jahre alt sein.");

        if (string.IsNullOrEmpty(Kundenkarte))
            throw new InvalidOperationException("❗ Kunde wird gefragt, ob eine Kundenkarte erwünscht ist. Diese:r ist genervt und geht aus dem Geschäft.");

        if (MitgliedschaftGueltigBis <= DateTime.Now)
            throw new InvalidOperationException("❗ Die Mitgliedschaft des Kunden ist abgelaufen.");

        if (Produkt.IstPremium && Bestellhistorie <= 20)
            throw new InvalidOperationException("❗ Kunde hat zu wenig Bestellungen für Premium-Produkte.");

        if (Produkt.Preis > Budget && !IstKreditwürdig)
            throw new InvalidOperationException("❗ Kunde benötigt einen Kredit, da das Produkt zu teuer ist.");

        // gewünschte Zustände 
        if (!Produkt.IstPremium)
        {
            Console.WriteLine("✅ Kunde darf das Produkt kaufen.");
        }
        else if (Produkt.Preis > Budget && IstKreditwürdig)
        {
            Console.WriteLine("✅ Kunde hat mehr als 20 Bestellungen und hat einen Kredit. Dieser Kunde darf Premium-Produkte kaufen.");
        } 
        else
        {
            Console.WriteLine("✅ Kunde hat mehr als 20 Bestellungen und darf Premium-Produkte kaufen.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Kunde kunde = new Kunde
        {
            IstAktiv = true,
            Alter = 26,
            IstKreditwürdig = true,
            Kundenkarte = "GoldCard",
            MitgliedschaftGueltigBis = DateTime.Now.AddMonths(12),
            Bestellhistorie = 21,
            Budget = 1000,
            Produkt = new Produkt { IstPremium = false, Preis = 10005 }
        };

        try
        {
            kunde.ValidateKunde();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }

        try
        {
            kunde.ValidateKundeGuardClause();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }
    }
}