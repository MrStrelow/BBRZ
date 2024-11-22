using System;

namespace multi;

interface IElement
{
    void Accept(IVisitor visitor);
}

class Dog : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

class Cat : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

interface IVisitor
{
    void Visit(Dog dog);
    void Visit(Cat cat);
}

class AnimalSoundVisitor : IVisitor
{
    public void Visit(Dog dog)
    {
        Console.WriteLine("Dog barks");
    }

    public void Visit(Cat cat)
    {
        Console.WriteLine("Cat meows");
    }
}

class visitor_pattern
{
    static void Main()
    {
        IElement dog = new Dog();
        IElement cat = new Cat();

        IVisitor visitor = new AnimalSoundVisitor();

        dog.Accept(visitor);  // Output: Dog barks
        cat.Accept(visitor);  // Output: Cat meows
    }
}
