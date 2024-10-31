using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02Generics;

public abstract class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public Animal Encounters(Animal animal)
    {
        Console.WriteLine($"Aggressor: {this} Encounters Defender: {animal}. They fight.");

        var survivor = new[] { this, animal }[new Random().Next(0, 2)];

        Console.WriteLine($"The survivor is: {survivor}");

        return survivor;
    }

    // why not createOffspring here?

    public override string ToString()
    {
        return $"{this.GetType()}: Name";
    }
}
