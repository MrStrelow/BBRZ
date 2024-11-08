using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5.ue2;
public class User
{
    public bool IsActive { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public DateTime SubscriptionEnd { get; set; }

    public void ProcessUser()
    {
        // Guard Clauses für allgemeine Prüfungen
        if (!IsActive)
            throw new InvalidOperationException("User is not active.");

        if (Age <= 18)
            throw new InvalidOperationException("User must be older than 18.");

        if (string.IsNullOrEmpty(Email))
            throw new InvalidOperationException("User email is missing.");

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
}


public class Programm
{
    static void Main(string[] args)
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
            user.ProcessUser();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }
}