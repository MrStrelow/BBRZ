using LiveCoding;
using System.Text;

class Simulation
{
    static void Main(string[] args)
    {
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
        Plane plane = new Plane(sizeOfPlane);

        while (true)
        {
            // logik
            //plane.SimulateHamster();
            //plane.SimulateSeed();

            // darstellung
            plane.Print();
        }
    }
}