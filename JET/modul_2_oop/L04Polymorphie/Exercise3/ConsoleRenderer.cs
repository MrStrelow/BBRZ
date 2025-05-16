// ConsoleRenderer.cs
using System; // Für Console
using System.Threading; // Für Thread.Sleep

namespace Hamster;

public class ConsoleRenderer : IRenderer // Implementiert IRenderer
{
    private readonly Plane _plane;
    private static readonly string _earthRepresentation = "🟫"; // readonly machen

    /// <summary>
    /// Die Zeit in Millisekunden, die nach dem Rendern eines Frames gewartet wird.
    /// </summary>
    public int TimeToSleepMs { get; set; } = 150; // Standardwert, kann von außen gesetzt werden

    public ConsoleRenderer(Plane plane)
    {
        _plane = plane ?? throw new ArgumentNullException(nameof(plane));
    }

    // Implementiert die Methode der IRenderer-Schnittstelle
    public void Render()
    {
        string[,] displayPlane = new string[_plane.Size, _plane.Size];
        AssignElementsToDisplay(displayPlane);

        // Optimierung: Nur neu zeichnen, wenn sich etwas geändert hat (komplexer)
        // Für dieses Beispiel zeichnen wir immer den gesamten Bildschirm neu.
        if (Console.WindowWidth > 0 && Console.WindowHeight > 0) // Vermeidet Fehler, wenn Konsole noch nicht bereit ist
        {
            Console.SetCursorPosition(0, 0);
        }


        for (int i = 0; i < _plane.Size; i++)
        {
            for (int j = 0; j < _plane.Size; j++)
            {
                Console.Write(displayPlane[i, j]);
            }
            Console.WriteLine();
        }

        Thread.Sleep(TimeToSleepMs);
    }

    private void AssignElementsToDisplay(string[,] displayPlane)
    {
        // Boden
        for (int i = 0; i < _plane.Size; i++)
        {
            for (int j = 0; j < _plane.Size; j++)
            {
                displayPlane[i, j] = _earthRepresentation;
            }
        }

        // Samen
        foreach (var seed in _plane.GetSeeds())
        {
            if (seed.Position.y < _plane.Size && seed.Position.x < _plane.Size &&
                seed.Position.y >= 0 && seed.Position.x >= 0) // Boundary check
            {
                displayPlane[seed.Position.y, seed.Position.x] = Seed.Representation;
            }
        }

        // Hamster
        foreach (var hamster in _plane.GetHamsters())
        {
            if (hamster.Position.y < _plane.Size && hamster.Position.x < _plane.Size &&
               hamster.Position.y >= 0 && hamster.Position.x >= 0) // Boundary check
            {
                // Stelle sicher, dass der Hamster über dem Samen gezeichnet wird, falls am selben Ort
                displayPlane[hamster.Position.y, hamster.Position.x] = hamster.Representation;
            }
        }
    }
}