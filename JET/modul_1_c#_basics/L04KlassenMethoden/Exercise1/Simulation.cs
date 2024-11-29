using Hamster;
using System.Text;

namespace Hamster;

public class Simulation
{
    static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Plane meinFeld = new Plane();

        while (true)
        {
            foreach (Hamster hamster in meinFeld.getHamsters())
            {
                hamster.Metabolize();
                hamster.Move();
            }

            meinFeld.PrintPlane();

            Thread.Sleep(500);
        }
    }
}
