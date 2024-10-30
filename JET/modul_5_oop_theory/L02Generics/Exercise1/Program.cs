using System;
using System.Data.Common;
using System.Security;
using Exercise1;
using Exercise1.src.Domain.People.Entities;


// Erstelle Humans, welche Worker oder Manager sind.
// var human = new Human { Name = "Alice", Age = 30 }; // geht nicht weil
var worker = new Worker { Name = "Alice", Age = 30, Factory = "Tesla" };
var manager = new Manager { Name = "Bob", Age = 40, Department= "Finance" };
var anotherWorker = new Worker { Name = "Charlie", Age = 25, Factory = "VW" };

// Erstelle alle Listen mit Typeparameter Human.
var arrayList = new ArrayList<Human>();
//var linkedList = new LinkedList<Human>(); // Geht nicht da LinkedList abstract ist.
//var myList = new IMyList<Human>(); // Geht nicht da IMyList ein Interface ist.
var linkedListIterative = new LinkedIterativeList<Human>();
var linkedListRecursive = new LinkedRecursiveList<Human>();
var linkedSortedList = new SortedLinkedList<Human>(ascending: true);

ListTest.RunTests(arrayList, worker, manager, anotherWorker);
ListTest.RunTests(linkedListIterative, worker, manager, anotherWorker);
ListTest.RunTests(linkedListRecursive, worker, manager, anotherWorker);
ListTest.RunTests(linkedSortedList, worker, manager, anotherWorker);

// ############## old ##############
//var arrayList = new ArrayList<string>(10);
//arrayList.AddBeginning("I'm");
//arrayList.AddBeginning("Hello");
//arrayList.AddEnd("List");

//foreach (var item in arrayList)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine(arrayList);
//Console.WriteLine("###########");

//var manager = new Manager();
//var human = new Human();

//var humanList = new LinkedRecursiveList<Human>();
//humanList.AddBeginning(new Human());
//humanList.AddBeginning(new Human());
//// geht weil Manager untertyp von Human.
//humanList.AddEnd(new Manager());

//Console.WriteLine(humanList);
//Console.WriteLine("###########");

//var managerList = new LinkedRecursiveList<Manager>();
//managerList.AddBeginning(new Manager());
//managerList.AddBeginning(new Manager());
//// geht nicht weil Human kein untertyp von Human.
////managerList.AddBeginning(new Human());

//Console.WriteLine(managerList);
//Console.WriteLine("###########");

// können wir eine Manager List anstatt einer Human list verwenden?
// manager sind ja humans, somit sollten wir die verwalten können.

// nein.
//managerList = humanList;
//humanList = managerList;

// Wir müssen Einschränkungen treffen:
// - entweder Covariant: siehe md file
// - oder Kontravariant: siehe md file


// verletzung der typbeziehung
//var manager = human;

// geht nicht, da nicht kontravariant
// "manager = human" ist nicht das gleiche wie "list<manager> = list<human>".
//managerList = new LinkedRecursiveList<Human>();
// die 2. Zuweisung verletzt per se nicht die Typbeziehung, die 1. schon.

// geht nicht, da nicht covariant
//managerList.AddEnd(new Human());
//humanList = new LinkedRecursiveList<Manager>();








