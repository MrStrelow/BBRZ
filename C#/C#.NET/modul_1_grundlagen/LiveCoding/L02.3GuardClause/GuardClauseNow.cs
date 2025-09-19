public class Programm
{
    // svm - geht nur in einer Klasse.
    static void Main(string[] args)
    {
        User user = new User("Aloso", 26, false);
        NestedIf(user);
        GuardClause(user);
    }

    static void GuardClause(User user)
    {
        // cw für console write
        Console.WriteLine("TODO: not implemented.");

        // 1. Was sind meine unerwünschten ❌ und erwünschten ✅ zustände 
        // 2. Für jeden unerwünschten Zustand eine Bedingte Anweisung (if ohne else) erstellen.
        // 3. Nimm die Bedingungen der if-Verzweigungen im verschachtelten Fall, und negiere sie in den guards.
        // 4. Nimm den Inhalt der if-Verzweigungen im verschachtelten Fall, und füge sie in die neuen guards ein.
        // 5. die gewünschten zustände (ohne IF) am ende nach den gaurds einfügen.


        // Guards - unerwünschte zustände
        if (user is null)
        {
            Console.WriteLine("User is null.");
            // ❌
        }

        if (!user.IsRegistered)
        {
            Console.WriteLine("User is not registered.");
            // ❌
        }

        if (user.Age < 18) // !(user.Age >= 18)
        {
            Console.WriteLine("User is too young.");
            // ❌
        }

        // erwünschte zustände
        Console.WriteLine("User is processed.");
    }

    static void NestedIf(User user)
    {
        if (user is not null) // -> A && B = !(!A || !B)
        {
            if (user.IsRegistered)
            {
                if (user.Age >= 18)
                {
                    Console.WriteLine("User is processed.");
                    // ✅ Gewünschter Zustand: HIER WOLLEN WIR HIN. also hier soll die Bedingung der gesamten Formel wahr sein.
                }
                else
                {
                    Console.WriteLine("User is too young.");
                    // ❌
                }
            }
            else
            {
                Console.WriteLine("User is not registered.");
                // ❌
            }
        }
        else
        {
            Console.WriteLine("User is null.");
            // ❌
        }
    }
}



public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsRegistered { get; set; }

    public User(string name, int age, bool isRegistered)
    {
        Name = name;
        Age = age;
        IsRegistered = isRegistered;
    }
}