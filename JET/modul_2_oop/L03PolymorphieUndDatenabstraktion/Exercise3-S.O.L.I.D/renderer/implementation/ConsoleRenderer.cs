using Hamster.Strategies;
using System; 
using System.Threading;

namespace Hamster;

public sealed class ConsoleRenderer : IRenderer 
{
    // Felder
    private readonly Plane _plane;
    private UnicodeRepresentation[,] _displayPlane;

    // Properties
    public int TimeToSleepMs { get; set; } = 150;

    public ConsoleRenderer(Plane plane)
    { 
        _plane = plane ?? throw new ArgumentNullException(nameof(plane));
        _displayPlane = new UnicodeRepresentation[_plane.Size, _plane.Size];
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

    private void AssignElementsToDisplay(IVisualRepresentation[,] displayPlane)
    {
        for (int i = 0; i < _plane.Size; i++)
        {
            for (int j = 0; j < _plane.Size; j++)
            {
                displayPlane[i, j] = Plane.Representation;
            }
        }

        // Seedlinglings
        foreach (var Seedling in _plane.Seedlings.Values)
        {
            if (Seedling.Position.y < _plane.Size && Seedling.Position.x < _plane.Size && Seedling.Position.y >= 0 && Seedling.Position.x >= 0) 
            {
                displayPlane[Seedling.Position.y, Seedling.Position.x] = Seedling.Representation?.Representation as string ?? throw new NullReferenceException();
            }
        }

        // Hamster
        foreach (var hamster in _plane.Hamsters)
        {
            if (hamster.Position.y < _plane.Size && hamster.Position.x < _plane.Size && hamster.Position.y >= 0 && hamster.Position.x >= 0)
            {
                displayPlane[hamster.Position.y, hamster.Position.x] = hamster.Representation?.Representation as string ?? throw new NullReferenceException();
            }
        }
    }
}