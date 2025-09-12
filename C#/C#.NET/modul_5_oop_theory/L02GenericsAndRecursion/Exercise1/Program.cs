using System;
using System.Data.Common;
using System.Security;
using Exercise1;


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





