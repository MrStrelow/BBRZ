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
        User user = new User("Alice", 10, false);
        ProcessUserNestedIf(user);
        ProcessUserGuardClause(user);
    }

    public static void ProcessUserNestedIf(User user)
    {
        if (user is not null)
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

    public static void ProcessUserGuardClause(User user)
    {
        if (user is null)
        {
            Console.WriteLine("User is null.");
            return;
        }

        if (!user.IsRegistered)
        {
            Console.WriteLine("User is not registered.");
            return;
        }

        if (user.Age < 18)
        {
            Console.WriteLine("User is too young.");
            return;
        }

        Console.WriteLine("User is processed.");
    }
}

