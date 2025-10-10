using java = OldJavaStyleHamster;
using csharp = NewCSharpStyleHamster;

namespace OldJavaStyleHamster
{
    public class Hamster
    {
        private readonly static string _namedRepresentation = "🐹";
        private readonly static string _unnamedRepresentation = "🐾";

        private string _nickname; // das soll null sein können
        private (int x, int y) _position;
        private List<Seedling> _mouth = new List<Seedling>();
        private Plane _habitat;

        public Hamster(Plane habitat, string nickname = null)
        {
            _habitat = habitat;
            _nickname = nickname;
        }

        public string GetRepresentation()
        {
            return _nickname == null ? _unnamedRepresentation : _namedRepresentation;
        }

        public string GetNickname() { return _nickname; }
        public void SetNickname(string name) { _nickname = name; }

        // Diese Methoden sind nun absichtlich einfach gehalten.
        public List<Seedling> GetMouth() { return _mouth; }
        public void SetMouth(List<Seedling> newMouthContent) { _mouth = newMouthContent; }

        public (int x, int y) GetPosition() { return _position; }

        // Diese Methode enthält die komplexe Logik.
        public void SetPosition(int x, int y)
        {
            if (_habitat != null)
            {
                if (x >= 0 && x < _habitat.GetWidth() && y >= 0 && y < _habitat.GetHeight())
                {
                    _position = (x, y);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Die Position liegt außerhalb der Grenzen des Habitats.");
                }
            }
            else
            {
                throw new InvalidOperationException("Dem Hamster wurde kein Habitat zugewiesen.");
            }
        }
    }

    public class Plane
    {
        private int _width;
        private int _height;
        public Plane(int width, int height) { _width = width; _height = height; }
        public int GetWidth() { return _width; }
        public int GetHeight() { return _height; }
    }

    public class Seedling;

    public class Programm
    {
        public static void run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Plane largeHabitat = new Plane(100, 50);
            Hamster speedy = new Hamster(largeHabitat, "Speedy");

            speedy.SetPosition(10, 20);
            Console.WriteLine($"Hamster '{speedy.GetNickname()}' {speedy.GetRepresentation()} befindet sich bei {speedy.GetPosition()}.");

            try
            {
                Console.WriteLine("Versuche, den Hamster außerhalb der Grenzen zu platzieren...");
                speedy.SetPosition(200, 30); // löst eine Exception aus
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"FEHLER ABGEFANGEN: {e.Message}");
            }
        }
    }
}


namespace NewCSharpStyleHamster
{
    public class Hamster
    {
        private static readonly string _namedRepresentation = "🐹";
        private static readonly string _unnamedRepresentation = "🐾";

        // Das ist das "Backing Field" für die Position-Property.
        private (int x, int y) _position;

        // **Property mit Lambda-Ausdruck (=>) für den Getter.**
        public string Representation => Nickname is not null ? _namedRepresentation : _unnamedRepresentation;

        // **Nullable-Operator (?) für den Referenztyp string.**
        public string? Nickname { get; set; }

        // **Einfache Auto-Property, da keine spezielle Logik benötigt wird.**
        public List<Seedling>? MouthContents { get; set; }

        // **'init'-Property: Das Habitat muss bei der Erstellung zugewiesen werden.**
        public Plane Habitat { get; init; }

        // **Property mit komplexer Logik und Guard Clauses im Setter.**
        public (int x, int y) Position
        {
            get => _position;
            set
            {
                // **Guard-Clause: Prüft, ob das Habitat existiert.**
                // 'init' stellt sicher, dass es nicht null ist, aber die Prüfung ist eine gute Praxis.
                if (Habitat is null)
                {
                    throw new InvalidOperationException("Dem Hamster wurde kein Habitat zugewiesen.");
                }

                // **Guard-Clause: Prüft die Grenzen des Habitats.**
                if (value.x < 0 || value.x >= Habitat.Width || value.y < 0 || value.y >= Habitat.Height)
                {
                    throw new ArgumentOutOfRangeException("Die Position liegt außerhalb der Grenzen des Habitats.");
                }

                // Wenn alle Prüfungen bestanden sind, wird der Wert zugewiesen.
                _position = value;
            }
        }
    }

    public class Plane
    {
        public int Width { get; }
        public int Height { get; }

        public Plane(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    public class Seedling;

    public class Programm
    {
        public static void run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // **Verwendung von 'var' und Object-Initializer.**
            var largeHabitat = new Plane(100, 50);
            var speedy = new Hamster
            {
                Habitat = largeHabitat,
                Nickname = "Speedy"
            };

            // Zuweisung über die Property.
            speedy.Position = (10, 20);

            // **Null-Coalescing-Operator (??) für eine saubere Ausgabe.**
            Console.WriteLine($"Hamster '{speedy.Nickname ?? "Namenlos"}' {speedy.Representation} befindet sich bei {speedy.Position}.");

            try
            {
                Console.WriteLine("Versuche, den Hamster außerhalb der Grenzen zu platzieren...");
                speedy.Position = (200, 30); // Löst die Exception im Setter aus.
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"FEHLER ABGEFANGEN: {e.Message}");
            }
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