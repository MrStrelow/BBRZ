using System.Text;

namespace asdf;
public class User
{
    public bool IsActive { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public DateTime SubscriptionEnd { get; set; }

    // Achtung! Wir haben hier 2 Endpunkte ("User is active,..." und "User is active, a senior,...")
    // welche wir als sinnvoll erachten. 
    // Versuche zerst die 2 Zweige des Programmes mit Endpunkten getrennt zu behandeln und verbinde diese nachher.
    public void ProcessUserNestedIf()
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

    public void ProcessUserGuardClause()
    {
        // Guard Clauses für allgemeine Prüfungen
        if (!IsActive)
            throw new InvalidOperationException("User is not active.");

        if (Age <= 18)
            throw new InvalidOperationException("User must be older than 18.");


        // Weitere Bedingungen je nach Altersgruppe: User
        if (Age < 65 && string.IsNullOrEmpty(Email))
            throw new InvalidOperationException("User email is missing.");

        if (Age >= 65 && string.IsNullOrEmpty(Email))
            throw new InvalidOperationException("Senior user email is missing.");

        // Weitere Bedingungen je nach Altersgruppe: Senior
        if (Age < 65 && SubscriptionEnd <= DateTime.Now)
            throw new InvalidOperationException("User's subscription has expired.");

        if (Age >= 65 && SubscriptionEnd <= DateTime.Now)
            throw new InvalidOperationException("Senior user's subscription has expired.");

        // Beide Endpunkte müssen wir in einer IF-Verzweigung trennen. Auch ein switch möglich.
        // Wir werden später Konzepte (ein paar Monate) anschauen welche uns erlauben solche Abfragen potentiell noch
        // eleganter zu gestalten (Pattern matching mit switch und when).
        if (Age < 65)
        {
            Console.WriteLine("User is active, adult, has a valid email, and an active subscription.");
        }
        else
        {
            Console.WriteLine("User is active, a senior, has a valid email, and an active subscription.");
        }
    }

    public void ProcessUserGuardClauseMixedWithNested()
    {
        // Guard Clauses für allgemeine Prüfungen
        if (!IsActive)
            throw new InvalidOperationException("User is not active.");

        if (Age <= 18)
            throw new InvalidOperationException("User must be older than 18.");


        // Weitere Bedingungen je nach Altersgruppe
        if (Age < 65)
        {
            if (string.IsNullOrEmpty(Email))
                throw new InvalidOperationException("User email is missing.");

            if (SubscriptionEnd <= DateTime.Now)
                throw new InvalidOperationException("User's subscription has expired.");

            Console.WriteLine("User is active, adult, has a valid email, and an active subscription.");
        }
        else
        {
            if (string.IsNullOrEmpty(Email))
                throw new InvalidOperationException("Senior user email is missing.");

            if (SubscriptionEnd <= DateTime.Now)
                throw new InvalidOperationException("Senior user's subscription has expired.");

            Console.WriteLine("User is active, a senior, has a valid email, and an active subscription.");
        }
    }

    // Rein logisch gesehen ist die folgende Methode nicht komplett gleich dem Programm mit dem verschachtelten if.
    // Wir haben jedoch hier in diesem Programm uns die Freiheit genommen, und Fehlermeldungen von Senior und User zusammenzufassen,
    // wenn z.B. die mail Adresse fehlt.
    public void ProcessUserKuerzerAberNichtGanzKorrekt()
    {
        // Guard Clauses für allgemeine Prüfungen
        if (!IsActive) 
            throw new InvalidOperationException("User is not active.");

        if (Age <= 18)
            throw new InvalidOperationException("User must be older than 18.");

        // Wir ignorieren hier die Senior vs. User Ausgabe beim Werfen der Exception.
        if (string.IsNullOrEmpty(Email))
            throw new InvalidOperationException("User email is missing.");

        // Wir ignorieren hier die Senior vs. User Ausgabe beim Werfen der Exception.
        if (SubscriptionEnd <= DateTime.Now)
            throw new InvalidOperationException("User's subscription has expired.");

        // Weitere Bedingungen je nach Altersgruppe
        if (Age < 65)
        {
            Console.WriteLine("User is active, adult, has a valid email, and an active subscription.");
        }
        else
        {
            Console.WriteLine("User is active, a senior, has a valid email, and an active subscription.");
        }
    }

    public static void CallUe2()
    {
        User user = new User
        {
            IsActive = true,
            Age = 30,
            Email = "example@domain.com",
            SubscriptionEnd = DateTime.Now.AddMonths(1)
        };

        try
        {
            user.ProcessUserNestedIf();
            user.ProcessUserGuardClause();
            user.ProcessUserGuardClauseMixedWithNested();
            user.ProcessUserKuerzerAberNichtGanzKorrekt();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}


public class Program
{
    static void Main(string[] args)
    {
        User.CallUe2();

        StringBuilder sb = new StringBuilder("This is a Test");

        string test = sb.ToString(10, 4);
        Console.WriteLine(test);
    }
}
