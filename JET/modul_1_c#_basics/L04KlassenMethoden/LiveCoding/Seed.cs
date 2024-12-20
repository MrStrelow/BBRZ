namespace LiveCoding;

class Seed
{
    // Fields
    private (int x, int y) position;
    private static string representation = "🌱";

    // has-A-Relation
    private Plane plane;

    // Constructor
    public Seed(Plane plane)
    {
        this.plane = plane;
    }

    // Methods

    // get-set methoden
    public (int x, int y) GetPosition()
    {
        return position;
    }
}
