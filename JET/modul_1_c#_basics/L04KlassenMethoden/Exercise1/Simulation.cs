﻿using Hamster;
using System.Text;

namespace Hamster;

public class Simulation
{
    public static void Main(String[] args)
    {
        Console.WriteLine(5 / 3);
        // User Input:
        Console.OutputEncoding = Encoding.UTF8;

        string promptForUser = "Wie groß soll die Wiese sein?: ";
        Console.Write(promptForUser);
        
        int sizeOfPlane;

        while (!int.TryParse(Console.ReadLine(), out sizeOfPlane))
        {
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Input is not an integer number. Please try again.");
            Console.ResetColor();

            Console.Write(promptForUser);
        }

        Console.Clear();
        Console.CursorVisible = false;

        // Erstelle das Feld und simuliere Hamster und Samen dort drinnen.
        Plane spielfeld = new Plane(sizeOfPlane);

        while (true) {
            spielfeld.SimulateHamster();
            spielfeld.SimulateSeed();

            //spielfeld.Print(1000);
            //spielfeld.Print(timeToSleep: 1000);
            spielfeld.Print(50);
        }
    }
}

