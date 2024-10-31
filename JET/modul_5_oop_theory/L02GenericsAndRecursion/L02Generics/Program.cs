using solution;
using System;
using System.Data.Common;
using System.Security;
using System.Security.Cryptography;

namespace L02Generics;

internal class Test
{
    public static void Main(String[] args)
    {
        // Was ist Kontravarianz und Kovarianz bei Methodenaufrufen?
        // TODO: namen erklären.

        // Hier ein Beispiel dazu.
        var cat = new Cat("catis");
        var dog = new Dog("doggus");
        Animal hiddenDog = new Dog("actuallyDog");
        Animal hiddenCat = new Dog("actuallyCat");

        // ########################### Argumente einer Methode ###########################
        // Wir schauen nun auf den Input der Methoden (arguments).
        // Die Methodensignatur gibt "Animal Encounters(Animal animal): return Animal animal" vor.
        // Können wir also Untertypen als Argument verwenden?
        cat.Encounters(dog);   // ja
        dog.Encounters(cat);   // ja

        // Natürlich geht der Typ selbst auch.
        var animal = (Animal)cat;
        dog.Encounters(animal);
        dog.Encounters(hiddenCat);
        dog.Encounters(hiddenDog);

        // Dieses Verhalten nennen wir kontravariant. Ein Untertyp wird akzeptiert wo dessen Obertyp erwartet wird.
        // Das deckt sich mit dem Ersetzbarkeitsprinzip, der Untertyp ist verwendbar wo dessen Obertyp erwartet wird.
        // MERKE: ARGUMENTE EINER METHODE SIND KONTRAVARIANT!

        // Funktioniert auch der umgekehrte Fall?
        // Der wäre: Ein Obertyp wird akzeptiert wo dessen Untertyp erwartet wird.
        // Laut dem Ersetzbarkeitsprinzip klingt das schon mal komisch.
        // Der Obertyp ist verwendbar wo dessen Untertyp erwartet wird?

        // Schauen wir uns folgende Methode mit Signatur: Dog GenerateOffspring(Dog dog, Dog dog): return Dog dog, an.
        // Wir verwenden hier als Argument den Obertyp, wo dessen Untertyp erwartet wird.
        // Geht das?

        //dog.GenerateOffspring(animal);          // nein. Nur ein Typ von Dog ist als argument erlaubt.
        //dog.GenerateOffspring(hiddenCat);       // Auch wenn es hier ein Hund (aber mit Animal als Typ) ist, muss es nicht im allgemeinen so sein.
        dog.GenerateOffspring((Dog)hiddenCat);  // erst durch explizite Typumwandlung von animal zu Pet geht das.
                                                // Jedoch nur formal, ob das Verhalten nun stimmt und ob es zu Laufzeitfehler kommt,
                                            // ist nicht klar.

        // MERKE: ARGUMENTE EINER METHODE SIND NICHT KOVARIANT!


        // ########################### Rückgabewerte einer Methode ###########################
        // Schauen wir uns nun die Rückgabewerte einer Methode an. Ist es gleich wie bei den Argumenten, also kontravariant?

        //dog = dog.Encounters(dog); // Nein. Es wir ein Animal als Rückgabe erwartet, jedoch haben wir einen Hund.

        // In unserem Fall, ist der Hund ein Animal, und dieser wird in die Methode gegeben
        // und durch die Kontravarianz akzeptiert. Danach wird dieser zurückgegeben.
        // Wieso akzeptiert hier der Compiler diesen Ausdruck nicht, wenn wir doch wissen,
        // dass ein Hund wieder returniert wird?
        // Wir haben hier eine Annahme gemacht. Unser Code gibt das Argument wieder in einer oder
        // der anderen Form zurück. Das argument Hund wird also ein Hund vom Typ Animal beim return. 
        // Unsere Methode gibt kann aber auch möglicherweise Katze zurück geben, auch wenn wir einen Hund übergeben.
        // Das geht so:
        
        //dog = cat.Encounters(dog);

        // Da der Compiler nicht so genau schauen will (performance) bzw. kann (unetscheidbar) was wir programmieren
        // haltet sich dieser an die Regel, wenn ein Animal zurück gegeben wird, ist es egal ob das ein Hund einmal war.
        // Wir merken uns das nicht, und gehen von einem allgemein Animal aus.
        // Durch die die Ersetzbarkeit, ist eine Katze kein Hund und führt deshalb kommt der Fehler.
                            
        // Da der Compiler keine implizite Typumwandlung vornehmen will, kommt hier ein Fehler.
        
        dog = (Dog)cat.Encounters(dog); // Hier ist eine explizite Umwandlung, durch type casts notwendig.
                                 // Problem: explizite Umwandlung kann zu vielen ifs/switches führen.
                                 // Wenn wir 100 Tiere haben können wir uns OOP sparen und Prozedural arbeiten
                                 // (structs reichen dann, kein Polymorphism notwendig).

        animal = cat.Encounters(dog);   // Wir geben hier einen Dog rein, welcher durch die methode wieder zurückgegeben wird.
                                        // Es ist aber am Schluss ein Animal.

        // Dieses Verhalten nennen wir kovariant. Ein Untertyp wird zurückgegeben aber 

        // schauen auf output

        // Kontravarianz bei Generizität
        // geht, da covariant
        var manager = new Manager();
        var human = new Human();
        ICovariantList<Human> covariantHumanList;
        covariantHumanList = new KovarianteList<Human>(human);     // geht weil invariant - links und rechts steht human (der standardfall)
        covariantHumanList = new KovarianteList<Human>(manager);   // geht weil manager untertyp von Human ist
        covariantHumanList = new KovarianteList<Manager>(manager); // geht weil covariat list<human> = list<manager>
                                                                   //LinkedIterativeList<Human> notCovariantList = new LinkedIterativeList<Manager>(); // geht nicht, geht weil nicht covariat list<human> != list<manager>

        //covariantHumanList = new KovarianteListList<Manager>(human);   // geht nicht weil human kein untertyp von manager.
        var humanOrManager = covariantHumanList.Get(101);         // Typ ist Human! da beim erstellen human links von der Zuweiseung steht.
                                                                  // (hover über var um derived type zu sehen)


        // geht da kontravariant
        IKontravariantList<Manager> kontravariantList;
        kontravariantList = new KontravarianteList<Human>(human);     // geht weil invariant - links und rechts steht human (der standardfall)
        kontravariantList = new KontravarianteList<Human>(manager);   // geht weil manager untertyp von Human ist
        kontravariantList = new KontravarianteList<Human>(manager); // geht weil kontravariant list<manager> = list<human>
                                                                    //LinkedIterativeList<Manager> notKontravariantList = new LinkedIterativeList<Human>(); // geht nicht, geht weil nicht covariat list<human> != list<manager>

        kontravariantList.Add(new Manager());
        //kontravariantList.Add(new Human());                       // Typ was erwartet wird ist Manager.
        // da beim erstellen der liste, list<manager> links von der Zuweiseung steht.

    }
}





