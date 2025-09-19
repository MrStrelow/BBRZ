Welche ``Konzepte`` der Programmiersprache üben wir hier?
* verschachtelte IF-Verzweigungen
* early exit 
* Exceptions werfen

Welche ``Denkweisen`` üben wir hier?
* Wie forme ich If-Verzweigungen um, ohne deren ``Logik`` zu verändern?

Bei Unklarheiten hier nachlesen: 
* [Welche Kontrollstrukturen soll ich verwenden?](../Skripten/L03.1Kontrollstrukturen.md)
* [Was sind gaurd clauses und de morgan's law?](../Skripten/L03.4GuardClauses.md)
* [exceptions: der 1. Absatz um eine Exception werfen zu können ist notwendig.](../../../modul_3_fortgeschrittene-sprachkonzepte/L00Exceptions/Skripten/L00Exceptions.md)

## Schreibe verschachtelte Ifs in eine Guard Clause um.

Wir üben folgende Konzepte der Programmiersprache:
* verschachtelte IF-Verzweigungen
* Exceptions

Welche ``Denkweisen`` üben wir hier?
* logische Ausdrücke in if-else umwandeln
* Boolesche Algebra

### 1. Ein gewünschter Zustand
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
                    Console.WriteLine("✅ User is processed.");
                }
                else
                {
                    Console.WriteLine("❗User is too young.");
                }
            }
            else
            {
                Console.WriteLine("❗User is not registered.");
            }
        }
        else
        {
            Console.WriteLine("❗User is null.");
        }
    }

    public static void ProcessUserGuardClause(User user) {
        //TODO:
        throw new NotImplementedException("TODO: Guard Clause Implementierung der Methode: ProcessUserNestedIf");
    }
}


```

### 2. Mehrere gwünschte Zustände
Hier eine kompliziertere Abfrage. Diese hat *mehrere* ``gewünschte Zustände``.
Verwende hier die gleichen Exceptions wie unten im Code.

```csharp
public class User
{
    public bool IsActive { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public DateTime SubscriptionEnd { get; set; }

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
                            Console.WriteLine("✅User is active, adult, has a valid email, and an active subscription.");
                        }
                        else
                        {
                            throw new InvalidOperationException("❗User's subscription has expired.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("❗User email is missing.");
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Email))
                    {
                        if (SubscriptionEnd > DateTime.Now)
                        {
                            Console.WriteLine("✅User is active, a senior, has a valid email, and an active subscription.");
                        }
                        else
                        {
                            throw new InvalidOperationException("❗Senior user's subscription has expired.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("❗Senior user email is missing.");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("❗User must be older than 18.");
            }
        }
        else
        {
            throw new InvalidOperationException("❗User is not active.");
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

### 3. Mehrere komplexere gewünschte Zustände
```csharp
using System.Text;

public class Berg
{
    public bool IstGefährlich { get; set; }
    public int höhe { get; set; }
}


public class Bergführer
{
    // Eigenschaften / Felder
    public bool IsActive { get; set; }
    public int Age { get; set; }
    public string MedicalClearanceCertificate { get; set; }
    public DateTime CertificationExpiry { get; set; }
    public int TourCount { get; set; }

    // Hat-Beziehungen
    public Berg BergRoute { get; set; }

    public void ValidateGuide()
    {
        if (IsActive)
        {
            if (Age >= 21)
            {
                if (!string.IsNullOrEmpty(MedicalClearanceCertificate))
                {
                    if (CertificationExpiry > DateTime.Now)
                    {
                        if (BergRoute.IstGefährlich)
                        {
                            if (TourCount >= 50 && TourCount <= 200)
                            {
                                Console.WriteLine("✅ Bergführer hat zwischen 50 und 200 Touren. Ein weiterer erfahrener Guide ist erforderlich, um diese Route zu bewältigen.");
                            }
                            else if (TourCount > 200)
                            {
                                Console.WriteLine("✅ Bergführer hat mehr als 200 Touren. Dieser Guide darf die Route alleine führen.");
                            }
                            else
                            {
                                throw new InvalidOperationException("❗ Bergführer hat zu wenig Erfahrung für diese Route.");
                            }
                        }
                        else
                        {
                            if (BergRoute.höhe > 5000) 
                            {
                                Console.WriteLine("✅ Berg ist zu hoch. Ein weiterer erfahrener Guide ist erforderlich, um diese Route zu bewältigen.");
                            } 
                            else 
                            {
                                Console.WriteLine("✅ Bergführer darf die Tour durchführen.");
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("❗ Die Zertifizierung des Bergführers ist abgelaufen.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("❗ Bergführer besitzt kein medizinisches Freigabezertifikat.");
                }
            }
            else
            {
                throw new InvalidOperationException("❗ Bergführer muss älter als 21 Jahre sein.");
            }
        }
        else
        {
            throw new InvalidOperationException("❗ Bergführer ist nicht aktiv.");
        }
    }

    public void ValidateGuideGuardClause()
    {
        // TODO: Schreibe hier das in ValidateGuide verschachtelte IF in eine Guard Clause um.
        throw new NotImplementedException("This method is not yet implemented: Schreibe hier das in ValidateGuide verschachtelte IF in eine Guard Clause um.");
    }
}


public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Bergführer guide = new Bergführer
        {
            IsActive = true,
            Age = 35,
            MedicalClearanceCertificate = "ValidCertificate",
            CertificationExpiry = DateTime.Now.AddMonths(12),
            TourCount = 150,
            BergRoute = new Berg { IstGefährlich = true, höhe = 4000 }
        };

        try
        {
            guide.ValidateGuide();
            guide.ValidateGuideGuardClause();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }
    }
}
```