using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Produkte
        string fahrrad = "Fahrrad";
        string tisch = "Tisch";
        string kulli = "Kulli";

        // Boxen erstellen (jede Box ist eine Liste von Produkten)
        List<string> großeBox = new List<string> { fahrrad, tisch };
        List<string> mittlereBox = new List<string> { tisch, kulli };
        List<string> kleineBox = new List<string> { kulli };

        // Lager als Dictionary, das die Boxen nach Größe kategorisiert
        Dictionary<string, List<string>> lager = new Dictionary<string, List<string>>
        {
            { "groß", großeBox },
            { "mittel", mittlereBox },
            { "klein", kleineBox }
        };

        // Lager-Inhalte ausgeben
        Console.WriteLine("Inhalt des Lagers:");
        foreach (var box in lager)
        {
            Console.WriteLine($"Box-Größe: {box.Key}");
            foreach (var produkt in box.Value)
            {
                Console.WriteLine($" - {produkt}");
            }
        }
    }
}