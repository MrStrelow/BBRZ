* a) wieso schreiben wir meistens ``public`` bei einer ``Property`` (Eigenschaft)? Sollten wir laut ``Data-Hiding`` nicht unsere ``Felder`` vor uneingeschränkten Zugrifen beschützen? 
    * ``Properties`` sind ``Methoden`` welche *private* ``Felder`` im Hintergrund generieren. Wir steuern die Sichbarkeit der ``Methoden`` mit ``... string Value { get; private set; }``. Mit ``public string Value {...}`` wird die Sichbarkeit von ``Get`` und ``Set`` gleichzeitg gesteuert. Feine Unterschiede sind hier ausgelassen worden.
* c) Wann ist es **notwendig** ``new ()`` anstatt ``var`` zu schreiben? Es scheint, dass ``var`` die flexiblere Variante ist. Schau dazu folgenden Code an und probiere diesen aus.
    * Wenn wir es bei ``Felder`` oder ``Properties`` anwenden wollen.

```csharp
public class Plane;
public class Hamster
{
    // Felder
    private var _plane = new Plane(); // Gibt es hier einen Fehler? ja
    //private Plane _plane = new (); // Gibt es hier einen Fehler? nein
}

public class Programm
{
    // Inhalt einer Methode
    public static void Main(string[] args)
    {
        var hempter = new Hamster(); // Gibt es hier einen Fehler? nein
        // vs.
        Hamster hompter = new(); // Gibt es hier einen Fehler? nein
    }
}
```