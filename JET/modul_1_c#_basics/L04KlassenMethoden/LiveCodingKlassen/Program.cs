using LiveCodingKlassen;

int zahl = 3;

Hund doggo = new Hund(
    chipped: true,
    name:    "dogotin"
);

Hund copyOfDoggy = new Hund(doggo);

doggo.SetSpielfreund(copyOfDoggy);
copyOfDoggy.SetSpielfreund(doggo);

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