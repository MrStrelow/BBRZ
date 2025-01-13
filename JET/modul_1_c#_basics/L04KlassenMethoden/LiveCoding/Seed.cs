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

        PositionAndManageSamen();
    }

    // Methods

    // private Methode
    private void PositionAndManageSamen()
    {
        var random = new Random();
        bool done;
        int x, y;

        do
        {
            x = random.Next(plane.GetSize());
            y = random.Next(plane.GetSize());

            done = plane.AssignInitialPosition(this, (x, y));
        } while (!done);


        position = (x, y);
    }

    // get-set methoden
    public (int x, int y) GetPosition()
    {
        return position;
    }

    public static string GetRepresentation()
    {
        return representation;
    }
}
