using java = OldJavaStyleHamster;
using csharp = NewCSharpStyleHamster;
using System.Text;

namespace OldJavaStyleHamster
{
    public class Hamster
    {
        private static string _hungryRepresentation = "😡";
        private static string _fedRepresentation = "🐹";
        private string _representation;

        // Keine Sorge. Dieser Nullable<bool> muss nicht genau verstanden werden.
        // Dieser Typ wird nicht mehr in der zu programmierenden Version verwendet.
        // Er dient nur um kompliziert _isHungry möglicherweise auf null setzten zu können.
        // Kennen wir eine einfachere und flexiblere Variante um null auf Wertdaten anzuwenden?
        // Schau dir in der Angabe die Liste mit Werkzeugen an und verwende eines davon in den Feldern/Eigenschaften im Hamster.
        // Danach wird der Typ Nullable<bool> nicht mehr benötigt und es kann bool (mit einem kleien Zusatz) verwendet werden.
        private Nullable<bool> _isHungry; 

        private (int x, int y) _position;
        private List<Seedling> _mouth = new List<Seedling>();
        private Plane _plane;

        public Hamster(Plane plane, Nullable<bool> isHungry)
        {
            _isHungry = isHungry;
            _representation = _fedRepresentation;
            
            if (plane == null) 
            {
                throw new ArgumentNullException(nameof(plane), "Eine Ebene (Plane) muss bereitgestellt werden.");
            } 
            else
            {
                _plane = plane;
            }
        }

        public string GetRepresentation()
        {
            return _representation;
        }

        protected void SetRepresentation(string representation)
        {
            if (representation is not null)
            {
                if (char.IsSurrogate(representation[0])) // Wir verwenden wahrscheinlich einen Emoji.
                {
                    if (representation.Length > 0) // Wir verwenden wahrscheinlich 
                    {
                        _representation = representation;
                    }
                }
                else
                {
                    throw new ArgumentException($"{nameof(representation)}: ist kein Emoji."); // Logik "guard": kein Emoji
                }
            }
            else
            {
                throw new ArgumentNullException($"{nameof(representation)}: ist null."); // Schnittstellen "guard": Referenz ist null 
            }
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

        public void SetPosition((int x, int y) position)
        {
            _position = position;
        }
    }

    public class Plane;

    public class Seedling;

    public class Programm
    {
        public static void run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Plane snowhabitat = new Plane();
            Hamster hempter = new Hamster(snowhabitat, null);

            Console.WriteLine(hempter.GetRepresentation());
            // Achtung! Hiest ist ? teil der If-Expression umgesetzt mit dem ?:-Operator. 
            // Das ? ist nicht der Nullable Operator und der : ist nicht der Delimiter des named Argument.
            Console.WriteLine(hempter.GetIsHungry() is null ? "ah. _isHungry ist null." : hempter.GetIsHungry() ); 
        }
    }
}

namespace NewCSharpStyleHamster
{
    public class Hamster
    {
        // Statische Felder für Repräsentationen, readonly ist gute Praxis
        private static readonly string _hungryRepresentation = "😡";
        private static readonly string _fedRepresentation = "🐹";

        // Backing Field für die Representation Property, notwendig wegen der Validierungslogik im Setter.
        private string _representation;

        // Property für Representation
        public string Representation
        {
            // Lambda-Operator für den Getter
            get => _representation;
            // protected set, um die ursprüngliche Sichtbarkeit von SetRepresentation beizubehalten
            protected set
            {
                // Null-Check für den Wert
                if (value is null)
                    throw new ArgumentNullException(nameof(value), "Representation darf nicht null sein.");

                // Expliziter Check auf leeren String, bevor auf value[0] zugegriffen wird
                if (value.Length == 0)
                    throw new ArgumentException("Representation darf nicht leer sein.", nameof(value));

                // Replikation der ursprünglichen (fehlerbehafteten) Logik für den "Emoji-Check".
                if (!char.IsSurrogate(value[0]))
                    throw new ArgumentException($"'{value}' ist kein Emoji (basierend auf Original-Logik und Annahme, dass Emoji mit Surrogate beginnt).", nameof(value));

                _representation = value;
            }
        }

        // IsHungry Property vom Typ bool? (Nullable<bool>).
        // Dies ermöglicht den null-Zustand und ist notwendig, um die ursprüngliche Konsolenausgabe zu erreichen.
        // Der "kleine Zusatz" aus dem Hinweis bezieht sich auf die Verwendung von bool? und den damit verbundenen C#-Features.
        public bool? IsHungry { get; protected set; } // Property; protected set wie bei SetIsHungry

        // Position Property, öffentlicher get und set Zugriff wie bei GetPosition/SetPosition
        public (int x, int y) Position { get; set; } // Property

        // Interne Datenliste für Seedling-Objekte.
        // Target-Typing (new()) wird für die Initialisierung verwendet.
        // Dieses Feld dient der internen Komposition und wird nicht direkt als von außen setzbare Eigenschaft offengelegt.
        private List<Seedling> _mouth = new();

        // Die dem Hamster zugeordnete Ebene (Plane).
        public Plane MyPlane { get; private set; } // Auto-Property mit Getter und implizitem Init-Setter

        // Konstruktor
        // Verwendet einen optionalen Parameter für isHungry (Standardwert false).
        public Hamster(Plane plane, bool? isHungry = false)
        {
            // Null-Coalescing-Operator (??) zur Prüfung des essentiellen Parameters.
            // Wirft eine ArgumentNullException, wenn associatedPlane null ist.
            MyPlane = plane ?? throw new ArgumentNullException(nameof(plane), "Eine Ebene (Plane) muss bereitgestellt werden.");

            IsHungry = isHungry; 
            _representation = _fedRepresentation;
        }
    }

    public class Plane;
    public class Seedling;

    public class Programm
    {
        public static void run()
        {
            // Stellt sicher, dass Emojis korrekt in der Konsole dargestellt werden.
            Console.OutputEncoding = Encoding.UTF8;

            // Verwendung von 'var' für die Typinferenz.
            var snowhabitat = new Plane();

            // Erstellung einer Hamster-Instanz:
            // - Verwendung von 'var'.
            // - Verwendung von benannten Argumenten (hier 'associatedPlane:') für bessere Lesbarkeit.
            // - Der 'isHungry'-Parameter im Konstruktor hat den Standardwert 'null', wenn er nicht angegeben wird.
            //   Hier wird explizit 'null' übergeben, um dem Verhalten des alten Codes zu entsprechen.
            var hempter = new Hamster(plane: snowhabitat, isHungry: null);

            // Beispiel für die Verwendung eines Objektinitialisierers für eine Eigenschaft mit öffentlichem Setter,
            // falls diese zusätzlich zu den Konstruktorargumenten initialisiert werden soll:
            // hempter.Position = (10, 5); 
            // Oder kombiniert bei der Erstellung:
            // var hempter = new Hamster(associatedPlane: plane, isHungry: null) { Position = (10, 5) };
            // Da Position standardmäßig (0,0) ist (Default für Tupel von Ints), ist eine explizite Initialisierung hier nicht nötig, um das alte Verhalten zu matchen.

            Console.WriteLine(hempter.Representation);

            // Replikation der ursprünglichen Ausgabelogik für IsHungry:
            // - Wenn IsHungry null ist, wird "ah. _isHungry ist null." ausgegeben.
            // - Andernfalls wird der boolesche Wert ("True" oder "False") ausgegeben.
            // Console.WriteLine behandelt bool? korrekt, wenn es nicht null ist.
            // Das Casting zu (object) stellt sicher, dass bei einem nicht-null hempter.IsHungry
            // dessen ToString()-Methode aufgerufen wird, was "True" oder "False" ergibt.
            Console.WriteLine(hempter.IsHungry is null ? "ah. _isHungry ist null." : (object)hempter.IsHungry);
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