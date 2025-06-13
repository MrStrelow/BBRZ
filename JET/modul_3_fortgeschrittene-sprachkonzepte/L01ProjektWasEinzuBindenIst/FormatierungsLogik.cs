namespace StringTools;

internal class FormatierungsLogik
{
    public string InGrossbuchstabenUmwandeln(string text)
    {
        return text.ToUpper();
    }

    public string LeerzeichenEntfernen(string text)
    {
        return text.Trim();
    }
}