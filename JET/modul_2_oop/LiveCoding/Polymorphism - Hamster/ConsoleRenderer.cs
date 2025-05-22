using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamster;

public class ConsoleRenderer : IRenderer
{
    // Felder
    private string[,] _plane;

    // Eigenschaft
    public int DelayInMilliseconds { get; set; } = 50;
    
    // Beziehungen
    public Plane Plane { get; set; }

    // Konstruktor
    public ConsoleRenderer(Plane plane)
    {
        Plane = plane;
        _plane = new string[plane.Size, plane.Size];
    }


    public void Render()
    {
        Console.SetCursorPosition(0, 0);

        AssignElementToPlane();

        for (int zeile = 0; zeile < Plane.Size; zeile++)
        {
            for (int spalte = 0; spalte < Plane.Size; spalte++)
            {
                Console.Write(_plane[zeile, spalte]);
            }
            Console.WriteLine();
        }

        Thread.Sleep(DelayInMilliseconds);
        Console.WriteLine();
    }

    private void AssignElementToPlane()
    {
        // alles ist erde
        for (int y = 0; y < Plane.Size; y++)
        {
            for (int x = 0; x < Plane.Size; x++)
            {
                _plane[y, x] = Plane.EarthRepresentation;
            }
        }

        // nimm hamster und zeichne die position
        foreach (var hamster in Plane.Hamsters)
        {
            _plane[hamster.Position.y, hamster.Position.x] = hamster.Representation;
        }

        // nimm seeds und zeichne die position
        foreach (var seedling in Plane.Seeds.Values)
        {
            _plane[seedling.Position.y, seedling.Position.x] = Seed.Representation;
        }
    }
}
