
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02Generics;


public class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public Dog GenerateOffspring(Dog partner)
    {
        // duplicate code?
        var child = new Dog(this.Name + new Random().Next(0, 100) + partner.Name);
        Console.WriteLine($"{this} and {partner} create {child}");

        return child;
    }

    public string Bark()
    {
        string ret = $"{this} does a bark.";
        Console.WriteLine(ret);
        return ret;
    }
}
