# Codewiederholung mit der For-Schleife

#### Welche Begriffe werden hier verwendet?
[``Wert``](../../../glossar.md#wert), [``Variable``](../../../glossar.md#variable), [``Typ``](../../../glossar.md#typ),  [``logische Formel``](../../../glossar.md#logische-formel), [``Kontrollstruktur``](../../../glossar.md#kontrollstruktur), [``Anweisung``](../../../glossar.md#anweisung), [``Ausdruck``](../../../glossar.md#ausdruck), [``Bedingung``](../../../glossar.md#bedingung), [``Verzweigung``](../../../glossar.md#bedingung), [``Block``](../../../glossar.md#bedingung), [``Zweig``](../../../glossar.md#zweig) [``For-Schleife``](../../../glossar.md#while-schleife), [``While-Schleife``](../../../glossar.md#while-schleife), [``Schleife``](../../../glossar.md#schleife), [``Zählvariable``](../../../glossar.md#zählvariable), [``break``](../../../glossar.md#break), [``continue``](../../../glossar.md#continue), [``Zuständigkeit eines Blocks``](../../../glossar.md#zuständigkeit-eines-blocks), [``Auswertungsreihenfolge``](../../../glossar.md#auswertungsreihenfolge), [``Syntax``](../../../glossar.md#syntax).

Wir haben 4 Grundlegende Werkzeuge erwähnt welche wir brauchen um Programme schreiben zu können.
Diese sind:
* ✅ Variablen 
* ✅ Operatoren (bzw. Methoden aufrufen) 
* ✅ Verzweigungen und Bedingte Ausdrücke
* ✅ Schleifen

Wir kennen bereits die ``While-Schleife`` und erinnern uns wenn diese *endlich $n<\infty$* Wiederholungen hat wir die ``For-Schleife`` bevorzugen. Das wäre der Fall wenn wir wissen, dass wir endlich viele *$n<\infty$* user haben, und für jeden eine *überprüfung* durchführen. Wir wissen nicht wie viele Wiederholungen eine ``Schleife`` hat wenn z.B. der User eine korrekte Eingabe tätigen muss. Diese kann theoretisch die Anzahl der Wiederholungen *unendlich* sein. Wir verwenden dort eine ``While-Schleife``.

## Warum eine For-Schleife?
Folgendes ändert sich nicht. Eine ``Schleife`` hat den Sinn einen ``Block`` zu wiederholen, und zwar solange bis eine ``Bedingung`` erfüllt ist. Die ``For-Schleife`` ist spezieller in dem Sinn als die ``While-Schleife``, da jede ```For-Schleife`` mit folgender ``While-Schleife`` (kompakter) geschreiben werden kann.

```java
int zaehlvariable = 0;

while (zaehlvariable < 10) {
    System.out.println("WHILE: wir haben " + zaehlvariable + " mal den Code in der Schleife ausgeführt.");

    zaehlvariable++; // bedeutet i+=1 und das bedeutet i = i + 1;
}
```

```java
for (int zaehlvariable = 0; zaehlvariable < 10; zaehlvariable++) {
    System.out.println("FOR: wir haben " + zaehlvariable + " mal den Code in der Schleife ausgeführt.");
}
```

Die ``While-Schleife`` lässt den Programmierer offen wo der ``Ausdrück`` für die ``Bedingung``, sowie den ``Ausdruck`` der ``Zählvariable`` und dem ``Inkrement``/``Dekrement`` steht. Wir können dadurch unübersichtlichen Code schreiben welcher die erwähnten Konzepte über viele Zeilen verteilt. Um dem Programmierer hier einen "Ort" zu geben wo all diese ``Anweisungen`` stehen, führen wir den ``Schleifenkopf`` ein. Dieser ist nach dem ``keyword`` ``for`` zu finden.

**Anmerkung:** Die ``While-Schleife`` besitzt auch einen ``Schleifenkopf``, dieser erlaubt jedoch nur einen ``Ausdruck`` für die ``Bedingung``.

Wir merken uns:
> Die ``For-Schleife`` ermutigt den Programmierer den ``Ausdrück`` für die ``Bedingung``, sowie den ``Ausdruck`` der ``Zählvariable`` und dem ``Inkrement``/``Dekrement`` im ``Schleifenkopf`` zu  schreiben. 

> Wir trennen innerhalb des ``Schleifenkopfs`` mit dem Semi-Colon *;* die ``Anweisungen``/``Ausdrücke``.

Betrachten wir ein wenig genauer die ``Syntax`` der ``For-Schleife``:
Wir haben 3 Bereiche des ``Schleifenkopfs`` welche mit ";" getrennt sind *for(Bereich1; Bereich2; Bereich3) { ... }*
    *Bereich1*:
        Hier kann eine ``Variable`` ``definiert``  und ``initialisiert`` werden (``Anweisung``). Diese ist die ``Zählvariable``, welche zählt wie oft wir die ``Schleife`` schon ausgeführt haben.
    *Bereich2*:
        Hier muss ``Ausdruck`` sein, welche die ``Bedingung`` der ``Schleife`` darstellt. Diese beinhaltet die in *Bereich1* definierte ``Zählvariable`` (z.B. *i < 5*). Solange diese ``Bedingung`` auf *true* auswertet, wird die ``Schleife`` wiederholt.
    *Bereich3*:
        Hier wird eine ``Anweisung`` erwartet. Dieser kann eine Variable manipulieren. Diese ist meist die Zählvariable aus Bereich1 (i++).
        
**Anmerkung:** 
* Der *Bereich1* kann (sehr selten) leer sein, falls wir die benötigte Variable schon initialisiert haben. Das ist jedoch zu Vermeiden, denn die Idee der ``For-Schleife`` ist es das im ``Schleifenkopf`` zu schreiben.

* Die ``Bedingung`` im *Bereich2* kann direkt hingeschrieben werden (z.B. i < 5), kann aber im Prinzip auch ein beliebiger ``Ausdruck`` sein, welcher eine ``booleschen Wert`` erzeugt. Ein Beispiel wäre eine ``Methode``, welche einen ``booleschen Wert`` zurückgibt.
        
* Der *Bereich3* kann (sehr selten) auch leer sein, falls wir die benötigte Variable an einer anderen Stelle verändert haben. Das ist jedoch zu Vermeiden, denn die Idee der ``For-Schleife`` ist es das im ``Schleifenkopf`` zu schreiben.

* Der *Bereich1* und *Bereich3* erlaubt komisches wie z.B. 
```java
groesseSpielfeld = 10;

for (int zeilen = 0; zeilen < groesseSpielfeld; System.out.println("aha...")) { ... }

int zeilen = 0;
for (System.out.println("ok..."); zeilen < groesseSpielfeld; System.out.println("aha...")) { ... }
```

Da *System.out.println()* eine korrekte ``Anweisung`` ist. Jedoch ist z.B. foglendes nicht vom *Compiler* erlaubt, obwohl *int a = 0;* auch eine korrekte ``Anweisung`` ist. Es sind anscheinend ``Definitionen`` verboten.

```java
for (int zeilen = 0; zeilen < groesseSpielfeld; int a) { ... }
for (int zeilen = 0; zeilen < groesseSpielfeld; int a = 0) { ... }
```

## Es gilt alle andere was wir von der While-Schleife kennen... deshalb... viele Beispiele
### Die Länge eines Strings als Basis für eine Schleife
Wir brauchen folgendes um die Anzahl der Symbole eines Strings ausgeben zu können. *"Wert des Typs string".length*.
```java
String myString = "Diese Symbole werden nun einzeln ausgegeben";

for (int i = 0; i < myString.length(); i++) {
    System.out.println(myString.charAt(i));
}
```

Falls wir größere (> 16 Bit) ``Zeichen`` aus einem *String* lesen wollen, brauchen wir folgendes, da wir mit der Methode ``chatAt()`` nur einen *Character* darstellen können (< 16 Bit).

```java
String myString = "🐻‍❄️🟠🤕🌊🏄🏻‍♂️";

for (int i = 0; i < myString.length(); i++) {
    // System.out.println(myString.charAt(i)); // Error.
    System.out.println(new String(Character.toChars(myString.codePointAt(i)))); 
}
```

### Erzeuge Formen mit For-Schleifen
Hier nun ein paar ``For-Schleifen`` welche Formen auf die Konsole zeichnet.

#### Aufgabe 1:
Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
```
⬜
⬜⬜
⬜⬜⬜
⬜⬜⬜⬜
⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜
```

```java
Integer oberesLimit = 6; // Das Limit wie oft etwas generiert werden soll. Kann z.B. der User eingeben. (Aufgabe 7)

System.out.println("------Aufgabe 1.0------");
System.out.println("Lösung mit zwei verschachtelten Schleifen - ohne die repeat methode eines Strings");

for (int zeilen = 0; zeilen < oberesLimit; zeilen++) {
    for (int spalten = 1; spalten <= zeilen; spalten++) {
        System.out.print("⬜");
    + zeilen + " " + spalten
    }
    System.out.println();
}

System.out.println("Lösung mit einer Schleife - mit der repeat methode");
```

oder 

```java
Integer oberesLimit = 6; // Das Limit wie oft etwas generiert werden soll. Kann z.B. der User eingeben. (Aufgabe 7)

System.out.println("------Aufgabe 1.1------");
System.out.println("Lösung mit zwei verschachtelten Schleifen und einer Verzweigung - ohne die repeat methode eines Strings");

for (int zeilen = 0; zeilen < oberesLimit; zeilen++) {
    for (int spalten = 1; zeilen <=oberesLimit; spalten++) {
        if (spalten <= zeilen) {
            System.out.print("⬜");
        }
    }
    System.out.println();
}
```

Die repeat Methode ist hier eine "kürzere" Variante.
Wir wollen mit der zweite verschachtelten Schleife im obigen Beispiel, zeichen wiederholt, nebeneinander ausgeben.
Das ist der gleiche Anwendungsfall wie die "repeat" Methode.
Hier ist quasi eine Schleife in der repeat Methode versteckt.
Wir haben also immer noch den Fall, dass wir "alle Symbole in der Richtung der Zeilen (y-Achse) und
Richtung der Spalten (x-Achse) abgehen.

```java
Integer oberesLimit = 6; // Das Limit wie oft etwas generiert werden soll. Kann z.B. der User eingeben. (Aufgabe 7)

System.out.println("------Aufgabe 1.3------");
System.out.println("Lösung mit der repeat methode eines Strings");

System.out.println("Lösung mit einer Schleife - mit der repeat methode");
for (int i = 0; i < oberesLimit; i++) {
    System.out.println("⬜".repeat(i));
}
```

#### Aufgabe 2:
Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
```
⬜
⬜⬜
⬜⬜⬜
⬜⬜⬜⬜
⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜
⬜⬜⬜⬜
⬜⬜⬜
⬜⬜
⬜
```

```java
Integer oberesLimit = 6; // Das Limit wie oft etwas generiert werden soll. Kann z.B. der User eingeben. (Aufgabe 7)

System.out.println("------Aufgabe 2------");
System.out.println("Lösung mit zwei verschachtelten Schleifen zwei mal hintereinander - ohne die repeat methode");
for (int zeilen = 1; zeilen <= oberesLimit; zeilen++) {
    for (int spalten = 1; spalten <= zeilen; spalten++) {
        System.out.print("⬜");
    }

    System.out.println();
}

for (int zeilen = oberesLimit-1; zeilen >= 1; zeilen--) {
    for (int spalten = 1; spalten <= zeilen; spalten++) {
        System.out.print("⬜");
    }

    System.out.println();
}
```

```java
Integer oberesLimit = 6; // Das Limit wie oft etwas generiert werden soll. Kann z.B. der User eingeben. (Aufgabe 7)

System.out.println("Lösung mit zwei Schleifen - mit der repeat methode");

for (int i = 1; i <= oberesLimit; i++) {
    System.out.println("⬜".repeat(i));
}

for (int i = oberesLimit - 1; i > 0; i--) {
    System.out.println("⬜".repeat(i));
}
```

```java
Integer oberesLimit = 6; // Das Limit wie oft etwas generiert werden soll. Kann z.B. der User eingeben. (Aufgabe 7)

System.out.println("Lösung mit einer Schleife");
for (int i = 0, j = 6; i <= 2 * oberesLimit - 1; i++ ) {

    if (i > oberesLimit) {
        j = j - 1;
        System.out.println("⬜".repeat(j));

    } else {
        System.out.println("⬜".repeat(i));
    }
}
```

#### Aufgabe 3:
Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
```
🌊
⬜⬜
🌊🌊🌊
⬜⬜⬜⬜
🌊🌊🌊🌊🌊
⬜⬜⬜⬜
🌊🌊🌊🌊🌊
⬜⬜⬜⬜
🌊🌊🌊
⬜⬜
🌊
```

```java
Integer oberesLimit = 6; // Das Limit wie oft etwas generiert werden soll. Kann z.B. der User eingeben. (Aufgabe 7)

System.out.println("------Aufgabe 3------");

for (int i = 0; i < oberesLimit; i++) {

    if (i % 2 == 0) {
        System.out.println("⬜".repeat(i));
    } else {
        System.out.println("🌊".repeat(i));
    }

}

for (int i = oberesLimit - 1; i > 0; i--) { // i -= 1 ODER i-- ODER --i

    if (i % 2 == 0) {
        System.out.println("⬜".repeat(i));
    } else {
        System.out.println("🌊".repeat(i));
    }

}
```

#### Aufgabe 4
Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
```
⬜
⬜⬜⬜
⬜⬜
⬜⬜⬜⬜
⬜⬜⬜
⬜⬜⬜⬜⬜
⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜
```

```java
Integer oberesLimit = 6; // Das Limit wie oft etwas generiert werden soll. Kann z.B. der User eingeben. (Aufgabe 7)

System.out.println("------Aufgabe 4------");
for (int j = 0, i = j; i < oberesLimit * 2; i++) {

    System.out.println("⬜".repeat(j));

    if (i % 2 == 1) {
        j += 2; // bedeutet j = j + 2;
    } else {
        j -= 1; // bedeutet j = j - 1;
    }

}
```


#### Aufgabe 5
Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
```
⬜
⬜⬜⬜
⬜⬜
⬜⬜⬜⬜
⬜⬜⬜
⬜⬜⬜⬜⬜
⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜
⛷️⛷️⛷️⛷️⛷️⛷️
⛷️⛷️⛷️⛷️⛷️⛷️⛷️
⛷️⛷️⛷️⛷️⛷️
⛷️⛷️⛷️⛷️⛷️⛷️
⛷️⛷️⛷️⛷️
⛷️⛷️⛷️⛷️⛷️
⛷️⛷️⛷️
⛷️⛷️⛷️⛷️
⛷️⛷️
⛷️⛷️⛷️
⛷️
```

```java
Integer oberesLimit = 6; // Das Limit wie oft etwas generiert werden soll. Kann z.B. der User eingeben. (Aufgabe 7)

System.out.println("------Aufgabe 5------");
int distance = 1;

int i = 1; // da wir die zählvariablen über 2 Schleifen verteilen definieren wir diese hier.
int j = i + distance; // da wir die zählvariablen über 2 Schleifen verteilen definieren wir diese hier.

int up = distance + 1;
int down = distance;

for (; i <= oberesLimit * 2; i++) {

    if (i % 2 == 0) {
        j += up;
    } else {
        j -= down;
    }

    System.out.println("⬜".repeat(j));
}

for (i = oberesLimit * 2 - 1; i > 0; i--) {

    if (i % 2 == 0) {
        j += down;
    } else {
        j -= up;
    }

    System.out.println("⛷️".repeat(j));

}
```

#### Aufgabe 6
Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
```
🌊
⬜⬜⬜⬜⬜
🌊🌊
⬜⬜⬜⬜⬜⬜
🌊🌊🌊
🤩🤩🤩🤩🤩🤩🤩
🌊🌊🌊🌊
⬜⬜⬜⬜⬜⬜⬜⬜
🌊🌊🌊🌊🌊
⬜⬜⬜⬜⬜⬜⬜⬜⬜
🌊🌊🌊🌊🌊🌊
🤩🤩🤩🤩🤩🤩🤩🤩🤩🤩
🌊🌊🌊🌊🌊🌊
⛷️⛷️⛷️⛷️⛷️⛷️⛷️⛷️⛷️
🌊🌊🌊🌊🌊
⛷️⛷️⛷️⛷️⛷️⛷️⛷️⛷️
🌊🌊🌊🌊
🤕🤕🤕🤕🤕🤕🤕
🌊🌊🌊
⛷️⛷️⛷️⛷️⛷️⛷️
🌊🌊
⛷️⛷️⛷️⛷️⛷️
🌊
```

```java
Integer oberesLimit = 6; // Das Limit wie oft etwas generiert werden soll. Kann z.B. der User eingeben. (Aufgabe 7)

System.out.println("------Aufgabe 6------");
int distance = 3;

int i = 1; // da wir die zählvariablen über 2 Schleifen verteilen definieren wir diese hier.
int j = i + distance; // da wir die zählvariablen über 2 Schleifen verteilen definieren wir diese hier.

int up = distance + 1;
int down = distance;

String schnee = "⬜";
String welle = "🌊";
String schi = "⛷️";
String sad = "🤕";
String happy = "🤩";

String symbolInUse;

for (; i <= oberesLimit * 2; i++) {

    if (i % 2 == 0) {
        j += up;

        if (i % oberesLimit == 0)
            symbolInUse = happy;
        else
            symbolInUse = schnee;

    } else {

        j -= down;
        symbolInUse = welle;

    }

    System.out.println(symbolInUse.repeat(j));

}

for (i = oberesLimit * 2 - 1; i > 0; i--) {

    if (i % 2 == 1) {

        j -= up;
        symbolInUse = welle;

    } else {

        j += down;
        if (i % oberesLimit == 0)
            symbolInUse = sad;
        else
            symbolInUse = schi;

    }

    System.out.println(symbolInUse.repeat(j));

}
```

#### Aufgabe 6.1
Gib das Muster aus Aufgabe 6... aber anders... und zwar ohne verschachtelte if mit guard clause logik.
```java
Integer oberesLimit = 6; // Das Limit wie oft etwas generiert werden soll. Kann z.B. der User eingeben. (Aufgabe 7)

System.out.println("------Aufgabe 6.1------");
int distance = 3;

int i = 1; // da wir die zählvariablen über 2 Schleifen verteilen definieren wir diese hier.
int j = i + distance; // da wir die zählvariablen über 2 Schleifen verteilen definieren wir diese hier.

int up = distance + 1;
int down = distance;

String schnee = "⬜";
String welle = "🌊";
String schi = "⛷️";
String sad = "🤕";
String happy = "🤩";

String symbolInUse;

for (; i <= oberesLimit * 2; i++) {

    if (i % 2 != 0) {
        j -= down;
        System.out.println(welle.repeat(j));
        continue;
    }

    if (i % oberesLimit != 0) {
        j += up;
        System.out.println(schnee.repeat(j));
        continue;
    }

    j += up;
    System.out.println(happy.repeat(j));

}

for (i = oberesLimit * 2 - 1; i > 0; i--) {

    if (i % 2 != 0) {
        j -= up;
        System.out.println(welle.repeat(j));
        continue;
    }

    if (i % oberesLimit != 0) {
        j += down;
        System.out.println(schi.repeat(j));
        continue;
    } 

    j += down;
    System.out.println(sad.repeat(j));

}
```

#### Aufgabe 6.2
Gib das Muster aus Aufgabe 6, mit beliebiger Länge welche vom User bestimmt wird, aus.

```java
System.out.println("------Aufgabe 6.2------");
int distance = 3;

int i = 1; // da wir die zählvariablen über 2 Schleifen verteilen definieren wir diese hier.
int j = i + distance; // da wir die zählvariablen über 2 Schleifen verteilen definieren wir diese hier.

int up = distance + 1;
int down = distance;

String schnee = "⬜";
String welle = "🌊";
String schi = "⛷️";
String sad = "🤕";
String happy = "🤩";

String symbolInUse;

Scanner scanner = new Scanner(System.in);
System.out.print("Wie lange soll das Muster sein? ");
oberesLimit = Integer.parseInt(scanner.nextLine());

i = 1;
j = i + distance;

for (; i <= oberesLimit * 2; i++) {

    if (i % 2 == 0) {
        j += up;

        if (i % oberesLimit == 0)
            symbolInUse = happy;
        else
            symbolInUse = raute;

    } else {

        j -= down;
        symbolInUse = tilde;

    }

    System.out.println(symbolInUse.repeat(j));

}

for (i = oberesLimit * 2 - 1; i > 0; i--) {

    if (i % 2 == 1) {

        j -= up;
        symbolInUse = tilde;

    } else {

        j += down;
        if (i % oberesLimit == 0)
            symbolInUse = sad;
        else
            symbolInUse = plus;

    }

    System.out.println(symbolInUse.repeat(j));

}
```

#### Aufgabe 8 - Christmas Tree
```
         🌲
        🌲🌲
       🌲🌲🌲
      🌲🌲🌲🌲
     🌲🌲🌲🌲🌲
    🌲🌲🌲🌲🌲🌲
   🌲🌲🌲🌲🌲🌲🌲
  🌲🌲🌲🌲🌲🌲🌲🌲
 🌲🌲🌲🌲🌲🌲🌲🌲🌲
🌲🌲🌲🌲🌲🌲🌲🌲🌲🌲
        🟫🟫
        🟫🟫
        🟫🟫
```

```java
System.out.println("------Aufgabe 9------");
Scanner scanner = new Scanner(System.in);
System.out.print("Höhe des Baumes (ohne Stamm): ");
int hoehe = scanner.nextInt();

// Nadeln
for (int i = 1; i <= hoehe; i++) {
    for (int j = hoehe - i; j > 0; j--) {
        System.out.print(" ");
    }

    for (int k = 1; k <= i; k++) {
        System.out.print("🌲");
    }

    System.out.println();
}

// Stamm
for (int i = 1; i <= hoehe/3; i++) {

    System.out.print(" ");

    for (int j = hoehe - 3; j > 0; j--) {
        System.out.print(" ");
    }

    for (int k = 2; k > 0; k--) {
        System.out.print("🟫");
    }

    System.out.println();
}
```