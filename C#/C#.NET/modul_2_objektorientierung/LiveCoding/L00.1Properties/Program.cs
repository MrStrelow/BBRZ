
var helloBoy = new Hund
{
    Name = "hello",
    Nachname = "Bello"
};

var h = new Hund(alter:17);
h.Name = "hallo";

h = new Hund(alter:17)
{
    Name = "hallo"
};

h = new Hund
{
    Name = "hallo",
    Alter = 17
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
    public int Alter {  get; set; }
    public  string Name { 
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

    public Hund(int alter)
    {
        Alter = alter;
    }

    public Hund() { }
}


