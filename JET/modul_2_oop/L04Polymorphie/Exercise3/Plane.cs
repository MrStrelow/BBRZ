// Plane.cs
namespace Hamster;

public class Plane
{
    // Felder
    // private string[,] _plane; // Entfernt - Darstellung übernimmt ConsoleRenderer
    private static string _earthRepresentation = "🟫"; // Wird ggf. nicht mehr hier benötigt oder an Renderer übergeben

    // Eigenschaften
    public int Size { get; }

    // Beziehungen
    private Dictionary<(int x, int y), Seed> seeds = new();
    private List<Hamster> hamsters = new();

    // Konstruktor
    public Plane(int size)
    {
        Random random = new();
        Size = size;
        // _plane = new string[size, size]; // Entfernt

        // Boden - Logik für _plane entfernt, da Darstellung ausgelagert
        // for (int i = 0; i < size; i++)
        // {
        //     for (int j = 0; j < size; j++)
        //     {
        //         _plane[i, j] = _earthRepresentation;
        //     }
        // }

        // Samen - Die Erzeugung könnte auch ausgelagert werden (später für OCP/DIP)
        int numberOfSeeds = random.Next(1, size * size / 2); // Sicherstellen, dass Platz für Hamster bleibt
        for (int i = 0; i < numberOfSeeds; i++)
        {
            // Die direkte Erzeugung hier ist noch nicht ideal für SRP, aber ein Schritt nach dem anderen.
            // Wir brauchen eine Möglichkeit, Samen zu platzieren, ohne dass Seed die Plane.AssignInitialPosition direkt aufruft,
            // oder wir müssen diese Kopplung akzeptieren, bis wir zu DIP kommen.
            // Vorerst bleibt die Erzeugung hier, aber `AssignInitialPosition` muss ohne `_plane` auskommen.
            _ = new Seed(this); // Seed Konstruktor muss angepasst werden, wenn er _plane direkt manipuliert
        }

        // Hamster - Die Erzeugung könnte auch ausgelagert werden
        int maxHamsters = size * size - seeds.Count;
        if (maxHamsters <= 0) maxHamsters = 1; // Mindestens ein Hamster, wenn Platz ist
        int numberOfHamster = random.Next(1, Math.Max(2, maxHamsters)); // Stelle sicher, dass die Obergrenze > Untergrenze ist
        for (int i = 0; i < numberOfHamster; i++)
        {
            _ = new Hamster(this); // Hamster Konstruktor muss angepasst werden
        }
    }

    public IEnumerable<Seed> GetSeeds() => seeds.Values;
    public IEnumerable<Hamster> GetHamsters() => hamsters.ToList(); // ToList, um eine Kopie zurückzugeben und interne Liste zu schützen

    public void SimulateSeed()
    {
        RegrowSeeds();
    }

    public void SimulateHamster()
    {
        // Kopie der Liste verwenden, falls Hamster sich während der Iteration entfernen (nicht im aktuellen Code, aber gute Praxis)
        foreach (var hamster in hamsters.ToList())
        {
            hamster.Move();
            hamster.NutritionBehaviour();
        }
    }

    // Print und AssignElementsToPlane wurden entfernt

    public void Position(Hamster hamster, Direction direction)
    {
        var pos = hamster.Position;
        var newPos = pos; // Arbeite mit einer neuen Position

        switch (direction)
        {
            case Direction.UP:
                if (pos.y > 0) newPos.y--;
                break;
            case Direction.DOWN:
                if (pos.y < Size - 1) newPos.y++;
                break;
            case Direction.LEFT:
                if (pos.x > 0) newPos.x--;
                break;
            case Direction.RIGHT:
                if (pos.x < Size - 1) newPos.x++;
                break;
        }

        // Hier könnte eine Kollisionsprüfung mit anderen Hamstern stattfinden,
        // bevor die Position des Hamsters aktualisiert wird.
        // Für SRP wäre eine Kollisionsprüfungs-Verantwortlichkeit vielleicht auch separat.
        // Vorerst: Einfache Positionsänderung, wenn das Feld nicht von einem anderen Hamster besetzt ist (außer sich selbst).
        if (!TileTakenByAnotherHamster(newPos, hamster))
        {
            hamster.Position = newPos;
        }
    }

    private bool TileTakenByAnotherHamster((int x, int y) key, Hamster requestingHamster)
    {
        return hamsters.Any(h => h != requestingHamster && h.Position == key);
    }


    public void HamsterIsEatingSeeds(Hamster hamster)
    {
        seeds.Remove(hamster.Position);
    }

    public void HamsterIsStoringSeeds(Hamster hamster)
    {
        seeds.Remove(hamster.Position);
    }

    public void RegrowSeeds()
    {
        var random = new Random();
        (int x, int y) key;

        // Vermeide Division durch Null, wenn seeds.Count 0 ist.
        int potentialGrowth = seeds.Count > 0 ? (int)Math.Pow(hamsters.Count, 2) / seeds.Count : hamsters.Count * 2;
        if (potentialGrowth == 0 && hamsters.Count > 0) potentialGrowth = 1; // Mindestens 1 Samen wachsen lassen, wenn Hamster da sind und keine Samen

        int freeTiles = Size * Size - hamsters.Count - seeds.Count;
        if (freeTiles <= 0) return; // Keine freien Felder

        int bound = Math.Min(potentialGrowth, freeTiles);
        bound = Math.Min(bound, Size * Size / 10); // Nicht zu viele auf einmal wachsen lassen

        for (int i = 0; i < bound; i++)
        {
            int attempts = 0; // Versuchszähler, um Endlosschleifen zu vermeiden
            bool fieldIsTaken;
            do
            {
                key = (random.Next(Size), random.Next(Size));
                fieldIsTaken = seeds.ContainsKey(key) || TileTakenByHamster(key);
                attempts++;
                if (attempts > Size * Size && freeTiles < bound) return; // Wenn wir keine freien Felder mehr finden können
            } while (fieldIsTaken && attempts < Size * Size * 2); // Erhöhte Versuche, falls das Feld sehr voll ist

            if (!fieldIsTaken)
            {
                // Erzeuge hier das Seed-Objekt direkt oder über eine Factory (später)
                // Das Seed-Objekt benötigt seine Position bei der Erstellung.
                // Die Logik `AssignInitialPosition(Seed seed, ...)` wird nun anders verwendet.
                var newSeed = new Seed(this); // Seed Konstruktor braucht evtl. keine Plane mehr, oder nur für Size
                newSeed.Position = key; // Eine neue Methode für Seed
                seeds[key] = newSeed;
            }
        }
    }

    // AssignInitialPosition muss angepasst werden, da _plane entfernt wurde.
    // Die Verantwortung der Plane ist es, sicherzustellen, dass Positionen nicht doppelt belegt sind.
    public bool AssignInitialPosition(Hamster hamster, (int x, int y) key)
    {
        if (!seeds.ContainsKey(key) && !TileTakenByHamster(key))
        {
            // _plane[key.y, key.x] = hamster.Representation; // Entfernt
            if (!hamsters.Contains(hamster)) // Füge Hamster nur hinzu, wenn er noch nicht in der Liste ist
            {
                hamsters.Add(hamster);
            }
            hamster.Position = key; // Position direkt am Hamster setzen
            return true;
        }
        return false;
    }

    public bool AssignInitialPosition(Seed seed, (int x, int y) key)
    {
        if (!seeds.ContainsKey(key) && !TileTakenByHamster(key))
        {
            // _plane[key.y, key.x] = Seed.Representation; // Entfernt
            seeds[key] = seed; // Seed zur Dictionary hinzufügen
            seed.SetPosition(key); // Position direkt am Seed setzen
            return true;
        }
        return false;
    }

    // Behält die Logik, um zu prüfen, ob ein Feld von einem Hamster besetzt ist.
    public bool TileTakenByHamster((int x, int y) key)
    {
        return hamsters.Any(h => h.Position == key);
    }

    public bool ContainsSeed((int x, int y) key)
    {
        return seeds.ContainsKey(key);
    }

    public Seed GetSeedOn((int x, int y) key)
    {
        if (seeds.TryGetValue(key, out Seed seed))
        {
            return seed;
        }
        return null; // Oder eine Ausnahme werfen
    }

    public void AddHamster(Hamster hamster)
    {
        if (!hamsters.Contains(hamster))
        {
            hamsters.Add(hamster);
        }
    }
    public void AddSeed(Seed seed, (int x, int y) position)
    {
        if (!seeds.ContainsKey(position) && !TileTakenByHamster(position))
        {
            seed.Position = position;
            seeds[position] = seed;
        }
        // Optional: Fehlerbehandlung, wenn Position belegt ist
    }
}