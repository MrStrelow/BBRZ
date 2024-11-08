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
    static void Main(string[] args)
    {
        User user = new User("Alice", 25, true);
        ProcessUser(user);

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

    public static void ProcessUserGuardClause(User user)
    {
        //TODO:
        throw new NotImplementedException("TODO: Guard Clause Implementierung der Methode: ProcessUserNestedIf");
    }
}