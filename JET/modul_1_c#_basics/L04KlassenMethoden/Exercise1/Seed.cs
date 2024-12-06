namespace Hamster;

public class Seed
{
    // Felder
    private (int x, int y) position;
    private static String representation = "🌱";

    // (hat) Beziehungen
    private Plane plane;

    // Konstruktor
    public Seed(Plane plane)
    {
        this.plane = plane;

        PositionAndManageSamen();
    }

    private void PositionAndManageSamen()
    {
        var random = new Random();
        bool done;
        int x, y;

        do
        {
            x = random.Next(plane.GetSize());
            y = random.Next(plane.GetSize());

            done = plane.Position(this, (x, y));
        } while (!done);

        position = (x, y);
    }

 
    public override String ToString()
    {
        return representation;
    }

    // get-set Methoden
    public (int x, int y) GetPosition()
    {
        return position;
    }

    public void SetPosition(int x, int y)
    {
        position.x = x;
        position.y = y;
    }

    public void SetPosition((int x, int y) position)
    {
        this.position = position;
    }

    public int GetX()
    {
        return position.x;
    }

    public void SetX(int x)
    {
        position.x = x;
    }

    public int GetY()
    {
        return position.y;
    }

    public void SetY(int y)
    {
        position.y = y;
    }

    public static String GetRepresentation()
    {
        return representation;
    }

    public Plane GetPlane()
    {
        return plane;
    }

    public void SetPlane(Plane spielfeld)
    {
        this.plane = spielfeld;
    }
}
