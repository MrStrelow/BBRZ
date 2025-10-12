1) Wann ist ein ``Konstruktor`` mit ``Parametern`` einem *parameterlosen* ``Konstruktor`` in *Kombination* mit einem ``Object-Initializer`` vorzuziehen? *Hinweis: Wer garantiert die Zuweisung einer ``Property`` (Eigenschaft)?*

    * Mit dem ``Konstruktor`` kann garantiert werden, dass ein Objekt genau so wie es im ``Konstruktor`` steht erzeugt wird. Die Verwendung eines ``Object-Initializers`` ist eine Kombination von (meistens) einem ``Default-Konstruktor`` und dem Aufruf mehrerer ``Set`` ``Methoden``. Wenn der Aufruf einer ``Set`` ``Methode`` vergessen wurde, dann kann ein ungewünschtes Verhalten entstehen. Es ist jedoch flexibler und nicht so *strikt* wie die Erzeugung nur über Konstruktoren. Es ist für jedes ``Objekt`` abzuwiegen, wie wichtig ein solches ungewünschtes Verhalten ist vs. viele verschiedene ``Konstruktoren`` erzeugen.
 
2) Welche ``Methoden`` bekommt eine ``Variable`` wenn wir den ``Nullable Operator`` *?* bei dem ``Wertdatentyp`` z.B. des ``Typs`` *int* verwenden? 
    * *HasValue*: Es erlaubt uns in einer ``Verzweigung`` abzufragen ob unser ``Wertdatentyp`` einen *"nullartigen"* Wert beinhaltet. Also nur einen Standardwert hat, welcher gesetzt wird, wenn die ``Variable`` nicht ``initialisiert`` wurde.
    **Anmekrung:** Der Compiler erlaubt auch Abfragen der ``Variable`` ``int? nullableInt;`` mit ``nullableInt == null`` und ``nullableInt is null``. Diese haben die gleiche Bedeutung wie ``!nullableInt.HasValue``. Es ist also nur eine Stilsache, ob wir *HasValue*, *is not null* oder *!= null*. Schreiben. 
    * *Value*: Wir schreiben z.B. 
    ```csharp
    // int? userInput = null; // Wir können null vergeben. HasValue ist false.
    int? userInput = 5; // Wir können einen Wert vergeben. HasValue ist true.
    if (userInput.HasValue) {
        // Hier ist ein Fehler wenn wir nur userInput schreiben. 
        // Console.WriteLine(InProzent(userInput)); 

        // Wir müssen int? zu int umwandeln. Das machen wir mit userInput.Value
        Console.WriteLine(InProzent(userInput.Value)); 
    }
    else
    {
        // hier wissen wir sicher dass userInput nicht initialisiert wurde.
    }

    // diese Methode erwartet einen int. Nicht int?.
    int InProzent(int zahlNichtInProzent) 
    {
        return zahlNichtInProzent * 100;
    }
    ```
    Es erlaubt uns also den direkten Zugriff auf die ``Werte`` der ``Variablen``, wie wenn es ein normaler *int* wäre. Dieser kann keinen *"nullartigen"* Wert beinhalten.

    * *GetValueOrDefault()*: Wir schreiben z.B. 
    ```csharp
    // int? userInput = null; // Wir können null vergeben. HasValue ist false.
    int? userInput = 5; // Wir können einen Wert vergeben. HasValue ist true.

    // Wenn wir den Fehlerzustand beheben können, rufen wir GetDefaultValue auf.
    // ... Heißt, wenn userInput null ist, dann verwende den Standardwert 0.
    Console.WriteLine(InProzent(userInput.GetDefaultValue())); 

    // ... Heißt, wenn userInput null ist, dann verwende den Standardwert 1.
    Console.WriteLine(InProzent(userInput.GetDefaultValue(1))); 

    // diese Methode erwartet einen int. Nicht int?.
    int InProzent(int zahlNichtInProzent) 
    {
        return zahlNichtInProzent * 100;
    }
    ```
    Wie *Value*, jedoch wenn wir den Fall des null seins, mit einem Standardwert beheben wollen.


3) Kann der ``Nullable Operator`` *?* bei einem ``Referenzdatentyp`` verwendet werden? Wenn **ja**, gib ein Beispiel an und was wir damit ereichen. Wenn **nein**, warum ist das nicht möglich bzw. nicht sinnvoll?
    * Ja. Dieser teilt dem ``Compiler`` zur ``Compilezeit`` mit, dass ein ``Objekt`` eine leere ``Referenz`` (``null``) annehen kann. Dieser erinnert Programmierer, wenn diese ``myNullableReference is not null`` vergessen mit einer ``Warning``. Zudem verhindern wir damit andere ``Warnings`` welche sagen, dass unsere Variable *null* sein kann, jedoch nicht mit *?* versehen wurde. Das ist gewünscht wenn wir ``string? myNullableReference`` schreiben und sollte keine ``Warnings`` erzeugen.