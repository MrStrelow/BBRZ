﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

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



