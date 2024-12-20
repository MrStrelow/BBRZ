
namespace LiveCoding;

class Plane
{
    // Fields
    private string[,] plane;
    private int size;
    private static string earthRepresentation = "🟫";

    // has-A-Relation
    List<Hamster> hamsters = new List<Hamster>();
    Dictionary<(int x, int y), Seed> seeds = new Dictionary<(int x, int y), Seed>();

    // Constructor
    public Plane(int size)
    {
        Random random = new Random();
        this.size = size;
        plane = new string[size,size];

        // wir belegen das spielfeld mit Bodensymbole
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                plane[i, j] = earthRepresentation;
            }
        }

        // wir brauchen Samen


        // wir brauchen Hamster


    }


    // Methods
    public void SimulateHamster()
    {
        throw new NotImplementedException();
    }

    public void SimulateSeed()
    {
        throw new NotImplementedException();
    }

    public void Print(int timeToSleep = 500)
    {
        Console.SetCursorPosition(0,0);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(plane[i, j]);
            }
            Console.WriteLine();
        }

        Thread.Sleep(timeToSleep);
    }
}
