using Microsoft.Extensions.DependencyInjection;

namespace Datenkapselung;

public class InjectedSingleton
{
    public int Counter { get; set; } = 0;

    public void Increment() => Counter++;
}

class Program
{
    static void Main(string[] args)
    {
        var theOnlyInstance = Singleton.Instance;


        var collection = new ServiceCollection();

        var serviceProvider = collection
            .AddSingleton<InjectedSingleton>()
            .BuildServiceProvider();

        var singletonDI = serviceProvider.GetService<InjectedSingleton>();
        singletonDI.Increment();

        var anotherDISingleton = serviceProvider.GetService<InjectedSingleton>();
        Console.WriteLine(anotherDISingleton.Counter); // Output: 1
        Console.WriteLine(singletonDI.Equals(anotherDISingleton)); // true
        Console.WriteLine(singletonDI == anotherDISingleton); // true

        serviceProvider = collection
            .AddTransient<InjectedSingleton>()
            .BuildServiceProvider();

        var transient = serviceProvider.GetService<InjectedSingleton>();
        singletonDI.Increment();

        var anotherTransient = serviceProvider.GetService<InjectedSingleton>();
        Console.WriteLine(transient.Counter); // Output: 0
        Console.WriteLine(transient.Equals(anotherTransient)); // false
        Console.WriteLine(transient == anotherTransient); // false
    }
}
