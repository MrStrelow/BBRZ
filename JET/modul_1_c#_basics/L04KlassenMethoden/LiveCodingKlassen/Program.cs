using LiveCodingKlassen;

int zahl = 3;
bool chipped = true;

Hund doggo = new Hund(
    name:   "doggo",
    chipped
);

Hund anotherDog = new Hund(doggo);
Console.WriteLine(anotherDog == doggo);
Console.WriteLine(anotherDog.Equals(doggo)); // TODO: not yet implemented :( methode equals überschreiben in Hund.

Console.WriteLine(anotherDog.name);


SchaeferHunder hannah = new SchaeferHunder();