using System.Text;
using Serilog;

namespace Hamster;

public class Simulation
{
    static void Main(string[] args)
    {
        // Logging - Config
        Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("../../../log.txt").CreateLogger();

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
        var renderers = new List<IRenderer> { new ConsoleRenderer(plane), new HtmlRenderer(plane) };

        while (true)
        {
            // Logik Methoden
            // simulate hamster
            plane.SimulateHamster();

            //// simulate Seedlinglings
            plane.SimulateSeedling();

            // Darstellungs Methoden
            //// Darstellung anzeigen
            foreach (var renderer in renderers)
            {
                renderer.Render();
            }


        }
    }
}