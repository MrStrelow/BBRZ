namespace Hamster;
public class Seed
{
    // Fields
    private int x; // use tuple instead: private (int x, int y) position;
    private int y;
    public static String seedSymbol = "🌱";

    // Association
    private Plane plane;

    // Constructor
    public Seed(Plane plane)
    {
        this.plane = plane;
        this.plane.assign(this);
    }

    // Methods
    // getter-setter Methods (Wird nicht in c# verwendet!)

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

    public String getSeedSymbol()
    {
        return seedSymbol;
    }
}
