namespace Exercise1;
public class Program
{
    public static void Main(string[] args)
    {
        MyConverter converter = new MyConverter();

        // Zahl zu Zahl Umwandlung
        Console.WriteLine(converter.ConvertIntToDouble(10));  // Ausgabe: 10.0
        Console.WriteLine(converter.ConvertDoubleToInt(10.5));  // Ausgabe: 11 (Achtung: Convert rundet kaufmännisch!)

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

class MyConverter
{
    // Zahl zu Zahl: Int zu Double
    public double ConvertIntToDouble(int number)
    {
        // return (double) number;
        return Convert.ToDouble(number);
    }

    // Zahl zu Zahl: Double zu Int
    public int ConvertDoubleToInt(double number)
    {
        // return (int) number; // Schneidet Nachkommastellen ab
        return Convert.ToInt32(number); // Rundet kaufmännisch
    }

    // String zu Zahl: String zu Int
    public int ParseStringToInt(string str)
    {
        // Gefählriche Variante - Programm bricht ab:
        // return int.Parse(str);
        return Convert.ToInt32(str);

        // Variante mit Try Methode ohne Try catch block.     
        //if (int.TryParse(str, out int result))
        //{
        //    return result;
        //}
        //else
        //{
        //    throw new FormatException("Ungültige Zahl");
        //}
    }

    // String zu Zahl: String zu Double
    public double ParseStringToDouble(string str)
    {
        // Gefählriche Variante - Programm bricht ab:
        // return double.Parse(str);
        return Convert.ToDouble(str);

        // Variante mit Try Methode ohne Try catch block.     
        //if (double.TryParse(str, out double result))
        //{
        //    return result;
        //}
        //else
        //{
        //    throw new FormatException("Ungültige Zahl");
        //}
    }

    // Zahl zu String: Int zu String
    public string ConvertIntToString(int number)
    {
        // return number.ToString();
        return Convert.ToString(number);
    }

    // Zahl zu String: Double zu String
    public string ConvertDoubleToString(double number)
    {
        // return number.ToString();
        return Convert.ToString(number);
    }

    // Zusätzliche Umwandlungen mit der Convert-Klasse
    public string ConvertBoolToString(bool value)
    {
        return Convert.ToString(value);
    }

    public double ConvertDecimalToDouble(decimal number)
    {
        return Convert.ToDouble(number);
    }
}