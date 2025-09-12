using System;

namespace single;

class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal speaks");
    }
}

class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}

class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Cat meows");
    }
}

class Program
{
    static void Main()
    {
        Animal myDog = new Dog();  // Single dispatch here
        Animal myCat = new Cat();  // Single dispatch here

        myDog.Speak();  // Output: Dog barks
        myCat.Speak();  // Output: Cat meows
    }
}
