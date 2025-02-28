# Variablen und Werte in Java

## Was wollen wir in einem Programm tun?
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
**Anmerkung**: Streng genommen sind die ``Typen`` der ``Werte``: ``String``, ``int``, ``double``, und ``boolean``. Was der Unterschied zwischen groß und klein geschriebenen Typen ist, ist vorerst nicht relevant.

## Kurzsprechweise von Werten
Da es umständlich ist immer von ``Werten`` eines ``Typs`` zu sprechen, werden wir z.B. anstatt ``"Hallo" ist ein Wert vom Typ String``, ``"Hallo" ist ein String`` sagen. Gleiches gilt für andere ``Typen``.

## Warum müssen wir Werte des Typ Strings zwischen "" schreiben?
Wir kennzeichnen ``Strings`` (oder auch ``Zeichenketten`` genannt) , mit ``""``, damit der ``Compiler`` es von Symbolen der Programmiersprache, wie `System.out.println` unterscheiden kann. Da unsere Sprache textbasiert ist, haben wir leider eine doppelte Verwendung von Text. Durch eine Kennzeichnung wie eben ``""`` ist diese Unterscheidung möglich.

## Was erlauben uns Variablen zu tun?
``Variablen`` erlauben uns ``Werte`` später im Programm wiederzuverwenden, indem wir diese durch einen ``Namen`` ansprechbar machen. Eine ``Variable`` wird also zu einem Platzhalter für verschiedene ``Werte`` eines bestimmten ``Typs``. Da JAVA eine ``statisch typisierte`` Programmiersprache ist müssen wir bei **jeder** ``Definition`` einer ``Variable`` den ``Typ`` dazuschreiben.

Wir haben bereits 2 verschiedene Arten kennen gelernt wie wir eine ``Variable`` anlegen könnnen. Eine ist die ``Variable`` zu ``definieren`` die andere ist eine `Variable` zu `definieren und initialisieren`.

### Deklaration, Definition und Initialisierung
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

## Was kann ich einer Varaible zuweisen?
Wir können mit dem Muster `<Typ> <Name>` eine Variable `definieren` bzw. mit `<Typ> <Name> <Zuweisungsoperator> <Wert>` `initialisieren`. Das Muster ist jedoch allgemeiner als hier dargestellt.
Eigentlich müsste es `<Typ> <Name> <Zuweisungsoperator> <"alles was einen Wert mit gleichem Typ wie <Typ> erzeugt kann hier stehen">` heißen. 

Der ``Zuweisungsoperator`` ist mit dem Symbol ``=`` abgebildet. Wir können uns auch einen Pfeil nach links denken ``<-``, wenn wir das ``=`` bei einer Zuweisung sehen. Wir nehmen also den Ausdruck welcher rechts vom ``Zuweisungsoperator`` steht und "schreiben" es in die Variable welche links steht.

```java
String myString = "das ist ein String";               // Der Wert rechts vom = hat den Typ String.
String otherString = myString;                        // Die Variable rechts vom = hat den Typ String.
String userInput = new Scanner(System.in).nextLine(); // Der Ausdruck rechts vom = erzeugt einen Wert vom Typ String
String formatiert = String.format("Wert: %d", 42);    // Der Ausdruck rechts vom = erzeugt einen Wert vom Typ String
String ersteZeileDerWebsite = new BufferedReader(new InputStreamReader(new URL("https://www.example.com").openStream())).readLine(); // Der Ausdruck rechts vom = erzeugt einen Wert vom Typ String
```

## Verschiedene Arten von Typen
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

``Merke!`` Wenn wir *nicht* die primitiven Typen verwenden sind immer alle Typen **groß** geschrieben. Wir können also gut unterscheiden zwischen klein geschriebenen ``Variablen`` und groß geschriebenen ``Typen``. Auch wenn wir den genauen Kontext nicht kennen, sollte es uns möglich sein ``Scanner`` als Typ zu identifizieren und ``scanner`` als variable.

## Klassen sind Typen, aber primitive Typen sind auch Typen
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

## Ergebnisse von Methoden

Das Ergebnis der Methode ist ein Wert, welcher wie bei Operatoren einen Typ hat.
Beim vorherigen Beispiel kommt eine Zahl in die Methode rein und ein String raus.

Wir können nun `yetAnotherString` weiter verwenden, z.B. ausgeben oder weiter manipulieren:

```java
System.out.println(yetAnotherString.toUpperCase());
```

Wir sehen auch, dass wir das Ergebnis der Methode `toUpperCase()` direkt verwenden können und dieses nicht in einer Variable speichern müssen. Falls wir später im Programm das Ergebnis erneut benötigen, wäre es jedoch verloren. Daher empfiehlt es sich, es in einer Variable zu speichern, insbesondere wenn die Berechnung aufwendig ist.

Falls eine Methode z. B. 3 Stunden benötigt, um ein Ergebnis zu erzeugen, sollte dieses Ergebnis auf jeden Fall in einer Variable gespeichert werden.

```java
String upperString = yetAnotherString.toUpperCase();
System.out.println(upperString); // 1. Verwendung
System.out.println(upperString); // 2. Verwendung ohne es neu ausrechnen zu müssen
System.out.println(yetAnotherString.toUpperCase()); // wird neu berechnet, kann in anderen Fällen lange dauern.
```

Gehen wir nun die verschiedenen Variablentypen durch. Beginnen wir mit Zeichenketten und einzelnen Zeichen.

---

## Zeichenketten (`String`) und einzelne Zeichen (`char`)

### `Character` Datentyp

Betrachten wir einen Typ, welcher nur eine Zuweisung zu einer Variable von einem Symbol erlaubt – Character.

Dieser Typ ist der "komplizierteste", denn er benötigt ein wenig Vorwissen darüber, wie der Computer Symbole darstellt. Fast immer ist dies jedoch nicht notwendig zu verstehen, wenn wir in Zukunft Programme schreiben. Trotzdem ist es nicht schlecht, einmal darüber nachgedacht zu haben, denn abstrakte Strukturen zu erkennen und zu verstehen hilft sehr im Alltag eines Programmierers. Besonders wenn wir fehlerhaftes Verhalten programmieren und den Fehler suchen müssen.

Seht diesen Abschnitt also mehr als eine Denkaufgabe, als praktisches, direkt täglich anwendbares Wissen. Wir reden von Symbolen wie 'a', 'ø' oder '҈'. Warum beginnen wir also mit einer Variable `userInput`, welche zwar vom Typ `Character` ist, aber den Wert einer Zahl zugewiesen bekommt?

```java
Character userInputDecimalNumber = 97; //ASCII-CODE - 10er basis - dec
Character userInputHexNumber = 0x0061; //UNI-CODE - 16er basis - hex
Character userInputHexUnicodeNumber = '\u0061'; //UNI-CODE - hex
Character userInputChar = 'a';

System.out.println("'" + userInputChar + "' ist das gleiche wie '" + userInputDecimalNumber + "' und auch das gleiche wie '" + userInputHexNumber + "' oder '" + userInputHexUnicodeNumber + "'");
```

Da der Computer meist nur mit Zahlen umgehen kann, gibt es ein "Mapping" von Zahlen zu Symbolen. Ein Beispiel: Der Wert 97 ist dem Symbol 'A' zugewiesen. Diese Codes haben Namen wie z. B. ASCII-Codes oder Unicode.

In Windows gibt es eine Zeichentabelle (bei englischen Betriebssystemen "Character Map"), welche es erlaubt, diese Codes bzw. Tastenkürzel einzusehen. Dazu die Windows-Taste drücken und nach "Zeichentabelle" oder "Character Map" suchen.

### ASCII-Codes:
- Besteht aus 0 bis 255 Zeichen (mit 7 Bit darstellbar) → diese sind mit `Alt + <vierstelliger Code>` ansprechbar.
- ø ist z. B. `Alt + 0248`. Der Bereich geht von `0032` bis `0255`. Die ersten 32 Zahlen sind Symbole, welche keine grafische Darstellung haben.
- Diese Zeichen signalisieren z. B. das Ende eines Strings in C/C++.
  - `Alt + 0000` → (NUL): Null-Symbol
  - `Alt + 0001` → (SOH): Start einer Heading
  - `Alt + 0002` → (STX): Start des Streams
  - `Alt + 0003` → (ETX): Ende des Streams (verwendet in manchen Netzwerkprotokollen)

Ein Zeichen, welches außerhalb der 256 ASCII-Zeichen liegt, ist folgendes Symbol (Cyrillic Million Symbol):

```java
Character million = '҉';
Character million = '\u0489'; // oder direkt mit dem code
```

Dieses hat den Unicode `U+0489`. Achtung! Diese Symbole sind als hexadezimale Zahlen angegeben, also 16 Ziffern statt 10!
Wir stellen das mit 0-9 sowie A-F dar.

Wie zuvor hat auch das Symbol 'a' den hexadezimalen Wert `0x61` und den Unicode `U+0061`. Der ASCII-Code ist also dezimal, der Unicode hexadezimal.

Smileys haben ebenfalls einen Unicode. Zum Beispiel hat 🌲 den Unicode `0x1F332`. Achtung! Hier ist ein fünftes Hex-Bit dazugekommen!
Der Standardsatz von Unicode hat aber nur vier Hex-Bits `U+0000`. Die Lösung dazu schauen wir uns in einem späteren Java-Programm an.

Für uns funktioniert es vorerst, wenn wir direkt das Symbol einfügen. Dazu die Windows-Taste und "Punkt" drücken.

```java
String tannenbaum = "🌲";
System.out.println(tannenbaum);
```

Wir müssen uns zuerst mit dieser Lösung zufriedengeben, wenn wir nicht "diesen Trick" verwenden wollen.

```java
Character basicSmiley = 0x263A;
System.out.println(basicSmiley);
```

### Verwendung von Operatoren mit Character-Typen

Wenn wir Operatoren wie `+` auf Zahlen anwenden, können wir damit auch neue Symbole erzeugen. Das liegt daran, dass das Ergebnis des Operators eine Zahl ist, die einem Symbol zugeordnet werden kann:

```java
Character aPlusB = 97 + 98; // a // b 
Character AMitToupee = 195; // Ã

System.out.println(aPlusB + " ist das gleiche Symbol wie " + AMitToupee); // Ã
```

Es kann jedoch zu unerwartetem Verhalten kommen, wenn man Zeichen addiert:
Wenn wir jedoch im Kopf haben dass Character Zahlen sind, sollte es weniger überraschend sein. 

```java
Character abOderEtwasAnders = 'a' + 'b'; // keine concatenation, arithmetische addition
System.out.println("ich bin hier: " + abOderEtwasAnders); // Ã
```

### Typumwandlung (Type Casting)
Wird eine Berechnung mit `Integer`-Werten durchgeführt, funktioniert eine direkte Zuweisung zu `Character` nicht mehr. In diesem Fall muss eine explizite Umwandlung vorgenommen werden. Wir schreiben vor dem ``Zuweisungsoperator`` eine runde Klammer in der der neue Typ stehen soll (z.B. ``(double) a``). 

``Achtung!`` Es kann nur in ``primitiven Typen`` umgewandelt werden. Das sind die klein geschriebenen (int, boolean, double, float, ...). Es muss also ``(char) (a+b)`` und nicht ``(Character) (a+b)`` stehen. 

Zudem ist auf die Klammerung zu Achten! ``(char) (a + b)`` bedeutet zuerst ``a + b`` und dann umwandeln in einen ``char``.

```java
Integer a = 97;
Integer b = 98;
Integer AMitToupeeInteger = a + b;
Character aPlusBAlsInteger = (char) (a + b);
```
Grund dafür ist die ``starke`` Typisierung der Programmiersprache JAVA. Typumwanldungen müssen dadurch immer ``explizit`` angegeben werden. JAVA darf also nicht einfach so ohne Aufforderung des Programmierers den Typ ändern. Jedoch gibt es Ausnahmen, welche für einfachere Schreibweisen genehmigt wurden. Siehe ``Character meinSymbol = 95;`` sollte eigentlich ``Character meinSymbol = (char) 95;`` sein. 

Allgemein können wir uns **vorerst** merken, dass wir mit ``Type Casting`` *Zahlen in andere ``primitive`` Zahlen umwandeln* können.

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

### Einschränkungen bei der Zeichenkodierung

Characters verwenden 16 Bit, während Integer 32 Bit haben. Zahlen über 65535 können nicht in `Character` gespeichert werden. Zudem gibt es Smileys welche 24 oder 32 bit brauchen in der UTF8 Kodierung. Das geht sich nicht in einer Variable aus.

```java
Character geht = 65535;
// Character gehtNicht = 65536; // Dies würde zu einem Fehler führen.
```

Auch `Short` kann hier nicht direkt verwendet werden, da es signiert ist. Ein Trick besteht darin, eine arithmetische Operation durchzuführen, die das Ergebnis nicht verändert:

```java
Short AMitToupeeShort = AMitToupeeInteger.shortValue();
Character AMitToupeeCharacter = (char) (AMitToupeeShort + 0);
AMitToupeeCharacter = (char) (AMitToupeeInteger * 1);

System.out.println(aPlusBAlsInteger + " ist das gleiche Symbol wie " + AMitToupeeCharacter);
```

Diese Dinge sind jedoch nicht nützlich und dienen zum Kennenlernen der Programmiersprache. Keine Sorge, es muss nicht so Programmiert werden. Wir verwenden die Abstraktion von characters, Strings welche viel einfacher zu handhaben sind.

### Charaktere als Zahlen

Zeichen können nicht einfach miteinander verknüpft werden:

```java
Character aSehrVielAngenehmer = 'a';
Character bSehrVielAngenehmer = 'b';
// Character aPlusBSehrVielAngenehmer = aSehrVielAngenehmer + bSehrVielAngenehmer; // Funktioniert nicht!
```

Addiert man jedoch `Character`-Werte als Integer, kann die Summe wieder in ein Zeichen umgewandelt werden:

```java
Integer aPlusBSehrVielAngenehmer = aSehrVielAngenehmer + bSehrVielAngenehmer;
System.out.println("Immer noch " + (char) (aPlusBSehrVielAngenehmer + 0));
```

Diese Dinge sind jedoch nicht nützlich und dienen zum Kennenlernen der Programmiersprache. Keine Sorge, es muss nicht so Programmiert werden. Wir verwenden die Abstraktion von characters, Strings welche viel einfacher zu handhaben sind.

### Strings in Java

Java besitzt keinen primitiven Datentyp `string`. Ein `String` ist eine Aneinanderreihung von `Character`-Werten. Zeichenketten werden mit `""` dargestellt und können mit `+` verknüpft werden:

```java
String myNewString = "hallo " + " " + "du"; // keine Addition. Wir hängen Strings aneinander.
System.out.println(myNewString);

String tannenbaum = "🌲";
System.out.println(tannenbaum);
```

Ein leistungsfähigerer Typ ist `StringBuilder`, der Methoden für Zeichenketten-Manipulationen bereitstellt:

```java
System.out.println(new StringBuilder("hallo").append(" ").append("du").reverse());
```

Mehr zu Strings aber in ``L05VariablenUmwandeln`` und String Builder in ``L12StringManipulation``.

## Ganze Zahlen
Ganze Zahlen (keine Kommazahlen, die aber negativ und positiv sein können) können wir mit mehreren Typen darstellen. Der Unterschied liegt in der maximalen Größe der darzustellenden Zahl.

---

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
## Komma Zahlen
Komma Zahlen unterscheiden sich von ganzen Zahlen, indem wir Nachkommastellen haben.
Wir könnten einfach sagen wir nehmen 2 Integer, einer für vor dem Komma und einen für die Zahl nach dem Komma.
Es gibt aber eine kompaktere Variante, welche sich Fließkommazahl nennt.
Hier wird bestimmt, wie viel Bits wir für Vor- und Nachkommastelle brauchen.
haben also keine fixe große Vor- und Nachkommastelle, sondern eine die "fließen" kann.

### Float
Für die Darstellung sind 32 bit zur Verfügung.
Da wir uns nicht direkt mit der Darstellung auseinandersetzten müssen, sollten wir uns aber eines merken.
Wenn wir viel Speicher für die Vorkommastelle brauchen, haben wir weniger Platz für die Nachkommastelle.
Auch wenn wir Operatoren verwenden, kann es dadurch zu Ungenauigkeiten kommen.

Zuerst schauen wir uns aber an wie wir eine Variable mit Typ float definieren.
Da wir standard mäßig einen Wert mit Typ Double erzeugen, wenn wir eine Kommazahl schreiben, müssen wir dem Computer
mitteilen, dass es sich um einen Float handelt. Wir tun das mithilfe des "F" oder "f" am Ende der Kommazahl.

```java
Float myFirstFloat = 0.25F;
System.out.println(myFirstFloat);
```

Durch die Art wie wir Fließkommazahlen darstellen, ist es uns möglich scheinbar größere Zahlen als mit Long darzustellen.
```java
Float myStrngeAndBigFloat = 182255459184527355549958849981255210445.0F;
Long tooLongforLong = 182255459184527355549958849981255210445L;
```

Aber das ist nur scheinbar so. Wir schneiden nämlich einige Zahlen weg, indem der Computer es so genau wie möglich approximiert.
1.8225546E38 bedeutet wir nehmen die Zahl 1.8225546 und multiplizieren es mit 10^38. 10^38 bedeutet eine Zahl mit 38 Nullen.
Also lässt sich 18225546 sehr genau darstellen und die restlichen 31 Stellen werden weggelassen.

```java
System.out.println(myStrngeAndBigFloat);
```

### Double
Genau das gleiche kann von Double behauptet werden, außer dass es doppelt so viele bits hat. 64 statt 32.
Da wir ca 7 Nachkommastellen mit Float und ca 16 mit Double wird Double standardmäßig verwendet, da es sehr schnell
passieren kann, dass wir mehr wie 6 Nachkommastellen brauchen. Grund dafür sind Rundungsfehler bei Operatoren.

```java
Double myFirstDouble = 0.25;
System.out.println(myFirstDouble);
```

Durch die Art wie wir Fließkommazahlen darstellen, ist es uns möglich scheinbar größere Zahlen als mit Long darzustellen.
```java
Double myStrngeAndBigDouble = 18225545918452735554995884998125521044555555555555555555544444444444481521515.0;
System.out.println(myStrngeAndBigDouble);
```

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