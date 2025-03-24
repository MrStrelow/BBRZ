# Operatoren in Java

Operatoren verknüpfen ``Variablen`` bzw. ``Werte`` miteinander und erzeugen basierend auf diesen einen neuen ``Wert``.

Der folgende *+* ``Operator``, welcher die Bedeutung *"Addition"* hat, verknüpft die Zahlen *35* und *17* und erzeugt den neuen ``Wert`` *52*:

```java
System.out.println(35 + 17);
```

Die Bedeutung eines ``Operators`` ist abhängig vom ``Typ`` der ``Variablen`` bzw. ``Werte``, welche in den ``Operator`` "hineingegeben" werden. Das sehen wir bei dem Ausdruck *"35" + "17"*. Hier hat der Operator `+` nicht die Bedeutung der *"Addition"*, sondern der *"Concatenation"* (zusammenfügen). Wir fügen also die Zeichenkette *"35"* mit der Zeichenkette "17" zusammen, was *"3517"* ergibt:

```java
System.out.println("35" + "17");
```

Das gleiche Verhalten gilt für ``Variablen``:

```java
Integer firstInt = 35;
Integer secondInt = 17;
System.out.println(firstInt + secondInt);

String firstString = "35";
String secondString = "17";
System.out.println(firstString + secondString);
```

Ein aufruf eines ``Operators`` erzeugt einen  ``Wert`` mit einem ``Typ``. Dieses Ergebnis kann direkt mit Operatoren weiter verknüpft werden kann. Es kann also eine Kette gebildet werden:

```java
System.out.println(firstInt + secondInt + firstInt + secondInt);
```

Hier wird die Reihenfolge nicht beachtet, da es bei dem Operator `+`, interpretiert als "Addition", eine vordefinierte Reihenfolge gibt. Diese ist:
1. Zuerst der am weitesten links stehende Ausdruck wird verarbeitet.
2. Dann der eins weiter rechts stehende Ausdruck.
3. Das Ergebnis wird mit dem nächsten rechten Ausdruck verknüpft und so weiter.

Wenn wir die Reihenfolge steuern wollen, muss dies mit einer Klammer gemacht werden. Der nächste Ausdruck ist gleich dem vorherigen, jedoch wird hier die Reihenfolge direkt angegeben:

```java
System.out.println(((firstInt + secondInt) + firstInt) + secondInt);
```

Wir können nun die Reihenfolge ändern, indem wir die Klammern verschieben. Das Ergebnis bleibt jedoch das gleiche, denn bei der Addition ist die Reihenfolge der Auswertung egal:

```java
System.out.println((firstInt + secondInt) + (firstInt + secondInt));
```

Für die anderen arithmetischen Operatoren der Zahlen (`-`, `*`, `/`) gelten die Regeln aus der Mathematik.

## Arten von Operatoren

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

```md
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

