## Variablen und Werte in Java

### Was wollen wir in einem Programm tun?
Ein Computerprogramm ist für uns ist die **laufende** manipulation von ``Werten`` um ein Ergebnis zu erzeugen. In den meisten Computersprachen müssen wir diesen ``Werten`` immer einen ``Typ`` geben. Wir tun dies mit einer speziellen Kennzeichnung dieser ``Werte``. Diese Kennzeichnung schaut für die folgende ``Typen`` folgendermaßen aus:

| Typ | Kennzeichnung | Beispiel |
|--------------|-----------|-----------|
| `String` | ein Text zwischen zwei doppelten Anfürhungsziechen "" | `"🔷 Hellø World, aber es kann auch viel mehr dort stehen wie ﬗ und 🌱"` |
| `Integer` | eine Zahl ohne Punkt (Ganze Zahl) | `-5` und `568` |
| `Double` | eine Zahl mit Punkt (Kommazahlen) |`-9.6584` und `7.` was abgekürzt `7.0` ist. |
| `Boolean` | das wort ``true`` und ``false`` klein geschrieben |  |

Um dies nun in JAVA zu übersetzten übergeben wir im folgenden Code der Konsole ``Werte`` von verschiedenen ``Typen``. 

```java
System.out.println("ich bin ein Wert vom Typ String.");
System.out.println(3658);       // ich bin ein Wert vom Typ Integer.
System.out.println(3658.968);   // ich bin ein Wert vom Typ Double.
System.out.println(true);       // ich bin ein Wert vom Typ Boolean.
```
**Anmerkung**: Streng genommen sind die ``Typen`` der ``Werte``: ``String``, ``int``, ``double``, und ``boolean``. Was der Unterschied zwischen groß und klein geschriebenen Typen ist, werden wir hier behandeln. #TODO

### Kurzsprechweise von Werten
Da es umständlich ist immer von ``Werten`` eines ``Typs`` zu sprechen, werden wir z.B. anstatt ``"Hallo" ist ein Wert vom Typ String``, ``"Hallo" ist ein String`` sagen. Gleiches gilt für andere ``Typen``.

### Warum müssen wir Werte des Typ Strings zwischen "" schreiben?
Wir kennzeichnen ``Strings`` (oder auch ``Zeichenketten`` genannt) , mit ``""``, damit der ``Compiler`` es von Symbolen der Programmiersprache, wie `System.out.println` unterscheiden kann. Da unsere Sprache textbasiert ist, haben wir leider eine doppelte Verwendung von Text. Durch eine Kennzeichnung wie eben ``""`` ist diese Unterscheidung möglich.

### Was erlauben uns Variablen zu tun?
``Variablen`` erlauben uns ``Werte`` später im Programm wiederzuverwenden, indem wir diese durch einen ``Namen`` ansprechbar machen. Eine ``Variable`` wird also zu einem Platzhalter für verschiedene ``Werte`` eines bestimmten ``Typs``. Da JAVA eine ``statisch typisierte`` Programmiersprache ist müssen wir bei jeder ``Variable`` **immer** den ``Typ`` dazuschreiben (mehr zu diesem Thema siehe hier #TODO). 

Wir haben bereits 2 verschiedene Arten kennen gelernt wie wir eine ``Variable`` anlegen könnnen. Eine ist die ``Variable`` zu ``definieren`` die andere ist eine `Variable` zu `definieren und initialisieren`.

#### Deklaration, Definition und Initialisierung
Die Unterscheidung der Wörter ``Deklaration`` und ``Definition`` macht nur begrenzt Sinn, da JAVA nicht zwische diesen Konzepten unterscheidet. Deshalb werden wir dieses immer als ``Definition`` benennen. Sie werden jedoch beide Begriffe online oder in Büchern sehen, welche jedoch meist Synonyme (gleich) für JAVA sind. Für Sprachen wie C/C++ ist jedoch eine solche Unterscheidung sinnvoll.

Bei der ``Definition`` verzichten wir auf eine **sofortige** Zuweisung einer ``Variable`` mit einem ``Wert``. Zudem verschieben wir diese Zuweisung auf einen späteren Zeitpunkt im Programm. Diese Zuweisung wird auch ``Initialisierung`` genannt. Variablen welche **nur** ``definiert`` werden und nie ``initialisiert`` werden können nicht verwendet werden. 

```java
Integer definiert;                           // definiert
String definiertUndInitialisiert = "Hallo";  // definiert + initialisiert
...
...
...
definiert = 5      // die zuerst definierte variable wird nun initialisiert.
```

Anmerkung: Für die ``Definition`` wird im ``Speicher`` ein Platz reserviert welcher für unsere ``Variable`` gedacht ist, jedoch ohne Wert. Eine physische Analogie wäre: *wir kaufen eine Leinwand, aber haben uns noch nicht entschieden, was wir malen wollen*. Für die ``Definition`` und ``Initialisierung`` wäre es *Wir kaufen eine Leinwand, und malen schon im Geschäft unser Bild*.

### Was kann ich einer Varaible zuweisen?
Wir können mit dem Muster `<Typ> <Name> <Zuweisungsoperator> <Wert>` eine Variable `definieren` und `initialisieren`. Das Muster ist jedoch allgemeiner als hier dargestellt.
Eigentlich müsste es `<Typ> <Name> <Zuweisungsoperator> <"alles was einen Wert mit gleichem Typ wie <Typ> erzeugt kann hier stehen">` heißen. 

Der ``Zuweisungsoperator`` ist mit dem Symbol ``=`` abgebildet. Wir können uns auch einen Pfeil nach links denken ``<-``, wenn wir das ``=`` bei einer Zuweisung sehen. Wir nehmen also den Ausdruck welcher rechts vom ``Zuweisungsoperator`` steht und "schreiben" es in die Variable welche links steht.

```java
String myString = "das ist ein String";               // Der Wert rechts vom = hat den Typ String.
String otherString = myString;                        // Die Variable rechts vom = hat den Typ String.
String userInput = new Scanner(System.in).nextLine(); // Der Ausdruck rechts vom = erzeugt einen Wert vom Typ String
String formatiert = String.format("Wert: %d", 42);    // Der Ausdruck rechts vom = erzeugt einen Wert vom Typ String
String ersteZeileDerWebsite = new BufferedReader(new InputStreamReader(new URL("https://www.example.com").openStream())).readLine(); // Der Ausdruck rechts vom = erzeugt einen Wert vom Typ String
```

### Verschiedene Arten von Typen
- Zeichen(ketten):
  - String (oder für mehr funktionalität, StringBuilder)
  - char oder Character (16 Bits - ein Symbol einer Zeichenkette kann nur gespeichert werden. Diese ist im Hintergrund eine ganze Zahl)
- Ganze Zahlen:
  - long oder Long     (ganze Zahl -> [-2^32, +2^32],  keine Kommazahlen)
  - int oder Integer   (ganze Zahl -> [-2^16, +2^16],  keine Kommazahlen)
  - short oder Short   (ganze Zahl -> [-2^8,   +2^8],  keine Kommazahlen)
  - byte oder Byte     (ganze Zahl -> [-2^4,   +2^4],  keine Kommazahlen)
- Kommazahlen:
  - float oder Float   (Kommazahl, weniger genau wie Double)
  - Double oder Double (Kommazahl)
- logische Werte:
  - boolean oder Boolean (hat ``false`` oder ``true`` als Wert)

### Klassen sind Typen, aber primitive Typen sind auch Typen
Wenn wir den `<Typ>`...
- klein schrieben → primitive Datentypen (keine ``Klassen``),
- groß schrieben → (sind ``Klassen``).

``Klassen`` sind die "Grundbausteine" in JAVA und jeder objektorientierten Sprache und erlauben uns
aus ``Klassen``, was ein `Typ` ist, ``Objekte``, was eine `Variable` ist, zu erzeugen. ``Objekte`` und ``Klassen`` können zusätzlich ``Metoden`` aufrufen. Diese ``Methoden`` stellen wir uns vor als "Befehle" vor die wir ausführen und (meistens) einen ``Wert`` zurückgeben.
``Primitive Typen`` besitzten keine solche ``Methoden``, sind jedoch schlänker und brauchen weniger Speicher (siehe hier für mehr infos).

Ein Beispiel dazu ist:
```java
Scanner meinScanner = new Scanner(System.in); // Der Ausdruck rechts vom = erzeugt eine Variable vom Typ "Scanner" 
Integer userInput = meinScanner.nextInt(); // und erzeugt mit der Methode "nextLine()" einen Wert vom Typ int, diese speichern wir in einer Variable vom Typ Integer.
userInput.toString();

int userInputPrimitiv = meinScanner.nextInt(); // und erzeugt mit der Methode "nextLine()" einen Wert vom Typ int, diese speichern wir in einer Variable vom Typ int.
userInputPrimitiv.toString(); // geht nicht, da Typ int und primitiv ist.
```

JAVA erlaubt und unabhängig, ob eine Variable primitive ist oder nicht, diese mit dem Zuweisungsoperator "=" gleich zusetzten.
An sich ist JAVA hier streng. wir können nicht eine Variable vom ``Typ`` ``String`` und eine vom Typ ``StringBuilder`` gleich setzten,
das diese nicht den exakt gleichen ``Typ`` haben. Wir sehen das am vorherigen Beispiel aber auch einfacher am nächsten.
Zudem sehen wir hier auch folgendes. Wenn eine Variable einmal definiert bzw. deklariert wird, dann muss diese nur mehr mit dem `<Namen>` angesprochen werden.

```java
userInputPrimitiv = userInput;
userInput = userInputPrimitiv;
```

Falls wir doch den Typ nochmals zu einer bereits ``definierten`` Variable dazuschreiben, bekommen wir einen Fehler vom Compiler.

```java
int myPrimitiveInteger = myInteger; // würde hier nicht funktionieren, da myPrimitiveInteger bereits definiert wurde.
```

Wir werden zuerst einfachheitshalber nur die "Klassen" als Typen verwenden. Also keine primitiven Datentypen.
Der Vorteil von Variablen, welche einen primitiven Typ haben ist, sie sind schlanker und verbrauchen "weniger" Speicher.

Anmerkung: Auch ``kann möglicherweise`` der Ort an dem sie sich befinden (Stack) schneller für den Computer verwendbar sein, als der Ort wo mit ``sicherheit`` Objekte liegen (Heap). Der Nachteil: primitive Datentypen erlauben weniger "Funktionalität".

Das sehen wir hier, wenn wir eine Zahl in einen String umwandeln wollen.
Variablen, welche eine Klasse als Typ haben, besitzen Methoden, primitive Datentypen nicht.

```java
String yetAnotherString = myInteger.toString();
System.out.println(yetAnotherString);
```

#TODO here

Wichtig: Das Ergebnis der Methode ist ein Wert, welcher wie bei Operatoren einen Typ hat.
Hier kommt also eine Zahl in die Methode rein und ein String raus.

Dieses Ergebnis kann wie jeder andere String verwendet werden.
Deshalb ist auch eine Zuweisung zu einer Variable mit dem Zuweisungsoperator `=` möglich!

Wir können nun `yetAnotherString` weiter verwenden, z.B. ausgeben oder weiter manipulieren:

```java
System.out.println(yetAnotherString.toUpperCase());
```

Wir sehen auch, dass wir das Ergebnis der Methode `toUpperCase()` direkt verwenden können und dieses nicht
in einer Variable speichern müssen. Falls wir später im Programm das Ergebnis erneut benötigen, wäre es jedoch verloren.
Daher empfiehlt es sich, es in einer Variable zu speichern, insbesondere wenn die Berechnung aufwendig ist.

Falls eine Methode z. B. 3 Stunden benötigt, um ein Ergebnis zu erzeugen, sollte dieses Ergebnis auf jeden Fall
in einer Variable gespeichert werden.

```java
String upperString = yetAnotherString.toUpperCase();
System.out.println(upperString);
```

Gehen wir nun die verschiedenen Variablentypen durch. Beginnen wir mit Zeichenketten und einzelnen Zeichen.


TODO: hier fehlen texte.....

## Variablen in Java

An sich ist JAVA hier streng. Wir können nicht eine Variable vom Typ String und eine vom Typ StringBuilder gleich setzen,
da diese nicht den exakt gleichen Typ haben.

Zudem sehen wir hier auch folgendes:
Wenn eine Variable einmal definiert bzw. deklariert wird, dann muss diese nur mehr mit dem `<Namen>` angesprochen werden.

```java
int myPrimitiveInteger = myInteger; // würde hier nicht funktionieren, da myPrimitiveInteger bereits definiert wurde.
```

Wir werden zuerst einfachheitshalber nur die "Klassen" als Typen verwenden. Also keine primitiven Datentypen.
Der Vorteil von Variablen, welche einen primitiven Typ haben ist, sie sind schlanker und verbrauchen "weniger" Speicher.
Auch ist der Ort an dem sie sich befinden (Stack) schneller für den Computer verwendbar, als der Ort wo Objekte liegen (Heap).
Der Nachteil: primitive Datentypen erlauben weniger "Funktionalität".

Das sehen wir hier, wenn wir eine Zahl in einen String umwandeln wollen.
Wir werden umwandlungen von Variablen in einem eigenen JAVA file behandeln.

&#x20;       // Wichtig für uns jetzt ist, Variablen, welche eine Klasse als Typ haben, haben Methoden

&#x20;       // und Variablen welche einen primitiven Datentyp haben, nicht.

&#x20;       // Methoden sind wie block1.Operatoren, welche Werte/Variablen entgegennehmen, diese umwandeln, und einen neuen Wert zurückgeben.

&#x20;       // Das sehen wir hier, wenn wir aus unserem Integer myInteger mit der Methode toString() eine Zahl nehmen und diese in einen String umwandeln.

&#x20;       // Methoden werden von Variablen (auch Objekten genannt, wenn der Typ eine Klasse ist) mit dem "." Operator aufgerufen.

```java
String yetAnotherString = myInteger.toString();
System.out.println(yetAnotherString);
```

Wichtig: Das Ergebnis der Methode ist ein Wert, welcher wie bei Operatoren einen Typ hat.
Hier kommt also eine Zahl in die Methode rein und ein String raus.

Dieses Ergebnis kann wie jeder andere String verwendet werden.
Deshalb ist auch eine Zuweisung zu einer Variable mit dem Zuweisungsoperator `=` möglich!

Wir können nun `yetAnotherString` weiter verwenden, z.B. ausgeben oder weiter manipulieren:

```java
System.out.println(yetAnotherString.toUpperCase());
```

Wir sehen auch, dass wir das Ergebnis der Methode `toUpperCase()` direkt verwenden können und dieses nicht
in einer Variable speichern müssen. Falls wir später im Programm das Ergebnis erneut benötigen, wäre es jedoch verloren.
Daher empfiehlt es sich, es in einer Variable zu speichern, insbesondere wenn die Berechnung aufwendig ist.

Falls eine Methode z. B. 3 Stunden benötigt, um ein Ergebnis zu erzeugen, sollte dieses Ergebnis auf jeden Fall
in einer Variable gespeichert werden.

```java
String upperString = yetAnotherString.toUpperCase();
System.out.println(upperString);
```

Gehen wir nun die verschiedenen Variablentypen durch. Beginnen wir mit Zeichenketten und einzelnen Zeichen.

### Zeichenketten (`String`) und einzelne Zeichen (`char`)

#### `Character` Datentyp

```java
Character userInputDecimalNumber = 97;  // ASCII-Code für 'a'
Character userInputHexNumber = 0x018E;  // Unicode-Zeichen
Character userInputChar = 'a';
```

```java
System.out.println("'" + userInputChar + "' ist das gleiche wie '" + userInputDecimalNumber + "'");
```

Da der Computer meist nur mit Zahlen umgehen kann, gibt es ein "Mapping" von Zahlen zu Symbolen.
Ein Beispiel: Der Wert `97` entspricht dem Symbol `'a'`. Diese Codes heißen ASCII- oder Unicode-Codes.

Beispiel für Unicode-Zeichen:

```java
Character million = '҉';
System.out.println(million);
```

**Smileys und Unicode-Zeichen:**

```java
String tannenbaum = "🌲";
System.out.println(tannenbaum);
```

Wir können auch Zeichen anhand ihrer ASCII- oder Unicode-Werte manipulieren:

```java
Character aPlusB = 97 + 98;
System.out.println(aPlusB);
```


