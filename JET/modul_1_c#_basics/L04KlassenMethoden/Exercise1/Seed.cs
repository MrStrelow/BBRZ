namespace Hamster;
public class Seed
{
    // Fields
    private int x;
    private int y;

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
}
