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
    public void move()
    {
        Random random = new Random();
        Direction[] values = (Direction[]) Enum.GetValues(typeof(Direction));
        Direction direction = values[random.Next(values.Length)];

        plane.move(this, direction);
    }

    public void Metabolize() // TODO: wort
    {
        GettingHungry();

        bool isHamsterOnSpotWithFood = spotToRemember == plane.getSeedSymbol();
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
    public int getX()
    {
        return x;
    }

    public void setX(int x)
    {
        this.x = x;
    }

    public int getY()
    {
        return y;
    }

    public void setY(int y)
    {
        this.y = y;
    }

    public void setSpotToRemember(String spotToRemember)
    {
        if (spotToRemember != null)
        {
            this.spotToRemember = spotToRemember;
        }
    }

    public String getSpotToRemember()
    {
        return this.spotToRemember;
    }

    public Boolean getIstHungrig()
    {
        return isHungry;
    }

    public void setIsHungry(Boolean isHungry)
    {
        this.isHungry = isHungry;
    }

    public List<Seed> getBackenSpeicher()
    {
        return mouth;
    }

    public String getDarstellung()
    {
        return symbol;
    }

    public void setDarstellung(String darstellung)
    {
        this.symbol = darstellung;
    }

    public String getHungrigeDarstellung()
    {
        return hungrySymbol;
    }

    public String getNormaleDarstellung()
    {
        return fedSymbol;
    }
}
