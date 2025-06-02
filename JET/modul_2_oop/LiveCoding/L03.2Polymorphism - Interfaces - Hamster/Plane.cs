using System.Drawing;
using System.Text;

namespace Hamster;

public class Plane
{
    // Felder

    // Eigenschaften
    public static string EarthRepresentation { get; private set; } = "🟫";
    public int Size { get; set; }

    // Beziehungen
    public Dictionary<(int x, int y), Seedling> Seedlings { get; private set; } = new();
    public List<Hamster> Hamsters { get; private set; } = new();

    // Konstruktor
    public Plane(int size)
    {
        // variablen initialisieren
        Size = size;

        var random = new Random();

        // wie viele hamster gibt es? zufällig.
        // Hamster erstellen
        for (int i = 0; i < random.Next(1, Size*Size); i++)
        {
            if( random.NextDouble() < 0.5 )
            {
                Hamsters.Add(new BigMouthHamster(this)); 
            }
            else
            {
                Hamsters.Add(new BigLegHamster(this)); 
            }
        }

        // wie viele Seedlings gibt es? zufällig.
        // Seedlings erstellen
        for (int i = 0; i < random.Next(1, Size*Size - Hamsters.Count); i++)
        {
            var Seedling = new Seedling(this);
            Seedlings[Seedling.Position] = Seedling;
        }
    }

    public bool TryToAssignInitialPosition(Hamster hamster, (int x, int y) positionOfHamsterToBeAssigned)
    {
        bool positionIsTaken = false;

        // Logik
        foreach (var alreadyExistingHamster in Hamsters)
        {
            if (alreadyExistingHamster.Position == positionOfHamsterToBeAssigned)
            {
                positionIsTaken = true;
                break;
            }
        }

        return positionIsTaken;

    }

    public bool TryToAssignInitialPosition(Seedling Seedling, (int x, int y) positionOfSeedlingToBeAssigned)
    {
        if (!Seedlings.ContainsKey(positionOfSeedlingToBeAssigned))
        {
            return false;
        }

        return true;
    }

    public void SimulateHamster()
    {
        foreach (var hamster in Hamsters)
        {
            hamster.Move();
            hamster.NutritionBehaviour();
        }
    }


    // überladen!
    public void Position(Hamster hamster, Direction direction)
    {
        Position(hamster, new List<Direction> { direction });
    }

    public void Position(Hamster hamster, List<Direction> directions)
    {
        var pos = hamster.Position;

        foreach (var direction in directions)
        {
            switch(direction)
            {
                case Direction.LEFT:
                    if (pos.x != 0)
                    {
                        pos.x--;
                    } 
                    break;

                case Direction.RIGHT:
                    if (pos.x != Size - 1)
                    {
                        pos.x++;
                    }
                    break;

                case Direction.UP:
                    if (pos.y != 0)
                    {
                        pos.y--;
                    }
                    break;

                case Direction.DOWN:
                    if (pos.y != Size - 1)
                    {
                        pos.y++;
                    }
                    break;
            }
        }


        hamster.Position = pos;

        //Console.WriteLine($"Hamster: {hamster.GetHashCode()} - pos:{hamster.Position}");
    }

    public void HamsterIsEatingSeedlings(Hamster hamster)
    {
        Seedlings.Remove(hamster.Position);
    }

    public Seedling GetSeedlinglingOn((int x, int y) position)
    {
        return Seedlings[position];
    }

    public bool ContainsSeedling((int x, int y) position)
    {
        return Seedlings.ContainsKey(position);
    }

    public void SimulateSeedling()
    {
        RegrowSeedlings();
    }

    public void RegrowSeedlings()
    {
        var random = new Random();
        bool fieldIsTaken;
        (int x, int y) key;

        int potentialGrowth = (int)Math.Pow(Hamsters.Count, 2) / Seedlings.Count;
        int freeTiles = Size * Size - Hamsters.Count - Seedlings.Count;

        int bound = Math.Min(potentialGrowth, freeTiles);

        for (int i = 0; i < bound; i++)
        {
            do
            {
                key = (random.Next(Size), random.Next(Size));
                fieldIsTaken = Seedlings.ContainsKey(key);
            } while (fieldIsTaken);

            Seedlings[key] = new Seedling(this);
        }
    }
}
