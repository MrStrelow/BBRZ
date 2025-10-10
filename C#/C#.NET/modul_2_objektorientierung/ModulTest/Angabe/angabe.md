# Modultest 2 - JET

Sie haben `180 Minuten` Zeit die Aufgaben zu lösen
* Sie können maximal 100 Punkte erreichen
* Es sind zur Prüfung zugelassen:
    * Taschenrechner (wenn erwünscht)
    * Transparente Wasserflasche
    * Papier, Geodreieck, Stifte, usw.
    * Am Computer sind alle Unterlagen sowie die Nutzung des Internets erlaubt.

Die Nutzung des Internets umfasst nicht
* Chatbots
* Veröffentlichung der Lösungen
* sonstige Kommunikation mit anderen Usern

Die Nutzung von allen anderen Dingen, muss vorher mit mir abgesprochen werden
(z.B. Nutzung von Ohropax), ansonsten wird dies als schummeln gewertet. 
Die Folge des Schummeln ist eine Bewertung mit 0 Punkten.

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 15 nach dem Ende der Prüfung schicken)
* Viel Erfolg! :)

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., (Schulnotensystem)

---

## Aufgabe 1: C# Style OOP - Properties, Object Initializer, Nullable, Null Coalescing, ... [55 / 100 Punkte]

### Programmverständnis [10 / 55 Teilpunkte]
Gegeben ist folgender Code welcher ``Properties``(Eigenschaften) und ``Set-Gaurds`` verwendet. 

1) 
    ```csharp
    private string Name { get; protected set; }
    ```
2) 
    ```csharp
    private int Id { private get; private set; }
    ```
3) 
    ```csharp
    public int TäglicherUmsatz
    {
        set
        {
            if (value > 2_000_000)
            {
                throw new ArgumentException("Der Umsatz ist nicht glaubwürdig");
            }
            field = value;
        }
        get;
    }
    ```
4) 
    ```csharp
    private int _täglicherUmsatz;
    public int TäglicherUmsatz
    {
        set
        {
            if (value > 2_000_000)
            {
                throw new ArgumentException("Der Umsatz ist nicht glaubwürdig");
            }
            _täglicherUmsatzMitKommazahlen = value;
        }
        get => _täglicherUmsatzMitKommazahlen;
    }
    ```

* Finde die Fehler in diesem Code und markiere diese. 
* Erkläre wieso diese Fehler zu einer nicht gültigen bzw. konzeptionell falschen ``Property``(Eigenschaft) führen. Falls dir konzeptionelle Probleme auffallen, merke diese an.  

**Hinweis:**
* es kann nicht 2 mal ein ``visibility modifier`` neben ``get`` und ``set`` stehen. Wenn so etwas gewünscht ist, schreiben wir den weniger restritiven ``visiblity modifier`` neben der ``Property`` (Eigenschaft) selbst. ``public string Name { proteced get; private set; }`` vs. ``protected string Name { get; private set; }``

---

### Programmieren [35 / 55 Teilpunkte]
Gegeben ist folgender Code welcher ``Klassen`` mit ``Felder`` (inklusive ``Hat-Beziehungen``) und die Erstellung von `Objekten` durch ``Konstruktoren`` darstellt. Schreibe den gegebenen Code um und verwende folgenden Werkzeuge von ``C#``:
* Diese **müssen** verwendet werden:
    * ``Properties``(Eigenschaften) *Name { get; set; }* 
    * ``Object-Initializer`` *new Hamster { Name = "hello" };*
    * ``Nullable-Operator`` *?* z.B. bei einem  ``Feld`` *private int _name?;* oder *private Hamster _hempter?;* 
* wähle **mindestens eines** aus den folgenden:
    * ``Null-Coalescing-Operator`` *??*  z.B. *_hempter ?? new Hamster();* oder *_hempter = hempter ?? throw new ArgumentNullException();* in einer ``Property``.
    * ``Lambda-Operator`` *=>* z.B. bei *string Name { get => _name; set => value = _name; }
    * ``var`` *var hempter = new Hamster(plane);* 
    * ``Target-Typing`` *new ()* z.B. in einem ``Feld`` *class Hamster { private List<Seedling> _mouth = new (); }
    * ``named-arguments`` *:* z.B. *new Hamster(plane: wateryAndMountainyHabitat) { Name = "hemptos" };*
    * ``optional-arguments`` *int age = 25* z.B. *public Hamster(string name, int age = 25)*. Es kann also *var Herbert = new Hamster("Herbert");* aufgerufen werden wo nun *herbert* *age=25* besitzt.
    * ``Guard-Clauses`` innerhalb der ``set`` der ``Property``.

Es soll dadurch **keine** 
* ``Get-Methoden`` bzw. ``Set-Methoden`` vorkommen,
* ``Felder`` (außer wir bruachen ``Backing Felder`` für ``set-guards``) vorkommen,
* Warnungen welche sich mit ``null`` beschäftigen vorkommen (Die Verwendung des ``Null-Forgiving`` Operator ``!`` ist nicht erlaubt), 
im Code vorhanden sein.

**Hinweise!:** 
* Achte im neu geschriebenen Code auf das ``Data-Hiding`` der ``Datenkaplesung``. Bei welchen ``Feldern`` und ``Methoden`` steht ``public``, ``protected``, ``private``, etc.
* Lassen Sie sich nicht durch ``Nullable<bool>`` verwirren. Am Ende brauchen wir es in dieser Form nicht. Schau dir in der Angabe die Liste mit Werkzeugen an *(was heißt ähnlich)* und verwende eines davon in den *Feldern bzw. Eigenschaften* im Hamster. Danach wird der Typ Nullable<bool> nicht mehr benötigt und es kann bool (mit einem kleien Zusatz) verwendet werden.

```csharp
// Dieses using dient nur der Organisation in diesem Beispiel.
using java = OldJavaStyleHamster;
using csharp = NewCSharpStyleHamster;

namespace OldJavaStyleHamster
{
    public class Hamster
    {
        private readonly static string _namedRepresentation = "🐹";
        private readonly static string _unnamedRepresentation = "🐾";

        private string _nickname; // Ein normaler string kann in altem Code 'null' sein
        private (int x, int y) _position;
        private List<Seedling> _mouth = new List<Seedling>();
        private Plane _habitat; // "Hat-Beziehung" zum Lebensraum

        public Hamster(Plane habitat, string nickname = null)
        {
            _habitat = habitat;
            _nickname = nickname;
        }

        public string GetRepresentation()
        {
            return _nickname == null ? _unnamedRepresentation : _namedRepresentation;
        }

        public string GetNickname() { return _nickname; }
        public void SetNickname(string name) { _nickname = name; }

        // Diese Methoden sind nun absichtlich einfach gehalten.
        public List<Seedling> GetMouth() { return _mouth; }
        public void SetMouth(List<Seedling> newMouthContent) { _mouth = newMouthContent; }

        public (int x, int y) GetPosition() { return _position; }

        // Diese Methode enthält die komplexe Logik.
        public void SetPosition(int x, int y)
        {
            if (_habitat != null)
            {
                if (x >= 0 && x < _habitat.GetWidth() && y >= 0 && y < _habitat.GetHeight())
                {
                    _position = (x, y);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Die Position liegt außerhalb der Grenzen des Habitats.");
                }
            }
            else
            {
                throw new InvalidOperationException("Dem Hamster wurde kein Habitat zugewiesen.");
            }
        }
    }

    public class Plane
    {
        private int _width;
        private int _height;
        public Plane(int width, int height) { _width = width; _height = height; }
        public int GetWidth() { return _width; }
        public int GetHeight() { return _height; }
    }

    public class Seedling; // Einfache Klasse wie zuvor

    public class Programm
    {
        public static void run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Plane largeHabitat = new Plane(100, 50);
            Hamster speedy = new Hamster(largeHabitat, "Speedy");

            speedy.SetPosition(10, 20);
            Console.WriteLine($"Hamster '{speedy.GetNickname()}' {speedy.GetRepresentation()} befindet sich bei {speedy.GetPosition()}.");

            try
            {
                Console.WriteLine("Versuche, den Hamster außerhalb der Grenzen zu platzieren...");
                speedy.SetPosition(200, 30); // Dies wird eine Exception auslösen
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"FEHLER ABGEFANGEN: {e.Message}");
            }
        }
    }
}


namespace NewCSharpStyleHamster
{
    public class Hamster
    {
        // TODO: implemente me.
    }

    public class Plane
    {
       // TODO: implemente me.

        public Plane(int width, int height)
        {
            // TODO: implemente me.
        }
    }
    public class Seedling
    {
        public Seedling(Seedling seedling) { }

        public Seedling() { }
    }

    public class Programm
    {
        public static void run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Plane plane = new Plane();

            // TODO: implement me.
            throw new NotImplementedException("\u001B[31mLösche diese Zeile und füge deinen eigenen Cod ein!.\u001b[0m");
        }
    }
}


public class Comparisson
{
    static void Main(string[] args)
    {
        java.Programm.run();

        Console.WriteLine("⚠️~~~~~ darüber und darunter soll beides gleich aussehn ~~~~~⚠️");

        csharp.Programm.run();
    }
}
```

Erwarteter Output:
```
Hamster 'Speedy' 🐹 befindet sich bei (10, 20).
Versuche, den Hamster außerhalb der Grenzen zu platzieren...
FEHLER ABGEFANGEN: Specified argument was out of the range of valid values. (Parameter 'Die Position liegt außerhalb der Grenzen des Habitats.')
⚠️~~~~~ darüber und darunter soll beides gleich aussehn ~~~~~⚠️
Hamster 'Speedy' 🐹 befindet sich bei (10, 20).
Versuche, den Hamster außerhalb der Grenzen zu platzieren...
FEHLER ABGEFANGEN: Specified argument was out of the range of valid values. (Parameter 'Die Position liegt außerhalb der Grenzen des Habitats.')
```

---

### Theorie [10 / 55 Teilpunkte]
1) Wann ist ein ``Konstruktor`` mit ``Parametern`` einem *parameterlosen* ``Konstruktor`` in *Kombination* mit einem ``Object-Initializer`` vorzuziehen? *Hinweis: Wer garantiert die Zuweisung einer ``Property`` (Eigenschaft)?*
2) Welche ``Methoden`` bekommt eine ``Variable`` wenn wir den ``Nullable Operator`` *?* bei dem ``Wertdatentyp`` z.B. des ``Typs`` *int* verwenden? 
3) Kann der ``Nullable Operator`` *?* bei einem ``Referenzdatentyp`` verwendet werden? Wenn **ja**, gib ein Beispiel an und was wir damit ereichen. Wenn **nein**, warum ist das nicht möglich bzw. nicht sinnvoll?

---

## Aufgabe 2: Interfaces, abstract Classes und S.O.L.I.D [45 Punkte]
### Programmverständnis [10 / 45 Teilpunkte]
Gehe auf folgende Fragen zu dem im Klassendiagramm angegebenen Inhalten. Es sind hier zwei Klassendiagramme gegeben, eines stellt eine **sauberere** bezogen auf ``S.O.L.I.D`` dar, die andere eine **schlechtere** Lösung.
* Begründe wieso ein ``Hamster`` im **oberen** Klassendiagramm bezogen auf ``The Dependency Inversion Principle``, welches das *D* in ``S.O.L.I.D`` ist, besser abgebildet ist.
* Begründe wieso ein ``Plane`` im **oberen** Klassendiagramm bezogen auf ``The Dependency Inversion Principle``, welches das *D* in ``S.O.L.I.D`` ist, besser abgebildet ist.

**Hinweis!** 
* Falls das Bild zu klein ist können Sie mit Rechtsklick dieses in einem Neuen Fenster öffnen.
* Falls die Linien schwer zu erkennen sind und sie keinen darkmode verwenden, probiere jene für den brightmode ohne transparenz [hier](LargeClassDiagram-bright-transparent.png) und [hier](SmallClassDiagram-bright-transparent.png), sowie ohne transparenz jedoch für den darkmode [hier](LargeClassDiagram.png) und [hier](SmallClassDiagram.png). 

---

![alt](LargeClassDiagram-transparent.png)

---

![alt](SmallClassDiagram-transparent.png)

---

### Programmieren [35 / 45 Teilpunkte]
Verwende folgenden Code welcher [hier](VorlageAufgabe2.zip) zu finden ist. Das vorhandene Zip-file ist ein Projekt welches in z.B. VisualStudio aufgemacht werden kann. **Erweitere** diesen code mit einem neuer ``Hamster`` **, welcher ein ``HoehenAngstHamster`` ist.
* anderes ``INutritionBehaviour`` mit Namen ``HoehenAngstNutritionBehaviour``:
    * Diese werden mit einer chance von *10%* pro Spielzug *hungrig*.
    * Wenn dieser **einmal** die *oberste* Zeile der ``Plane`` berührt hat, dann wird dieser alle ``Seedlings`` aus seinem *Mund* leeren und nie wieder essen oder samen sammeln.
    **Hinweis:** Verwende eine ``Property`` des *hamster* ``Objekts`` mit Namen *TouchedTopWallOnce*.
* andere ``IRandomMovementStrategy`` mit Namen ``HoehenAngstMovementStrategy``: 
    * Anwendung der ``DoubleStepMovementStrategy`` solange bis...
    * ... dieser **einmal** die *oberste* Zeile der ``Plane`` berührt hat, dann wird dieser nur mehr nach unten gehen.
    
    **Hinweis:** überschreibe dazu die ``Methode`` *Move* von *Hamster* und frage dort ab welche *Strategy* zu verwenden ist. Verwende dazu eine ``Property`` des *hamster* ``Objekts`` mit Namen *TouchedTopWallOnce*. Diese wird in der ``Plane`` auf *true* gesetzt. Füge dazu in der ``Methode`` *Position* bei ``case Direction.UP:`` im ``Else-Zweig`` des dort stehenden ``If-Zweigs`` folgenden Code ein: 
        ```
        if (hamster is HoehenAngstHamster hoehenAngstHamster)
        {
            hoehenAngstHamster.TouchedTopWallOnce = true;
        }
        ```
* andere ``IVisuals``:
    * Diese soll für die ``HtmlRepresentation`` ein beliebiges *Bild* ihrer Wahl sein für die ``hungry`` und ``fed`` ``Representation``.
    * Diese soll für die ``UnicoeRepresentation`` ein beliebiges *Emoji* ihrer Wahl sein für die ``hungry`` und ``fed`` ``Representation``.

**Hinweis:** 
* Orientieren Sie sich an den bereits geschreibenen Code! Z.B. ist in ``FedBigLegHamsterVisuals`` der Code den Sie benötigen gegeben. Dieser kann kopiert und in einer **neuen** ``Klasse`` implementiert werden. Danach wird dieser leicht angepasst. Z.B. der ``Emoji`` wird ausgetauscht.

Erwarteter Output:
```
🟫🟫🟫🐹🟫🟫🟫🟫🟫🟫
🌱🌱🟫🌱🟫🟫🟫🟫🟫🟫
🌱🟫🟫🟫🟫🟫🌱🟫🟫🟫
🟫🟫🌱🟫🟫🌱🟫🟫🟫🟫
🌱🌱🌱👿🟫🟫🟫🌱🌱🟫
🟫🟫🌱🌱🟫🟫🟫🌱🟫🌱
🟫🌱🟫🟫🌱🟫🟫🟫🟫🟫
🌱🌱🟫🟫🟫🌱🟫🌱🌱🟫
🟫🟫🟫🟫🌱🟫🟫🟫🟫🟫
🟫🟫🤮🟫🟫🌱🟫🟫🌱🤮
```