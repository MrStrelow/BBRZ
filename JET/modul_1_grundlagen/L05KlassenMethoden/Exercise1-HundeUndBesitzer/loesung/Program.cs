namespace Hunde;

public class Prigramm
{
    public static void Main(string[] args)
    {
        HundeBesitzer karo = new HundeBesitzer(name: "Karo", happiness: 1.0, age: 25, hatHundeFuehrerschein: false, capacity: 20);
        Hund gilbert = new Hund("Gilbert", 1, "m", 10, false);
        Hund golbert = new Hund("Gilbert", 1, "m", 10, false);
        Hund frido = new Hund("Frido", 2, "w", 15, true);
        Hund[] hunde = { frido, gilbert };

        Console.WriteLine($"ist null? {frido.GetSpielFreund()}"); // ist null! kein output

        gilbert.SetSpielFreund(frido);
        Console.WriteLine(gilbert.GetSpielFreund());
        Console.WriteLine(frido.GetSpielFreund()); // ist nicht mehr null!

        karo.Kaufen(frido);
        karo.Kaufen(gilbert);
        karo.Fuettern();

        gilbert.Spielen();
        frido.Spielen();

        Mensch hatBaldHunde = new Mensch("Walo", 0.1, 51);
        Console.WriteLine(hatBaldHunde.GetType());
        Console.WriteLine(hatBaldHunde.GetHashCode());

        hatBaldHunde = hatBaldHunde.WirdEinHundeBesitzer(gilbert, hatHundeFuehrerschein: true, hunde.Length * 2);

        Console.WriteLine(hatBaldHunde.GetType());
        Console.WriteLine(hatBaldHunde.GetHashCode());

        Mensch hatNieHunde = new Mensch("Raldira", 0.5, 55);
        Console.WriteLine(hatNieHunde.GetType());
        Console.WriteLine(hatNieHunde.GetHashCode());
    }
}
