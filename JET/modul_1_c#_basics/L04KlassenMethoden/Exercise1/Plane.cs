namespace Hamster;

public class Plane
{
    // Fields
    private String[,] plane;
    private String earthSymbol = "🟫";
    private int size = 5;

    // Association
    private List<Seed> seed;
    private List<Hamster> hamsters;

    // Constructor
    public Plane()
    {
        // hier ist die Logik der Darstellung drinnen
        plane = new String[size, size];

        // spielfeld mit leerzeichen befüllen
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                plane[i,j] = earthSymbol;
            }
        }

        // hier ist Logik ohne spezielle Darstellung vorhanden.
        // fuer Samen
        seed = new List<Seed>();

        Random random = new Random();
        int numberOfSeeds = random.Next(1, size * size - 1);

        for (int i = 0; i < numberOfSeeds; i++)
        {
            seed.Add(new Seed(this));
        }

        // fuer Hamster
        hamsters = new List<Hamster>();

        int anzahlHamster = random.Next(1, size * size - numberOfSeeds + 1);

        for (int i = 0; i < anzahlHamster; i++)
        {
            hamsters.Add(new Hamster(this));
        }
    }


    // Methods
    public void assign(Seed seed)
    {
        Random random = new Random();
        int x = random.Next(size);
        int y = random.Next(size);

        if (plane[y,x] == earthSymbol)
        {
            seed.SetX(x);
            seed.SetY(y);

            plane[y,x] = seed.getSeedSymbol();
        }
        else
        {

            // rekursion!!! wenns spielfeld bereits voll ist, probiers nocheinmal.
            assign(seed);

        }
    }

    public void assign(Hamster hamster)
    {
        Random random = new Random();
        int x = random.Next(size);
        int y = random.Next(size);

        if (plane[y,x] == earthSymbol)
        {
            hamster.SetX(x);
            hamster.SetY(y);

            plane[y,x] = hamster.GetSymbol();
        }
        else
        {

            // rekursion!!! wenns spielfeld bereits voll ist, probiers nocheinmal.
            assign(hamster);

        }
    }

    public void move(Hamster hamster, Direction richtung)
    {
        // setze vorheriges Feld auf das Feld welches ich bald verlassen werde
        if (hamster.GetSpotToRemember() != null)
        {
            plane[hamster.GetY(), hamster.GetX()] = hamster.GetSpotToRemember();
        }

        // ich bewege mich
        switch (richtung)
        {
        case Direction.Right:
            if (size - 1 != hamster.GetX())
            {
                hamster.SetX(hamster.GetX() + 1);
            }
            break;

        case Direction.Left:
            if (hamster.GetX() != 0)
            {
                hamster.SetX(hamster.GetX() - 1);
            }
            break;

        case Direction.Up:
            if (hamster.GetY() != 0)
            {
                hamster.SetY(hamster.GetY() - 1);
            }
            break;

        case Direction.Down:
            if (size - 1 != hamster.GetY())
            {
                hamster.SetY(hamster.GetY() + 1);
            }
            break;
        }


        // ist das neue Feld, auf das ich gehe ein Hamster?
        bool isFedHamsterOnThePlan = plane[hamster.GetY(), hamster.GetX()] == Hamster.GetFedSymbol();
        bool isHungryHamsterOnThePlane = plane[hamster.GetY(), hamster.GetX()] == Hamster.GetHungrySymbol();

        // wenn es kein Hamster ist, merke es dir
        // wenn es ein Hamster ist, vergiss dein gemerktes feld
        if (!(isFedHamsterOnThePlan || isHungryHamsterOnThePlane))
        {
            hamster.SetSpotToRemember(plane[hamster.GetY(), hamster.GetX()]);
        }
        else
        {
            hamster.SetSpotToRemember(null);
        }

        plane[hamster.GetY(), hamster.GetX()] = hamster.GetSymbol();
    }


    public void EatingSeeds(Hamster hamster)
    {
        foreach (Seed s in seed)
        {

            bool hamsterStehtDrauf = hamster.GetX() == s.GetX() && hamster.GetY() == s.GetY();

            if (hamsterStehtDrauf)
            {
                seed.Remove(s);
                break;
            }
        }

        // symbol im spielfeld wird überschrieben mit dem standard symbol (boden)
        hamster.SetSpotToRemember(earthSymbol);
    }

    public void StoringSeeds(Hamster hamster)
    {
        // wir wollen hier den backenspeicher mit einem essen befüllen
        foreach (Seed s in seed)
        {

            bool hamsterStehtDrauf = hamster.GetX() == s.GetX() && hamster.GetY() == s.GetY();

            if (hamsterStehtDrauf)
            {
                hamster.GetMouth().Add(s);
                seed.Remove(s);
                break;
            }
        }

        hamster.SetSpotToRemember(earthSymbol);
    }

    public void PrintPlane()
    {
        Console.Clear();

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(plane[i,j]);
            }
            Console.WriteLine();
        }
    }

    // getter-setter
    public List<Hamster> getHamsters()
    {
        return hamsters;
    }

    public String getEarthSymbol()
    {
        return earthSymbol;
    }

    public List<Seed> getSeed()
    {
        return seed;
    }
}
