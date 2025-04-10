# Mehrfachverzweigungen mit Switch-Anweisungen und Switch-Ausdrücken

Wir haben 4 Grundlegende Werkzeuge erwähnt welche wir brauchen um Programme schreiben zu können.
Diese sind:
* ✅ Variablen 
* ✅ Operatoren (bzw. Methoden aufrufen) 
* ✅ Verzweigungen und Bedingungen
* ❔ Schleifen

Der Grund warum wir nun eine weitere ``Verzweigung`` kennenlernen, ist rein um unseren "Wortschatz" aufzubessern. 
An sich können Programme auch ohne ``Switch-Anweisugnen`` bzw. ``Ausdrücke`` geschreiben werden. Da ``switch`` eine speziellere ``Verzweigung`` als die ``If-Verzweigung`` ist, können wir nicht alles mit ``switch`` schreiben was mit ``if`` geht. *Speziellere* Sprachkonstrukte bedeuten aber, dass in passenden Situationen diese leichter lesbar oder effizienter vom Computer umgesetzt werden können. Allgemein ist die ``Switch-Anweisung``, sowie der ``Switch-Ausdruck``, nicht essentiell von Bedeutung in JAVA. Wir bereiten uns jedoch damit auf *mächtigere* Ausdrücke wie dem ``Pattern-Matcher`` vor. Diese werden mittels ``Switch-Ausdruck`` in C# oder Python umgesetzt. In Python wird ledeglich das Keyword *match* anstatt *switch* verwendet.

Wir beginnen hier anders als bei der ``If-Verzweigung`` mit dem Variante des ``Ausdrucks``. Der Grund ist die veraltete schreibweise der *klassischen* ``Switch-Anweisung``. Wir behandeln diese kurz später, denn diese hat ein *unerwartetes* Verhalten. 

## Wie schreibe ich eine Verzweigung als Switch-Ausdruck?
Ohne weiters diesen ``Ausdruck`` zu motivieren schauen wir uns die ``Syntax`` an anhand eines Beispiels an.
```java
Integer variable = 5;

String ergebnis = switch (variable) {
    case 1      -> "Die Variable hat den Wert eins";
    case 2, 5   -> "Die Variable hat den Wert zwei oder fünf.";
    default     -> "Die Variable hat nicht den Wert 1, 2 oder 5.";
}

System.out.println(ergebnis); // Die Variable hat den Wert zwei oder fünf.
```

Wir vergleichen den ``Switch-Ausdruck`` mit einem gleichbedeutender ``Mehrfachverzewigung`` welche als ``If-Ausdruck`` mit dem ``?: Operator`` umgesetzt wird. 
```java
Integer variable = 5;

String ergebnis = 
    variable == 1                  ? "Die Variable hat den Wert eins" : 
    variable == 1 || variable == 5 ? "Die Variable hat den Wert zwei oder fünf." : 
                                     "Die Variable hat nicht den Wert 1, 2 oder 5.";
```

Hier bemerken wir folgendes:
> Ein ``Switch-Ausdruck`` vergleicht eine ``Variable`` auf ``Gleichheit`` (*==* bzw. *.equals()*) mit einem ``Wert``. 
> Ist ein Vergleich erfoglreich, wird der entsprechende ``Programmcode`` ausgeführt. 
> Ist *kein* Vergleich erfolgreich, wird der ``Programmcode`` im *default-case* ausgeführt.

Weiters können wir in den *cases* mehrere ``Werte`` angeben. Dies ist eine schnellere schreibweise als wenn diese untereinander in einzelnen ``cases`` behandelt werden.
```java
case 2 -> "Die Variable hat den Wert zwei oder fünf.";
case 5 -> "Die Variable hat den Wert zwei oder fünf.";
```

Wir merken uns:
> Ein ``logisches ODER`` ist durch die Angabe von mehreren ``Werten`` in den *cases* umsetzbar.

**Anmerkung:**: Die eingefügten Tabulatoren (? steht über dem ?´in der näcshten Zeile), dienen der schöneren Lesbarkeit in **diesem Beispiel** hier. Es ist nicht immer möglich einen gut lesbaren Code mittels Tabulatoren oder anderen geometrischen Überlegungen zu erzeugen. Wenn in der Gruppe *professionell* programmiert wird, sollten ``Coding Conventions`` festgelegt werden. Solche legen fest wie der Code aussieht. ``IDEs`` bieten dazu automatisches styling an. Wie diese aussehen werden oft von den Erstellern von Programmiersprachen wie z.B. für JAVA von [Oracle](https://www.oracle.com/java/technologies/javase/codeconventions-contents.html), Python - [PEP 8](https://peps.python.org/pep-0008/) oder C# von [Mircorsoft](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions).

### Brauche ich immer eine Rückgabe? - Switch-Anweisung.
Die Antwort hier ist *nein*. Wir können mit der gleichen ``Syntax`` auch eine ``Anweisung`` schreiben. Dazu lassen wir einfach den ``Zuweisungsoperator`` weg. Der Code welcher nun in jedem *case* ausgeführt wird, muss nun was machen. Wie z.B. eine Ausgabe. Ansosnten verlieren wir das Ergebnis.

```java
Integer variable = 5;

switch (variable) {
    case 1      -> System.out.println("Die Variable hat den Wert eins");
    case 2, 5   -> System.out.println("Die Variable hat den Wert zwei oder fünf.");
    default     -> System.out.println("Die Variable hat nicht den Wert 1, 2 oder 5.");
}
```

### Eine Anweisung verwende ich wenn ich mehr Zeilen schreiben will, geht das hier?
Wie bereits erwähnt gibt es Situationen in denen wir ``Anweisungen`` schreiben wollen. Ein Beispiel dazu ist, wenn wir mehrere Zeilen Code in einem ``Block`` schreiben müssen.

Ein Beispiel, welches wir nicht ganz verstehen müssen. Wir bemerken nur, dass mehrere Zeilen Code innerhalb des *if* benötigen werden. Diese Zeilen können auch nicht außerhalb des *if* stehen. 

```java
User databaseUser = userConnection.findUser(guiUser);
User user;

if(guiUser.kennung().equals("dasIstEineGültigeKennung")) {

    databaseUser.setLastLogin(LocalDateTime.now());
    databaseUser.setActive(true);
    databaseUser.setRememberMe(guiUser.getRememberMe());

    user = userConnection.updateUser(databaseUser);

} else {
    throw new FalscheKennungException(guiUser);
}
```

Wir versuchen nun dies in eine ``Switch-Anweisung`` umzuschreiben. Das dient rein der **Übung** einen If-Ausdruck in einen Switch-Ausdruck umzuschreiben und hat ansonsten keine Vorteile. Wir betrachen später wann ein ``Switch-Anweisung`` bzw. ``Switch-Ausdruck`` sinnvoll ist und wann nicht.

```java
User databaseUser = userConnection.findUser(guiUser);
User user;

String dieZuSwitchendeVariable = guiUser.kennung();

switch(dieZuSwitchendeVariable) {
    case "dasIstEineGültigeKennung" -> {
        databaseUser.setLastLogin(LocalDateTime.now());
        databaseUser.setActive(true);
        databaseUser.setRememberMe(guiUser.getRememberMe());

        user = userConnection.updateUser(databaseUser);
    }
    default -> {
        throw new FalscheKennungException(guiUser);
    }
}
```

Wir merken uns:
> Ein mehrzeiliger *case* einer ``Switch-Anweisung`` kann mit einem neuen ``Block`` *{ ... }* erzeugt werden.

### Kann ich auch mehrzeilige Switch-Ausdrücke schreiben?
Hier ist die Anwort ebenso *ja* und belassen es bei diesem Beispiel.

```java
User databaseUser = userConnection.findUser(guiUser);
String dieZuSwitchendeVariable = guiUser.kennung();

User user = switch(dieZuSwitchendeVariable) {
    case "dasIstEineGültigeKennung" -> {
        databaseUser.setLastLogin(LocalDateTime.now());
        databaseUser.setActive(true);
        databaseUser.setRememberMe(guiUser.getRememberMe());

        yield userConnection.updateUser(databaseUser);
    }
    default -> {
        throw new FalscheKennungException(guiUser);
    }
}
```

Wir merken uns:
> In einem mehrzeiligen *case* eines ``Switch-Ausdrucks`` muss innerhalb des ``Blocks`` *{ ... }* jene ``Variable`` welche *zurückgegeben* wird mit ``yield`` gekennzeichnet werden.

## Welche Typen von Variablen kann ich in einem Switch-Ausdruck verwenden?
### Double? Nein - Keine Bereiche
Ändern wir nun den Typ der ``Variable`` von *String* auf einen *Double*. Wir erinnern uns, dass durch die ``FLießkommadarstellung`` Rundungsfehler entstehen können und wir daher *Bereiche* angeben müssen um einen Vergleich zu tätigen. Wir fragen nicht ``a == b`` ab, sondern beginnen mit ``a - b == 0``. Danach lockern wir das ``== 0`` auf und schreiben z.B ``-0.1 < a - b && a - b < 0.1``. Wir legen also einen Bereich um 0 welcher -0.1 und 0.1 ist. Innerhalb dieses Bereichs sehen wir die Subtraktion ``a - b`` als gleichwertig an. Kürzer geht es mit der *absolut Value* Methode ``Math.abs(a - b)`` welche das Vorzeichen entfernt. Wir müsen damit nur mehr auf "eine Seite" des *Bereichs* abfragen und bekommen ``Math.abs(a - b) < 0.1`` als Bedingung.

Wir sehen jeodch schon das Problem. Dieser Ausdruck ``Math.abs(a - b) < 0.1`` hat nichts mehr mit Gleichheit zu tun und ist deshalb nicht Umsetzbar mit einem ``Switch-Ausdruck`` in **JAVA**. 

**Anmerkung**: Da die Handhabung von Kommazahlen fehleranfällig sein kann ist bei *wichtigen* Berechnungen bzw. Vergleichen eine ``Variable`` des Typs ``BigDecimal`` mit dessen Methode ``compareTo`` zu verwenden. Die Erstellung der Variable ist mittels eines **Strings** und nicht mit einem *Double* zu vollziehen! ``BigDecimal`` ist jedoch langsamer als der primitve ``double``. 

### Boolean? Nein - Keine logischen Ausdrücke
Der Grund kann nicht sein, dass wir diesmal auf einen Bereich abfragen, denn ``true == true`` ist in JAVA möglich. Wir können nun einfach akzeptieren dass es nicht geht und weiter machen. Dieser Fall erlaubt und jedoch kurz über den ``Hintergrund`` der ``Switch-Expresison`` zu sprechen. Der Grund warum die ``Switch-Verzweigung`` eingeschränkt im Vergleich zur ``If-Verzeigung`` ist, hat wenig mit der Lesbarkeit des Codes zu tun. Es hat mit dem Maschinencode welcher im ``Hintergrund`` erzeugt wird  zu tun. Schauen wir uns dazu nochmals die ``Mehrfachverzweigung`` welche mit dem ``?:Operator`` umgesetzt wird an. 

```java
Integer variable = 5;

String ergebnis = 
    variable == 1                  ? "Die Variable hat den Wert eins" : 
    variable == 1 || variable == 5 ? "Die Variable hat den Wert zwei oder fünf." : 
                                     "Die Variable hat nicht den Wert 1, 2 oder 5.";
```

Diese geht schrittweise von oben nach unten TODO


### Was dann?
Wir merken uns:
> ``Switch-Ausdrücke`` haben folgenden Einschränkungen:
> * Der ``Typ`` der ``Variable`` darf nur: *char*, *Character*, *byte*, *Byte*, *short*, *Short*, *int*, *Integer*, *String*, oder *Enum* sein.
> * Der ``Bedingung`` ist auf *==* oder *.equals()* beschränkt.


## Wann verwenden wir einen Switch-Ausdruck?
Wir schreiben diese um vereinfacht ``Bedingungen`` darzustellen, welche den ``Vergleichsoperator`` *==* oder *.equals()* verwenden. Die Variablen, die wir damit im `switch` vergleichen können, sind ``Zeichen(ketten)``, ``Zahlen`` und die uns unbekannte ``Enums``. 

Genauer gesagt, merken wir uns folgendes:
> ``Switch-Statements`` haben folgenden Einschränkungen:
> * Der ``Typ`` der ``Variable`` darf nur: *Enum*, *int*, *Integer*, *String*, *char* oder *Character* sein.
> * Der ``Bedingung`` ist auf *==* oder *.equals()* beschränkt.


## Historisch: Die Switch-Anweisung

### Warum ist break bei der Switch-Anweisung essentiell:
Kein ``break`` notwendig.

```java
switch (Variable) {
    case Wert:
        // Code
        break;
    case Wert:
        // Code
        break;
    default:
        // Code
}


## Wie schreibe ich eine Verzweigung als Switch Anweisung?
Ohne weiters diese ``Anweisung`` zu motivieren schauen wir uns die ``Syntax`` an.
```java
switch (Variable) {
    case Wert:
        // Code
        break;
    case Wert:
        // Code
        break;
    default:
        // Code
}
```

Hier sehen wir.

*Beispiel:* Wochentage ausgeben

Wir haben Wochentage [Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag]:
- Wenn die Integer-Variable den Wert 1 hat, soll "Montag" ausgegeben werden, usw.
- Für "Montag" fügen wir ":(" hinzu, für "Freitag" fügen wir ":)" hinzu.

```java
Scanner scanner = new Scanner(System.in);
System.out.print("Geben Sie eine Zahl zwischen 1 und 7 ein um einen Wochentag zu erhalten: ");
Integer input = Integer.parseInt(scanner.nextLine());

switch (input) {
    case 1: System.out.println("Montag :("); break;
    case 2: System.out.println("Dienstag"); break;
    case 3: System.out.println("Mittwoch"); break;
    case 4: System.out.println("Donnerstag"); break;
    case 5: System.out.println("Freitag :)"); break;
    case 6: System.out.println("Samstag"); break;
    case 7: System.out.println("Sonntag"); break;
    default: System.out.println("Kein Wochentag.");
}
```

```java
String output = switch (input) {
    case 1 -> "Montag :(";
    case 2 -> "Dienstag";
    case 3 -> "Mittwoch";
    case 4 -> "Donnerstag";
    case 5 -> "Freitag :)";
    case 6 -> "Samstag";
    case 7 -> "Sonntag";
    default -> "Kein Wochentag.";
}
```

Wir können uns auch die Rückgabe sparen und diesen Ausdruck als Anweisung verwenden.
```java
switch (input) {
    case 1 -> System.out.println("Montag :(");
    case 2 -> System.out.println("Dienstag");
    case 3 -> System.out.println("Mittwoch");
    case 4 -> System.out.println("Donnerstag");
    case 5 -> System.out.println("Freitag :)");
    case 6 -> System.out.println("Samstag");
    case 7 -> System.out.println("Sonntag");
    default -> System.out.println("Kein Wochentag.");
}
```

### Mehrzeilige Blöcke mit `yield`:
```java
Random random = new Random();
Double zufallszahl = random.nextDouble();
Double zufallszahlJederTag = random.nextDouble();

String output = switch (input) {
    case 1 -> {
        String res = "Montag :)";
        if (zufallszahl < 0.8) {
            res = res + ":(".repeat(5);
        }
        yield res;
    }
    case 2 -> "Dienstag";
    case 3 -> "Mittwoch";
    case 4 -> "Donnerstag";
    case 5 -> {
        String res = "Freitag :)";
        if (zufallszahl < 0.3) {
            res = res + ":)".repeat(7);
        }
        yield res;
    }
    case 6 -> "Samstag";
    case 7 -> "Sonntag";
    default -> "kein Wochentag";
};

if (zufallszahlJederTag < 0.01) {
    System.out.print(output + ":)");
} else {
    System.out.println(output);
}
```