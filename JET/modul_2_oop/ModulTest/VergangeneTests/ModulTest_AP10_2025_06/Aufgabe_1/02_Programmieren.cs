using java = OldJavaStyleHamster;
using csharp = NewCSharpStyleHamster;

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
            _plane = plane;
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

            Plane plane = new Plane();
            Hamster hempter = new Hamster(plane, null);

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
        // TODO: implemente me.
    }
    public class Plane;
    public class Seedling;

    public class Programm
    {
        public static void run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Plane plane = new Plane();

            // TODO: implement me.
            throw new NotImplementedException("\u001B[31mLösche diese Zeile und füge deinen eigenen Cod ein!.\u001b[0m");
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