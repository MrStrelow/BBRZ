namespace Exercise2;
public class Program
{
    public static void Main(string[] args)
    {
        Converter converter = new Converter();

        // Zahl zu Zahl Umwandlung
        Console.WriteLine(converter.ConvertIntToDouble(10));  // Ausgabe: 10.0
        Console.WriteLine(converter.ConvertDoubleToInt(10.5));  // Ausgabe: 10

        // String zu Zahl Umwandlung
        Console.WriteLine(converter.ParseStringToInt("123"));  // Ausgabe: 123
        Console.WriteLine(converter.ParseStringToDouble("123.45"));  // Ausgabe: 123.45

        // Zahl zu String Umwandlung
        Console.WriteLine(converter.ConvertIntToString(100));  // Ausgabe: "100"
        Console.WriteLine(converter.ConvertDoubleToString(99.99));  // Ausgabe: "99.99"

        // Zusätzliche Umwandlungen
        Console.WriteLine(converter.ConvertBoolToString(true));  // Ausgabe: "True"
        Console.WriteLine(converter.ConvertDecimalToDouble(99.99m));  // Ausgabe: 99.99
    }
}