using System.Text;

namespace Hamster;

public class Simulation
{
    static void Main(string[] args)
    {
        // User Intput:
        Console.OutputEncoding = Encoding.UTF8;

        string promotForUser = "How large should the plane be?: ";
        Console.Write(promotForUser);

        int sizeOfPlane;

        while (!int.TryParse(Console.ReadLine(), out sizeOfPlane))
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Input is not an integer number. Please try again.");
            Console.ResetColor();

            Console.Write(promotForUser);
        }

        Console.Clear();
        Console.CursorVisible = false;

        // Start der Simulation:
        Plane plane = new Plane(sizeOfPlane);
        //IRenderer renderer = new ConsoleRenderer(plane) { TimeToSleepMs = 1000 };
        IRenderer renderer = new HtmlRenderer(plane) { TimeToSleepMs = 1000 };

        while (true)
        {
            // Logik Methoden
            // simulate hamster
            plane.SimulateHamster();

            //// simulate seedlings
            plane.SimulateSeed();

            // Darstellungs Methoden
            //// Darstellung anzeigen
            renderer.Render();
        }

    }
}