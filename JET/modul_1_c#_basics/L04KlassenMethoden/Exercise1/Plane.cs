namespace Hamster;

public class Plane
{
    // Fields
    private String[,] plane;
    private String earthSymbol = "🟫";
    private String seedSymbol = "🌱";
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
    public void assign(Seed samen)
    {
        Random random = new Random();
        int x = random.Next(size);
        int y = random.Next(size);

        if (plane[y,x] == earthSymbol)
        {
            samen.setX(x);
            samen.setY(y);

            plane[y,x] = seedSymbol;
        }
        else
        {

            // rekursion!!! wenns spielfeld bereits voll ist, probiers nocheinmal.
            assign(samen);

        }
    }

    public void assign(Hamster hamster)
    {
        Random random = new Random();
        int x = random.Next(size);
        int y = random.Next(size);

        if (plane[y,x] == earthSymbol)
        {
            hamster.setX(x);
            hamster.setY(y);

            plane[y,x] = hamster.getDarstellung();
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
        if (hamster.getSpotToRemember() != null)
        {
            plane[hamster.getY(), hamster.getX()] = hamster.getSpotToRemember();
        }

        // ich bewege mich
        switch (richtung)
        {
            case rechts-> {
                    if (size - 1 != hamster.getX())
                    {
                        hamster.setX(hamster.getX() + 1);
                    }
                }
            case links-> {
                    if (0 != hamster.getX())
                    {
                        hamster.setX(hamster.getX() - 1);
                    }
                }
            case oben-> {
                    if (0 != hamster.getY())
                    {
                        hamster.setY(hamster.getY() - 1);
                    }
                }
            case unten-> {
                    if (size - 1 != hamster.getY())
                    {
                        hamster.setY(hamster.getY() + 1);
                    }
                }
        }

        // ist das neue Feld, auf das ich gehe ein Hamster?
        bool isFedHamsterOnThePlan = plane[hamster.getY(), hamster.getX()] == hamster.getNormaleDarstellung();
        bool isHungryHamsterOnThePlane = plane[hamster.getY(), hamster.getX()] == hamster.getHungrigeDarstellung();

        // wenn es kein Hamster ist, merke es dir
        // wenn es ein Hamster ist, vergiss dein gemerktes feld
        if (!(isFedHamsterOnThePlan || isHungryHamsterOnThePlane))
        {
            hamster.setSpotToRemember(plane[hamster.getY(), hamster.getX()]);
        }
        else
        {
            hamster.setSpotToRemember(null);
        }
    }


    public void EatingSeeds(Hamster hamster)
    {
        foreach (Seed s in seed)
        {

            bool hamsterStehtDrauf = hamster.getX() == s.getX() && hamster.getY() == s.getY();

            if (hamsterStehtDrauf)
            {
                seed.Remove(s);
                break;
            }
        }

        // symbol im spielfeld wird überschrieben mit dem standard symbol (boden)
        hamster.setSpotToRemember(earthSymbol);
    }

    public void StoringSeeds(Hamster hamster)
    {
        // wir wollen hier den backenspeicher mit einem essen befüllen
        foreach (Seed s in seed)
        {

            bool hamsterStehtDrauf = hamster.getX() == s.getX() && hamster.getY() == s.getY();

            if (hamsterStehtDrauf)
            {
                hamster.getBackenSpeicher().Add(s);
                seed.Remove(s);
                break;
            }
        }

        hamster.setSpotToRemember(earthSymbol);
    }

    public void PrintPlane()
    {
        PlaceHamster();

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(plane[i,j]);
            }
            Console.WriteLine();
        }
    }

    private void PlaceHamster()
    {
        foreach (Hamster hamster in hamsters)
        {
            plane[hamster.getY(), hamster.getX()] = hamster.getDarstellung();
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

    public String getSeedSymbol()
    {
        return seedSymbol;
    }

    public List<Seed> getSeed()
    {
        return seed;
    }
}
