using Hamster;
using System.Text;

namespace Hamster;

public class Main
{
    public static void main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Plane meinFeld = new Plane();

        while (true)
        {
            for (Hamster hamster : meinFeld.getHamsters())
            {
                hamster.Metabolize();
                hamster.move();
            }

            meinFeld.PrintPlane();
            System.out.println("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            try
            {
                Thread.sleep(1000);
            }
            catch (InterruptedException e)
            {
                throw new RuntimeException(e);
            }

        }
    }
}
