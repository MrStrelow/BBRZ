using System;
using System.IO; // Notwendig für Dateioperationen
using System.Text.Json; // Notwendig für die JSON-Serialisierung

// Eine einfache Datenklasse (auch POCO - Plain Old CLR Object genannt)
public class Benutzer
{
    // Die Properties müssen public sein, damit der Serializer sie sieht.
    public string Name { get; set; }
    public int Alter { get; set; }
    public string? Email { get; set; } // Nullable, falls die E-Mail nicht immer vorhanden ist
}

public class Programm
{
    public static void Main()
    {
        // 1. Objekt erstellen
        var benutzer = new Benutzer
        {
            Name = "Maria Musterfrau",
            Alter = 34,
            Email = "maria@example.com"
        };

        // 2. Objekt in einen JSON-String serialisieren
        // JsonSerializerOptions sorgt für eine schön formatierte (eingerückte) Ausgabe
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(benutzer, options);

        Console.WriteLine("--- Serialisiertes Objekt als JSON-String ---");
        Console.WriteLine(jsonString);
        // Ausgabe:
        // {
        //   "Name": "Maria Musterfrau",
        //   "Alter": 34,
        //   "Email": "maria@example.com"
        // }

        // 3. JSON-String in eine Datei schreiben
        string dateipfad = "../../../benutzer.json";
        File.WriteAllTextAsync(dateipfad, jsonString);
        Console.WriteLine($"\nBenutzerdaten wurden in '{dateipfad}' gespeichert.");
    }
}