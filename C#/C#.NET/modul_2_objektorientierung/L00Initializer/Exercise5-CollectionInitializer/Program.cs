var tuple = ParseCoordinates("48.2082, 16.3738");
if (tuple.wasSuccessful)
{
    Console.WriteLine($"Latitude: {tuple.lat}, Longitude: {tuple.lon}");
}
else
{
    Console.WriteLine("Ungültiges Format.");
}

(bool success, double latitude, double longitude) ParseCoordinates(string input)
{
    string[] parts = input.Split(',');
    if (parts.Length != 2)
    {
        return (false, 0, 0); // Fehlerfall zurückgeben
    }

    bool latParsed = double.TryParse(parts[0], out var lat);
    bool lonParsed = double.TryParse(parts[1], out var lon);

    if (latParsed && lonParsed)
    {
        return (true, lat, lon); // Erfolgsfall mit Werten zurückgeben
    }

    return (false, 0, 0); // Fehlerfall zurückgeben - Nachteil, es muss immer ein ganzes Tuple zurückgegeben werden, auch wenn Teile dieses Tuples fehlen.
}