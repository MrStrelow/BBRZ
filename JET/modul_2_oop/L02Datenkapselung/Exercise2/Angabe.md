Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Schleifen
* Verzweigungen
* 2D-Arrays (Multidimensional Arrays)
* Collections (List, Dictionary)
* Operatoren
* Methoden und Konsturktoren
* Erstellen von Klassen
* Erstellen von Felder
* Erstellen von Methoden
* hat und ist Beziehungen

Welche ``Denkweisen`` üben wir hier?
* Wer hat welche Zuständigkeiten in einer Software?
* Wie gehe ich mit komplexerer Software, welche teilweise vorprogrammiert ist.

Bei Unklarheiten hier nachlesen:
* [Klassen, Methoden und Eigenschaften](https://github.com/MrStrelow/BBRZ/blob/main/JET/modul_1_c%23_basics/L04KlassenMethoden/L04KlassenMethoden/L04.1KlassenMethoden.md)

## 1. Hamstern 🌲🟫🐹🌱🟦
Generiere ein ``Feld (Plane)`` mit `Boden(Earth)` in der Konsole welches von ``Hamstern`` und `Saatgut (Seeds)` besiedelt wird.

Verwende dazu folgende `Klassen`:
* **Simulation**: Dient als Startpunkt der `Main` Methode und erstellt die `Plane`. Weiters kann hier jeder `Hamster` welcher von der `Plane` verwaltet wird, hier gesteuer werden. Damit ist gemeint, dass z.B. die Methode welche `Hunger` zufällig erzeugt oder die `Bewegung` durchführt, hier aufgerufen werden. Weiters kann die `Plane` hier dargestellt werden. Verwende `System.Sleep(500)` um jede Bewegung der `Hamster` zeitlich zu verzögern.
* **Plane**: Dient als `Verwaltung` und `Darstellung` der `Earth` Felder, sowie den `Hamstern` und `Seeds`. Die `Plane` ist zwei dimensional im Terminal darzustellen. `Earth` Felder sind nicht entfernbar, diese dienen als Basis Felder der `Plane`. `Hamster` und `Seeds` können sich auf diesen befinden. Da die `Earth` Felder keine Eigenschaften haben, müssen wir diese nicht als eigene Klasse modellieren. Die Klasse `Plane` verwaltet `Seeds` und `Hamster` in einer `Collection` freier Wahl. Bedeutet, wie viele `Hamster` und `Seed` in einer `Plane` existieren. Wenn ein `Hamster` ein `Seed` `frisst` oder `"speichert"` (im Mund), wird dieser `Seed` aus der Seed `Collection` entfernt.
* **Seed**: Dient als Verwaltung eines `Seeds`. Damit ist seine `Darstellung` auf der `Plane` und dessen `Position` gemeint. Weiteres Verhalten ist nicht vorgesehen.
* **Hamster**: Dient als Verwaltung eines `Hamsters`. Damit ist seine `Darstellung` auf der `Plane`, dessen `Position` und `Verhalten` gemeint. Mit `Verhalten` ist `bewegen`, `Seed essen wenn er/sie hungrig ist` und `Seed speichern wenn diese/r nicht hungrig ist`. Verwende zum `speichern` der Seeds im Mund des Hamsters eine `Collection` freier Wahl. Die Anzahl der zu speichernden `Samen` ist im `Hamster` begrenzt. 

### Möglicher Ablauf:
Verwende die unter [Zuständigkeiten](#zustandigkeiten) und [Starthilfe](#starthilfe) definierten Code-Skelette.

* Erstelle ein `UML-Klassendiagramm` welches die `Beziehungen (hat und ist)`, `Klassen`, dessen `Felder`, und `Methoden` darstellt.
* Erstelle alle `Klassen` und dessen `Felder und Methoden/Kosntruktoren`. Programmierde diese jedoch `nicht aus` sondern definiere nur die `Methodensignaturen`.
* Beginne mit der `Simulationsklasse` und erstelle die `Objekte` und rufe dessen `Methoden` auf.
* Beginne nun die verwendeten `Methoden` auszuprogrammieren.
* Es werden Fehler im `UML-Klassendiagramm` auffallen... starte alles von vorne.

Tipp: 
* Beschränke das Programm zuerst nur auf einen `Hamster` welcher in der `Plane` herumwandert.
* Verwende die "extended" Unicodes (24 Bit statt 16 Bit) für die Darstellung der Symbole (Emojis). Drücke dazu `"windows" + "."` Taste und füge die Symoble direkt in Visual Studio `string darstellung = "🐹";` ein. Ein `string` ist hier zu empfehlen, denn `char` besitzt nur eine größe von 16 Bit.
* Verwende `Console.Clear();` bzw. `Console.SetCursorPosition(0, 0);` falls der Terminal blinken sollte, um die alte Darstellung der `Plane` zu entfernen. Damit kannst du die `Bewegung` der Hamster auf einen Ort "over printen".
* Verwende `Console.OutputEncoding = Encoding.UTF8;` um die "extended" Unicode wie 🐹 im Terminal ausgeben zu können.

### Zuständigkeiten:
Definiere welche Klasse, was entscheiden soll. Damit ist z.B. gemeint: 
* Der `Hamster` selbst entscheidet wo er sich hin bewegt (z.B zufällig oder fixe Reihenfolge - rauf, runter, links, rechts; ...), aber 
* die `Plane` ist für die `Überprüfung` der Bewegung des Hamsters und die Darstellung auf dem `2D-String-Array` zuständig. 
* in der `Plane` werden zudem alle `Hamster` in einer `Collection` gespeichert um das Verhalten der Hamster umsetzen zu können.

Das bedeutet nun:
* Wir haben eine Methode `void move()` im `Hamster` welche die `neue Position` der Bewegung ausrechnet, 
* aber die `Plane` wird in dieser `void move()` Methode aufgefordert die Entscheidung des `Hamsters` `auf Sinnhaftigkeit` zu überprüfen. Diese Aufforderung ist als eigene Methode `void Position(Hamster hamster, Direction direction)` welche in der `Plane` liegt zu implementieren." 
* Weiters muss nun dem 2D-Array in der `Plane`, welches das Spielfeld darstellt, die `Positionen` der `Hamster` zugewiesen werden. Das geschieht mit der Methode `AssignElementsToPlane`.
* Zum Schluss wird das `aktualisierte` 2D-Array auf die `Console` ausgegeben. Wir setzen das mit der Methode `print` um.

Hier als Code:
```csharp
class Hamster {
    ...
    // Felder
    private Plane plane;
    ...
    // Methoden
    void Move() 
    {
        // TODO: z.B zufällige Entscheidung in welche Richtung sich der Hamster bewegt.
        Random random ...
        ...
        Direction direction = //z.B. hier nach OBEN - hier ist Direction ein Enum und es steht OBEN in der Variable direction.
        
        // TODO: Übermittlung der Entscheidung an die Plane
        plane.Position(this, direction);
    }
}

class Plane {
    ...

    void Position(Hamster hamster, Direction direction) 
    {
        // logik um abzufragen, ob der Hamster auf dieses Feld darf.
        switch (richtung)...

        // setzte die Position des Hamsters auf die neue Position
        z.B. hamster.SetX(hamster.GetX() + 1);
        ...
    }

    ...

    public void AssignElementsToPlane()
    {
        // wir malen alles mit Erde aus, um die "alten" Symbole zu entfernen.
        for (int i = 0; i < plane.GetLength(0); i++)
        {
            for (int j = 0; j < plane.GetLength(1); j++)
            {
                plane[i,j] = earthRepresentation;
            }
        }

        // wir malen nun die Hamster dort hin, wo diese sich befinden sollen.
        foreach (var hamster in hamsters)
        {
            plane[hamster.GetY(), hamster.GetX()] = hamster.GetRepresentation();    
        }

        // wir malen nun die Seeds dort hin, wo diese sich befinden sollen.
        foreach (var seed in seeds)
        {
            plane[seed.GetY(), seed.GetX()] = Seed.GetRepresentation();
        }
    }

    ...

    public void Print(int timeToSleep = 500)
    {
        // berechne die richtige Darstellung.
        AssignElementsToPlane();

        // setze die position auf links oben in die Console um die alte Darstellung "drüber" zu "printen".
        Console.SetCursorPosition(0, 0);

        // Stelle nun diese im Terminal dar.
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(plane[i, j]);
            }
            Console.WriteLine();
        }

        // Warte nun z.B. 500 ms und mache dann mit dem Programm weiter.
        Thread.Sleep(timeToSleep);
    }
}
```

### Starthilfe:
Gehe von dieser Simulations Klasse aus:
```csharp
public class Simulation 
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Plane spielfeld = new Plane(5);

        while (true) {
            spielfeld.SimulateHamster();
            spielfeld.SimulateSeed();

            spielfeld.Print();
        }
    }
}
```

Weiters ein Vorschlag für die `Plane` Klasse:

```csharp
...
public class Plane 
{
    // Felder
    ...
    // hat-Beziehungen
    ...

    // Konstruktor
    public Plane(int size)
    {
        // Erstelle das 2D array basierend auf dem Parameter size
        // belege das Feld mit dem Symbol für die Erde
        // wir brauchen Samen - erzeuge eine zufällige Anzahl an Samen
        // wir brauchen Hamster - erzeuge eine zufällige Anzahl an Hamster 
        // (pass auf dass nicht zu viele Hamster erzeugt werden!)
    }
    
    // Methoden
    public void SimulateSeed()
    {
        Regrowth();
    }

    public void SimulateHamster()
    {
        foreach (var hamster in hamsters)
        {
            hamster.Move();
            hamster.NutritionBehaviour();
        }
    }

    public void Print(int timeToSleep = 500)
    {
    ... siehe Zuständigkeiten
    }

    public void Position(Hamster hamster, Direction direction)
    {
    ... siehe Zuständigkeiten
    }

    public void AssignElementsToPlane()
    {
    ... siehe Zuständigkeiten
    }

    public void RegrowSeeds()
    {
    ... BONUS: Muss nicht implementiert werden. Wer aber keine hungrigen Hamster will, muss dies tun.
    }

    public bool AssignInitialPosition(Hamster hamster, (int x, int y) key)
    {
    ... wird im Konstruktor der Klasse Hamster aufgerufen
        // ist das Feld bereits besetzt? (Hamster oder Seed bereits dort)
    }

    public bool AssignInitialPosition(Seed seed, (int x, int y) key)
    {
    ... wird im Konstruktor der Klasse Seed aufgerufen
        // ist das Feld bereits besetzt? (Hamster oder Seed bereits dort)
    }

    ...

    // get-set Methoden
    ...
}
```

für den Hamster:

```csharp
public class Hamster
{
    // Felder
    ...

    // (hat) Beziehungen
    ...

    // Konstruktor
    public Hamster(Plane plane)
    {
        // weise Felder und hat-Beziehungen zu
        ...

        PositionAndManageHamster();
    }

    // Methoden
    private void PositionAndManageHamster()
    {
        // positioniere en Hamster an einer zufälligen Stelle. 
        // falls dies nicht möglich ist, wiederhole es solange bis es geht
        do 
        {
        // wir fragen hier das Spielbrett, ob es möglich ist auf Position (x,y) den Hamster zu plazieren.
        // wenn nicht... neuer Versuch.
        ...
        done = plane.AssignInitialPosition(this, (x, y));
        ...
        } while(!done);

        // weise nun die gültige Position (x, y) dem Feld in der Klasse Hamster zu. 
    }

    // Methoden
    public void Move()
    {
       ... siehe Zuständigkeiten
    }

    public void NutritionBehaviour()
    {
        // werde zufällig hungrig und passe die Darstellung je nach dem an.
        
        // Ist ein Samen unter mir (hamster) ?
        // - Wenn ja, 
        //    - habe ich hunger?
        //      - wenn ja, 
        //         - iss den samen.
        //      - wenn nein,
        //         - sammle den Samen im Mund
        // - Wenn nein,
        //    - habe ich hunger und hab ich einen Samen im Mund?
        //      - wenn ja,
        //        - iss den samen aus dem Mund.
        //      - wenn nein,
        //        - Hamster bleibt hungrig.
    }


    private void EatSeedFromMouth()
    {
        // hamster wird nicht mehr hungrig.
        Eat();

        // hamster entfernt den Samen aus dem Mund
        ...
    }

    public void EatSeedFromTile()
    {
        // hamster wird nicht mehr hungrig.
        Eat();

        // hamster sagt dem spielfeld, der samen ist weg
        ...
    }

    private void Eat()
    {
        // hamster ist nicht mehr hungrig.
        // die darstellung wird von hungrig auf normal geändert.
    }

    public void PutInMouth()
    {
        // hamster steckt samen auf seiner Position in den Mund (Collection).
        //  - hole dazu von der Plane einen Samen auf der Position des Hamsters.
        //  - und füge den dem Mund hinzu.

        // hamster sagt dem spielfeld, der Samen gegessen wurde. Das Spielfeld kümmert sich nun darum diesen zu entfernen.
    }

    // Wir überschreiben die Methode ToString, damit wir eine einfachere Ausgabe Darstellung von den Objekten der Klasse Hamster haben
    // Ist angenehmer falls wir den Debug-Modus verwenden müssen. Sehen das Symbol und nicht eine Nummer.
    public override String ToString()
    {
        return representation;
    }

    // get-set Methoden
    ...
}
```

und für den Seed:
```csharp
public class Seed
{
    // Felder
    ...
    // (hat) Beziehungen
    ...

    // Konstruktor
    public Seed(Plane plane)
    {
        // weise Felder und hat-Beziehungen zu
        ...

        PositionAndManageSamen();
    }

    private void PositionAndManageSamen()
    {
       ... sehr ähnlich wie in PositionAndManageHamster()
    }

    // Wir überschreiben die Methode ToString, damit wir eine einfachere Ausgabe Darstellung von den Objekten der Klasse Hamster haben
    // Ist angenehmer falls wir den Debug-Modus verwenden müssen. Sehen das Symbol und nicht eine Nummer.
    public override String ToString()
    {
        return representation;
    }

    // get-set Methoden
    ...
```

Möglicher Output:

🟫🐹🟫🌱🌱

🌱🌱🟫🌱🌱

🟫🐹🌱🌱🌱

🟫🟫🟫🌱🌱

🟫🐹🟫🟫🌱
