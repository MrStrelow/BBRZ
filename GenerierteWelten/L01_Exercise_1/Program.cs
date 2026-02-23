using SkiaSharp;
using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string pfadOhneBaeume = "../../../world_1.png";
        string[,] karteOhneBaeume = LadeKarte(pfadOhneBaeume);

        int anzahlFelder = karteOhneBaeume.GetLength(0) * karteOhneBaeume.GetLength(1);

        double prozentWaldAufKarte = SetProzentWaldAufKarte(0.25, karteOhneBaeume);
        int anzahlBaeume = (int)Math.Ceiling(anzahlFelder * prozentWaldAufKarte);

        double prozentInselAufKarte = 0.035; // darf nicht über 0.0947 sein! Wir vertrauen uns und überprüfen es nicht.
        int anzahlInseln = (int)Math.Ceiling(anzahlFelder * prozentInselAufKarte);

        Console.WriteLine($"1) --- schuette {anzahlInseln} 🥪Inseln⏳ in einer Karte mit {anzahlFelder} Felder auf ---");
        string[,] karteMitInseln = SchuetteInselnAuf(karteOhneBaeume, anzahlInseln);

        Console.WriteLine($"2) --- pflanze {anzahlBaeume} 🌲Baeume🌳 in einer Karte mit {anzahlFelder} Felder ein ---");
        string[,] karteMitInselnUndBaeume = PflanzeBaeume(karteMitInseln, anzahlBaeume);

        Console.WriteLine("3) --- Speichere neue Karte  ---");
        string pfadMitBaeumeUndInseln = pfadOhneBaeume.Replace(".png", "_mit_Baeume_und_Inseln.png");
        SpeichereKarte(karteMitInselnUndBaeume, pfadMitBaeumeUndInseln);

        Console.WriteLine("4) --- Zeichne neue Karte in den Terminal ---");
        ZeichneKarte(karteMitInselnUndBaeume);

        Console.WriteLine($"\nSimulation beendet. Bild in {pfadMitBaeumeUndInseln} gespeichert.");
    }

    static string[,] SchuetteInselnAuf(string[,] karteOhneInseln, int limitAnInseln)
    {
        string symbolDesWassers = "🟦";
        string symbolDesSandes = "🟨";

        string[,] karteMitInseln = (string[,]) karteOhneInseln.Clone();

        Random generator = new Random(101);
        int entstandeneInseln = 0;

        Console.WriteLine("    werfe Sand...");

        while (entstandeneInseln < limitAnInseln)
        {
            // a)
            //int y = generator.Next(0, karteMitInseln.GetLength(0) / 2);
            //int x = generator.Next(0, karteMitInseln.GetLength(1) / 2);
            
            // b)
            // int y = generator.Next(karteMitInseln.GetLength(0) / 2, karteMitInseln.GetLength(0));
            //int x = generator.Next(karteMitInseln.GetLength(0) / 2, karteMitInseln.GetLength(1));
            
            // c)
            int y = generator.Next(karteMitInseln.GetLength(0) / 4, karteMitInseln.GetLength(0) * 3 / 4);
            int x = generator.Next(karteMitInseln.GetLength(0) / 4, karteMitInseln.GetLength(1) * 3 / 4);

            string ort = karteMitInseln[y, x];

            if (ort == symbolDesWassers)
            {
                karteMitInseln[y, x] = symbolDesSandes;
                entstandeneInseln++;
            }
        }

        return karteMitInseln;
    }

    static string[,] PflanzeBaeume(string[,] karteOhneBaeume, int limitAnBaeumen)
    {
        string symbolDerErde = "🟫";
        string symbolDerSteine = "🗻";
        string symbolDerBaeume = "🌳";
        string symbolDerMangrove = "🌲";
        string symbolDerPalme = "🌴";
        string symbolDesWassers = "🟦";
        string symbolDesSandes = "🟨";

        string[,] karteMitBaeumen = (string[,]) karteOhneBaeume.Clone();

        Random generator = new Random(101);
        int gepflanzteBaeume = 0;

        Console.WriteLine("    werfe Seedlings...");

        while (gepflanzteBaeume < limitAnBaeumen)
        {
            int y = generator.Next(0, karteMitBaeumen.GetLength(0));
            int x = generator.Next(0, karteMitBaeumen.GetLength(1));

            string ort = karteMitBaeumen[y, x];

            if (ort == symbolDerErde)
            {
                karteMitBaeumen[y, x] = symbolDerBaeume;
                gepflanzteBaeume++;
            }
            else if (ort == symbolDerSteine)
            {
                if (generator.NextDouble() < 0.1)
                {
                    karteMitBaeumen[y, x] = symbolDerBaeume;
                    gepflanzteBaeume++;
                }
            }
            else if (ort == symbolDesWassers)
            {
                if (generator.NextDouble() < 0.05)
                {
                    karteMitBaeumen[y, x] = symbolDerMangrove;
                    gepflanzteBaeume++;
                }
            }
            else if (ort == symbolDesSandes)
            {
                karteMitBaeumen[y, x] = symbolDerPalme;
                karteMitBaeumen = ZeichneSandUmBaum(x, y, karteMitBaeumen);
                gepflanzteBaeume++;
            }
        }

        return karteMitBaeumen;
    }

    static string[,] ZeichneSandUmBaum(int xPalme, int yPalme, string[,] karte)
    {
        string symbolDerPalme = "🌴";
        string symbolDesSandes = "🟨";

        int[,] nachbarn =
        {
            { yPalme - 1, xPalme },
            { yPalme + 1, xPalme },
            { yPalme, xPalme - 1 },
            { yPalme, xPalme + 1 }
        };

        for (int i = 0; i < nachbarn.GetLength(0); i++)
        {
            int y = nachbarn[i, 0];
            int x = nachbarn[i, 1];

            bool wagrechtPasst = 0 <= x && x < karte.GetLength(1);
            bool senkrechtPasst = 0 <= y && y < karte.GetLength(0);

            if (wagrechtPasst && senkrechtPasst)
            {
                bool istKeinBaum = karte[y, x] != symbolDerPalme;

                if (istKeinBaum)
                {
                    karte[y, x] = symbolDesSandes;
                }
            }
        }

        return karte;
    }

    static void ZeichneKarte(string[,] karte)
    {
        for (int y = 0; y < karte.GetLength(0); y++)
        {
            for (int x = 0; x < karte.GetLength(1); x++)
            {
                Console.Write(karte[y, x]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void SpeichereKarte(string[,] karteAlsArray, string pfad)
    {
        SKColor farbeDerErde = new SKColor(120, 67, 21);
        SKColor farbeDerSteine = new SKColor(128, 128, 128);
        SKColor farbeDesWassers = new SKColor(0, 0, 255);
        SKColor farbeDerBaeume = new SKColor(50, 205, 50);
        SKColor farbeDerMangroven = new SKColor(0, 100, 0);
        SKColor farbeDesSandes = new SKColor(255, 127, 0);
        SKColor farbeDerPalmen = new SKColor(144, 238, 144);

        string symbolDerErde = "🟫";
        string symbolDerSteine = "🗻";
        string symbolDesWassers = "🟦";
        string symbolDerBaeume = "🌳";
        string symbolDerMangroven = "🌲";
        string symbolDesSandes = "🟨";
        string symbolDerPalme = "🌴";

        int hoehe = karteAlsArray.GetLength(0);
        int breite = karteAlsArray.GetLength(1);
        SKBitmap karteAlsBild = new SKBitmap(breite, hoehe);

        for (int y = 0; y < karteAlsArray.GetLength(0); y++)
        {
            for (int x = 0; x < karteAlsArray.GetLength(1); x++)
            {
                if (karteAlsArray[y, x] == symbolDerErde)
                {
                    karteAlsBild.SetPixel(x, y, farbeDerErde);
                }
                else if (karteAlsArray[y, x] == symbolDerSteine)
                {
                    karteAlsBild.SetPixel(x, y, farbeDerSteine);
                }
                else if (karteAlsArray[y, x] == symbolDesWassers)
                {
                    karteAlsBild.SetPixel(x, y, farbeDesWassers);
                }
                else if (karteAlsArray[y, x] == symbolDerBaeume)
                {
                    karteAlsBild.SetPixel(x, y, farbeDerBaeume);
                }
                else if (karteAlsArray[y, x] == symbolDerMangroven)
                {
                    karteAlsBild.SetPixel(x, y, farbeDerMangroven);
                }
                else if (karteAlsArray[y, x] == symbolDerPalme)
                {
                    karteAlsBild.SetPixel(x, y, farbeDerPalmen);
                }
                else if (karteAlsArray[y, x] == symbolDesSandes)
                {
                    karteAlsBild.SetPixel(x, y, farbeDesSandes);
                }
                else
                {
                    karteAlsBild.SetPixel(x, y, new SKColor(255, 0, 255));
                    Console.WriteLine($"Unbekannte Farbe in Zeile:{y} und Spalte:{x}.");
                }
            }
        }

        File.WriteAllBytes(pfad, karteAlsBild.Encode(SKEncodedImageFormat.Png, 100).ToArray());
    }

    static string[,] LadeKarte(string dateiPfad)
    {
        SKColor farbeDerErde = new SKColor(120, 67, 21);
        SKColor farbeDerSteine = new SKColor(128, 128, 128);
        SKColor farbeDesWassers = new SKColor(0, 0, 255);
        SKColor farbeDerBaeume = new SKColor(50, 205, 50);

        string symbolDerErde = "🟫";
        string symbolDerSteine = "🗻";
        string symbolDesWassers = "🟦";

        SKBitmap karteAlsBild = SKBitmap.Decode(dateiPfad);
        string[,] karteAlsArray = new string[karteAlsBild.Height, karteAlsBild.Width];

        for (int y = 0; y < karteAlsBild.Height; y++)
        {
            for (int x = 0; x < karteAlsBild.Width; x++)
            {
                SKColor pixelFarbe = karteAlsBild.GetPixel(x, y);

                if (pixelFarbe == farbeDerErde)
                {
                    karteAlsArray[y, x] = symbolDerErde;
                }
                else if (pixelFarbe == farbeDerSteine)
                {
                    karteAlsArray[y, x] = symbolDerSteine;
                }
                else if (pixelFarbe == farbeDesWassers)
                {
                    karteAlsArray[y, x] = symbolDesWassers;
                }
                else
                {
                    karteAlsArray[y, x] = "💀";
                    Console.WriteLine($"Unbekannte Farbe in Zeile:{y} und Spalte:{x}.");
                }
            }
        }

        return karteAlsArray;
    }

    static double SetProzentWaldAufKarte(double wunschProzentBaeume, string[,] karte)
    {
        string symbolDerErde = "🟫";
        string symbolDerSteine = "🗻";
        int anzahlSteineOderErde = 0;
        int hoehe = karte.GetLength(0);
        int breite = karte.GetLength(1);
        int anzahlOrte = breite * hoehe;

        for (int y = 0; y < karte.GetLength(0); y++)
        {
            for (int x = 0; x < karte.GetLength(1); x++)
            {
                if (karte[y,x] == symbolDerErde || karte[y, x] == symbolDerSteine)
                {
                    anzahlSteineOderErde++;
                }
            }
        }

        if (anzahlOrte * wunschProzentBaeume > anzahlSteineOderErde)
        {
            Console.WriteLine($"❗ WARNUNG: Nicht genug Land! Maximal mögliche Bäume: {anzahlSteineOderErde} ❕");
            Console.WriteLine($"❗ Das Limit wird von {wunschProzentBaeume} auf 0.8 * {(double)anzahlSteineOderErde / anzahlOrte} reduziert ❕");

            return 0.8 * anzahlSteineOderErde / anzahlOrte;
        }
        else
        {
            return wunschProzentBaeume;
        }
    }
}