using System.Text.Json;

var benutzer = new BenutzerDTO
{
    Name = "Maria Musterfrau",
    Alter = 34,
    Email = "maria@example.com"
};

string benutzerAlsJson = JsonSerializer.Serialize(benutzer);
File.WriteAllText("../../../benutzer.json", benutzerAlsJson);

// schicke dieses Json ans frontend.

// bekomme antwort als Json

Console.WriteLine(benutzerAlsJson);




public class BenutzerDTO
{
    public string Name { get; set; }
    public int Alter { get; set; }
    public string? Email { get; set; }
}