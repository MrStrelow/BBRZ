Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Schleifen
* Verzweigungen
* 2D-Arrays (Multidimensional Arrays)
* Operatoren
* Methoden und Konsturktoren
* erstellen von Klassen
* hat und ist Beziehungen
* erstellen von Felder

Welche ``Denkwweisen`` üben wir hier?
* Wer hat welche Zuständigkeiten in einer Software? 

Lies davor:
* [Klassen, Methoden und Eigenschaften]()

## 1. Hamstern 🌲🟫🐹🌱
Generiere ein ``Feld (Plane)`` mit `Boden(Earth)` in der Konsole welches von ``Hamstern`` und `Saatgut (Seeds)` besiedelt wird.

Verwende dazu folgende `Klassen`:
* Simulation: Dient als Startpunkt der `Main` Methode und erstellt die `Plane`. Weiters kann hier jeder `Hamster` welcher von der `Plane` verwaltet wird, hier gesteuer werden. Damit ist gemeint, dass z.B. die Methode welche `Hunger` zufällig erzeugt oder die `Bewegung` durchführt, hier aufgerufen werden. Weiters kann die `Plane` hier dargestellt werden. Verwende `System.Sleep(500)` um jede Bewegung der `Hamster` zeitlich zu verzögern.
* Plane: Dient als Verwaltung der `Earth`, sowie den `Hamstern` und `Seeds`. `Earth` Felder sind nicht entfernbar, diese dienen als Basis der `Plane`. `Hamster` und `Seeds` können auf diesen sich befinden. Die Klasse `Plane` verwaltet `Seeds` und `Hamster` in einer `Collection` freier Wahl. Bedeutet, wie viele `Hamster` und `Seed` in einer `Plane` existieren. Auch wenn ein `Hamster` ein `Seed` `frisst` oder `"speichert"` (im Mund) wird, behinhaltet diese Verwaltung.
* Seed: Dient als Verwaltung eines `Seeds`. Damit ist seine `Darstellung` auf der `Plane` und dessen `Position` gemeint. Weiteres Verhalten ist nicht vorgesehen.
* Hamster: Dient als Verwaltung eines `Hamsters`. Damit ist seine `Darstellung` auf der `Plane`, dessen `Position` und `Verhalten` gemeint. Mit `Verhalten` ist `bewegen`, `Seed essen wenn er/sie hungrig ist` und `Seed speichern wenn diese/r nicht hungrig ist`. Die Anzahl der zu speichernden `Samen` ist im `Hamster` begrenzt. 

möglicher Ablauf:
* Erstelle ein `UML-Klassendiagramm` welches die `Beziehungen (hat und ist)`, `Klassen`, dessen `Felder`, und `Methoden` darstellt.
* Erstelle alle `Klassen` und dessen `Felder und Methoden/Kosntruktoren`. Programmierde diese jedoch `nicht aus` sondern definiere nur die `Methodensignaturen`.
* Beginne mit der `Simulationsklasse` und erstelle die `Objekte` und rufe dessen `Methoden` auf.
* Beginne nun die verwendeten `Methoden` auszuprogrammieren.

Tipp: Verwende die "extended" Unicodes (24 Bit statt 16 Bit) für die Darstellung der Symbole (Emojis). Drücke dazu "windows" + "." Taste und füge die Symoble direkt in Visual Studio `string darstellung = "🐹";` ein. Ein `string` ist hier zu empfehlen, denn `char` besitzt nur eine größe von 16 Bit.

Starthilfe:
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