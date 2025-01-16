//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LiveCoding;

//public class User
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//    public bool IsRegistered { get; set; }

//    public User(string name, int age, bool isRegistered)
//    {
//        Name = name;
//        Age = age;
//        IsRegistered = isRegistered;
//    }
//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        User user = new User("Alice", 25, true);
//        ProcessUserNestedIf(user);
//        ProcessUserGuardClause(user);
//    }

//    public static void ProcessUserNestedIf(User user)
//    {
//        //if (user is not null)
//        if (user != null)
//        {
//            if (user.IsRegistered)
//            {
//                if (user.Age >= 18)
//                {
//                    Console.WriteLine("User is processed.");
//                    // HIER WOLLEN WIR HIN. also hier soll die Bedingung der gesamten Formel wahr sein.
//                }
//                else
//                {
//                    Console.WriteLine("User is too young.");
//                }
//            }
//            else
//            {
//                Console.WriteLine("User is not registered.");
//            }
//        }
//        else
//        {
//            Console.WriteLine("User is null.");
//        }
//    }

//    public static void ProcessUserGuardClause(User user)
//    {
//        if (user is null)
//        {
//            Console.WriteLine("User is null.");
//            return;
//        }

//        if (!user.IsRegistered)
//        {
//            Console.WriteLine("User is not registered.");
//            return;
//        }

//        if (user.Age < 18)
//        {
//            Console.WriteLine("User is too young.");
//            return;
//        }

//        Console.WriteLine("user is processed");

//    }
//}


