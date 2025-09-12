using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02Generics;

public class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }

    public Cat GenerateOffspring(Cat partner)
    {
        // duplicate code?
        var child = new Cat(this.Name + new Random().Next(0, 100) + partner.Name);
        Console.WriteLine($"{this} and {partner} create {child}");

        return child;
    }

    public string Fluff()
    {
        string ret = $"{this} does fluff Stuff.";
        Console.WriteLine(ret);

        return ret;
    }
}
