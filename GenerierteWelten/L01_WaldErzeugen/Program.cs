using System;
using System.IO;
using SkiaSharp;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Fuer Emojis

        // ------------ Variablen ------------
        // --- Pfad des Bildes ---
        string pfadOhneBaeume = "../../../world_1.png";

        // --- Karte als 2D-string-Array ---
        //string[,] bildOhneBaeume = LadeKarte(pfadOhneBaeume);
        string[,] bildOhneBaeume = LadeKarteBackup();

        // --- Begrenzungen fuer Waldwuchs ---
        double prozentWaldAufKarte = 0.25;
        int anzahlFelder = bildOhneBaeume.GetLength(0) * bildOhneBaeume.GetLength(1);
        int anzahlBaeume = (int) Math.Ceiling(anzahlFelder * prozentWaldAufKarte);

        // ------------ Funktionsaufrufe und Konstrollstrukturen ------------
        // --- Funktionsaufrufe ---
        Console.WriteLine($"1) --- pflanze {anzahlBaeume} 🌴Baeume🌳 in einer Karte mit {anzahlFelder} Felder ein ---");
        string[,] karteMitBaeume = PflanzeBaeume(bildOhneBaeume, anzahlBaeume);

        Console.WriteLine("2) --- Speichere neue Karte  ---");
        string pfadMitBaeume = pfadOhneBaeume.Replace(".png", "_mit_Baeume.png");
        SpeichereKarte(karteMitBaeume, pfadMitBaeume);

        Console.WriteLine("3) --- Zeichne neue Karte in den Terminal ---");
        ZeichneKarte(karteMitBaeume);

        Console.WriteLine($"\nSimulation beendet. Bild in {pfadMitBaeume} gespeichert.");
    }

    static string[,] PflanzeBaeume(string[,] karteOhneBaeume, int limitAnBaeumen)
    {
        // ------------ Variablen ------------  
        // --- Emojis --- 
        string symbolDerErde = "🟫";
        string symbolDerSteine = "🗻";
        string symbolDerBaeume = "🌲";

        // --- neues, leeres Array --- 
        string[,] karteMitBaeumen = (string[,]) karteOhneBaeume.Clone();

        // --- Generator für Zufallszahlen --- 
        Random generator = new Random(101);

        // --- Zählvariablen --- 
        int gepflanzteBaeume = 0;
        int versucheEinenBaumZuPflanzen = 0;

        // ------------ Kontrollstrukturen ------------  
        // --- Zustaendigkeit der Kontrollstruktur ---
        // Wir pflanzen solange Baeume bis wir erfolgreich 25% der Karte besetzt haben.
        // Wir erhoehen die Zaehlvariable der Schleife nur wenn wir einen Baum pflanzen koennen.
        // Wir wissen nicht wie oft genau wir die Schleife wiederholen -> While-Schleife. 
        Console.WriteLine("    werfe Seedlings...");

        while (gepflanzteBaeume < limitAnBaeumen)
        {
            // 1) Zufällige Koordinate wählen
            int y = generator.Next(0, karteMitBaeumen.GetLength(0));
            int x = generator.Next(0, karteMitBaeumen.GetLength(1));

            string ort = karteMitBaeumen[y, x];

            // --- Zustaendigkeit der Kontrollstruktur ---
            // Prüfe ob wir an dem zufälligen Ort der Welt einen Baum pflanzen können?

            // 1) Ist der Untergrund Erde? Wenn ja, zeichne einen Baum mit einer Chance von 100%.
            if (ort == symbolDerErde)
            {
                karteMitBaeumen[y, x] = symbolDerBaeume;
                gepflanzteBaeume++;
            }
            // 2) Ist der Untergrund Stein? Wenn ja, zeichne einen Baum mit einer Chance von 10%.
            else if (ort == symbolDerSteine)
            {
                if (generator.NextDouble() < 0.1)
                {
                    karteMitBaeumen[y, x] = symbolDerBaeume;
                    gepflanzteBaeume++;
                }
            }
        }

        return karteMitBaeumen;
    }

    // --- Zustaendigkeit der Funktion ---
    // Zeichne die Karte (Array) auf den Terminal. 
    static void ZeichneKarte(string[,] karte)
    {
        // --- Zustaendigkeit der Kontrollstruktur ---
        // Wandere die Zeile des Bildes ab. Das "wandern" wird mit einer Zaehlvariable y in einer for-Schleife umgesetzt.
        for (int y = 0; y < karte.GetLength(0); y++)
        {
            // --- Zustaendigkeit der Kontrollstruktur ---
            // Wandere die Spalten des Bildes ab. Das "wandern" wird mit einer Zaehlvariable x in einer for-Schleife umgesetzt.
            for (int x = 0; x < karte.GetLength(1); x++)
            {
                Console.Write(karte[y, x]);
            }

            Console.WriteLine();
        }
    }

    // --- Zustaendigkeit der Funktion ---
    // Zeichne die Karte (Array) auf den Terminal. 
    static void SpeichereKarte(string[,] karteAlsArray, string pfad)
    {
        // ------------ Variablen ------------
        // --- Farben der Pixel ---
        SKColor farbeDerErde = new SKColor(120, 67, 21);
        SKColor farbeDerSteine = new SKColor(128, 128, 128);
        SKColor farbeDesWassers = new SKColor(0, 0, 255);
        SKColor farbeDerBaeume = new SKColor(50, 205, 50);

        // --- Symbole der Pixel ---
        string symbolDerErde = "🟫";
        string symbolDerSteine = "🗻";
        string symbolDesWassers = "🟦";
        string symbolDerBaeume = "🌳";
        string symbolDerMangroven = "🌴";

        // --- Bild welches gespeichert wird ---
        // Kopiere in dem Terminal: dotnet add package SkiaSharp 
        // erst dann kann die Klasse SKBitmap verwendet werden.
        int hoehe = karteAlsArray.GetLength(0);
        int breite = karteAlsArray.GetLength(1);
        SKBitmap karteAlsBild = new SKBitmap(breite, hoehe);

        // --- Zustaendigkeit der Kontrollstruktur ---
        // Wandere die Zeile des Bildes ab. Das "wandern" wird mit einer Zaehlvariable y in einer for-Schleife umgesetzt.
        for (int y = 0; y < karteAlsArray.GetLength(0); y++)
        {
            // --- Zustaendigkeit der Kontrollstruktur ---
            // Wandere die Spalten des Bildes ab. Das "wandern" wird mit einer Zaehlvariable x in einer for-Schleife umgesetzt.
            for (int x = 0; x < karteAlsArray.GetLength(1); x++)
            {
                // --- Zustaendigkeit der Kontrollstruktur ---
                // Je nach Farbe des Pixels im Bild, schreibe ein Emoji in das Array.

                // 1) Ist die Farbe des Pixels braun? Wenn ja, setze ein braunes Emoji in das Array.
                if (karteAlsArray[y, x] == symbolDerErde)
                {
                    karteAlsBild.SetPixel(x, y, farbeDerErde);
                }
                // 2) Ist die Farbe des Pixels grau? Wenn ja, setze ein grau Emoji in das Array.
                else if (karteAlsArray[y, x] == symbolDerSteine)
                {
                    karteAlsBild.SetPixel(x, y, farbeDerSteine);
                }
                // 3) Ist die Farbe des Pixels blau? Wenn ja, setze ein blau Emoji in das Array.
                else if (karteAlsArray[y, x] == symbolDesWassers)
                {
                    karteAlsBild.SetPixel(x, y, farbeDesWassers);
                }
                // 4) Ist die Farbe des Pixels hellgruen? Wenn ja, setze ein Baum Emoji in das Array.
                else if (karteAlsArray[y, x] == symbolDerBaeume)
                {
                    karteAlsBild.SetPixel(x, y, farbeDerBaeume);
                }
                // Wenn keines der vorherigen Fälle zutrifft, setze ein Skull 💀 Emoji in das Array.
                // Dieses ist ein Dummy falls wir eine nicht bekannte Farbe lesen.
                else
                {
                    karteAlsBild.SetPixel(x, y, new SKColor(255, 0, 255));
                    Console.WriteLine($"Unbekannte Farbe in Zeile:{y} und Spalte:{x}.");
                }
            }
        }

        // Wir speichern das bild...
        File.WriteAllBytes(pfad, karteAlsBild.Encode(SKEncodedImageFormat.Png, 100).ToArray());
    }

    // --- Zustaendigkeit der Funktion ---
    // Wandle ein Bild in ein 2D-Array um und gib das 2D-Array an den Aufrufer zurück.
    static string[,] LadeKarte(string dateiPfad)
    {
        // ------------ Variablen ------------
        // --- Farben der Pixel ---
        SKColor farbeDerErde = new SKColor(120, 67, 21);
        SKColor farbeDerSteine = new SKColor(128, 128, 128);
        SKColor farbeDesWassers = new SKColor(0, 0, 255);
        SKColor farbeDerBaeume = new SKColor(50, 205, 50);

        // --- Symbole der Pixel ---
        string symbolDerErde = "🟫";
        string symbolDerSteine = "🗻";
        string symbolDesWassers = "🟦";

        // --- Bild welches gespeichert wird ---
        // Kopiere in dem Terminal: dotnet add package SkiaSharp 
        // erst dann kann die Klasse SKBitmap verwendet werden.
        SKBitmap karteAlsBild = SKBitmap.Decode(dateiPfad);
        string[,] karteAlsArray = new string[karteAlsBild.Height, karteAlsBild.Width];

        // --- Zustaendigkeit der Kontrollstruktur ---
        // Wandere die Zeile des Bildes ab. Das "wandern" wird mit einer Zaehlvariable y in einer for-Schleife umgesetzt.
        for (int y = 0; y < karteAlsBild.Height; y++)
        {
            // --- Zustaendigkeit der Kontrollstruktur ---
            // Wandere die Spalten des Bildes ab. Das "wandern" wird mit einer Zaehlvariable x in einer for-Schleife umgesetzt.
            for (int x = 0; x < karteAlsBild.Width; x++)
            {
                SKColor pixelFarbe = karteAlsBild.GetPixel(x, y);

                // --- Zustaendigkeit der Kontrollstruktur ---
                // Je nach Farbe des Pixels im Bild, schreibe ein Emoji in das Array.

                // 1) Ist die Farbe des Pixels braun? Wenn ja, setze ein braunes Emoji in das Array.
                if (pixelFarbe == farbeDerErde)
                {
                    karteAlsArray[y, x] = symbolDerErde;
                }
                // 2) Ist die Farbe des Pixels grau? Wenn ja, setze ein grau Emoji in das Array.
                else if (pixelFarbe == farbeDerSteine)
                {
                    karteAlsArray[y, x] = symbolDerSteine;
                }
                // 3) Ist die Farbe des Pixels blau? Wenn ja, setze ein blau Emoji in das Array.
                else if (pixelFarbe == farbeDesWassers)
                {
                    karteAlsArray[y, x] = symbolDesWassers;
                }
                // Wenn keines der vorherigen Fälle zutrifft, setze ein Skull 💀 Emoji in das Array.
                // Dieses ist ein Dummy falls wir eine nicht bekannte Farbe lesen.
                else
                {
                    karteAlsArray[y, x] = "💀";
                    Console.WriteLine($"Unbekannte Farbe in Zeile:{y} und Spalte:{x}.");
                }
            }
        }

        return karteAlsArray;
    }

    static string[,] LadeKarteBackup()
    {
        return new string[,]
        {
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🟫", "🟫" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🟫" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🗻", "🗻", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🟫" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻", "🟫" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🟦", "🟦", "🟦", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🟦", "🟦", "🟫", "🟫", "🗻", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🗻", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🗻", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🗻", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🟫" },
            { "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🗻", "🟫", "🟫", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫" },
            { "🗻", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫" },
            { "🗻", "🗻", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫" },
            { "🟦", "🗻", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫" },
            { "🟦", "🟦", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫" },
            { "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦" },
            { "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🗻", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🟫", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🗻", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🟫", "🟫", "🟦", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🗻", "🗻", "🗻" },
            { "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🟦", "🗻", "🗻", "🗻", "🟦", "🟦", "🟦", "🟦", "🟫", "🟫", "🟫", "🟫", "🟫", "🟫", "🗻", "🗻", "🗻", "🗻", "🗻", "🗻" }
        };
    }
}