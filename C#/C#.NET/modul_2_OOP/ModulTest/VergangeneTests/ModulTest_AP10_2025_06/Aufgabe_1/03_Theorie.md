* wieso schreiben wir meistens ``public`` bei einer ``Property`` (Eigenschaft)? Sollten wir laut ``Data-Hiding`` nicht unsere ``Felder`` vor uneingeschränkten Zugrifen beschützen? 
    * ``Properties`` sind ``Methoden`` welche *private* ``Felder`` im Hintergrund generieren. Wir steuern die Sichbarkeit der ``Methoden`` mit ``... string Value { get; private set; }``. Mit ``public string Value {...}`` wird die Sichbarkeit von ``Get`` und ``Set`` gleichzeitg gesteuert. Feine Unterschiede sind hier ausgelassen worden.
    
* Was bedeutet der ``Nullable Operator`` *?* bei einem ``Referenzdatentyp`` und was *?* bei einem ``Wertdatentyp``?
    * ``Referenzdatentyp``: Ein ``Referenzdatentyp`` kann immer ``null`` sein, jedoch gibt der ``Compiler`` ``Warnings`` an. Mit *?* entfernen wir die Warnings, denn wir sagen damit, es mit **Absicht** möglich dass diese ``Referenz`` ``null`` sein kann. Dadurch entstehen neue ``Warnings`` wenn wir z.B. nicht diese ``Variable`` auf ``null`` abfragen.
    * ``Wertdatentyp``: Wir erlauben dadurch den ``Wert`` ``null`` bei z.B. einem *int*. Es ist hier nur ein Platzhalter für *der Wert ist undefiniert* und ist bei der Verwendung von z.B. einem *int* aus einer ``Datenbank`` angenehm. Wenn dieser dort ``null`` sein darf, dann muss wohl oder übel das auch in ``C#`` so sein. Es erlaubt uns zudem die Verwendung von ``Methoden`` und dem ``Null-Coalescing Operator`` bei einem *int* wie z.B. ``int? meinInt = 5; ... if (meinInt.HasValue) {...} ... var a = meinInt ?? -1;``. Letzeres ist nützlich um einen anderen Wert als ``null`` für den *undefinierten* Zustand zu verwenden. 

* Ist ``int? a = 5;`` und ``int a = true ? 5 : 3;`` konzeptionell verwandt? Begründe.
    * ``int? a = 5;`` ist der ``Nullable Operator``. Das eine ist ein ``If-Ausdruck``, umgesetzt in ``C#`` mit dem ``?: Operator``. Es geht also um **nicht** verwandte Konzepte.

* Wann ist es **notwendig** ``new ()`` anstatt ``var`` zu schreiben? Es scheint, dass ``var`` die flexiblere Variante ist. Schau dazu folgenden Code an und probiere diesen aus.
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