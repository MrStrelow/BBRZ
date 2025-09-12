# Operatoren in Java

#### Welche Begriffe werden hier verwendet?
[``Wert``](../../../glossar.md#wert), [``Variable``](../../../glossar.md#variable), [``Typ``](../../../glossar.md#typ),  [``Zuweisungsoperator``](../../../glossar.md#zuweisungsoperator), [``Klasse``](../../../glossar.md#klasse), [``Objekt``](../../../glossar.md#objekt), [``Methode``](../../../glossar.md#methode), [``Anweisung``](../../../glossar.md#anweisung), [``Auswertungsreihenfolge eines Ausdrucks``](../../../glossar.md#auswertungsreihenfolge-eines-ausdrucks), [``Auswertung eines Ausdrucks``](../../../glossar.md#auswertung-eines-ausdrucks), [``Klammersetzung``](../../../glossar.md#klammersetzung)

---

Wir merken uns:
> ``Operatoren`` verknüpfen ``Variablen``, ``Werte`` oder allgemein ``Ausdrücke`` miteinander und erzeugen basierend auf diesen einen neuen ``Wert``.

Der folgende **+** ``Operator``, welcher die Bedeutung *"Addition"* hat, verknüpft die Zahlen *35* und *17* und erzeugt den neuen ``Wert`` *52*:

```java
System.out.println(35 + 17);
```

## Operatoren können überladen sein
Wir schauen uns zuerst forlgendes Programm an.
```java
System.out.println("35" + "17");
```

Was ist das Ergebnis dieses ``Operatores`` **+**? Wir haben vorher gesehen, **+** stellt die Addition dar, also sollte hier "53" rauskommen.
Wir sehen jedoch wenn wir dieses Programm ausführen, dass nicht *53* sondern *3517* rauskommt.
```java
System.out.println("35" + "17"); // 3517
```

Die Bedeutung eines ``Operators`` ist abhängig vom ``Typ`` der ``Variablen`` bzw. ``Werte``, welche in den ``Operator`` "hineingegeben" werden. Das sehen wir bei dem ``Ausdruck`` *"35" + "17"*. Hier hat der Operator **+** nicht die Bedeutung der *"Addition"*, sondern der *"Concatenation"* (zusammenfügen). Wir fügen also die Zeichenkette *"35"* mit der Zeichenkette *"17"* zusammen, was *"3517"* ergibt.

Das gleiche Verhalten gilt für ``Variablen``:

```java
Integer firstInt = 35;
Integer secondInt = 17;
System.out.println(firstInt + secondInt); //52

String firstString = "35";
String secondString = "17";
System.out.println(firstString + secondString); //3517
```

Wir merken uns:
> Nicht das *Symbol* des ``Operators`` legt die Bedeutung von diesem fest, sondern die ``Typen`` der ``Werte`` und ``Variablen`` welche in den ``Operator`` "hineinfließen".

## Operatoren erzeugen Werte und deshalb Ausdrücke
Ein Aufruf eines ``Operators`` erzeugt einen  ``Wert`` mit einem ``Typ``. Dieses Ergebnis kann direkt mit ``Operatoren`` weiter verknüpft werden kann. Es kann also eine "Kette" gebildet werden. Da am Schluss dieser "Kette" ein finaler ``Wert`` erzeugt wird, ist diese "Kette" ebenfalls ein ``Ausdruck``.

```java
Integer firstInt = 35;
Integer secondInt = 17;
System.out.println(firstInt + secondInt + firstInt + secondInt); // Kette: firstInt + secondInt + firstInt + secondInt ist ein Ausdruck

Integer term = firstInt + secondInt + firstInt + secondInt // Kette: firstInt + secondInt + firstInt + secondInt ist ein Ausdruck
System.out.println(term);
```

Wie *werten* wir jedoch einen ``Ausdruck`` aus? Die pragmatische Antwort hier ist **gar nicht**, denn der Computer tut dies für uns. Wir sollten aber wissen was der Computer macht, ansonsten schreiben wir ``Ausdrücke`` welche wir anders verstehen als der Computer.

Um nun "im Kopf" ``Ausdrücke`` auswerten zu können legen wir genauer fest was die ``Auswertung`` eines ``Ausdrucks`` bedeutet.
Diese ist...
* ein schrittweises ersetzen der ``Variablen`` mit dessen ``Werten`` und 
* diese ``Werte`` mit den ``Operatoren`` zu neuen ``Werten`` zusammenfassen,
* bis nur mehr *ein* ``Wert`` übrig ist.
* ... ``Auswertungsreihenfolge``?

Versuchen wir es hier und lassen es den Computer überprüfen. Jedoch haben wir ein Problem. Wo beginnen wir? 
Mangels einer genaueren Anweisung... beginnen wir irgendwo. Sagen wir mit **secondInt** und **thirdInt**.
```java
Integer firstInt = 35;
Integer secondInt = 17;
Integer thirdInt = 21;
Integer fourthInt = 5;

System.out.println(firstInt + secondInt + thirdInt + fourthInt); // 78: Ersetzen der Variablen durch dessen Werte
System.out.println(35       + 17        + 21       + 5);         // 78: Wir beginnen die Variable secondInt mit Wert 17 und die Variable thirdInt mit Wert 21 zusammenzuzählen. Das ergibt 38.
System.out.println(35       + 38                   + 5);         // 78: Was nun? z.B. 38 + fourthInt, also 38 + 5 ergibt 43
```

Wie gehts nun weiter? Wir haben hier 2 Möglichkeiten. Entweder *firstInt + 38* oder *38 + fourthInt*. Mangels genauer Anweisungen beginnen wir wieder irgendwo. Sagen wir *38 + fourthInt*, also *38 + 5* ergibt *43*.

```java
System.out.println(35 + 43);         // 78: 78
System.out.println(78);
```

Wir haben nun nur mehr eine Möglichkeit und bekommen als Ergebnis: *35 + 43 = 78*

Es scheint richtig zu sein, denn wir haben das gleiche Ergebnis wie der Computer. Es scheint aber unwahrscheinlich, dass wir die gleiche ``Auswertungsreihenfolge`` wie der Computer gewählt haben. Versuchen wir "Dinge" zu ändern welche wir schon kennen. Was wenn wir einen anderen ``Typ`` bei den ``Variablen`` verwenden und dadurch die Bedeutung des ``Operators`` **+** von *Addition* auf ``Concatenation`` ändern?
```java
String halloString = "hallo";
String duString = "du";
String wieString = "wie";
String gehtsString = "gehts";

System.out.println(halloString + duString + wieString + gehtsString); // "halloduwiegehts"
```

Auch hier erkennen wir egal welche ``Auswertungsreihenfolge`` verwendet wird, kommt *"halloduwiegehts"* als ``Wert`` heraus. Ersetzen wir nun **+** mit __*__ 
(*Multiplikation*) und gehen zum ``Typ`` *Integer* für die ``Variablen`` zurück. 
```java
Integer firstInt = 35;
Integer secondInt = 17;
Integer thirdInt = 21;
Integer fourthInt = 5;

System.out.println(firstInt * secondInt * thirdInt * fourthInt); // 62475
```

Eine händische Auswertung kommt zum gleichen Ergebnis, auch wenn wir wieder eine zufällige Reihenfolge wählen. Es scheint also, dass die ``Auswertungsreihenfolge`` egal ist wenn wir *gleiche* ``Operatoren`` in einem ``Ausdruck`` verwenden. **Wir sind jeodoch skeptisch und machen weiter.**

### Wie steuere ich die Ausertungsreihenfolge?
Um sicher zu gehen wiederholen wir nochmals mit **-** und **/**. Wir stoßen hier jedoch auf Probleme und führen gleich ein Werkzeug ein welches uns die ``Auswertungsreihenfolge`` steuern lässt. 
Dies ist die ``Klammersetzung`` durch *runde* Klammern. Wenn wir nun einen ``Ausdrücke`` in einer runden Klammer sehen, dann wissen wir, dass dieser als erstes ausgeführt werden muss. Wenn in einer Klammer nur mehr ein ``Wert`` übrig ist, kann die Klammer entfernt werden.

```java
Integer firstInt = 35;
Integer secondInt = 17;
Integer thirdInt = 21;
Integer fourthInt = 5;

System.out.println(firstInt - secondInt - thirdInt - fourthInt);    // -8: hier legen wir keine Reihenfolge fest.
System.out.println(firstInt - (secondInt - thirdInt) - fourthInt);  // 34: wir sehen dass (secondInt - thirdInt) geklammer ist und müssen diesen Ausdruck als erstes auswerten. 
```

Wir bemerken ein komisches Verhalten. Der ``Ausdruck`` *firstInt - secondInt - thirdInt - fourthInt* ergibt *-8*, jedoch wenn wir *firstInt - (secondInt - thirdInt) - fourthInt* schreiben ergibt dieser *34*. Schon hier sehen wir, dass die **``Auswertungsreihenfolge`` wichtig** ist. Für die *Division* haben wir ein ähnliches Verhalten wie bei der *Subtraktion*.

Wir schauen uns deshalb gar nicht die weiteren Schritte an und merken uns.
> Bei ``Ausdrücke`` welche nur ``+`` (*Addition* und *Concatenation*) oder nur ``*`` (*Multiplikation*) verwenden, spielt die ``Auswertungsreihenfolge`` des ``Ausdrucks`` **keine** rolle.

> Bei ``Ausdrücke`` welche nur ``-`` (*Subtraktion*) oder nur ``/`` (*Multiplikation*) verwenden, spielt die ``Auswertungsreihenfolge`` des ``Ausdrucks`` **eine** rolle.

### Was ist die Auswertungsreihenfolge ohne Klammern und verschiedenen Operatoren?
Da ``Operatoren`` eine vordefinierte Reihenfolge haben müssen wir nicht immer alles Klammern. Wir haben gesehen, bei "sortenreinen" ``Ausdrücken`` welche nur **+** oder __*__ verwenden, kommt immer der gleiche ``Wert`` heraus, egal welche ``Auswertungsreihenfolge`` verwendet wird. 

**Anmerkung:** Die Regeln aus der Mathematik gelten auch hier. **Klammer vor Punkt vor Strich** - kurz *KlaBuStri*.

Es muss aber eine ``Auswertungsreihenfolge`` geben wenn wir nicht Klammern. Jedoch welche ist diese?
```java
String duString = "du";
Integer firstInt = 35;
Integer secondInt = 17;
Integer thirdInt = 21;
Integer fourthInt = 5;

System.out.println(duString + firstInt * (secondInt - thirdInt) + fourthInt); // du-1405
System.out.println(duString + firstInt * secondInt - thirdInt + fourthInt); // Fehler!
```

Hier bemerken wir *duString + firstInt * (secondInt - thirdInt) + fourthInt* zwingt den Computer bei *(secondInt - thirdInt)* zu beginnen. 
Wir werten nun folgendermaßen aus:
```java
System.out.println(duString + firstInt * (secondInt - thirdInt) + fourthInt); // du-1405: auszuwertende Variablen durch Werte ersetzen
System.out.println(duString + firstInt * (17 - 21) + fourthInt); // du-1405: (17 - 21) ist -4
System.out.println(duString + 35 * -4 + fourthInt); // du-1405: 35 * -4 ist -140
System.out.println(duString + -140 + fourthInt); // du-1405: Was nun keine Klammer ist vorhanden? Wir wissen es kommt du-1405 raus. Der Computer scheint also einfach von links nach rechts vorzugehen.
System.out.println("du" + -140 + fourthInt); // du-1405: Ist + die Addition oder die Concatenation?
System.out.println("du" + -140 + fourthInt); // du-1405: Scheint die Concatenation zu sein, denn es müsste ein Fehler kommen, wenn es anders wäre. 
System.out.println("du-140" + fourthInt); // du-1405: Scheint die Concatenation zu sein, denn es müsste ein Fehler kommen, wenn es anders wäre. 
System.out.println("du-1405");
```

Wir merken uns:
> Wenn keine Klammern vorhanden sind, ist die ``Auswertungsreihenfolge`` von *links* nach *rechts*. 

Wieso erzeugt jedoch *duString + firstInt * secondInt - thirdInt + fourthInt* einen Fehler? 

```java
System.out.println(duString + firstInt * secondInt - thirdInt + fourthInt); // Wir beginnen links und interpretieren + als Concatenation
System.out.println("du" + 35 * secondInt - thirdInt + fourthInt); // "du" + 35 ist "du35"
System.out.println("du35" * secondInt - thirdInt + fourthInt); // wir starten wieder links und haben "du35" * secondInt. * hat keine Bedeutung bei Strings.
... Fehler
```

Wir merken uns:
> Die ``Auswertungsreihenfolge`` legt die *Bedeutung* eines ``Ausdrucks`` fest. 

> Es gelten die *KlaBuStri* regeln aus der Mathematik. Diese müssen jedoch um die Vielzahl der noch nicht erwähnten ``Operatoren`` erweitert werden.

## Welche Operatoren gibt es?
TODO
Unterschiedliche Bedeutungen von Operatoren haben zur Folge, dass verschiedene Namen für diese existieren. Diese unterschiedlichen Bedeutungen sind meistens aufgrund der Typen der Werte, welche in eine Variable "reinfließen" bzw. "rausfließen".

Wir unterscheiden folgende Operatoren:

### Operatoren, welche den Typ erhalten:

- **String-Operatoren:**
    - `+`: concatenate bedeutet, Zeichen bzw. Zeichenketten zusammenzufügen.
- **Arithmetische Operatoren:**
    - `+`, `-`, `*`, `/`, `%` bei Variablen, welche Zahlen darstellen.
- **Logische (oder auch boolesche) Operatoren:**
    - `!`, `||`, `&&`: Dies sind beispielsweise das logische Nicht, logische Und, logische Oder und exklusives Oder.
- **Bitweise Operatoren:**
    - `|`, `&`, `^`, `~`, `<<`, `>>`, `>>>`: Bitweise Operatoren nehmen die binäre Darstellung einer Zahl und verknüpfen diese bitweise. Beispiel:

```java
System.out.println(5 & 6); // 101 & 110 = 100 (Ergebnis: 4)
```

### Operatoren, welche den Typ nicht erhalten:

- **Vergleichsoperatoren:**
    - `==`, `<`, `>`, `<=`, `>=`, `instanceof`
    - Beispiel:

```java
System.out.println(10 > 5); // true
```

- **Zuweisungsoperatoren:**
    - Java hat nur einen direkten Zuweisungsoperator: `=`
    - Beispiel:

```java
int a = 10;
```

- **Gemischte Operatoren:**
    - `+=`, `-=`, `*=`, `/=`: Kombination aus Zuweisung und arithmetischen Operatoren.
    - `++`, `--`: Inkrement- und Dekrementoperatoren (z.B. `x = x + 1`).
    - Beispiel:

```java
int x = 5;
x += 3; // x = 8
System.out.println(x);
```

- **Selbst definierte Operatoren:**
    - Das ist in Java nicht möglich (in C++ schon). Wir können jedoch Methoden erstellen, welche ein ähnliches Verhalten abbilden.

### Unäre, binäre und tertiäre Operatoren:

Wir unterscheiden zudem in unäre, binäre und tertiäre Operatoren. Diese Kategorisierung gibt an, wie viele Inputs diese annehmen.
Achtung, damit ist nicht deren Verkettung gemeint, sondern wirklich ein Operator nimmt 1, 2 oder 3 Inputs an.

- **Unärer Operator:**

```java
System.out.println(!true); // false
```

- **Binäre Operatoren:**

Hier sind sogar zwei binäre Operatoren (* und =) dargestellt. Eine neuen abgekürzte schreibweise durch einen gemischten Operator ist zudem dargestellt.

```java
firstInt = firstInt * 10; // binärer arithmetischer Operator * sowie der Zuweisungsoperator =
System.out.println(firstInt *= 10); // 
```

Hier ist eine Kombination aus beidem: Ein unärer Operator `nicht` mit Symbol `!` und der binäre Operator `logisches und` mit dem Symbol `&&`.

**Achtung!** Der Operator `&` bedeutet "bitweises und"!

```java
Boolean firstBoolean = false;
Boolean ergebnis = !( firstBoolean && firstBoolean);
```

- **Tertiärer Operator:**
Diese besprechen wir genauer in ``L06Verzweigungen``, da dieser ``Operator`` eigentlich eine ``Verzweigung`` ist. Hier jedoch ein kurzes Beispiel für interessierte.

```java
int a = 5;
int b = 10;
int min = (a < b) ? a : b;
System.out.println(min); // 5
```

---

## Zeichen(ketten) Operatoren

Das gewohnte `+`:

```java
System.out.println( "hallo" + " " + "wir " + "verknüpfen" + " Strings");
```

Wir können hier auch Character mit Strings verknüpfen:

```java
System.out.println("Zeichenkette" + ' ' + "getrennt mit einem Character");
```

Ein weniger generischer Anwendungsfall ist der, wenn wir `"` und `'` in einem Text darstellen wollen:

```java
System.out.println("'" + " das geht in dem wir die Symbole verdrehen " + '"');
```

**Achtung!** Hier ist `"'"` ein Character. Wir können also nicht `"undnochmehr'` schreiben, da dies eine Zeichenkette wäre.

---

## Arithmetische Operatoren

**Typ des Inputs:** `[Zahl, Zahl]`  
**Typ des Outputs:** `[Zahl]`

Arithmetisch bedeutet hier "grundlegende Operationen auf Zahlen bezogen". Streng genommen sind auch die booleschen Operatoren arithmetisch, aber wir verwenden den Begriff, um auf `+`, `-`, `*` und `/` bei Zahlen zu verweisen.

**Wichtig:** Operatoren können überladen werden. Das bedeutet, ein Operator wie `/` kann mehrere Bedeutungen haben. Schauen wir uns dazu folgendes an:

```java
Double meinErsterDouble = 2.0;
Integer meinErsteInteger = 2;
Integer meinZweiterInteger = 5;
```

Wir erwarten hier die Zahl `2.5`, bekommen aber `2`:

```java
System.out.println( meinZweiterInteger / meinErsteInteger);
```

Was wir meinen ist folgendes:

```java
System.out.println( meinZweiterInteger / meinErsterDouble );
```

Wir haben als Input zwei `Integer` und bekommen einen `Integer` zurück. Das bedeutet, die Division erfolgt ohne Nachkommastellen:

```java
System.out.println( 5 / 2 );
```

Den Rest einer Division können wir mit dem Modulo-Operator `%` berechnen:

```java
System.out.println( 5 % 2 );
```

Um eine "Fließkomma-Division" zu erzwingen, müssen wir dem Operator einen anderen Typ als Input geben. Wenn eine der Eingaben eine Kommazahl ist, interpretiert Java dies als `double`:

```java
System.out.println( 5 / 2. );  // double
System.out.println( 5 / 2.0);  // double
System.out.println( 5 / 2D);   // double
System.out.println( 5 / 2d);   // double
System.out.println( 5 / 2F);   // float
System.out.println( 5 / 2f);   // float
```

Ein übersichtlicherer Weg, Operatoren darzustellen, ist durch Methoden. Hier ist die `divideExact`-Methode verwendet worden:

```java
System.out.println( Math.divideExact(5, 2) );
```

## Logische Operatoren

**Typ des Inputs:**  `[Boolean, Boolean]`  
**Typ des Outputs:** `[Boolean]`

Logische Operatoren verknüpfen Variablen vom Typ `boolean`, also Wahrheitswerte. Solche Ausdrücke steuern den Ablauf eines Programms.

Ein Beispiel:
> "Wenn `i` kleiner als 6 und die Eingabe vom User eine Stadt in Europa ist, dann brich das Programm ab."

Mehr Anwendungen dazu gibt es bei [Verzweigungen]() und [Schleifen]().

- **`!` (nicht)**:
  - Negiert eine Aussage (z.B. `!wahr` wird zu `falsch`).
  - Komplexe Aussagen müssen in Klammern gesetzt werden: `!(a && b)`.
- **`&&` (und)**:
  - Nur wenn beide Input-Variablen `true` sind, ist der Output `true`.
  - Wird genutzt, wenn alle ``Atome`` erfüllt sein müssen (alle Puzzelsteine zusammen ergeben das Bild), z.B.:
    ```java
    boolean userBerechtigt = true; // ein Atom
    boolean userAktiv = true; // das nächste Atom usw.
    boolean ausweisHinterlegt = true;
    boolean alterErlaubt = true;
    boolean zugangErlaubt = userBerechtigt && userAktiv && ausweisHinterlegt && alterErlaubt;
    ```
- **`||` (oder)**:
  - Wenn eine der Input-Variablen `true` ist, ist der Output `true`.
  - Wird genutzt, wenn mindestens eine Bedingung erfüllt sein muss (jedes ``Atom`` alleine führt zum Ziel), z.B.:
    ```java
    boolean genugPunkte = false;
    boolean genugZeit = true;
    boolean genugGeld = false;
    boolean spielWeiter = (genugPunkte || genugGeld) && genugZeit;
    ```
---

## Bitweise Operatoren

**Typ des Inputs:** `[Integer, Integer]`  
**Typ des Outputs:** `[Integer]`

Bitweise Operatoren arbeiten auf der binären Darstellung von Zahlen. Sie vergleichen Bit für Bit.

### Beispiel:
```java
Integer bitwise = 6 & 5;
System.out.println("Bitwise: " + bitwise);
```

**Erklärung:**
- `6` ist binär `110`.
- `5` ist binär `101`.
- `6 & 5` vergleicht jedes Bit:
  - `1 UND 1` ergibt `1`
  - `1 UND 0` ergibt `0`
  - `0 UND 1` ergibt `0`
- Ergebnis: `100` (binär) = `4` (dezimal).

### Weitere bitweise Operatoren:
- **`|` (bitweises ODER)**: Ein Bit wird auf `1` gesetzt, wenn mindestens eines der Bits `1` ist.
- **`^` (bitweises exklusives ODER)**: Ein Bit wird auf `1` gesetzt, wenn die beiden Eingabe-Bits unterschiedlich sind.

### Übung:
Stelle deine ITN-Nummer binär dar und verknüpfe sie mit `|`, `&` und `^` mit einer anderen ITN-Nummer. Rechne das Ergebnis in eine Dezimalzahl um.

## Vergleichsoperatoren
**Typ des Inputs:**  `[X, Y]`  
**Typ des Outputs:** `[Boolean]`

Wir sehen, ein unbekannter Typ X, wird mit einem anderen Typ Y verglichen (Input kann auch vom selben Typ sein).
Danach ist aber das Ergebnis IMMER vom Typ Boolean!
Wir können also Vergleichsoperatoren verwenden, um dessen Ergebnis mit logischen Operatoren weiter zu verknüpfen.
Konzeptionell stellen Vergleichsoperatoren immer eine ja/nein-Frage. "Ist die 8 größer als 7?" -> "ja".

Schauen wir uns zuerst "==" an.
ACHTUNG! Nicht mit dem Zuweisungsoperator "=" verwechseln!
Wir stellen bei "==" uns die Frage "ist 7 dasselbe wie 8?"
Auch "!=" ist möglich. Hier ist die Frage "ist 7 nicht das dasselbe wie 8?"
Wir werden später bei komplexeren Datentypen (Objekte) sehen, dass wir mit == wirklich das SELBE meinen und nicht das GLEICHE.

```java
Integer a = 10;
Integer b = 10;
Integer c = 20;

System.out.println("a == b: " + (a == b));
System.out.println("a == c: " + (a == c));
System.out.println("a != c: " + !(a == c));
System.out.println("a != c: " + (a != c));
```

```java
String str1 = "hello";
String str2 = "hello";
// hier greifen wir ein wenig vor... aber damit wir uns hier was komisches anschauen können
String str3 = new String("hello");

System.out.println("str1 == str2: " + (str1 == str2));
System.out.println("str1 das SELBE wie str3: " + (str1 == str3)); // ?
```

Wir sehen, wenn wir das Gleiche abfragen wollen, also interessiert an den Eigenschaften sind,
z.B. "steht der gleiche Text in 2 Strings"? Dann müssen wir mit `<nameVonTyp1>.equals(<nameVonTyp2>);` schreiben.
Das geht nur, wenn die verwendete Variable auch ein Objekt ist, also nicht bei z.B. `boolean` vs. `Boolean` oder `int` vs. `Integer`.
Wir werden das aber näher behandeln, wenn wir Variablen umwandeln.

```java
System.out.println("str1 das GLEICHE wie str3: " + str1.equals(str3));
```

Nun schauen wir uns die angesprochene Verbindung mit logischen Operatoren (und auch arithmetischen) an.
Alles ein Puzzle, was wir zusammenstecken müssen. Die Teile sind die Typen der Operatoren.
Wichtig ist, wenn ein Operator einen booleschen Wert (wahr oder falsch) erzeugt, können wir diesen weiter
mit logischen Operatoren verknüpfen. Das sehen wir im folgenden Beispiel.

```java
String correctUsername = "admin";
String correctPassword = "password123";
Boolean active = true;
Integer userMessage = 248;
Integer saltForHash = 145;
Boolean ausweisHinterlegt = true;
Integer alter = 19;

String username = correctUsername; // Ändere diesen Text auf "TODO CHANGE THIS";
String password = correctPassword; // Ändere diesen Text auf "TODO CHANGE THIS";

result = false;

result = username.equals(correctUsername + "das ist ein gehackter Teil des Textes") &&
         password.equals(correctPassword) &&
         active &&
         (userMessage & saltForHash) % 2 == 0 &&
         ausweisHinterlegt &&
         alter > 18;

System.out.println(result);
```

Ähnlich dazu ist kleiner `"5 < 6"`, größer `"8 > 8"`, sowie die kleiner oder gleich `"<="` bzw. größer oder gleich `">="` Operatoren.
Ein weiterer Vergleichsoperator ist `instanceof`. Dieser ist nur als Anmerkung hier angeführt, da wir diesen erst in der Objektorientierung verwenden werden:
Es soll nur ein Beispiel sein, dass es auch andere, "abstraktere" Operatoren geben kann.

Entschuldigung für das Missverständnis! Hier ist der Text mit den korrekten Anpassungen, bei denen ` ``` ` durch ````` ersetzt wurde:

## Gemischte Operatoren

### Zuweisung und Arithmetische Operatoren

Wir haben mit diesen die Möglichkeit, eine Zuweisung und eine arithmetische Operation mit einem Operator durchzuführen.
Beginnen wir mit:
- `+=`, `-=`, `*=`, `/=`: Diese sind eine Kombination aus Zuweisung und arithmetischen Operatoren.
Diese verwenden den arithmetischen Operator, der am Anfang steht, und den Zuweisungsoperator.

```java
// Wir können also
alter = alter + 25;
System.out.println(alter);

// mit folgendem Ausdruck ersetzen.
alter += 25;
System.out.println(alter);

// Gleiches gilt für
System.out.println(alter /= 2);
```

### Inkrement und Dekrement

Als Nächstes schauen wir uns Inkremente und Dekremente an.
Ein Inkrement bedeutet eine Erhöhung um eine Einheit, ein Dekrement eine Verringerung um eine Einheit.
- `++`, `--`: Diese werden Inkrement- und Dekrement-Operatoren genannt und sind eine Kombination aus `x = x + 1`.
Diese sind ähnlich zu `+=`, jedoch spezieller. Wir zählen immer 1 dazu oder ziehen 1 ab.

```java
// Folgendes ist also
alter = alter + 1;
System.out.println(alter);

// Als Inkrement geschrieben
alter++;
System.out.println(alter);

// und nun als Dekrement.
alter--;
System.out.println(alter);
```

Dieser Operator ist also ein unärer Operator wie das `!`. Ansonsten waren bisher alle Operatoren binär.
Es gibt hier noch eine Anmerkung zu den Inkrement/Dekrement-Operatoren:
Wir können beide schreiben, und es wird das Gleiche ausgegeben.

```java
System.out.println("start here:");
alter = 25;
alter++;
System.out.println(alter);

++alter;
alter = alter + 1;
System.out.println(alter);
```

Der Unterschied ist subtil und hier nicht erkennbar. Schauen wir uns jedoch Folgendes an:
Wir wollen nicht immer doppelt `alter++;` und danach die Ausgabe schreiben.
Geht das nicht in einer Zeile? Die Antwort ist ja, aber:

```java
System.out.println("Das momentane Alter ist: " + alter);
System.out.println("und jetzt erhöhen wir es auf: " + alter++);
System.out.println("wieso erst jetzt? " + alter);
```

Schreiben wir es ohne Dekrement-Operator, sondern als zwei separate Operationen:

```java
System.out.println("Zuweisung und Erhöhung separat: " + (alter = alter + 1) );
System.out.println("Das momentane Alter ist: " + alter);
```

Komisch. Das Verhalten ist hier zwischen `alter++` und `alter = alter + 1` verschieden.
`alter++` gibt die Änderung der Variable nicht sofort an die übergebene Methode weiter!
Die Variable wird aber um 1 erhöht und gespeichert.
In der gleichen Zeile können wir jedoch nicht auf den erhöhten Wert zugreifen.

Mit `alter = alter + 1` passiert aber alles sofort.
Wir können das Verhalten mit `++alter` erzeugen.

```java
System.out.println("Inkrement mit ++alter: " + ++alter );
System.out.println("Das momentane Alter ist: " + alter);
```

### Schachteln von Inkrement und Dekrement

Wir können auch den `++` und `--` Operator nicht hintereinander schachteln wie `+` und `-`.
Zum Beispiel schachteln wir hier:

```java
Integer index = 0;
System.out.println(((index+1)+1)+1);
System.out.println(index);
```

Hier mit Zuweisung, damit am Schluss die Berechnung des Index erhalten bleibt:

```java
index = 0;
System.out.println(index = ((index+1)+1)+1);
System.out.println(index);
```

Aber folgendes geht nicht. JAVA will damit "unklare" Befehlsabfolgen verhindern.

```java
System.out.println(++(++(++index)));
// Ansonsten könnte folgender Ausdruck möglich sein? Wann hier was ausgeführt wird, ist nicht ganz offensichtlich und kann eine Grundlage für Bugs sein.
System.out.println((++((++index)++))++);
```

## Operatoren vs. Methoden

In der Praxis werden Operatoren meist bei Zahlen verwendet und Methoden für alles andere.
In C++ oder C# können auch Operatoren "überladen" werden. Zum Beispiel kann das `+` Symbol für das Kombinieren von eigenen Klassen verwendet werden.
ASCII - Tabelle -> gibt Nummer rein, hier 195 und gibt das Symbol an dieser Stelle aus. `a -> 97, b -> 98, usw.`

Wenn wir Methoden verwenden, haben wir einen Aufruf eines Operators versteckt.
Der `.` nach der Variable oder des Typs ist der Mitgliedszugriffsoperator bzw. nur Zugriffsoperator.
Dieser ist ein unärer Operator, der die Variable oder den Typ nimmt und uns erlaubt, die Methoden aufzurufen. Genaueres aber später.

```java
Integer zahl = (((97 + 98) + 82) + 16);
Integer andereZahl = Math.addExact(97, 98);
Integer neueZahl1 = Math.addExact(andereZahl, 82);
Integer neueZahl2 = Math.addExact(neueZahl1, 16);
Integer andereZahl2 = Math.addExact(Math.addExact(97, 98), 82);
```

Wir verwenden hier `Integer` und nicht `int`, weil es einfacher für uns ist, da wir damit schon mit Objekten in Berührung kommen.
Denn Kommazahlen sind Objekte und haben dementsprechend Methoden für die weitere Verarbeitung zur Verfügung.

```java
Double kommazahl = zahl.doubleValue();
```

