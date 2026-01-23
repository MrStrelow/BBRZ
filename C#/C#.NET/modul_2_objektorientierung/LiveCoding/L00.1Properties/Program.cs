
var helloBoy = new Hund
{
    Name = "hello",
    Nachname = "Bello"
};

//var helloBoy = new Hund
//(
//    nachname: "bello", 
//    name: "hello"
//);

helloBoy.Name = "hello"; // Schreibweise wie Feld
helloBoy.Nachname = "hello"; // Schreibweise wie Feld - dürfen nicht set aufrufen durch init! (quasi private set aber geht init geht mit initializer)
Console.WriteLine(helloBoy.Name);
Console.WriteLine(helloBoy.Nachname);

public class Hund
{
    public required string Name { 
        get;
        set //init
        {
            if (value is null) // set- guard
                throw new Exception("test");

            field = value;
        }
    } // Property: Definiert wie Get und Set Methode
        
    public string Nachname { get; init; } // Property: Definiert wie Get und Set Methode

    //public Hund(string name, string nachname) // kein kosntruktor -> initialiser verwendenn
    //{
    //    Name = name;
    //    Nachname = nachname;
    //}
}


