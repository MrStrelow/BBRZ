//using System.Xml.Linq;

//namespace Beziehungen;
//public class PersonFactory :
//{
//    public static Person CreatePerson(string name, string street)
//    {
//        var address = new Address { Street = street };
//        var person = new Person { Name = name, Address = address };
//        return person;
//    }
//}

//public interface Creatable
//{

//}

//public class Person : 
//{
//    public string Name { get; protected set; }
//    public Address Address { get; protected set; }
//}

//public class Address
//{
//    public string Street { get; protected set; }
//    public Person Resident { get; protected set; }
//}

//public class Start
//{
//    static void Main(string[] args)
//    {
//        var person = PersonFactory.CreatePerson("John", "123 Elm St");
//        Console.WriteLine(person.Address);
//    }
//}
