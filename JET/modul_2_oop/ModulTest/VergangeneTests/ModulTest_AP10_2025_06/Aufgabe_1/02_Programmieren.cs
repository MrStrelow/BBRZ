using java = OldJavaStyleHamster;
using csharp = NewCSharpStyleHamster;

// Deaktiviert die Warnung CS8618, da die 'Plane' Eigenschaft im neuen Stil
// durch den Objekt-Initializer zugewiesen wird und nicht im Konstruktor.
#pragma warning disable CS8618

namespace OldJavaStyleHamster
{
    public class Hamster
    {
        private readonly static string _hungryRepresentation = "😡";
        private readonly static string _fedRepresentation = "🐹";
        private const int _MAX_MOUTH_CAPACITY = 10;
        private string _representation;

        // Keine Sorge. Dieser Nullable<bool> muss nicht genau verstanden werden.
        // Dieser Typ wird nicht mehr in der zu programmierenden Version verwendet.
        // Er dient nur um kompliziert _isHungry möglicherweise auf null setzten zu können.
        // Kennen wir eine einfachere und flexiblere Variante um null auf Wertdaten anzuwenden?
        private Nullable<bool> _isHungry;

        private (int x, int y) _position;
        private List<Seedling> _mouth = new List<Seedling>();
        private Plane _plane;

        public Hamster(Plane plane, Nullable<bool> isHungry = null)
        {
            _isHungry = isHungry;
            _representation = _fedRepresentation;
            _plane = plane;
        }

        public string GetRepresentation()
        {
            return _representation;
        }

        protected void SetRepresentation(string representation)
        {
            _representation = representation;
        }

        public Nullable<bool> GetIsHungry()
        {
            return _isHungry;
        }

        protected void SetIsHungry(Nullable<bool> isHungry)
        {
            _isHungry = isHungry;
        }

        public (int x, int y) GetPosition()
        {
            return _position;
        }

        public Plane GetPlane()
        {
            return _plane;
        }

        public List<Seedling> GetMouth()
        {
            var deepCopyOfMouth = new List<Seedling>(_mouth.Count);
            foreach (var originalSeedling in _mouth)
            {
                var copiedSeedling = new Seedling(originalSeedling);
                deepCopyOfMouth.Add(copiedSeedling);
            }
            return deepCopyOfMouth;
        }

        public void SetMouth(List<Seedling> someExternalMouth)
        {
            if (someExternalMouth != null)
            {
                if (someExternalMouth.Count <= _MAX_MOUTH_CAPACITY)
                {
                    bool foundNull = false;
                    foreach (var seedling in someExternalMouth)
                    {
                        if (seedling == null)
                        {
                            foundNull = true;
                            break;
                        }
                    }

                    if (!foundNull)
                    {
                        var deepCopyOfMouth = new List<Seedling>(someExternalMouth.Count);
                        foreach (var originalSeedling in someExternalMouth)
                        {
                            deepCopyOfMouth.Add(new Seedling(originalSeedling));
                        }

                        _mouth = deepCopyOfMouth;
                    }
                    else
                    {
                        throw new ArgumentException("Die Liste der Setzlinge darf keine null-Referenzen enthalten.", nameof(someExternalMouth));
                    }
                }
                else
                {
                    throw new ArgumentException($"Ein Hamster kann nicht mehr als {_MAX_MOUTH_CAPACITY} Setzlinge im Maul halten.", nameof(someExternalMouth));
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(someExternalMouth), "Die 'mouth'-Liste darf nicht null sein.");
            }
        }
    }

    public class Plane;

    public class Seedling
    {
        public Seedling(Seedling seedling)
        {
            // Da wäre ein copy Konstruktor. Diese muss hier nicht implementiert werden!
        }

        public Seedling() { }
    }

    public class Programm
    {
        public static void run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Plane plane = new Plane();
            Hamster hempter = new Hamster(plane, null);

            Seedling seedling = new Seedling();
            Seedling anotherSeedling = new Seedling();
            Seedling yetAnotherSeedling = new Seedling();

            List<Seedling> seedlings = new List<Seedling>();
            seedlings.Add(seedling);
            seedlings.Add(anotherSeedling);
            seedlings.Add(yetAnotherSeedling);

            hempter.SetMouth(seedlings);

            Console.WriteLine("Die seedlings sind diese...");
            Console.Write("[");
            foreach (var seed in seedlings)
            {
                Console.Write(seed.GetHashCode() + " ");
            }
            Console.Write("]");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(hempter.GetRepresentation());
            // Achtung! Hiest ist ? teil der If-Expression umgesetzt mit dem ?:-Operator. 
            // Das ? ist nicht der Nullable Operator und der : ist nicht der Delimiter des named Argument.
            Console.WriteLine(hempter.GetIsHungry() is null ? "ah. _isHungry ist null." : hempter.GetIsHungry());

            Console.WriteLine("Die seedlings im Hamster sind kopien davon, deshalb ein anderer HashCode.");
            Console.Write("[");
            foreach (var seed in hempter.GetMouth())
            {
                Console.Write(seed.GetHashCode() + " ");
            }
            Console.Write("]");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

namespace NewCSharpStyleHamster
{
    public class Hamster
    {
        // Konstanten bleiben private und unverändert.
        private readonly static string _hungryRepresentation = "😡";
        private readonly static string _fedRepresentation = "🐹";
        private const int _MAX_MOUTH_CAPACITY = 10;

        // Ein privates "backing field" für den Mouth des Hamsters.
        // Target-Typing "new()" wird für eine kompakte Initialisierung verwendet.
        private List<Seedling> _mouth = new();

        // **Property** für die Darstellung. Der Standardwert wird direkt zugewiesen.
        // Der Setter ist 'protected', um die ursprüngliche Logik des Datenkapselungsprinzips beizubehalten.
        public string Representation { get; protected set; } = _fedRepresentation;

        // **Property** für den Hungerstatus. Der **Nullable-Operator `?`** wird verwendet,
        // um `bool?` als Kurzform für `Nullable<bool>` zu nutzen.
        public bool? IsHungry { get; set; }

        // Property für die Position.
        public (int x, int y) Position { get; set; }

        // **Property** für die Ebene.
        public Plane Plane { get; set; }

        // **Property** für den MundSpeicher mit guards für set und get.
        public List<Seedling> Mouth
        {
            get
            {
                var deepCopyOfMouth = new List<Seedling>(_mouth.Count);
                foreach (var seedling in _mouth)
                {
                    deepCopyOfMouth.Add(new Seedling(seedling));
                }
                return deepCopyOfMouth;
            }

            set
            {
                // **Guard-Clauses** werden verwendet, um die verschachtelten if-Anweisungen zu ersetzen.
                if (value is null)
                    throw new ArgumentNullException(nameof(Mouth), "Der MundSpeicher darf nicht null sein.");

                if (value.Count > _MAX_MOUTH_CAPACITY)
                    throw new ArgumentException($"Ein Hamster kann nicht mehr als {_MAX_MOUTH_CAPACITY} Setzlinge im Maul halten.", nameof(Mouth));

                // Überprüfung auf null-Referenzen in der Liste mit einer foreach-Schleife.
                foreach (var seedling in value)
                {
                    if (seedling is null)
                        throw new ArgumentException("Die Liste der Setzlinge darf keine null-Referenzen enthalten.", nameof(Mouth));
                }

                // Wenn alle Prüfungen erfolgreich sind, wird eine tiefe Kopie der zugewiesenen Liste erstellt.
                var deepCopyOfMouth = new List<Seedling>(value.Count);
                foreach (var seedling in value)
                {
                    deepCopyOfMouth.Add(new Seedling(seedling));
                }
                _mouth = deepCopyOfMouth;
            }
        }

        public Hamster(Plane plane)
        {
            Plane = plane;
        }
    }

    public class Plane;

    public class Seedling
    {
        public Seedling(Seedling other)
        {
            // Da wäre ein copy Konstruktor. Diese muss hier nicht implementiert werden!
        }

        public Seedling() { }
    }


    public class Programm
    {
        public static void run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var plane = new Plane();

            // Die Liste der Seedlings wird mit Collection-Initializer und Target-Typing 'new()' erstellt.
            var seedlings = new List<Seedling> { new(), new(), new() };

            // Der Konstruktor wird verwendet - wir wollen sichrestellen dass immer ein Hamster eine Plane hat -
            // Mit dem **Object-Initializer** wäre das nicht der Fall.
            var hempter = new Hamster(plane);

            // Die Property MundSpeicher wird gesetzt, was set mit den Guard-Clauses auslöst.
            hempter.Mouth = seedlings;

            // Die Ausgabe-Logik bleibt identisch, verwendet aber die neuen Properties.
            Console.WriteLine("Die seedlings sind diese...");
            Console.Write("[");
            foreach (var seed in seedlings)
            {
                Console.Write(seed.GetHashCode() + " ");
            }
            Console.Write("]");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(hempter.Representation);
            Console.WriteLine(hempter.IsHungry is null ? "ah. _isHungry ist null." : hempter.IsHungry);

            Console.WriteLine("Die seedlings im Hamster sind kopien davon, deshalb ein anderer HashCode.");
            Console.Write("[");
            // Der get-Accessor der 'Mouth'-Eigenschaft wird hier aufgerufen.
            foreach (var seed in hempter.Mouth)
            {
                Console.Write(seed.GetHashCode() + " ");
            }
            Console.Write("]");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

public class Comparisson
{
    static void Main(string[] args)
    {
        java.Programm.run();

        Console.WriteLine("⚠️~~~~~ darüber und darunter soll beides gleich aussehn ~~~~~⚠️");

        csharp.Programm.run();
    }
}
