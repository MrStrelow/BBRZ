public class Person
{
    // Felder -> Eigenschaften
    private string _name;

    public string Name {
        set
        {
            if (!Name.Equals("Hallo"))
            {
                _name = value;
            }
        }
        get; 
    }

    public string NickName { get; set; }

    // Konstruktor
    public Person(string name, string nickName)
    {
        Name = name;
        NickName = nickName;
    }

    public Person() { }


    public void CalcuclateStuff()
    {
        NickName = "neuerNameWelchenIchAusrechne";
    }
}

public class Schueler : Person
{
    public Schueler(string name, string nickName) : base(name, nickName)
    {
    }

    public void Lernen()
    {
        Console.WriteLine(NickName);
        NickName = "nein";
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Objekt Initialisierung
        Person hans = new Person { Name = "hans", NickName = "qwerty" };
        //Person per = new Person();
        //per.SetName("hans");
        //per.SetNickName("qwerty");

        Person sans = new Person { NickName = "qwerty" };
        //Person per = new Person();
        //per.SetNickName("qwerty");

        Person lans = new Person { Name = "qwerty" };
        //Person per = new Person();
        //per.SetName("hans");

        // var: typ wird ausgerechnet
        var bans = new Person(name: "hans", nickName: "qwerty"); 


        Console.WriteLine(hans.Name);


        // Eigenschaften
        hans.Name = "asdf";
        Console.WriteLine(hans.Name);
        hans.NickName = "geht nicht";
        //Person hans = new Person(nickName: "asdf", age: 1);
        //Person hans = new Person(age: 1);
    }
}