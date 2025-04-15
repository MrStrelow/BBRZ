# Variablen und Werte in Java

#### Welche Begriffe werden hier verwendet?
[``Programm``](../../../glossar.md#programm), [``Wert``](../../../glossar.md#wert), [``Konsole``](../../../glossar.md#Variable), [``Variable``](../../../glossar.md#variable), [``Typ``](../../../glossar.md#typ), [``String``](../../../glossar.md#string), [``StringBuilder``](../../../glossar.md#stringbuilder), [``Integer``](../../../glossar.md#integer), [``Double``](../../../glossar.md#double), [``Fließkommazahl``](../../../glossar.md#fließkommazahl), [``Boolean``](../../../glossar.md#boolean), [``deklarieren``](../../../glossar.md#deklarieren), [``initialisieren``](../../../glossar.md#initialisieren), [``definieren``](../../../glossar.md#definieren), [``Zuweisungsoperator``](../../../glossar.md#zuweisungsoperator), [``Compiler``](../../../glossar.md#compiler), [``statisch typisierte Programmiersprache``](../../../glossar.md#statisch-typisierte-programmiersprache), [``stark typisierte Programmiersprache``](../../../glossar.md#stark-typisierte-programmiersprache), [``objektorientierte Programmiersprache``](../../../glossar.md#objektorientierte-programmiersprache), [``Klasse``](../../../glossar.md#klasse), [``Objekt``](../../../glossar.md#objekt), [``Methode``](../../../glossar.md#methode), [``primitive Datentypen``](../../../glossar.md#primitive-datentypen), [``explizite Typumwandlung``](../../../glossar.md#explizite-typumwandlung), [``Anweisung``](../../../glossar.md#anweisung), [``Ausdruck``](../../../glossar.md#ausdruck)

---

## Was wollen wir in einem Programm tun?
Ein ``Programm`` ist für uns ist die Manipulation von ``Werten`` um ein Ergebnis zu erzeugen. In den meisten Computersprachen müssen wir diesen ``Werten`` immer einen ``Typ`` geben. Wir tun dies mit einer speziellen Kennzeichnung dieser ``Werte``. Diese Kennzeichnung schaut für die folgende ``Typen`` folgendermaßen aus:

| Typ | Kennzeichnung | Beispiel |
|--------------|-----------|-----------|
| `String` | ein Text zwischen zwei doppelten Anfürhungsziechen "" | `"🔷 Hellø World, aber es kann auch viel mehr dort stehen wie ﬗ und 🌱"` |
| `Integer` | eine Zahl ohne Punkt (Ganze Zahl) | `-5` und `568` |
| `Double` | eine Zahl mit Punkt (Kommazahlen) |`-9.6584` und `7.` was abgekürzt `7.0` ist. |
| `Boolean` | das wort ``true`` und ``false`` klein geschrieben |  |

Wir übergeben nun im folgenden Code der ``Konsole`` ``Werte`` von verschiedenen ``Typen``. Bedeutet wir geben diese auf der ``Konsole`` aus.

```java
System.out.println("ich bin ein Wert vom Typ String.");
System.out.println(3658);       // ich bin ein Wert vom Typ Integer.
System.out.println(3658.968);   // ich bin ein Wert vom Typ Double.
System.out.println(true);       // ich bin ein Wert vom Typ Boolean.
```
**Anmerkung**: Streng genommen sind die ``Typen`` der ``Werte``: ``String``, ``int``, ``double``, und ``boolean``. Was der Unterschied zwischen groß und klein geschriebenen Typen ist, ist vorerst nicht relevant.

Wir merken uns:
> Ein ``Computerprogramm`` ist für uns ist die Manipulation von ``Werten`` um ein Ergebnis zu erzeugen.

## Kurzsprechweise von Werten
Da es umständlich ist immer von ``Werten`` eines ``Typs`` zu sprechen, werden wir z.B. anstatt ``"Hallo" ist ein Wert vom Typ String``, ``"Hallo" ist ein String`` sagen. Gleiches gilt für andere ``Typen``.

## Warum müssen wir Werte des Typ Strings zwischen "" schreiben?
Wir kennzeichnen ``Strings`` (oder auch ``Zeichenketten`` genannt) , mit ``""``, damit der ``Compiler`` es von Symbolen der Programmiersprache, wie *System.out.println* unterscheiden kann. Da unsere Sprache textbasiert ist, haben wir leider eine doppelte Verwendung von Text. Durch eine Kennzeichnung wie eben ``""`` ist diese Unterscheidung möglich.

## Was erlauben uns Variablen zu tun?
``Variablen`` erlauben uns ``Werte`` später im Programm wiederzuverwenden, indem wir diese durch einen ``Namen`` ansprechbar machen. Eine ``Variable`` wird also zu einem Platzhalter für verschiedene ``Werte`` eines bestimmten ``Typs``. Da Java eine ``statisch typisierte Programmiersprache`` ist müssen wir bei **jeder** ``Definition`` einer ``Variable`` den ``Typ`` dazuschreiben.

Wir haben bereits 2 verschiedene Arten kennen gelernt wie wir eine ``Variable`` anlegen könnnen. Eine ist die ``Variable`` zu ``definieren`` die andere ist eine ``Variable`` zu `definieren` und zu ``initialisieren``.

### Deklaration, Definition und Initialisierung
Wir haben dieses Konzept schon in der vorherigen Lektion kennengelernt. Wir wiederholen es nur begrenzt hier und einigen uns, dass die Unterscheidung der Wörter ``Deklaration`` und ``Definition`` nur begrenzt Sinn macht. Grund ist Java unterscheidet nicht zwische diesen Konzepten für uns als Programmiere. Deshalb werden wir dieses immer als ``Definition`` benennen. Sie werden jedoch beide Begriffe online oder in Büchern sehen, welche jedoch meist Synonyme (gleich) für Java sind. Für Sprachen wie C/C++ ist jedoch eine solche Unterscheidung sinnvoll.

Bei der ``Definition`` verzichten wir auf eine **sofortige** Zuweisung einer ``Variable`` mit einem ``Wert``. Zudem verschieben wir diese Zuweisung auf einen späteren Zeitpunkt im Programm. Diese Zuweisung wird auch ``Initialisierung`` genannt. Variablen welche **nur** ``definiert`` werden und nie ``initialisiert`` werden können nicht verwendet werden. 

```java
Integer definiert;                           // definiert
String definiertUndInitialisiert = "Hallo";  // definiert + initialisiert
...
...
...
definiert = 5      // die zuerst definierte variable wird nun initialisiert.
```

Anmerkung: Für die ``Definition`` wird im *Speicher* ein Platz reserviert welcher für unsere ``Variable`` gedacht ist, jedoch ohne Wert. Eine physische Analogie wäre: *wir kaufen eine Leinwand, aber haben uns noch nicht entschieden, was wir malen wollen*. Für die ``Definition`` und ``Initialisierung`` wäre es *Wir kaufen eine Leinwand, und malen schon im Geschäft unser Bild*.

## Was kann ich einer Varaible zuweisen?
Wir können mit dem Muster *<Typ> <Name>* eine Variable ``definieren`` bzw. mit *<Typ> <Name> <Zuweisungsoperator> <Wert>* ``initialisieren``. Das Muster ist jedoch allgemeiner als hier dargestellt.
Eigentlich müsste es *<Typ> <Name> <Zuweisungsoperator> <"Ausdrücke welche einen Wert mit gleichem Typ wie <Typ> erzeugt">* heißen. 

Der ``Zuweisungsoperator`` ist mit dem Symbol *=* abgebildet. Wir können uns auch einen Pfeil nach links denken **<-**, wenn wir das *=* bei einer Zuweisung sehen. Wir nehmen also den ``Ausdruck`` welcher *rechts* vom ``Zuweisungsoperator`` steht und "schreiben" den erzeugten ``Wert`` in die ``Variable`` welche links steht.

```java
String myString = "das ist ein String";               // Der Wert rechts vom = hat den Typ String.
String otherString = myString;                        // Die Variable rechts vom = hat den Typ String.
String userInput = new Scanner(System.in).nextLine(); // Der Ausdruck rechts vom = erzeugt einen Wert vom Typ String
String formatiert = String.format("Wert: %d", 42);    // Der Ausdruck rechts vom = erzeugt einen Wert vom Typ String
String ersteZeileDerWebsite = new BufferedReader(new InputStreamReader(new URL("https://www.example.com").openStream())).readLine(); // Der Ausdruck rechts vom = erzeugt einen Wert vom Typ String
```

Die *komplette Zeile* welche mit *;* abschließen wird nennen wir eine ``Anweisung``.

Wir merken uns:
> Der ``Typ`` des ``Wertes``, der ``Variable`` oder allgmein des ``Ausdrucks welcher einen Wert erzeugt`` rechts des ``Zuweisungsoperators`` *=*, muss mit dem ``Typ`` der ``Variable`` links zusammenpassen.

> Ein ``Ausdruck`` ist ``Programmcode`` welche einen ``Wert`` erzeugt. 
> Eine *Zeile* eines ``Programmcodes`` welche mit einem ``;`` abgeschlossen wird ist eine ``Anweisung``. Diese erzeugt *keinen* ``Wert``.

## Verschiedene Arten von Typen
- **Zeichen(ketten)**:
  - ``String`` (oder *StringBuilder*)
  - ``char`` oder ``Character`` (16 Bits - ein Symbol einer Zeichenkette kann nur gespeichert werden. Diese ist im Hintergrund eine ganze Zahl)
- **Ganze Zahlen**:
  - ``long`` oder ``Long``     (ganze Zahl -> [-2^32, +2^32],  keine Kommazahlen)
  - ``int`` oder ``Integer``   (ganze Zahl -> [-2^16, +2^16],  keine Kommazahlen)
  - ``short`` oder ``Short``   (ganze Zahl -> [-2^8,   +2^8],  keine Kommazahlen)
  - ``byte`` oder ``Byte``     (ganze Zahl -> [-2^4,   +2^4],  keine Kommazahlen)
- `**Kommazahlen**`:
  - ``float`` oder ``Float``   (Kommazahl, weniger genau wie Double)
  - ``Double`` oder ``Double`` (Kommazahl)
- **logische Werte**:
  - ``boolean`` oder ``Boolean`` (hat ``false`` oder ``true`` als Wert)

**Anmerkung:** Wenn wir *nicht* die primitiven Typen verwenden sind immer alle Typen *groß* geschrieben. Wir können also gut unterscheiden zwischen klein geschriebenen ``Variablen`` und groß geschriebenen ``Typen``. Auch wenn wir den genauen Kontext nicht kennen, sollte es uns möglich sein ``Scanner`` als ``Typ`` zu identifizieren und ``scanner`` als variable.

```java
Scanner scanner = new Scanner(System.in); // Scanner ist hier der Typ, scanner ist die Variable und rechts vom = steht ein Ausdruck welcher einen Wert des Types Scanner erzeugt.
```

Wir merken uns:
> ``Typen`` werden groß geschrieben, ``Variablen`` klein und rechts neben dem `Zuweisungsopertator` *=* steht ein ``Ausdruck``. Wir erkennen somit anhand der Schreibweise, um welches Konzept es sich handelt.

## Klassen und primitive Typen sind Typen
Wenn wir den `<Typ>`...
- klein schrieben → ``primitive Datentypen`` (keine ``Klassen``),
- groß schrieben → (sind ``Klassen``).

``Klassen`` sind die "Grundbausteine" in Java und jeder ``objektorientierten Programmiersprache`` und erlauben uns
aus ``Klassen``, was ein `Typ` ist, ``Objekte``, was eine `Variable` ist, zu erzeugen. ``Objekte`` und ``Klassen`` können zusätzlich ``Metoden`` aufrufen. Wir können das durch die Verwendung des ``Aufrufeoperators`` welcher durch einen *Punkt* dargestellt wird. ``Methoden`` stellen wir uns vor als "Befehle" vor die wir ausführen und ``Werte``/``Variablen`` entgegennehmen nehmen. Meistens wird ein ``Wert`` zurückgeben. Wir können diesen ``Wert`` also wieder mit dem ``Zuweisungsoperator`` einer ``Variable`` zuweisen.

``Primitive Typen`` besitzten keine solche ``Methoden``, sind jedoch schlänker und brauchen weniger Speicher.

Ein Beispiel dazu ist:
```java
Scanner meinScanner = new Scanner(System.in); // Der Ausdruck rechts vom = erzeugt eine Variable vom Typ "Scanner" 
Integer userInput = meinScanner.nextInt(); // und erzeugt mit der Methode "nextLine()" einen Wert vom Typ int, diese speichern wir in einer Variable vom Typ Integer.
userInput.toString();

int userInputPrimitiv = meinScanner.nextInt(); // und erzeugt mit der Methode "nextLine()" einen Wert vom Typ int, diese speichern wir in einer Variable vom Typ int.
userInputPrimitiv.toString(); // geht nicht, da Typ int und primitiv ist.
```

Java erlaubt und unabhängig, ob eine Variable primitiv ist oder nicht, diese mit dem Zuweisungsoperator "=" gleich zusetzten.
An sich ist Java hier streng. wir können nicht eine Variable vom ``Typ`` ``String`` und eine vom Typ ``StringBuilder`` gleich setzten,
da diese verschiedene ``Typen`` haben. Wir sehen das am vorherigen Beispiel aber auch einfacher am nächsten.

```java
Integer userInput = 5;
int userInputPrimitiv = userInput;

userInput = userInputPrimitiv;
```

Zudem sehen wir hier auch folgendes. Wenn eine Variable einmal ``definiert`` wird, dann muss diese nur mehr mit dem Namen der ``Variable`` angesprochen werden.
Falls wir den ``Typ`` nochmals zu einer bereits ``definierten`` Variable dazuschreiben, bekommen wir einen Fehler vom ``Compiler``.

```java
int myPrimitiveInteger;
int myPrimitiveInteger = myInteger; // würde hier nicht funktionieren, da myPrimitiveInteger bereits definiert wurde.
```

Wir werden zuerst einfachheitshalber nur die ``Klassen`` als ``Typen`` verwenden. Also keine ``primitiven`` als ``Typen``.
Der Vorteil von Variablen, welche einen ``primitiven Typ`` haben ist, sie sind schlanker und verbrauchen "weniger" Speicher und sind im **allgemeinen die korrekte Wahl**. Wir wünschen uns jedoch eine einheitliche Struktur welche uns die ```Klassen`` liefern. Diese ist, *Groß geschrieben bedeutet ``Typ``*.  

Im folgenden Beispiel sehen wir, wie wir eine Zahl in eine Zeichenkette umwandeln wollen.
``Variablen``, welche eine ``Klasse`` als ``Typ`` haben, besitzen ``Methoden``, ``primitive Datentypen`` nicht.

```java
Integer myInteger = 5; // Integer ist eine Klasse also ist myInteger ein Objekt und besitzt Methoden.

String yetAnotherString = myInteger.toString();
System.out.println(yetAnotherString);
```

vs.

```java
int myPrimitiveInteger = 5; // int ist ein primitiver Typ, deshalb keine Klasse, also ist myInteger kein Objekt und hat keine Methoden.

// String yetAnotherString = myInteger.toString(); // Fehler!
String yetAnotherString = Integer.toString(myInteger);  // Wir verwenden eine Methode welche bei der Klasse Integer "lebt".
System.out.println(yetAnotherString);
```

**Anmerkung:** 
* Der Vorteil ``primitiver Typen``: Auch kann *möglicherweise* der Ort an dem sich ``primitive Variablen`` befinden (Stack, Register, etc.) schneller für den Computer verwendbar sein, als der Ort wo mit *sicherheit* ``Objekte`` liegen (Heap). 
* Der Nachteil: ``primitive Datentypen`` erlauben weniger "Funktionalität", da diese keine ``Methoden`` besitzen.

Wir merken uns:
> ``Methoden`` erlauben uns kompakt "Befehle" auszuführen. Wir können ``Variablen``, ``Werte`` oder allgemein die erzeugten ``Werte`` eines ``Ausdrucks`` diesen ``Methoden`` übergeben und erhalten meist wieder einen ``Wert`` zurück.

> ``Klassen`` sind ``Typen`` welche groß geschrieben werden, ``Objekte`` sind die ``Variablen`` wenn der ``Typ`` eine ``Klasse`` ist.

> ``Methoden`` können bei ``Klassen`` oder ``Objekten`` mit dem ``Aufrufeoperator`` verwendet werden. 

> Der ``Aufrufeoperator`` ist ein *Punkt* welcher nach der ``Klasse`` oder dem ``Objekt`` geschrieben wird.

> ``Primitive Typen`` haben keine ``Methoden``, sind aber *effizienter*.

## Ergebnisse von Methoden
Das Ergebnis der ``Methode`` ist ein ``Wert`` einen Typ hat.

Beim folgenden Beispiel kommt nochmals eine ``Variable`` des ``Typs`` *Integer* in die ``Methode`` rein und ein ``Wert`` mit ``Typ`` *String* raus.

Wir können nun *yetAnotherString* weiter verwenden, z.B. ausgeben oder weiter manipulieren:

```java
Integer myInteger = 5; 
String yetAnotherString = myInteger.toString() + " hallo"; // Probier aus was Wert mit Typ String + " hallo" auf sich hat.
System.out.println(yetAnotherString.toUpperCase()); // manipulieren diesen String mit der Methode toUpperCase().
```

Wir sehen auch, dass wir das Ergebnis der Methode *toUpperCase()* direkt verwenden können und dieses nicht in einer ``Variable`` speichern müssen. Falls wir später im ``Programm`` das Ergebnis erneut benötigen, ist es verloren. Daher empfiehlt es sich, es in einer ``Variable`` zu speichern. Insbesondere wenn die Berechnung, also der Aufruf der ``Methode`` aufwendig ist und viel Zeit in anspruch nimmt. Falls eine ``Methode`` z. B. drei Minuten benötigt um ein Ergebnis zu erzeugen, sollte dieses Ergebnis auf jeden Fall in einer ``Variable`` gespeichert werden.

```java
...
String upperString = yetAnotherString.toUpperCase();
System.out.println(upperString); // 1. Verwendung
System.out.println(upperString); // 2. Verwendung ohne es neu ausrechnen zu müssen
System.out.println(yetAnotherString.toUpperCase()); // wird neu berechnet, kann in anderen Fällen lange dauern.
```

Gehen wir nun die verschiedenen ``Typen`` von ``Variablen`` genauer durch. Beginnen wir mit Zeichenketten und einzelnen Zeichen.

---

## Zeichenketten und einzelne Zeichen

### Ein Zeichen - Character

Betrachten wir einen ``Typ``, welcher nur eine Zuweisung zu einer ``Variable`` von einem Symbol erlaubt – dem Character.

Dieser ``Typ`` ist der "komplizierteste", denn er benötigt ein wenig Vorwissen darüber, wie der Computer Symbole darstellt. Fast immer ist dies jedoch nicht notwendig zu verstehen, wenn wir in Zukunft ``Programme`` schreiben. Trotzdem ist es nicht schlecht, einmal darüber nachgedacht zu haben, denn abstrakte Strukturen zu erkennen und zu verstehen hilft sehr im Alltag eines Programmierers. Besonders wenn wir fehlerhaftes Verhalten programmieren und den Fehler suchen müssen. Dieser Abschnitt ist mehr als eine Denkaufgabe, als ein praktisches, direkt täglich anwendbares Werkzeug zu verstehen.

Wir reden von Symbolen wie 'a', 'ø' oder '҈'. Warum beginnen wir also mit einer Variable `userInput`, welche zwar vom Typ `Character` ist, aber den Wert einer Zahl zugewiesen bekommt?

```java
Character userInputDecimalNumber = 97; //ASCII-CODE - 10er basis - dec
Character userInputHexNumber = 0x0061; //UNI-CODE - 16er basis - hex
Character userInputHexUnicodeNumber = '\u0061'; //UNI-CODE - hex
Character userInputChar = 'a';

System.out.println("'" + userInputChar + "' ist das gleiche wie '" + userInputDecimalNumber + "' und auch das gleiche wie '" + userInputHexNumber + "' oder '" + userInputHexUnicodeNumber + "'");
```

Da der Computer meist nur mit Zahlen umgehen kann, gibt es ein "Mapping" von Zahlen zu Symbolen. Ein Beispiel: Der Wert 97 ist dem Symbol 'A' zugewiesen. Diese Codes haben Namen wie z. B. ASCII-Codes oder Unicode.

In Windows gibt es eine Zeichentabelle (bei englischen Betriebssystemen "Character Map"), welche es erlaubt, diese Codes bzw. Tastenkürzel einzusehen. Dazu die Windows-Taste drücken und nach "Zeichentabelle" oder "Character Map" suchen.

### ASCII/ANSI-Codes:
- Besteht aus 0 bis 255 Zeichen (mit 8 Bit darstellbar) → diese sind mit *Alt + <vierstelliger Code>* ansprechbar. Wir können dies tun in dem wir die *Alt* Taste und den vierstelligen Code am **Touchpad** drücken. 
- ø ist z. B. *Alt + 0248*. Der Bereich geht von *0032* bis *0255* und deckt große und kleine *Buchstaben*, sowie *Zahlen* und *Sonderzeichen* ab. 
- Die ersten 32 Zahlen sind Symbole, welche keine grafische Darstellung haben. Diese Zeichen werden *Steuerzeichen* genannt und signalisieren z. B. das Ende eines Strings in C/C++.
  - `Alt + 0000` → (NUL): Null-Symbol
  - `Alt + 0001` → (SOH): Start einer Heading
  - `Alt + 0002` → (STX): Start des Streams
  - `Alt + 0003` → (ETX): Ende des Streams (verwendet in manchen Netzwerkprotokollen - z.B. Serial/RS-232)
  ...
  - `Alt + 0010` → (LF): Line Feed. Auch als "\n" bekannt.


### UNI-Codes
Ein Zeichen, welches außerhalb der 256 ASCII-Zeichen liegt, ist folgendes Symbol (Cyrillic Million Symbol):

```java
Character million = '҉'; // aus der Zeichentabelle kopiert
Character million = '\u0489'; // oder direkt mit dem code
```

Dieses hat den Unicode `U+0489`. Achtung! Diese Symbole sind als hexadezimale Zahlen angegeben, also 16 Ziffern statt 10!
Wir stellen das mit 0-9 sowie A-F dar.

Wie zuvor hat auch das Symbol 'a' den hexadezimalen Wert `0x61` und den Unicode `U+0061`. Der ASCII-Code ist also dezimal, der Unicode hexadezimal.

Smileys haben ebenfalls einen Unicode. Zum Beispiel hat 🌲 den Unicode `0x1F332`. Achtung! Hier ist ein fünftes Hex-Bit dazugekommen!
Der Standardsatz von Unicode hat aber nur vier Hex-Bits `U+0000`. Wir können also 🌲 nicht als ``Character`` darstellen.

Für uns funktioniert es vorerst, wenn wir direkt das Symbol einfügen und zwar in einen ``Wert`` des ``Typs`` *String*. Dürcke dazu die Windows-Taste und "Punkt" Taste.

```java
// Character tannenbaum = '🌲'; // Fehler!
String tannenbaum = "🌲"; // Mit String, welches eine Kette von Character ist, geht es aber.
System.out.println(tannenbaum);
```

Wir merken uns:
> ``Werte`` des ``Typs`` *Character* werden mit einem ``'`` am Beginn und einem ``'`` am Ende gekennzeichnet und erlauben nur ein Symbol dazwischen.

> ``Character`` sind ``Integer`` welche wenn angezeigt mit dem entsprechenden Symbol dargestellt werden.

> Der ``Integer`` welcher einen ``Character`` ausmacht, können in verschiedenen ``Zahlensystemen`` angegeben werden.

### Verwendung von Operatoren mit Character-Typen

Wenn wir ``Operatoren`` wie *+* auf Zahlen anwenden, können wir damit auch neue Symbole erzeugen. Das liegt daran, dass das Ergebnis des ``Operators`` eine Zahl ist, die einem Symbol zugeordnet werden kann:

```java
Character aPlusB = 97 + 98; // a // b 
Character AMitToupet = 195; // Ã

System.out.println(aPlusB + " ist das gleiche Symbol wie " + AMitToupet); // Ã
```

Es kann jedoch zu unerwartetem Verhalten kommen, wenn man Zeichen addiert:
Wenn wir jedoch im Kopf haben dass ``Character`` Zahlen sind, sollte es weniger überraschend sein. 

```java
Character abOderEtwasAnders = 'a' + 'b'; // keine concatenation, arithmetische addition
System.out.println("ich bin hier: " + abOderEtwasAnders); // Ã
```

### Typumwandlung (Type Casting)
Wird eine Berechnung mit ``Variablen`` des Typs *Integer* durchgeführt, funktioniert eine direkte Zuweisung zu `Character` nicht mehr. In diesem Fall muss eine ``explizite Typumwandlung`` vorgenommen werden. Wir schreiben vor dem ``Zuweisungsoperator`` eine runde Klammer in der der neue ``Typ`` stehen soll (z.B. *(char) a*). Zudem ist auf die Klammerung zu Achten! ``(char) (a + b)`` bedeutet zuerst ``a + b`` und dann umwandeln in einen ``char``.

**Anmerkung:** Es kann nur in ``primitiven Typen`` umgewandelt werden. Das sind die klein geschriebenen (int, boolean, double, float, ...). Es muss also *(char) (a+b)* und nicht *(Character) (a+b)* stehen. 

```java
Integer a = 97;
Integer b = 98;
Integer AMitToupetInteger = a + b;
Character aPlusBAlsInteger = (char) (a + b);
```

Grund dafür ist die ``starke Typisierung der Programmiersprache`` Java. Typumwanldungen müssen dadurch immer ``explizit`` angegeben werden. Java darf also nicht einfach so ohne Aufforderung des Programmierers den ``Typ`` eines ``Ausdrucks`` ändern. Jedoch gibt es Ausnahmen, welche für einfachere Schreibweisen genehmigt wurden. Siehe *Character meinSymbol = 95;* sollte eigentlich *Character meinSymbol = (char) 95;* sein. 

```java
Character userInputCharacter = (char) (98 + primitiv); //3 + 98 = 101 = e
Integer alter = 32;
Double hoehe = 10.8;
Float breite = 10.8f;

alter = (int) hoehe;  // wir verlieren Information 10.8 wird zu  
hoehe = (double) alter; // geht auch ohne (double) weil, keine Information verloren wird.
breite = (float) alter;
breite = (float) hoehe;
```

Zudem ist noch ein komischer Fall hier zu sehen. Warum lässt der Compiler zu, dass ich eine Kommazahl zu einem Character caste? Es kommt kein Fehler bevor ich das Programm ausführe (``Compilezeit``), auch wenn ich das Programm ausführe kommt kein Fehler (``Laufzeit``). Das Symbol wird jedoch nicht dargestellt und ist scheinbar leer.

```java
double doubleZahl = 10.8;
userInputCharacter = (char) doubleZahl;
System.out.println(userInputCharacter); // warum leer?
```

Es ist hier eine ähnliche Logik wie bei ``(int) doubleZahl``. Es wird unntiges abgeschnitten und mit dem Rest weitergearbeitet. Es bleibt also der ``Wert`` 10 übrig. Was ist jedoch die Darstellung eines Symols mit ASCII Code 10? Die ersten 32 Zeichen werden für interne Steuerung verwendet und nicht dargestellt. Z.B. ist ``char newLine = 10`` das gleiche wie `\n`! Dieses wissen ist jedoch schon eher speziell und dient nur zum "erforschen". 

Wir merken uns:
> ``Type Casting`` wandelt ``Werte`` mit ``primitiven Typ`` in andere ``Werte`` mit ``primitiven Typ`` um.
> ``Type Casting`` wird mittels ``runder Klammern`` und dem gewünschten ``primitiven Typ`` dazwischen angegeben. 
> Ausdrücke rechts neben dem ``Type Casting`` müssen geklammert werden, wenn diese ``Operatoren`` beinhalten.

### Trockene Experimente: Einschränkungen bei der Zeichenkodierung

``Characters`` verwenden 16 Bit, während ``Integer`` 32 Bit haben. Zahlen über *65535* können nicht in `Character` gespeichert werden. Zudem gibt es Emojis welche 24 oder 32 bit haben. Das geht sich nicht in einer ``Variable`` des ``Typs`` *Character* aus.

```java
Character geht = 65535;
// Character gehtNicht = 65536; // Dies würde zu einem Fehler führen.
```

#### Warum passen 16 Bit shorts nicht mit dem 16 bit character zusammen?
Ein `Short` wie wir später sehen ist ein ganze Zahl wie ein ``Integer`` nur mit 16 bit. ``Short`` kann jedoch nicht direkt verwendet werden, da alle ganzen Zahlen ``signiert`` sind. Das Bedeutet wir haben ca. gleich viele negative wie positive Zahlen. Dadurch haben wir 15 bit für die positiven und 15 bit für die negativen Zahlen. Ein bit wird für die Codierung ob es eine positive oder negative Zahl ist reserviert. Dadurch ist ``Short`` mit seinen 15 bit für positive Zahlen zu klein um 16 bit ``Characters`` darstellen zu können. Wir müssen also dem Computer sagen er soll eine groß genuge ``Variable`` daraus machen - einen ``Integer``. Wir können dies durch:
* ``Type Casting`` wenn wir einen ``primitiven Typen`` wollen, 
* ``Methoden`` wenn wir ein ``Objekt`` als ``Variable`` haben, oder einen
* Trick verwenden indem wir eine arithmetische ``Operation`` durchzuführen, die das Ergebnis nicht verändert. Diese gibt einen ``Integer`` zurück.

```java
Short AMitToupetShort = AMitToupetInteger.shortValue();
Character AMitToupetCharacter;
AMitToupetCharacter = (char) ((int) AMitToupetShort); // Typecasting
AMitToupetCharacter = (char) (AMitToupetShort.intValue()); // Methoden
AMitToupetCharacter = (char) (AMitToupetShort + 0); // Trick - Aufruf eines Operators welcher einen Integer erzeugt
AMitToupetCharacter = (char) (AMitToupetInteger * 1); // Trick - Aufruf eines Operators welcher einen Integer erzeugt

System.out.println(aPlusBAlsInteger + " ist das gleiche Symbol wie " + AMitToupetCharacter);
```

**Anmerkung:** Diese Dinge sind jedoch begrenzt nützlich in der Praxis und dienen hier zum **Kennenlernen** der ``Programmiersprache``. Keine Sorge, es muss nicht so Programmiert werden. Wir verwenden die Verkettung von ``Characters``, welche wir als ``Strings`` bezeichnen. Dise sind viel einfacher zu handhaben.

#### Warum können zwei Charaktere nicht miteinander verknüpft werden?

Unser Ziel ist foglendes: Ich habe zwei ``Variablen`` des ``Typs`` *Character* und ich möchte diese aneinanderhängen. Wir werden sehen, dass so etwas ähnliches mit dem ``Operator`` *Concatenation* funktioniert und ebenso mit *+* umgesetzt wird.

```java
Character aSehrVielAngenehmer = 'a';
Character bSehrVielAngenehmer = 'b';
// Character aPlusBSehrVielAngenehmer = aSehrVielAngenehmer + bSehrVielAngenehmer; // Funktioniert nicht!
```

Wir können versuchen mit ``Type Casting`` dem Computer explizit zu sagen, dass wir gerne einen neuen ``Character`` hätten und schreiben folgendes:

```java
Character aSehrVielAngenehmer = 'a';
Character bSehrVielAngenehmer = 'b';
Character aPlusBSehrVielAngenehmer = (char) (aSehrVielAngenehmer + bSehrVielAngenehmer);
System.out.println("Wir addieren und haben wieder A mit dem Toupet: " + aPlusBSehrVielAngenehmer);
```

Jedoch wir sagen hier, "addiere die bieden `Character`-Werte als Integer". Was nicht dem entspricht was wir wollen. 

Leider haben wir hier ein konzeptionelles Problem. Wenn wir 2 Character zusammenhängen wollen, dann sind es 2 Zeichen. Wir können nicht 2 Zeichen in einem Character speichern. Wenn wir das Ergebnis in einem *String*, welcher mehrere *Charactäre* gleichzeitg speichern kann schreiben wollen, müssen wir zuerst die ``Variablen`` des ``Typs`` *Character* in einen *String* umwandeln.

```java
Character aSehrVielAngenehmer = 'a';
Character bSehrVielAngenehmer = 'b';
String aPlusBSehrVielAngenehmer = aSehrVielAngenehmer.toString() + bSehrVielAngenehmer.toString();
System.out.println("Ah wir können nur zusemmhängen wenn wir den Typ String haben: " + aPlusBSehrVielAngenehmer);
```

### Mehrere Zeichen zusammengefasst als Zeichenketten - Strings

Java besitzt keinen ``primitiven Typ`` *string*. Ein *String* ist eine Aneinanderreihung von ``Werten`` des ``Typs`` *Character*. Diese Aneinanderreihung stellt eine Zeichenkette dar und eine mögliche Form ist der ``Typ`` *String*. Diese werden mit *""* anstatt *''* gekennzeichnet und können mit `+` verknüpft werden:

```java
String myNewString = "hallo " + " " + "du " + "🌲"; // keine Addition. Wir hängen Strings aneinander.
System.out.println(myNewString);
```

Ein "leistungsfähigerer" ``Typ`` ist `StringBuilder`, der Methoden für Zeichenketten-Manipulationen bereitstellt:

```java
System.out.println(new StringBuilder("hallo").append(" ").append("du").reverse());
```

Mehr zu ``String`` und ``StringBuilder`` werden wir in späteren Lerneinheiten kennenlernen.

Wir merken uns:
> Eine Aneinanderreihung von ``Character`` wird *Zeichenkette* genannt.

> Ein *Typ* welcher eine Zeichenkette darstellt ist ``String``. 

> Die ``Operation`` ``Concatenation`` beschreibt das aneinanderhängen von ``Werten``, ``Variablen`` oder allgemein ``Ausdrücken`` welche Zeichenketten darstellen.

> Um ``Strings`` effizient manipulieren zu können verwenden wir den *Typ* ``StringBuilder``.

## Positive und Negative Zahlen ohne Komma - Ganze Zahlen
Ganze Zahlen (keine Kommazahlen, die aber negativ und positiv sein können) können wir mit mehreren ``Typen`` darstellen. Der Unterschied liegt in der maximalen Größe der darzustellenden Zahl. Es reicht aber über den ``Typ`` *Integer* beschreid zu wissen, denn wir werden diesen fast auschließlich verwenden.


### Byte
Wir haben die kleinste Variante mit dem Typ **Byte** (8 Bit), welche hier eine sogenannte *signed Variable* ist. Wir berücksichtigen also das Vorzeichen.

Das bedeutet, wir haben negative und positive Zahlen, die wir mit 8 Bit darstellen können (0|000 0000).

Es gibt also $2^8 = 256$ mögliche Darstellungen von Zahlen:
- 127 positive Zahlen
- 128 negative Zahlen
- und eine 0.

```java
Byte kleinsteGanzeZahlPositive = 127;
Byte kleinsteGanzeZahlNegative = -128;
Byte kleinsteGanzeZahlNull = 0;

kleinsteGanzeZahlPositive = Byte.MAX_VALUE;
kleinsteGanzeZahlNegative = Byte.MIN_VALUE;
Integer bitsOfByte = Byte.SIZE;

System.out.println(kleinsteGanzeZahlPositive + " " + kleinsteGanzeZahlNegative + " " + bitsOfByte);
```

---

### Short
Die nächste Variante ist der Typ **Short** (16 Bit). Auch hier handelt es sich um eine *signed Variable*.

Das bedeutet, wir haben negative und positive Zahlen, die wir mit 16 Bit darstellen können (0|000 0000 0000 0000).

Es gibt also $2^{16} = 65.536$ mögliche Darstellungen:
- 32.767 positive Zahlen
- 32.768 negative Zahlen
- und eine 0.

```java
Short kleineGanzeZahlPositive = 32767;
Short kleineGanzeZahlNegative = -32768;
Short kleineGanzeZahlNull = 0;

kleineGanzeZahlPositive = Short.MAX_VALUE;
kleineGanzeZahlNegative = Short.MIN_VALUE;
Integer bitsOfShort = Short.SIZE;

System.out.println(kleineGanzeZahlPositive + " " + kleineGanzeZahlNegative + " " + bitsOfShort);
```

---

### Integer
Die nächste Variante ist der Typ **Integer** (32 Bit). Auch hier handelt es sich um eine *signed Variable*.

Das bedeutet, wir haben negative und positive Zahlen, die wir mit 32 Bit darstellen können (0|000 0000 0000 0000 0000 0000 0000 0000).

Es gibt also $2^{32} = 4.294.967.296$ mögliche Darstellungen:
- 2.147.483.647 positive Zahlen
- 2.147.483.648 negative Zahlen
- und eine 0.

```java
Integer ganzeZahlPositive = 2147483647;
Integer ganzeZahlNegative = -2147483648;
Integer ganzeZahlNull = 0;

ganzeZahlPositive = Integer.MAX_VALUE;
ganzeZahlNegative = Integer.MIN_VALUE;
Integer bitsOfInteger = Integer.SIZE;

System.out.println(ganzeZahlPositive + " " + ganzeZahlNegative + " " + bitsOfInteger);
```

---

### Long
Die nächste Variante ist der Typ **Long** (64 Bit). Auch hier handelt es sich um eine *signed Variable*.

Das bedeutet, wir haben negative und positive Zahlen, die wir mit 64 Bit darstellen können (0|000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000).

Es gibt also $2^{64} = 18.446.744.073.709.551.616$ mögliche Darstellungen:
- 9.223.372.036.854.775.807 positive Zahlen
- 9.223.372.036.854.775.808 negative Zahlen
- und eine 0.

Wenn wir Zahlen direkt in die Entwicklungsumgebung schreiben, sind dies standardmäßig **Integers (32 Bit)**. Deshalb müssen wir, wenn wir eine **Long**-Zahl definieren wollen, ein **"L"** am Ende der Zahl anhängen, um dem Computer explizit zu sagen, dass er 64 Bit verwenden soll.

```java
Long grosseGanzeZahlPositive = 9223372036854775807L;
Long grosseGanzeZahlNegative = -9223372036854775808L;
Integer grosseGanzeZahlNull = 0;

// Maximal- und Minimalwerte abrufen

grosseGanzeZahlPositive = Long.MAX_VALUE;
grosseGanzeZahlNegative = Long.MIN_VALUE;
Integer bitsOflong = Long.SIZE;

System.out.println(grosseGanzeZahlPositive + " " + grosseGanzeZahlNegative + " " + bitsOflong);
```

## Zahlen mit Kommastellen
Kommazahlen unterscheiden sich von ganzen Zahlen, indem wir Nachkommastellen haben.
Wir könnten einfach sagen wir nehmen 2 ``Integer``, einer für vor dem Komma und einen für die Zahl nach dem Komma.
Es gibt aber eine kompaktere Variante, welche sich ``Fließkommazahl`` nennt. Hier wird berechnet, wie viel Bits wir für Vor- und Nachkommastelle brauchen.
haben also keine fixe große Vor- und Nachkommastelle, sondern eine die "fließen" kann.

### Float - 32 Bit
Für die Darstellung sind 32 bit zur Verfügung.
Da wir uns nicht direkt mit der Darstellung auseinandersetzten müssen, sollten wir uns aber eines merken.
Wenn wir viel Speicher für die Vorkommastelle brauchen, haben wir weniger Platz für die Nachkommastelle.
Auch wenn wir Operatoren verwenden, kann es dadurch zu Ungenauigkeiten kommen.

Zuerst schauen wir uns aber an wie wir eine ``Variable`` des ``Typs`` *float* ``definieren``.
Da wir standard mäßig einen Wert mit ``Typ`` *Double* erzeugen, wenn wir eine Kommazahl schreiben, müssen wir dem Computer
mitteilen, dass es sich um einen ``Float`` handelt. Wir tun das mithilfe des "F" oder "f" am Ende der Kommazahl.

```java
Float myFirstFloat = 0.25F;
System.out.println(myFirstFloat);
```

Durch die Art wie wir Fließkommazahlen darstellen, ist es uns möglich scheinbar größere Zahlen als mit ``Long`` darzustellen.
```java
Float myStrngeAndBigFloat = 340282346638528860000000000000000000000.0F; // kein Fehler - Zahl nicht zu groß für float
                                                                        // aber nicht alle Zahlen dazwischen genau darstellbar, denn wir haben 32 bit zur Verfügung. 
                                                                        // Es ist also nur ein Trick.
Long tooLongforLong =       340282346638528860000000000000000000000L;   // Zahl zu groß für 64 Bit -> 2^64
```

Aber das ist nur scheinbar so. Wir schneiden nämlich einige Zahlen zwischen dem Maximalen Wert und den nächst größeren Wert weg. Wir können also nicht den *Float.MAX_VALUE - 1* darstellen. Dieser ist gleich dem *Float.MAX_VALUE* *3.402823**5**e38*. Die nächst genauere Zahl wäre *Math.nextDown(Float.MAX_VALUE);*  was *3.402823**3**e38* ist. Wir haben also Löcher/Rundungsfehler der Größenordnung *1e31* was eine Zahl mit *31* Nullen ist.

```java
System.out.println(Float.MAX_VALUE);   // ergibt 3.4028235E38
System.out.println(Float.MAX_VALUE-1); // ..auch 3.4028235E38
System.out.println(Math.nextDown(Float.MAX_VALUE)); // 3.4028233E38
```

### Double - 2 * 32 Bit
Genau das gleiche kann von ``Double`` behauptet werden, außer dass es doppelt so viele bits wie ``Float`` hat. *64* statt *32*.
Da wir ca. *7* Nachkommastellen mit ``Float`` und ca. *16* mit ``Double``, wird ``Double`` standardmäßig verwendet, da es sehr schnell
passieren kann, dass wir mehr wie *6* Nachkommastellen brauchen. Grund dafür sind Rundungsfehler und die oben geplante Ungenauigkeit. Wir werden nicht darauf eingehen wie ``Fließkommazahlen`` genau funktionieren, wir sollten uns jedoch merken, dass wir nicht auf magische weise viel größere Zahlen darstellen können als es die Bits zulassen. Wir müssen mit Rundungsfehlern leben und diese werden "smart" gestaltet, damit wir nicht eine Rundugnsgenauigkeit von *1e31* bei der Zahl *1* haben. Die Folge wäre dass die nächst genauere Zahl neben *1* *1e31* wäre. Dem ist aber nicht so. 

```java
Double myFirstDouble = 0.25;
System.out.println(myFirstDouble);
```

Durch die Art wie wir Fließkommazahlen darstellen, ist es uns möglich scheinbar größere Zahlen als mit Long darzustellen.
```java
Double myStrngeAndBigDouble = 18225545918452735554995884998125521044555555555555555555544444444444481521515.0;
System.out.println(myStrngeAndBigDouble);
```

Gleich wie oben auch hier:
```java
System.out.println(Double.MAX_VALUE);   // ergibt 1.7976931348623157e308
System.out.println(Double.MAX_VALUE-1); // ..auch 1.7976931348623157e308
System.out.println(Math.nextDown(Double.MAX_VALUE)); // 1.7976931348623155e308
```

Wir merken uns:
> ``Double`` und ``Float`` sind ``Fließkommzahlen`` da wir per Bedarf die Präzession einer Zahl durch ein fließendes Komma steuern können.

> ``Werte``, ``Variablen`` und ``Ausdrücke`` welche mit ``Double`` und ``Float`` in Verbindung stehen, haben Rundungsfehler. 

> Wir präferieren ``Double``, da ``Float`` nur ca *7*. Nachkommastellen darstellen kann. ``Double`` schafft ca. *14*.

> Vorgriff: Wir vergleichen **niemals** ``Werte``, ``Variablen`` und ``Ausdrücke`` welche mit ``Double`` und ``Float`` in Verbindung stehen mit dem ``Vergleichsoperator`` *==*. 

### Optional: Beispiele zur den Rundungsfehlern welche mit Operatoren enstehen

Hier ein paar kurze Beispiele zu den Rundungsfehlern der Fließkommadarstellung der Zahlen.
```java
Double doubleA = 0.1;     // nicht genau darstellbar   - ?
// Double doubleA = 0.2;     // nicht genau darstellbar   - ?
// Double doubleA = 0.5;     // genau darstellbar       - summe genau darstellbar
// Double doubleA = 0.4;     // nicht genau darstellbar - summe genau darstellbar
// Double doubleA = 0.0;     // genau darstellbar       - summe genau GENUG darstellbar

Double doubleB = 0.2;     // nicht genau darstellbar   - ?
// Double doubleB = 0.2;     // nicht genau darstellbar   - ?
// Double doubleB = 0.25;    // genau darstellbar       - summe genau darstellbar
// Double doubleB = 0.35;    // nicht genau darstellbar - summe genau darstellbar
//Double doubleB = 0.3;     // nicht genau darstellbar - summe genau GENUG darstellbar

Double sum = doubleA + doubleB;
System.out.println("a: " + doubleA);
System.out.println("b: " + doubleB);
System.out.println("Sum: " + sum);
```

Tausche num im obigen Code die Kommazahl gegen eine "2er Potenz" aus. z.B 0.5 und 0.25
Wir schneiden alle möglichen Nachkommastellen in 2 Gebiete. Alle größer wie 0.5 und alle kleiner.
Wichtig hier ist, dass die Summe der beiden Zahlen gut mit einer 2er-Potenz darstellbar ist.

Wir sehen:
- Die Summe aus genau darstellbaren Zahlen ist genau.
- Die Summe aus genau und ungenau darstellbaren Zahlen ist meistens genau genug.
- Die Summe aus ungenau darstellbaren Zahlen kann genau oder auch ungenau sein.
- Die Summe aus ungenau darstellbaren Zahlen welche eine genau darstellbare ergeben ist genau.

Ein Weiteres Beispiel, welches wiederholt zahlen zusammenzählt, welche sehr unterschiedlich von der Größe sind.
```java
Double x = 1e6;
Double epsilon = 1e-10;

// zaehle eine kleine Zahl zu x in a Schleife. 
// Die Schleife wiederholt die addition oft.
for (int i = 0; i < 10; i++) {
    x = x + epsilon;
}
```

Wir zählen 10 mal 0.0000000001 (1 an 10. nachkommastelle), also 0.000000001 (1 an 9. Nachkommastelle), dazu.
System.out.println(x);

Wir erwarten 1000000.000000001 bekommen aber 1000000.0000000012
```java
System.out.println(x == 1000000.000000001);
```

## Boolesche Werte
Jetzt zu einem ganz andern Typ von Variablen. Boolesche Werte sind 2 Wertige Variablen wie "Falsch" und "Wahr", 0 oder 1, oder auch 24155 und 41. Wir brauchen nur 2 bestimmte voneinander unterscheidbare Werte, wo ein Wert als "Wahr"
und ein andere als "Falsch" interpretiert wird.
Es macht aber durchaus Sinn hier 0 und 1 im Kopf zu behalten.

Wir legen wir nun eine Boolesche Variable an.
```java
Boolean myFirstBoolean = true;
myFirstBoolean = false;
```

Hier können wir nicht mit 0 oder 1 direkt arbeiten wie bei den Characters. Müssen also true und false verwenden.
Boolesche Werte für das Programmieren selbst eine der wichtigsten Werte, da wir mithilfe von logischen Operatoren bzw. Vergleichsoperatoren den Ablauf eines Programmes steuern.
Dazu aber mehr in ``L03Operatoren``.