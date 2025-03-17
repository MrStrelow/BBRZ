Welche ``Konzepte`` der Programmiersprache üben wir hier?
* verschachtelte IF-Verzweigungen
* early exit 
* Exceptions werfen

Welche ``Denkweisen`` üben wir hier?
* Wie forme ich If-Verzweigungen um, ohne deren ``Logik`` zu verändern?

Lies davor: 
* [gaurd clauses und de morgan's law](https://github.com/MrStrelow/BBRZ/blob/main/JET/modul_1_c%23_basics/L02BasicProgrammingConcepts/Skripten/L02.3GuardClauses.md)
* [exceptions: nur das werfen dieser](https://github.com/MrStrelow/BBRZ/blob/main/JET/modul_1_c%23_basics/L02BasicProgrammingConcepts/Skripten/L02.7Exceptions.md)

## 3. Übung - Guard Clauses

Wir üben folgende Konzepte der Programmiersprache:
* verschachtelte IF-Verzweigungen
* Exceptions

Welche ``Denkweisen`` üben wir hier?
* logische Ausdrücke in if-else umwandeln
* Boolesche Algebra

### 1. Schreibe folgendes verschachtelte If in eine Guard Clause um.
Implementiere eine 2. Methode ``ProcessUserGuardClause`` und teste ob diese gleich der ``ProcessUserNestedIf`` ist.

```csharp
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

public class Program
{
    public static void Main()
    {
        User user = new User("Alice", 25, true);
        ProcessUserNestedIf(user);
        ProcessUserGuardClause(user);
    }

    public static void ProcessUserNestedIf(User user)
    {
        if (user != null)
        {
            if (user.IsRegistered)
            {
                if (user.Age >= 18)
                {
                    Console.WriteLine("User is processed.");
                }
                else
                {
                    Console.WriteLine("User is too young.");
                }
            }
            else
            {
                Console.WriteLine("User is not registered.");
            }
        }
        else
        {
            Console.WriteLine("User is null.");
        }
    }

    public static void ProcessUserGuardClause(User user) {
        //TODO:
        throw new NotImplementedException("TODO: Guard Clause Implementierung der Methode: ProcessUserNestedIf");
    }
}


```

### 2. Schreibe folgendes verschachtelte If in eine Guard Clause um.
Hier eine kompliziertere Abfrage.
Verwende hier die gleichen Exceptions wie unten im Code.

```csharp
public class User
{
    public bool IsActive { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public DateTime SubscriptionEnd { get; set; }

    //TODO: rewrite me. 
    public void ProcessUser()
    {
        if (IsActive)
        {
            if (Age > 18)
            {
                if (Age < 65)
                {
                    if (!string.IsNullOrEmpty(Email))
                    {
                        if (SubscriptionEnd > DateTime.Now)
                        {
                            Console.WriteLine("User is active, adult, has a valid email, and an active subscription.");
                        }
                        else
                        {
                            throw new InvalidOperationException("User's subscription has expired.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("User email is missing.");
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Email))
                    {
                        if (SubscriptionEnd > DateTime.Now)
                        {
                            Console.WriteLine("User is active, a senior, has a valid email, and an active subscription.");
                        }
                        else
                        {
                            throw new InvalidOperationException("Senior user's subscription has expired.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Senior user email is missing.");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("User must be older than 18.");
            }
        }
        else
        {
            throw new InvalidOperationException("User is not active.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        User user1 = new User
        {
            IsActive = true,
            Age = 30,
            Email = "example@domain.com",
            SubscriptionEnd = DateTime.Now.AddMonths(1)
        };

        try
        {
            user1.ProcessUser();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

```