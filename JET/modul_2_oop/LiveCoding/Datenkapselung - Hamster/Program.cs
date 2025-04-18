﻿namespace Hamster;

public class Simulation
{
    static void Main(string[] args)
    {
        // User Intput:
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

        while (true)
        {
            // Logik Methoden
            // simuliere die hamster
            plane.SimulateHamster();

            // simuliree die seeds
            plane.SimulateSeed();

            // Darstellung anzeigen
            //wie schnell läuft unser spiel
            plane.Print(50);
        }

    }
}