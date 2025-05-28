namespace Hamster;

public class Plane
{
    // Felder
    private string[,] _plane;

    // Eigenschaften
    public int Size { get; }
    public static string EarthRepresentation { get; } = "🟫";

    // Beziehungen
    private Dictionary<(int x, int y), Seedling> _Seedlings = new();
    private List<Hamster> _hamsters = new();

    // Konstruktor
    public Plane(int size)
    {
        var random = new Random();
        Size = size;
        _plane = new string[size, size];

        // Boden
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                _plane[i, j] = EarthRepresentation;
            }
        }

        // Samen
        int numberOfSeedlings = random.Next(1, size * size);
        for (int i = 0; i < numberOfSeedlings; i++)
        {
            var Seedling = new Seedling(this);
            _Seedlings[Seedling.Position] = Seedling;
        }

        // Hamster
        int numberOfHamster = random.Next(1, size * size - numberOfSeedlings + 1);
        Console.WriteLine(numberOfSeedlings + numberOfHamster);
        for (int i = 0; i < numberOfHamster; i++)
        {
            _hamsters.Add(new Hamster(this));
        }
    }

    public void SimulateSeedling()
    {
        RegrowSeedlings();
    }

    public void SimulateHamster()
    {
        foreach (var hamster in _hamsters)
        {
            hamster.Move();
            hamster.NutritionBehaviour();
        }
    }

    public void Print(int timeToSleep = 500)
    {
        Console.SetCursorPosition(0, 0);

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Console.Write(_plane[i, j]);
            }
            Console.WriteLine();
        }

        Thread.Sleep(timeToSleep);
    }

    public void Position(Hamster hamster, Direction direction)
    {
        // Problematisch! Wir sehen hier warum.
        _plane[hamster.Position.y, hamster.Position.x] = hamster.RememberSymbolOnPlane;
        var pos = hamster.Position;

        switch (direction)
        {
            case Direction.UP:
                if (pos.y > 0)
                    // Alternativ:// hamster.Position = (hamster.Position.x, hamster.Position.y - 1);
                    pos.y--;
                break;

            case Direction.DOWN:
                if (pos.y < Size - 1)
                    pos.y++;
                break;

            case Direction.LEFT:
                if (pos.x > 0)
                    pos.x--;
                break;

            case Direction.RIGHT:
                if (hamster.Position.x < Size - 1)
                    pos.x++;
                break;
        }

        hamster.Position = pos;

        // Sehr Problematisch!
        // Dieser Code ist ein "dirty fix"! Wir beheben das Problem, jedoch ist dieses Konstrukt relativ unnötig.
        // Wir haben hier eine "View-Driven Logic". Bedeutet wir greifen bei der Bestimmung des Zustandes unseres Programmes auf grafische Elemente zu.
        // Dieses ist alles was mit der Eigenschaft RememberSymbolOnPlane des Hamsters in Verbindung steht.
        // Der Zweck dieser war, dass der Hamster sich das Symbol merkt wenn ein Tile betreten wird und dieses wieder hinmalt, wenn er dieses verlassen wird.
        // Durch diese Mischer der Logik des Zustandes unseres Programms und dessen Darsatellung, passiert nun folgendes.
        // Was ist wenn zwei Hamster auf das gleiche Feld fahren?
        //  * 1. Hamster mekrt sich die Erde und malt sich selber darüber.
        //  * 2. Hamster mekrt sich, DEN ANDEREN HAMSTER, und malt sich selber darüber. 
        //  * 1. Hamster verlässt das Tile und malt die gemerkte Erde hin.
        //  * [BUG] 2. Hamster verlässt ebenso das Tile und malt den gemerkten HAMSTEr hin.
        // Es entsteht ein zustätzliches Symbol eines Hamsters auf dem Spielfeld, welches nicht gewünscht ist.
        // Aus 2 Hamster werden nun graifsch 3, jedoch logisch in unserer Liste bleiben es 2.

        // Wir müssen nun folgende Beingung einbauen, welche sich darum kümmert, sich keine Hamster zu merken.
        // Das funktioniert, jedoch wenn wir das Programm erweitern, ist es nun nicht an einer Stelle wo unser, sondern potentiell verteilt...
        // Wir bauen somit sehr leicht weitere Fehler ein, welche uns in den Wahnsinn treiben wenn wir 300 verschiedene Darstellungen von Hamstern haben,
        // und all diese an verschiedenen Orten abfragen um diese sich nicht zu merken.

        // Um den Bug "dirty" zu beheben kommentiere die folgende If-Bedingung ein.
        string hamsterSymbol = _plane[hamster.Position.y, hamster.Position.x];
        bool noHamsterOnThisPosition =
                hamsterSymbol == Hamster.FedRepresentation ||
                hamsterSymbol == Hamster.HungryRepresentation;

        if (!noHamsterOnThisPosition)
        {
            hamster.RememberSymbolOnPlane = _plane[hamster.Position.y, hamster.Position.x]; // Problematisch! Wir sehen hier warum.
        }

        _plane[hamster.Position.y, hamster.Position.x] = hamster.Representation;
    }

    public void HamsterIsEatingSeedlings(Hamster hamster)
    {
        _Seedlings.Remove(hamster.Position);
        hamster.RememberSymbolOnPlane = EarthRepresentation; // Problematisch! Wir sehen bald warum...
    }

    public void HamsterIsStoringSeedlings(Hamster hamster)
    {
        _Seedlings.Remove(hamster.Position);
        hamster.RememberSymbolOnPlane = EarthRepresentation; // Problematisch! Wir sehen bald warum...
    }

    public void RegrowSeedlings()
    {
        int potentialGrowth = (int)Math.Pow(_hamsters.Count, 2) / _Seedlings.Count;
        int freeTiles = Size * Size - _hamsters.Count - _Seedlings.Count;

        int bound = Math.Min(potentialGrowth, freeTiles);

        for (int i = 0; i < bound; i++)
        {
            var Seedling = new Seedling(this);
            _Seedlings[Seedling.Position] = Seedling;
            _plane[Seedling.Position.y, Seedling.Position.x] = Seedling.Representation;
        }
    }

    public bool AssignInitialPosition(Hamster hamster, (int x, int y) key)
    {
        if (!_Seedlings.ContainsKey(key) && !TileTakenByHamster(key))
        {
            _plane[key.y, key.x] = hamster.Representation;
            return true;
        }

        return false;
    }

    public bool AssignInitialPosition(Seedling Seedling, (int x, int y) key)
    {
        if (!_Seedlings.ContainsKey(key) && !TileTakenByHamster(key))
        {
            _plane[key.y, key.x] = Seedling.Representation;
            return true;
        }

        return false;
    }

   public bool TileTakenByHamster((int x, int y) key)
    {
        foreach (var hamster in _hamsters)
        {
            if (hamster.Position == key)
            {
                return true;
            }
        }

        return false;

        //Zukunft - alternative schreibweise: return _hamsters.Any(h => h.Position == key);
    }

    public bool ContainsSeedling((int x, int y) key)
    {
        return _Seedlings.ContainsKey(key);
    }

    public Seedling GetSeedlingOn((int x, int y) key)
    {
        return _Seedlings[key];
    }
}
