using System.Text;
using Serilog;

namespace Hamster;

public class Simulation
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().MinimumLevel.Fatal().WriteTo.File("../../../log.txt").CreateLogger();
        // 1. package installieren - in der Package Manager Console
        // * Install-Package Serilog
        // * Install-Package Serilog.Sinks.Console
        // * Install-Package Serilog.Sinks.File
        // 2. mit using Serilog;  reinladen
        // 3. in one-step-strategy umsetzten

        // Achtung! nicht in der Developer Power Shell, da müsstet wir eine ander syntax verwenden -
        // > nuget install Serilog -L01HamsterMitLogsInFile L01HamsterMitLogsInFile.csproj

        // Logging - Config

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