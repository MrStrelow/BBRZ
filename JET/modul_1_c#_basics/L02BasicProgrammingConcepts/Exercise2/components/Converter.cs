using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2;

class Converter
{
    // Zahl zu Zahl: Int zu Double
    public double ConvertIntToDouble(int number)
    {
        return (double)number;
    }

    // Zahl zu Zahl: Double zu Int
    public int ConvertDoubleToInt(double number)
    {
        return (int)number;
    }

    // String zu Zahl: String zu Int
    public int ParseStringToInt(string str)
    {
        if (int.TryParse(str, out int result))
        {
            return result;
        }
        else
        {
            throw new FormatException("Ungültige Zahl");
        }
    }

    // String zu Zahl: String zu Double
    public double ParseStringToDouble(string str)
    {
        if (double.TryParse(str, out double result))
        {
            return result;
        }
        else
        {
            throw new FormatException("Ungültige Zahl");
        }
    }

    // Zahl zu String: Int zu String
    public string ConvertIntToString(int number)
    {
        return number.ToString();
    }

    // Zahl zu String: Double zu String
    public string ConvertDoubleToString(double number)
    {
        return number.ToString();
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