using System.Text;

namespace Hamster;

public class Hamster
{
    // Fields
    private String namen;
    private String symbol;
    private String fedSymbol;
    private String hungrySymbol;
    private int x;
    private int y;
    private String spotToRemember;
    private Boolean isHungry;

    // Association
    private Plane plane;
    private List<Seed> mouth;

    // Constructor
    public Hamster(Plane plane)
    {
        mouth = new List<Seed>();
        this.isHungry = false;

        fedSymbol = "🐹";
        hungrySymbol = "🐰";

        this.plane = plane;
        this.spotToRemember = plane.getEarthSymbol();
        symbol = fedSymbol;

        this.plane.assign(this);
    }

    // hier wird der hamster dem spielfeld zugewiesen. Siehe Samen.
    // wo wird der hamster im spielfeld hingesetzt?

    // Methods
    public void Move()
    {
        Random random = new Random();
        Direction[] values = (Direction[]) Enum.GetValues(typeof(Direction));
        Direction direction = values[random.Next(values.Length)];

        plane.move(this, direction);
    }

    public void Metabolize() // TODO: wort
    {
        GettingHungry();

        bool isHamsterOnSpotWithFood = spotToRemember == Seed.seedSymbol;
        if (isHungry && isHamsterOnSpotWithFood)
        {
            Eating();
        }

        if (!isHungry && isHamsterOnSpotWithFood)
        {
            Storing();
        }
    }

    private void GettingHungry()
    {
        Random random = new Random();
        if (random.NextDouble() < 0.1)
        {
            isHungry = true;
            symbol = hungrySymbol;
        }
    }

    private void Eating()
    {
        isHungry = false;
        symbol = fedSymbol;
        plane.EatingSeeds(this);
    }

    private void Storing()
    {
        plane.StoringSeeds(this);
    }

    //TODO 3: nicht passierbare felder einbauen (wie steine oder, ab jetzt dann hamster! -  mit exception)
    //TODO 4: verschiedene typen von hamstern bzw. essen

    // getter-setter
    public int GetX()
    {
        return x;
    }

    public void SetX(int x)
    {
        this.x = x;
    }

    public int GetY()
    {
        return y;
    }

    public void SetY(int y)
    {
        this.y = y;
    }

    public void SetSpotToRemember(String spotToRemember)
    {
        if (spotToRemember != null)
        {
            this.spotToRemember = spotToRemember;
        }
    }

    public String GetSpotToRemember()
    {
        return this.spotToRemember;
    }

    public Boolean GetIstHungrig()
    {
        return isHungry;
    }

    public void SetIsHungry(Boolean isHungry)
    {
        this.isHungry = isHungry;
    }

    public List<Seed> GetMouth()
    {
        return mouth;
    }

    public String GetSymbol()
    {
        return symbol;
    }

    public void SetSymbol(String darstellung)
    {
        this.symbol = darstellung;
    }

    public String GetHungrySymbol()
    {
        return hungrySymbol;
    }

    public String GetFedSymbol()
    {
        return fedSymbol;
    }
}
