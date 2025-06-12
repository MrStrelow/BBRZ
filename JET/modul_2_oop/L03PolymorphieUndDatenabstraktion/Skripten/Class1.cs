using java = OldJavaStyleHamster;
using csharp = NewCSharpStyleHamster;

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
            // da wäre ein copy Konstruktor
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