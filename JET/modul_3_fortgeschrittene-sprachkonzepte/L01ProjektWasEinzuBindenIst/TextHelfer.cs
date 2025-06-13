namespace StringTools;

public class TextHelfer
{
    public string BeidesAufrufen(string text)
    {
        var formattierungslogik = new FormatierungsLogik();
        string groß =  formattierungslogik.InGrossbuchstabenUmwandeln(text);
        
        return formattierungslogik.LeerzeichenEntfernen(groß);
    }
}