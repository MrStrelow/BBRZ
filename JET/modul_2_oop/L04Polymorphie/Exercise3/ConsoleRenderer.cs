using System; 
using System.Threading;

namespace Hamster;

public class ConsoleRenderer : IRenderer 
{
    // Felder
    private readonly Plane _plane;
    private static readonly string _earthRepresentation = "🟫";
    private string[,] _displayPlane;

    // Properties
    public int TimeToSleepMs { get; set; } = 150;

    public ConsoleRenderer(Plane plane)
    { 
        _plane = plane ?? throw new ArgumentNullException(nameof(plane));
        _displayPlane = new string[_plane.Size, _plane.Size];
    }

    public void Render()
    {
        AssignElementsToDisplay(_displayPlane);
        Console.SetCursorPosition(0, 0);

        for (int i = 0; i < _plane.Size; i++)
        {
            for (int j = 0; j < _plane.Size; j++)
            {
                Console.Write(_displayPlane[i, j]);
            }
            Console.WriteLine();
        }

        Thread.Sleep(TimeToSleepMs);
    }

    private void AssignElementsToDisplay(string[,] displayPlane)
    {
        for (int i = 0; i < _plane.Size; i++)
        {
            for (int j = 0; j < _plane.Size; j++)
            {
                displayPlane[i, j] = _earthRepresentation;
            }
        }

        // Seedlings
        foreach (var seed in _plane.Seeds.Values)
        {
            if (seed.Position.y < _plane.Size && seed.Position.x < _plane.Size && seed.Position.y >= 0 && seed.Position.x >= 0) 
            {
                displayPlane[seed.Position.y, seed.Position.x] = Seed.Representation;
            }
        }

        // Hamster
        foreach (var hamster in _plane.Hamsters)
        {
            if (hamster.Position.y < _plane.Size && hamster.Position.x < _plane.Size && hamster.Position.y >= 0 && hamster.Position.x >= 0)
            {
                displayPlane[hamster.Position.y, hamster.Position.x] = hamster.Representation;
            }
        }
    }
}