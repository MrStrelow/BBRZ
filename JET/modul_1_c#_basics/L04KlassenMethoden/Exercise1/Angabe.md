Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Schleifen
* Verzweigungen
* 2D-Arrays (Multidimensional Arrays)
* Collections
* Operatoren
* Methoden und Konsturktoren
* erstellen von Klassen
* hat und ist Beziehungen
* erstellen von Felder

Welche ``Denkwweisen`` üben wir hier?
* Wer hat welche Zuständigkeiten in einer Software?

Lies davor:
* [Klassen, Methoden und Eigenschaften]()

## 1. Hamstern 🌲🟫🐹🌱🟦
Generiere ein ``Feld (Plane)`` mit `Boden(Earth)` in der Konsole welches von ``Hamstern`` und `Saatgut (Seeds)` besiedelt wird.

Verwende dazu folgende `Klassen`:
* Simulation: Dient als Startpunkt der `Main` Methode und erstellt die `Plane`. Weiters kann hier jeder `Hamster` welcher von der `Plane` verwaltet wird, hier gesteuer werden. Damit ist gemeint, dass z.B. die Methode welche `Hunger` zufällig erzeugt oder die `Bewegung` durchführt, hier aufgerufen werden. Weiters kann die `Plane` hier dargestellt werden. Verwende `System.Sleep(500)` um jede Bewegung der `Hamster` zeitlich zu verzögern.
* Plane: Dient als `Verwaltung` und `Darstellung` der `Earth` Felder, sowie den `Hamstern` und `Seeds`. Die `Plane` ist zwei dimensional im Terminal darzustellen. `Earth` Felder sind nicht entfernbar, diese dienen als Basis Felder der `Plane`. `Hamster` und `Seeds` können sich auf diesen befinden. Da die `Earth` Felder keine Eigenschaften haben, müssen wir diese nicht als eigene Klasse modellieren. Die Klasse `Plane` verwaltet `Seeds` und `Hamster` in einer `Collection` freier Wahl. Bedeutet, wie viele `Hamster` und `Seed` in einer `Plane` existieren. Wenn ein `Hamster` ein `Seed` `frisst` oder `"speichert"` (im Mund), wird dieser `Seed` aus der Seed `Collection` entfernt.
* Seed: Dient als Verwaltung eines `Seeds`. Damit ist seine `Darstellung` auf der `Plane` und dessen `Position` gemeint. Weiteres Verhalten ist nicht vorgesehen.
* Hamster: Dient als Verwaltung eines `Hamsters`. Damit ist seine `Darstellung` auf der `Plane`, dessen `Position` und `Verhalten` gemeint. Mit `Verhalten` ist `bewegen`, `Seed essen wenn er/sie hungrig ist` und `Seed speichern wenn diese/r nicht hungrig ist`. Verwende zum `speichern` der Seeds im Mund des Hamsters eine `Collection` freier Wahl. Die Anzahl der zu speichernden `Samen` ist im `Hamster` begrenzt. 

### Zuständigkeiten:
* Definiere welche Klasse, was entscheiden soll. Damit ist z.B. gemeint: "Der `Hamster` selbst entscheidet wo er sich hin bewegt (z.B zufällig oder fixe Reihenfolge - rauf, runter, links, rechts; ...), aber die `Plane` ist für die Darstellung auf dem `2D-String-Array` zuständig. Bedeutet, wir haben eine Methode `void move()` im `Hamster` welche die `neue Position` der Bewegung ausrechnet, aber die `Plane` wird in dieser `void move()` Methode aufgefordert die Entscheidung des `Hamsters` `grafisch` umzusetzen. Diese Aufforderung ist als eigene Methode `void position(Hamster hamster, Direction direction)` welche in der `Plane` liegt zu implementieren."

Hier als Code:

```csharp
class Hamster {
    ...
    // Felder
    private Plane plane;
    ...
    // Methoden
    void move() 
    {
        // TODO: z.B zufällige Entscheidung in welche Richtung sich der Hamster bewegt.
        Random random ...
        ...
        Direction direction = //z.B. hier nach OBEN - hier ist Direction ein Enum und es steht OBEN in der Variable direction.
        
        // TODO: Übermittlung der Entscheidung an die Plane
        plane.position(this, direction);
    }
}

class Plane{
    ...
    void position(Hamster hamster, Direction direction) 
    {
        // logik um abzufragen, ob der Hamster auf dieses Feld darf.
        switch (richtung)...
        ...

        plane[hamster.GetY(), hamster.GetX()] = hamster.GetSymbol(); 
        // Wir verzichten hier auf den Einsatz von EIGENSCHAFTEN. Wer diese verwenden will, gerne. Deshalb hier die `GetMethode` wie in JAVA.
    }
}
```

* Wenn wir eine `Bewegung` durchführen wollen, müssen wir uns das Symbol `merken` welches wir betreten. Beim `Verlassen` des Feldes müssen wir das alte Symbol `wieder herstellen`.
Achtung! Was passiert wenn zwei `Hamster` sich auf das gleiche Feld stellen? Was merkt sich der spätere `Hamster` für ein Feld?

### möglicher Ablauf:
* Erstelle ein `UML-Klassendiagramm` welches die `Beziehungen (hat und ist)`, `Klassen`, dessen `Felder`, und `Methoden` darstellt.
* Erstelle alle `Klassen` und dessen `Felder und Methoden/Kosntruktoren`. Programmierde diese jedoch `nicht aus` sondern definiere nur die `Methodensignaturen`.
* Beginne mit der `Simulationsklasse` und erstelle die `Objekte` und rufe dessen `Methoden` auf.
* Beginne nun die verwendeten `Methoden` auszuprogrammieren.

Tipp: 
* Beschränke das Programm zuerst nur auf einen `Hamster` welcher in der `Plane` herumwandert.
* Verwende die "extended" Unicodes (24 Bit statt 16 Bit) für die Darstellung der Symbole (Emojis). Drücke dazu "windows" + "." Taste und füge die Symoble direkt in Visual Studio `string darstellung = "🐹";` ein. Ein `string` ist hier zu empfehlen, denn `char` besitzt nur eine größe von 16 Bit.
* Verwende `Console.Clear();` um die alte Darstellung der `Plane` zu entfernen. Damit kannst du die `Bewegung` der Hamster auf einen Ort "over printen".
* Verwende `Console.OutputEncoding = Encoding.UTF8;` um die "extended" Unicode wie 🐹 im Terminal ausgeben zu können.

### Starthilfe:
Gehe von dieser Simulations Klasse aus:
```csharp
using Hamster;
using System.Text;

namespace Hamster;

public class Simulation
{
    static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Plane meinFeld = new Plane();

        while (true)
        {
            foreach (Hamster hamster in meinFeld.getHamsters())
            {
                hamster.Metabolize();
                hamster.Move();
            }

            meinFeld.PrintPlane();

            Thread.Sleep(500);
        }
    }
}

```

Möglicher Output:

🟫🐹🟫🌱🌱

🌱🌱🟫🌱🌱

🟫🐹🌱🌱🌱

🟫🟫🟫🌱🌱

🟫🐹🟫🟫🌱
