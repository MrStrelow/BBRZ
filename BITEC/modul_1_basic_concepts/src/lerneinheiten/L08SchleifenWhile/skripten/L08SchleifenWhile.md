# Codewiederholung mit der While-Schleife

#### Welche Begriffe werden hier verwendet?
[``Wert``](../../../glossar.md#wert), [``Variable``](../../../glossar.md#variable), [``Typ``](../../../glossar.md#typ),  [``logische Formel``](../../../glossar.md#logische-formel), [``Kontrollstruktur``](../../../glossar.md#kontrollstruktur), [``Anweisung``](../../../glossar.md#anweisung), [``Ausdruck``](../../../glossar.md#ausdruck), [``Bedingung``](../../../glossar.md#bedingung), [``Verzweigung``](../../../glossar.md#bedingung), [``Block``](../../../glossar.md#bedingung), [``Zweig``](../../../glossar.md#zweig) [``While-Schleife``](../../../glossar.md#while-schleife), [``Schleife``](../../../glossar.md#schleife), [``Zählvariable``](../../../glossar.md#zählvariable), [``break``](../../../glossar.md#break), [``continue``](../../../glossar.md#continue), [``Zuständigkeit eines Blocks``](../../../glossar.md#zuständigkeit-eines-blocks), [``Do-While-Schleife``](../../../glossar.md#wo-while-schleife), [``Auswertungsreihenfolge``](../../../glossar.md#auswertungsreihenfolge).

Wir haben 4 Grundlegende Werkzeuge erwähnt welche wir brauchen um Programme schreiben zu können.
Diese sind:
* ✅ Variablen 
* ✅ Operatoren (bzw. Methoden aufrufen) 
* ✅ Verzweigungen und Bedingte Ausdrücke
* ➡️ Schleifen

Wir beginnen nun mit unserer ersten Schleife. Diese so genannte ``While-Schleife`` erlaubt uns im Prinzip alles zu tun was wir auch mit anderen ``Schleifen`` erreichen können. Varianten von ``Schleifen`` als Werkzeug gesehen, sind nur in gewissen Situationen passender oder weniger passend.

## Warum Schleifen?
Schauen wir uns folgenden Code an:
```java
System.out.println("🙂");
System.out.println("🙂");
System.out.println("🙂");
System.out.println("🙂");
```

Dieser wiederholt 4 mal die Ausgabe des ``Strings`` *🙂*. Wie oft aber soll jedoch ein solches *Wiederholen* geschehen, wenn wir die Anzahl der Wiederholungen nicht im vorhinein wissen? Ein Beispiel dafür wäre jede Interaktion mit einem User. Wir wissen nicht wie oft ein User eine *falsche* Eingabe tätigen wird. Wir können ohne ``Schleifen`` ein solches Problem nicht lösen. 

Versuchen wir nun ein Programm zu schreiben welches den User eine Zahl eingeben lässt und so oft *'🙂'* ausgibt.
Wir müssten ohne Schleifen dazu eine *unendlich lange Verzweigung* schreiben.

```java
Scanner scanner = new Scanner(System.in);
Integer userInput = Integer.parseInt(scanner.nextLine());

switch (userInput) {
    case 1 -> System.out.print("🙂");
    case 2 -> System.out.print("🙂🙂");
    case 3 -> System.out.print("🙂🙂🙂");
    case 4 -> System.out.print("🙂🙂🙂🙂");
    case...
    case 2_147_483_647 -> System.out.print("🙂🙂🙂🙂🙂🙂🙂🙂🙂🙂🙂🙂....");
    default -> System.out.println("Ohne Schleifen nicht sinnvoll lösbar.");
}
```

**Anmerkung:** *"🙂".repeat(userInput)* kann hier verwendet werden um sich das Schreiben einer ``Schleife`` zu ersparen. Schleifen sind jedoch so allgemein, dass wir *"alles"* damit programmieren können. Falls es nicht wie hier durch *"🙂".repeat(userInput)* eine Lösung des Problems bereits gibt, müssen wir auf ``Schleifen`` als ``Kontrollstruktur`` zurückgreifen.

Wir merken uns:
> Ohne ``Schleifen`` müssten wir für die Lösung mancher Probleme unendlich lange ``Programme`` schreiben, was nicht umsetzbar ist.

## Was benötige ich um eine While-Schleife zu schreiben?
Hier nun die *allgemeinste* Schleife. Die ``While-Schleife``. *Allgemein* bedeutet hier, dass alle anderen Schleifen, als diese dargestellt werden können.

Die Essenz einer ``While-Schleife`` ist ein Wiederholen eines Teils des Codes, bis eine ``logische Bedingung`` nicht mehr erfüllt ist. Hier ist diese *zaehlvariable < 3*. Solange diese ``Bedingung`` erfüllt ist, also auf *true* auswertet, wird der Code welcher im ``Block`` unterhalb der ``While-Schleife`` ist, ausgeführt. In diesem ``Block`` steht *System.out.println("🙂");* und *zaehlvariable = zaehlvariable + 1;*.

```java
int zaehlvariable = 0; // Zählvariable beginnt oft bei 0 - Grund für uns: Arrays, welche wir noch nicht kennen.

While (zaehlvariable < 5) { // Start des Blocks
    System.out.println("🙂");

    zaehlvariable = zaehlvariable + 1; // Inkrement der Zählvariable
}
```

Wir merken uns:
> Eine ``While-Schleife`` wiederholt den Code des zugehörigen ``Blocks`` solange bis die ``Bedingung`` nicht mehr erfüllt ist.

### Wenn die Schleife enldich ($n<\infty$) Wiederholungen hat
Eine ``Zählvariable`` ist eine ``Variable`` welche zählt *wie oft* die ``Schleife`` ausgeführt wurde. Diese wird meist mit "i" für **I***ndex* geschrieben. Das obige Beispiel für eine ``While-Schleife`` ist eine welche eine ``Zählvariable`` verwendet. Wenn wir eine solche verwenden, wissen wir meist wie oft wir etwas wiederholen wollen. In dem obigen Fall ist es *3* mal. Wir nennen zudem die *Eröhung* der ``Zählvariable`` am Schluss der ``Schleife`` das *Inkrement* dieser. Wir inkrementieren damit am Ende der ``Schleife`` als letzte ``Anweisung`` diese um *1* und zählen damit wie oft die Schleife ausgeführt wurde. Die ``Bedingung`` muss nun diese Zählvariable beinhalten. Ansonsten zählen wir zwar, aber brechen die ``Schleife`` nicht nach 3 Wiederholungen ab.

Wenn wir eine ``Zählvariable`` verwenden ist fast immer eine andere Art der Schleife zu bevorzugen. Die Konzepte hier sind jedoch 1 zu 1 dort Anwendbar.

Wir merken uns ohne zu wissen was eine ``For-Schleife``:
> Eine ``Zählvariable`` zählt wie oft eine ``Schleife`` ausgeführt wird. Die ``Zählvariable`` muss in der ``Bedingung`` enthalten sein.

> Wenn eine ``Variable`` um *1* erhöht wird, nennen wir es ein ``Inkrement``.

> Wenn eine ``Zählvariable`` welche nie unendlich $\infty$ werden kann vorkommt, verwenden wir eine ``For-Schleife`` anstatt einer ``While-Schleife``.

#### Ich zähle von 0 bis 4, du von 107 bis 111, wer anderer von 4 bis 0
Es ist wichtig wie oft eine ``Schleife`` ausgeführt wird. Wenn wir eine ``Zählvariable`` verwenden ist jedoch der ``Wert`` dieser meist unwichtig. Nur das *"3 Mal wiederholen"* der ``Schleife`` ist wichtig. Zählen wir *händisch* für den folgenden Code, wie wir eine ``Schleife`` zum Abbruch nach 5 Wiederholungen bringen.

```java
int i = 0; // Zählvariable beginnt oft bei 0 - Grund für uns: Arrays, welche wir noch nicht kennen.

While (i < 5) { // Start des Blocks
    System.out.println("🙂");

    i = i + 1; // Inkrement der Zählvariable
}
```

| Anzahl Wiederholungen | Wert von *i* vor der **einmaligen** Ausführung des Blocks | Ausgabe | Wert *nach* der **einmaligen ** Ausführung des Blocks | Bedingung vor der **einmaligen** Ausführung des Blocks  : i < 5 |
|------------------------|-------------------------------|---------|--------------------------------| ---- |
| 1                      | 0                             | 🙂       | 1                             | ✅ 0 < 5 |
| 2                      | 1                             | 🙂       | 2                             | ✅ 1 < 5 |
| 3                      | 2                             | 🙂       | 3                             | ✅ 2 < 5 |
| 4                      | 3                             | 🙂       | 4                             | ✅ 3 < 5 |
| 5                      | 4                             | 🙂       | 5                             | ✅ 4 < 5 |
| 5                      | 5                             |           | 5                            | ❌ 5 < 5 |

Wir merken uns:
> Der ``Block`` der ``Schleife`` wird betreten, wenn die ``Bedingung`` *wahr* ist. 

> Die ``Bedingung`` muss vor dem 1. betreten des ``Blocks`` der ``Schleife`` *wahr* sein.

Wir versuchen nun eine ähnliche Tabelle für folgenden Code zu erzeugen.
```java
int i = 0; 

While (i <= 5) { // Änderung: i < 5 wurde zu i <= 5
    System.out.println("🙂");

    i = i + 1; 
}
```

| Anzahl Wiederholungen | Wert von *i* vor der **einmaligen** Ausführung des Blocks | Ausgabe | Wert *nach* der **einmaligen ** Ausführung des Blocks | Bedingung vor der **einmaligen** Ausführung des Blocks  : i < 5 |
|------------------------|-------------------------------|---------|--------------------------------| ---- |
| 1                      | 0                             | 🙂       | 1                             | ✅ 0 <= 5 |
| 2                      | 1                             | 🙂       | 2                             | ✅ 1 <= 5 |
| 3                      | 2                             | 🙂       | 3                             | ✅ 2 <= 5 |
| 4                      | 3                             | 🙂       | 4                             | ✅ 3 <= 5 |
| 5                      | 4                             | 🙂       | 5                             | ✅ 4 <= 5 |
| 6                      | 5                             | 🙂       | 6                            | ✅ 5 <= 5 |
| 6                      | 6                             |           | 6                            | ❌ 6 <= 5 |

Es wird also diese Schleife *6* mal ausgeführt. Die vorherige nur *5* mal. Wie schaffen wir es wieder *5* Wiederholungen zu haben, ohne dem ``Vergleichsoperator`` zu verändern? Versuchen wir folgendes.

```java
int i = 1; // Änderung: i = 0 wurde zu i = 1

While (i <= 5) { 
    System.out.println("🙂");

    i = i + 1; 
}
```

| Anzahl Wiederholungen | Wert von *i* vor der **einmaligen** Ausführung des Blocks | Ausgabe | Wert *nach* der **einmaligen ** Ausführung des Blocks | Bedingung vor der **einmaligen** Ausführung des Blocks  : i <= 5 |
|------------------------|-------------------------------|---------|--------------------------------| ---- |
| 1                      | 1                             | 🙂       | 2                             | ✅ 1 <= 5 |
| 2                      | 2                             | 🙂       | 3                             | ✅ 2 <= 5 |
| 3                      | 3                             | 🙂       | 4                             | ✅ 3 <= 5 |
| 4                      | 4                             | 🙂       | 5                             | ✅ 4 <= 5 |
| 5                      | 5                             | 🙂       | 6                             | ✅ 5 <= 5 |
| 6                      | 6                             |           | 6                            | ❌ 6 <= 5 |

Wir sehen, wir haben wieder *5* Wiederholungen des ``Blocks`` der ``Schleife``.

Schauen wir uns nun eine eher unnütze Zählweise an, jedoch welche auch *5* Wiederholungen des ``Blocks`` der ``Schleife`` erzeugt.

```java
int i = 107; // Änderung: i = 0 wurde zu i = 1

While (i < 112) { 
    System.out.println("🙂");

    i = i + 1; 
}
```

| Anzahl Wiederholungen | Wert von *i* vor der **einmaligen** Ausführung des Blocks | Ausgabe | Wert *nach* der **einmaligen ** Ausführung des Blocks | Bedingung vor der **einmaligen** Ausführung des Blocks  : i < 112 |
|------------------------|-------------------------------|---------|--------------------------------| ---- |
| 1                      | 107                             | 🙂       | 108                             | ✅ 107 < 112 |
| 2                      | 108                             | 🙂       | 109                             | ✅ 108 < 112 |
| 3                      | 109                             | 🙂       | 110                             | ✅ 109 < 112 |
| 4                      | 110                             | 🙂       | 111                             | ✅ 110 < 112 |
| 5                      | 111                             | 🙂       | 112                             | ✅ 111 < 112 |
| 6                      | 112                             |           | 112                             | ❌ 112 < 112 |

Wir sehen, wir haben wieder *5* Wiederholungen des ``Blocks`` der ``Schleife``.

```java
int i = 5; // Änderung: i = 0 wurde zu i = 5

While (i > 0) { 
    System.out.println("🙂");

    i = i - 1; // Änderung: i = i + 1 wurde zu i = i -1
}
```

Die Verringerung von *i* um eins wird ``Dekrement`` genannt.

| Anzahl Wiederholungen | Wert von *i* vor der **einmaligen** Ausführung des Blocks | Ausgabe | Wert *nach* der **einmaligen ** Ausführung des Blocks | Bedingung vor der **einmaligen** Ausführung des Blocks  : i > 0 |
|------------------------|-------------------------------|---------|--------------------------------| ---- |
| 1                      | 5                             | 🙂       | 4                             | ✅ 5 > 0 |
| 2                      | 4                             | 🙂       | 3                             | ✅ 4 > 0 |
| 3                      | 3                             | 🙂       | 2                             | ✅ 3 > 0 |
| 4                      | 2                             | 🙂       | 1                             | ✅ 2 > 0 |
| 5                      | 1                             | 🙂       | 0                             | ✅ 1 > 0 |
| 6                      | 0                             |           | 0                             | ❌ 0 > 0 |

Wir sehen, wir haben wieder *5* Wiederholungen des ``Blocks`` der ``Schleife``.
Jedoch ist hier die Richtung der Zählweise umgedereht worden. Diese ist für manche Probleme praktisch, wie z.B. dem umdrehen eines Musters. Mehr dazu in der Lerneinheit zur ```For-Schleife``. Es soll also aus
```
⬜🔹🔹🔹🔹
⬜⬜🔹🔹🔹
⬜⬜⬜🔹🔹
⬜⬜⬜⬜🔹
⬜⬜⬜⬜⬜
```
dieses Muster werden.
```
⬜⬜⬜⬜⬜
⬜⬜⬜⬜🔹
⬜⬜⬜🔹🔹
⬜⬜🔹🔹🔹
⬜🔹🔹🔹🔹
```     

Wir merken uns:
> Die Anzahl der Wiederholungen einer ``Schleife`` ist nicht an eine bestimmte zählweise gebunden. Wir zählen jedoch fast immer die ``Zählvariable`` von ``0`` bis ``n`` oder von ``n`` bis ``0``.

> Wenn die ``Zählvariable`` von ``0`` bis ``n`` gezählt wird, muss die ``Zählvariable`` ``inkrementiert`` werden.

> Wenn die ``Zählvariable`` von  ``n`` bis ``0`` gezählt wird, muss die ``Zählvariable`` ``dekrementiert`` werden.

### Wenn die Schleife unendlich ($\infty$) Wiederholungen haben kann
Wenn nicht klar ist, ob der ``Block`` **innerhalb** der ``Schleife`` **unendlich oft** ausgeführt wird, verwenden wir eine ``While-Schleife``. Schauen wir uns ein Beispiel an. Hier wird das Alter vom User eingegeben und erst wenn dieses "plausibel" ist, machen wir mit dem ``Block`` **nach** der ``Schleife`` weiter.

```java
System.out.print("Bitte Alter eingeben: ");
Integer alter = Integer.parseInt(scanner.nextLine());

While ( alter < 18 || alter > 120) {
    System.out.print("Bitte korrektes Alter eingeben: ");
    alter = Integer.parseInt(scanner.nextLine());
}
```

Unser Problem hier ist wir wissen nicht, wie oft die ``Zuweisung`` der ``Variable`` alter durch *Integer.parseInt(scanner.nextLine());* passieren wird.


**Anmerkung:** Beachte hier die ``Bedingung`` der ``Schleife``! Sind die beiden ``Bedingungen`` die gleichen?
Versuche es mit einer Wahrheitstabelle zu überprüfen! Denke an ``Guard Clauses``.
```java
System.out.print("Bitte Alter eingeben: ");
alter = Integer.parseInt(scanner.nextLine());

While ( !(alter >= 5 && alter <= 120) ) {
    System.out.print("Bitte korrektes Alter eingeben: ");
    alter = Integer.parseInt(scanner.nextLine());
}
```

Wir merken uns:
> Wenn der ``Block`` der ``Schleife`` **möglicherweise** unendlich oft ausgeführt wird, verwenden wir eine ``While-Schleife``.

#### ... kann dann auch die Schleife unendlich oft ausgeführt werden?
Die kurze Antwort ist, ja. Genauer ist damit ist gemeint, dass die ``Bedingung`` **für immer** auf *true* auswertet. Die einfachste ``Bedingung`` wo so etwas zutrifft ist der ``Ausdruck`` *true*.

```java
While (true) {
    System.out.println("das ist der letzte Durchlauf... oder?");
}
```

#### break und continue - gut oder schlecht?
Ist damit die ``Bedingung`` direkt mit dem ``Wert`` *true* niemals zu verwenden? Nicht wenn wir folgendes ``Keyword`` verwenden. ``break``. Wir kennen ``break`` bereits aus der ``Switch-Anweisung``. Diese erlaubt uns aus dem ``Block`` zu springen falls ein *case* zutrifft. Ansonsten würden alle anderen *cases* auch ausgeführt werden. 

Wir können hier mit ``break`` aus der ``Schleife`` springen, egal ob die ``Bedingung`` erfüllt ist.

```java
While (true) {
    System.out.println("sind wir hier für immer?... ");
    break;
}
```

Ein weiteres ``keyword`` ist ``condinue``. Dieses ist ähnlich wie ``break`` verwendet, jedoch springen wir nicht **aus** dem ``Block``, sondern "starten den ``Block`` neu". Wir steuern somit eine Art Neustart der Schleifendurchlaufs. Wir verwenden ``continue`` wenn wir z.B. eine Usereingabe nicht gültig ist, und wir neu nachfragen wollen, aber nicht den Code unterhalb von ``continue`` ausführen wollen.

Es kann in manchen Situationen sinnvoll sein ``break`` zu verwenden, anstatt eine extra ``Variable`` einzuführen, welche wir als ``Bedingung`` verwenden. Auch spielt die ``Guard-Clause`` sehr in die ``Logik`` von ``break`` und ``continue``.Folgender Code ist kompakter und übersichtlicher 

```java
Scanner scanner = new Scanner(System.in);

// Zuständigkeit: stelle sicher dass das Passwort passt und wiederhole die Eingabe.
while (true) {
    System.out.print("Gib ein Passwort ein: ");
    String passwort = scanner.nextLine();

    if (passwort.length() < 8) {
        System.out.println("❌ Zu kurz (mind. 8 Zeichen)");
        continue;
    }

    if (!passwort.matches(".*\\d.*")) {
        System.out.println("❌ Muss mindestens eine Zahl enthalten");
        continue;
    }

    if (passwort.equals("12345678")) {
        System.out.println("❌ Dieses Passwort ist zu unsicher");
        continue;
    }

    System.out.println("✅ Passwort akzeptiert");
    break;
}
```

als dieser Code.

```java
Scanner scanner = new Scanner(System.in);
boolean akzeptiert = false;

while (!akzeptiert) {
    System.out.print("Gib ein Passwort ein: ");
    String passwort = scanner.nextLine();

    if (passwort.length() >= 8) {
        if (passwort.matches(".*\\d.*")) {
            if (!passwort.equals("12345678")) {
                System.out.println("✅ Passwort akzeptiert");
                akzeptiert = true;
            } else {
                System.out.println("❌ Dieses Passwort ist zu unsicher");
            }
        } else {
            System.out.println("❌ Muss mindestens eine Zahl enthalten");
        }
    } else {
        System.out.println("❌ Zu kurz (mind. 8 Zeichen)");
    }
}

```

Das ist natürlich übertrieben, denn hier ist die ``Verschachtelung`` der ``Mehrfachverzweigung`` das Problem und weniger die ``Schleife``.  Folgender Code ist ähnlich übersichtlich wie jener mit ``break`` und ``continue``. Falls wir eine ähnlich übersichtliche Variante finden welche ohne ``break`` und ``continue`` auskommt, sollten wir diese verwenden.
 
```java
Scanner scanner = new Scanner(System.in);
boolean passwortAkzeptiert = false;

while (!passwortAkzeptiert) {
    System.out.print("Gib ein Passwort ein: ");
    String passwort = scanner.nextLine();

    boolean istZuKurz = passwort.length() < 8;
    boolean keineZahl = !passwort.matches(".*\\d.*");
    boolean unsicheresPasswort = passwort.equals("12345678");

    if (istZuKurz) {
        System.out.println("❌ Zu kurz (mind. 8 Zeichen)");

    } else if (keineZahl) {
        System.out.println("❌ Muss mindestens eine Zahl enthalten");

    } else if (unsicheresPasswort) {
        System.out.println("❌ Dieses Passwort ist zu unsicher");

    } else {
        System.out.println("✅ Passwort akzeptiert");
        passwortAkzeptiert = true;
    }
}
```

Wir merken uns:
> Wir springen aus den ``Block`` einer ``Schleife`` mit dem ``keyword`` ``break``.

> Wir *können* ``break`` in einer ``Schleife`` verwenden, wenn uns klar ist welche``Pfade`` in einer ``Verzweigung`` zum Abbruch einer ``Schleife`` führen und diese **nicht** ``verschachtelt`` ist.

> Wenn eine ``Guard Clause`` innerhalb einer ``Schleife`` verwendet wird, **kann** ``break`` verwendet werden um die Schleife zu verlassen.

**Anmerkung:** Da wir aus dem ``Block`` mit dem ``keyword`` ``break``springen, wird Code welcher unterhal von ``break`` und ``continue`` steht nie ausgeführt. 

```java
While (true) {
    System.out.println("sind wir hier für immer?... ");
    break;
    int a = 1+1; // Wird nie ausgeführt
}
```

```java 
int i = 0;

While (i<10) {
    System.out.println("Hallo " + i);
    i++;
    continue;
    int a = 1+1; // Wird nie ausgeführt
}
```

## Zuständigkeiten eines Bocks
Wir betrachten folgenden Code:

```java
Scanner scanner = new Scanner(System.in);

// Was ist die Aufgabe dieser Schleife? Überprüfen und "wichtigen" Code ausführen...
while (true) {
    System.out.print("Bitte gib eine ganze Zahl ein: ");

    if (!scanner.hasNextInt()) {
        System.out.println("Das war keine gültige Zahl!");
        scanner.next(); // ungültige Eingabe verbrauchen
        continue;       // Schleife neu starten
    }

    int userEingabe = scanner.nextInt();
    // ... wichtiger Code welcher nur wiederholt werden soll, wenn der user eine korrekte Zahl eingibt.
}
```

Wir können diesen Code jedoch schöner schreiben, denn wenn wir an ``Zuständigkeiten`` eins ``Blocks`` im Code denken, mischen wir hier zwei. Der *wichtige* code welcher wiederholt werden soll und die *Überprüfung* ob die Eingabe ein Ganze Zahl ist. Wir sollten diese trennen und erhalten eine ``Schleife`` welche kein ``continue`` benötigt.

```java
// Zuständigkeit: Überprüfung
while (true) {
    System.out.print("Bitte gib eine ganze Zahl ein: ");
    int userEingabe;

    if (scanner.hasNextInt()) {
        userEingabe = scanner.nextInt();

    } else {
        System.out.println("Ungültige Eingabe.");
        scanner.next(); // verbrauchen
    }
}

// Zuständigkeit: Wichtiger Code welcher nur ausgeführt weden soll, wenn UserEingabe eine ganze Zahl ist.
while (...) {
    ...
}
```

Wir merken uns:
> Die ``Zuständigkeit`` eines ``Blocks`` soll eindeutig in einem ``Kommentar`` erfasst werden können. 

> Die ``Keywords`` ``continue`` und ``break`` können auf Fehler in der Zuteilung der ``Zuständigkeiten`` einer ``Kontrolstruktur`` hinweisen. 

> Wir überlegen uns ``Zuständigkeiten`` eines ``Blocks`` bevor wir diesen implementieren und erfassen diese ``Zuständigkeiten`` in ``Kommentaren``.

## Experimente: Auf der Suche nach der Do-While-Schleife
Schauen wir uns zuerst folgendes Scenario an. Wir schreiben eine ``While-Schleife``, welche aufgrund eines User-Inputs entscheiden soll, ob die ``Schleifer`` weiter fortgeführt werden soll, oder nicht.
Sagen wir der user soll so lange eine Zahl raten bis diese erraten wurde. Diese Zahl ist zwischen 1 und 100.

```java
Scanner scanner = new Scanner(System.in);
Random random = new Random();

int draw = random.nextInt(101);
int trials = 0;
int guess;

System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");

While (true) {
    guess = Integer.parseInt(scanner.nextLine());
    String hint;
    trials++;

    if (guess > draw) {
        hint = "groß";
        System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");

    } else if (guess < draw) {
        hint = "klein";
        System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");

    } else { // guess == draw
        System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");
        break;
    }
}
```

Es fallen uns hier 2 Dinge auf:
    * Die ``While-Schleife`` müssen wir mittels ``break`` beenden. Wir benötigen dazu keine ``Bedingung`` in der ``While-Schleife``. Eine häufige bzw. verschachtelte Verwendung von ``break`` und ``continue`` macht den Code unleserlich und schwer wartbar.
    * An sich wird die Steuerung, ob die Schleife beendet wird in der Bedingung der ``While-Schleife`` gesteuert. Da wir mit ``break`` arbeiten brauchen wir zusätzliche ``If-Verzweigungen``. Diese sind aber möglicherweise nicht in diesem Ausmaß notwendig.

Versuchen wir es nun ohne break zu schreiben.
```java
Scanner scanner = new Scanner(System.in);
Random random = new Random();

int draw = random.nextInt(101);
int trials = 0;
System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");

int guess = Integer.parseInt(scanner.nextLine());
String hint;
trials++;

if (guess > draw) {
    hint = "groß";
    System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");

} else if (guess < draw) {
    hint = "klein";
    System.out.println("Inkorrekt! - Zahl ist zu  " + hint + "!");

} else {
    System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");
}

While (guess != draw) {
    guess = Integer.parseInt(scanner.nextLine());
    trials++;

    if (guess > draw) {
        hint = "groß";
        System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");

    } else if (guess < draw) {
        hint = "klein";
        System.out.println("Inkorrekt! - Zahl ist zu  " + hint + "!");

    } else {
        System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");
    }
}
```

Wir stoßen hier aber auf ein Problem. Wir können nicht *guess* und *draw* vergleichen, wenn wir *guess* erst innerhalb des ``BLocks`` der ``Schleife`` zum ersten Mal ``initialisieren``. Bedeutet wir können, um dieses Problem zu umgehen außerhalb der Schleife "ein mal" den gesamten Inhalt dieser ausführen. Das führt jedoch zu doppelten Code. Wir können dies ein wenig kürzer schreiben, jedoch das Problem verschwindet nicht. Dieses ist, dass wir einmal am Anfang eine Eingabe des Users benötigen, um die Logik der ``Schleife`` für beliebige Wiederholungen zu implementieren.

Wir können jedoch einen Standardwert für den "guess" festlegen. Dieser muss aber mit Sicherheit *guess != draw* garantieren! Ansonsten ist das Spiel sofort gewonnen! Hier ist dies einfach, da wir den User nur zwischen 1 und 100 raten lassen. Wir können also guess auf einen Wert außerhalb legen (z.B. *-5*), um sicherzustellen, dass *guess* und *draw* unterschiedlich sind.

Wir sehen, dass in diesem Fall die ``While-Schleife`` mit Aufwand und dadurch mit potenziellen Fehlern verbunden ist.

Wir können nun weiters die ``IF-Anweisung`` versuchen zu vereinfachen. Wenn die ``Bedingung`` nicht erfüllt ist, muss *guess == draw* gelten. Dadurch wissen wir, dass nach der ``While-Schleife`` der Spieler die Zahl erraten hat.
Wir können dadurch den else-``Zweig`` und das ``break`` entfernen.

Wir sehen jetzt, dass wir in beiden *IF's* die gleiche ``Methode`` *sout* steht. Wir können somit einen ``If-Ausdruck`` verwenden. **Achtung!** Wir haben hier aber einen Fehler eingebaut! Welcher? Gewinne dazu das Spiel um es zu sehen.

```java
Scanner scanner = new Scanner(System.in);
Random random = new Random();

int draw = random.nextInt(101);
System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");
int guess = -5;
int trials = 0;

While (guess != draw) {
    guess = Integer.parseInt(scanner.nextLine());

    hint = guess > draw ? "groß" : "klein";
    System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");

    trials++;
}

System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");
```

Der Fehler war, dass wir hier eine ``Mehrfachverzweigung`` in einen ``If-Ausdruck`` umgewandelt haben. Wir haben jedoch *guess != draw* als ``Bedingung`` der ``Schleife``. Es sollte also wenn wir gewonnen *guess == draw* haben die ``Schleife`` abbrechen. Jedoch passiert das immer nur am *Anfang* des ``Blocks`` bis dieser komplett ausgeführt wird. Es wird also auch wenn wir gewinnen ausgegeben *System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");*

Um diesen Fehler ausbessern zu können, müssen wir eine ``If-Bedingung`` mit ``Bedingung`` *guess != draw* einführen.
```java
Scanner scanner = new Scanner(System.in);
Random random = new Random();

int draw = random.nextInt(101);
System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");
int guess = -5;
int trials = 0;

While (guess != draw) {
    guess = Integer.parseInt(scanner.nextLine());

    if (guess != draw) {
        hint = guess > draw ? "groß" : "klein";
        System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");
    }

    trials++;
}
```

Es schaut aber komisch aus, denn wir haben bereits die gleiche ``Bedingung``, welche in der ``If-Bedingung`` ist
in der ``While-Schleife`` geschrieben. Wir haben jedoch das Problem, dass nach der Überprüfung der ``Bedingung`` der ``Schleife`` *guess != draw* unser relevanter Input erst nach dieser Überprüfung eingelesen wird.

Versuchen wir deshalb folgendes: Schieben wir den User-Input ans Ende der Schleife,
dann wird im nächsten Schritt der passende User-Input in der While Bedingung verglichen.

**Achtung!:** Leider ist auch hier ein Fehler. Beginne das Spiel um diesen zu sehen.

```java
Scanner scanner = new Scanner(System.in);
Random random = new Random();

int draw = random.nextInt(101);
System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");
int guess = -5;
int trials = 0;

While (guess != draw) {
    hint = guess > draw ? "groß" : "klein";
    System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");

    guess = Integer.parseInt(scanner.nextLine());

    trials++;
}

System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");
```

Der Fehler war folgendes. Wir vergleichen den standard Wert von "guess", welcher "-5" ist, während des ersten Schleifendurchlaufs. Dies erzeugt immer einen falschen Vergleich.

Wir kommen also unserem Problem nicht aus, dass wir ein Problem mit der ``Auswertungsreihenfolge`` von der ``Bedingung`` der ``Schleife`` und der Zuweisung der ``Variablen`` haben.

Eine Möglichkeit das zu umgehen ist die erste ``Iteration`` der ``Schleife`` auszuschalten. Dies ist auch mit einem
*if()* innerhalb der ``Schleife`` möglich. Jedoch sind meist sogenannte "of by one Conditions" wenn möglich zu vermeiden. "Off by one" bedeutet hier, der Code der ``Schleife`` ist korrekt für alle Wiederholungen, jedoch nicht für den 1. oder letzten. Diese verursachen zusätzlichen Code, wie hier das "if(trials > 0)" dargestellt wird.

```java
Scanner scanner = new Scanner(System.in);
Random random = new Random();

int draw = random.nextInt(101);
System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");
int guess = -5;
int trials = 0;

While (guess != draw) {
    if (trials > 0) {
        hint = guess > draw ? "groß" : "klein";
        System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");
    }

    guess = Integer.parseInt(scanner.nextLine());

    trials++;
}

System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");
```

### Die Do-While Schleife
Eine kleine Vereinfachung erlaubt uns die Do-``While-Schleife``. Damit können wir in diesem Fall:
- doppelten Code vermeiden,
- pre (vorher) initialisierung von guess,
- ABER nicht die ``If-Verzweigungen``.

Zuerst schauen wir uns aber die Syntax der ``Do-While-Schleife`` an.
Es wird zuerst einmal der ``Block`` der ``Schleife`` ausgeführt, und erst danach die ``Bedingung`` überprüft.
Dadurch haben wir kein Problem mit der Weiterverarbeitung der Eingabe des Users.

Wir schreiben nun unser Programm als ``Do-While-Schleife``. Wir beginnen mit dem Keyword *do* und geben das ``keyword`` *While* am Ende der ``Schleife`` hin. Dies soll auf die Überprüfung nach dem einmaligen Ausführen des Codes im ``Block`` der ``Schleife`` hinweisen.

Wir müssen uns nun nicht mehr um die Initialisierung von *guess* kümmern.

**Achtung!** Es muss jedoch leider diese vor der Schleife deklariert werden. Frage: warum?

```java
Scanner scanner = new Scanner(System.in);
Random random = new Random();
int guess; // nur definiert, früher auf -5 initialisiert.
int trials = 0;

int draw = random.nextInt(101);
System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");

do {
    guess = Integer.parseInt(scanner.nextLine());

    if (trials == 0) {
        hint = guess > draw  ? "groß" : "klein";
        System.out.println("Inkorrekt! - Zahl ist zu " + hint + "!");
    }

    trials++;
} While (guess != draw);

System.out.println("Korrekt! Sie haben " + trials + " Versuche benötigt.");
```

Es mag nun die Nützlichkeit der ``Do-While-Schleife`` hier nicht sehr dramatisch ausfallen, was nach dem ganzen Aufbau
ernüchternd erscheinen mag.

Jedoch scheint der Code mit dem ``If-Ausdruck`` nicht "geeignet" zu sein und gehen wieder zurück zur ``If-Anweisung``. Der Grund ist, dass wir nicht "kompakt" den Ausgabetext ergänzen können. Siehe folgendes Beispiel welches **nicht funktioniert**.

```java
Scanner scanner = new Scanner(System.in);
Random random = new Random();

int guess;
int trial = 0;

int draw = random.nextInt(101);
System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");

do {
    System.out.print("Rate eine Zahl: ");
    guess = Integer.parseInt(scanner.nextLine());

    String hint = 
        guess > draw  ? 
        "groß" : 
            guess < draw ?
            "klein" :
             break; // unklar was hier bei einer Zuweisung passiert. Der Compiler lässt es nicht zu. Es wird kein Wert generiert.

    System.out.println("Zahl ist zu " + hint + "!");

    trial++;

} while (guess != draw);

System.out.println("Richtig! Du hast " + trials + " Versuche gebraucht.");
```

Wir ändern es wieder zurück auf eine ``If-Anwiesung``, einer ``Do-While-Schleife`` mit ``break`` um die ``Bedingung`` der ``Schleife`` einfach zu halten. Wir haben hier keine ``Verschachtelungen``, sowie viele "exits" mit ``break``.

```java
Scanner scanner = new Scanner(System.in);
Random random = new Random();

int guess;
int trial = 0;

int draw = random.nextInt(101);
System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");

do {
    System.out.print("Rate eine Zahl: ");
    guess = Integer.parseInt(scanner.nextLine());

    if (guess < draw) {
        System.out.println("Inkorrekt! - Zahl ist zu groß.");

    } else if (versuch > draw) {
        System.out.println("Inkorrekt! - Zahl ist zu klein.");
    }

    trials++;

} while (true);

System.out.println("Richtig! Du hast " + trials + " Versuche gebraucht.");
```

Warum sind wir jedoch noch nicht ganz zufrieden. Der Grund ist, da wir hier nicht *exiplizit* die Ausgabe des Gewinns angeben. Wir erkennen jedoch hier, dass wir nicht immer eine ``Mehrfachverzweigung`` mit ``else`` abschließen müssen. Die ``Bedingung`` der ``Schleife`` ergänzt dann die ``Bedingung`` der ``Verzweigung``. Denke an die ``Zuständigkeiten``, welche hier nicht verteilt sind und nicht eindeutig den ``Konstrollstrukturen`` zugewisen sind.

Wir beenden nun unsere "Experimente" halb frustriert, da wir es nicht so "hinbiegen" können, wie wir uns das vorgestellt haben und verbleiben mit folgender
* ``If-Anwiesung``, einer 
* ``Do-While-Schleife`` mit 
* ``break`` um die ``Bedingung`` der ``Schleife`` einfach zu halten und
* eindeutig zugewiesenen ``Zuständigkeiten``. 

```java
Scanner scanner = new Scanner(System.in);
Random random = new Random();

int guess;
int trial = 0;

int draw = random.nextInt(101);
System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");

// Zuständigkeit: Game Loop - Jede Iteration ist ein Spielzug.
do {
    System.out.print("Rate eine Zahl: ");
    versuch = Integer.parseInt(scanner.nextLine());

    // Zuständigkeit: Was passiert in allen 3 Zweigen mit Bedingungen versuch < draw, versuch > draw und versuch == draw
    if (versuch < draw) {
        System.out.println("Inkorrekt! - Zahl ist zu groß.");

    } else if (versuch > draw) {
        System.out.println("Inkorrekt! - Zahl ist zu klein.");

    } else { // if versuch == draw
        System.out.println("Richtig! Du hast " + trials + " Versuche gebraucht.");
        break;
    }

    trials++;

} while (true);
```

Wir merken uns:
> Wir verwenden ein ``Do-While-Schleife``, wenn wir code einmal ausführen müssen unabhängig von der ``Beindung`` der ``Schleife``.