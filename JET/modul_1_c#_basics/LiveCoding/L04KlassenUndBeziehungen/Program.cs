using LiveCodingKlassen;

int zahl = 3;

Hund doggo = new Hund(
    chipped: true,
    name:    "dogotin"
);

Hund copyOfDoggy = new Hund(doggo);

Console.WriteLine(doggo == copyOfDoggy);
Console.WriteLine(doggo.Equals(copyOfDoggy));


doggo.SetSpielfreund(copyOfDoggy);

//Console.WriteLine(anotherDog == doggo);
//Console.WriteLine(anotherDog.Equals(doggo)); // TODO: not yet implemented :( methode equals überschreiben in Hund.

doggo.Spielen();
copyOfDoggy.Spielen();

var hunde = new List<Hund>() { doggo, copyOfDoggy };

SchaeferHunde hannah = new SchaeferHunde(
    name: "Hannah", 
    chipped: false, 
    capacity: 10, 
    zuBehueten: hunde
);

Hund doggu;
Console.WriteLine(doggu.alter);

HundeBesitzer hundeBesitzer = new HundeBesitzer(name: "Sabine", alter: 30, happiness: 5.0, capacity: 46, meinErsterHund: doggo);
