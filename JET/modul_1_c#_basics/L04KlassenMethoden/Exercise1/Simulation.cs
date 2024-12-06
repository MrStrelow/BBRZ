using Hamster;
using System.Text;

namespace Hamster;

public class Simulation
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Plane spielfeld = new Plane(5);

        while (true) {
            spielfeld.SimulateHamster();
            spielfeld.SimulateSeed();

            spielfeld.Print();
            Thread.Sleep(50);
        }
    }
}

