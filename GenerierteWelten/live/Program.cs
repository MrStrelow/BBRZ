using SkiaSharp;

namespace live;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string[,] karte = LadeKarte("../../../world_1.png");
        ZeichneKarte(karte);
    }

    // Planze Baeume


    // Lade Bild
    static string[,] LadeKarte(string pfad)
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

        SKBitmap karteAlsBild = SKBitmap.Decode(pfad);
        string[,] karteAlsArray = new string[karteAlsBild.Height, karteAlsBild.Width];

        for (int y = 0; y < karteAlsBild.Height; y++)
        {
            for (int x = 0; x < karteAlsBild.Width; x++)
            {
                SKColor pixelFarbe = karteAlsBild.GetPixel(x, y);

                if (pixelFarbe == farbeDesWassers)
                {
                    karteAlsArray[y, x] = symbolDesWassers;
                }
            }
        }

        return karteAlsArray;
    }

    // Speichere Bild


    // Gib Bild aus
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
}