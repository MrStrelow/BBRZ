# Spezielle Verzweigungen mit Switch Anweisung und Ausdrücke

Wir haben 4 Grundlegende Werkzeuge erwähnt welche wir brauchen um Programme schreiben zu können.
Diese sind:
* ✅ Variablen 
* ✅ Operatoren (bzw. Methoden aufrufen) 
* ✅ Verzweigungen und Bedingungen
* ❔ Schleifen

Der Grund warum wir nun eine weitere ``Verzweigung`` kennenlernen, ist rein um unseren "Wortschatz" aufzubessern. 
An sich können Programme auch ohne ``switch`` ``Anweisugnen`` bzw. ``Ausdrücke`` geschreiben werden. Da ``Switch`` eine speziellere ``Verzweigung`` als die ``If-Verzweigung`` ist, können wir nicht alles mit ``switch`` schreiben was mit ``if`` geht. *Speziellere* Sprachkonstrukte bedeuten aber, dass in passenden Situationen diese leichter lesbar oder effizienter vom Computer umgesetzt werden können.

## Was wollen wir mit einem Switch erreichen?
Diese eignet sich, wenn wir mit dem Vergleichsoperator `==` oder `.equals()` arbeiten. Die Variablen, die wir damit im `switch` vergleichen können, sind ``Strings``, ``Zahlen`` und uns unbekannte ``Enums`` (leider keine Objekte wie z.B. der Scanner).

## Wie schreibe ich eine Verzweigung als Switch Statement?
Die Syntax lautet:
```java
switch (Variable) {
    case Wert:
        // Code
        break;
    default:
        // Code
}
```
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

### Wie schreibe ich eine Switch Verzweigung als Expression (Java 14+):
Kein ``break`` notwendig.
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

### Mehrere Fälle zusammenfassen:
```java
switch (input) {
    case 1 -> System.out.println("Montag :(");
    case 2,3,4,5,6,7 -> System.out.println("jeder andere Tag, außer Montag");
    default -> System.out.println("Kein Wochentag.");
}
```

### Rückgabe mit `switch` (als Ausdruck):
```java
String output = switch (input) {
    case 1 -> "Montag :(";
    case 2 -> "Dienstag";
    case 3 -> "Mittwoch";
    case 4 -> "Donnerstag";
    case 5 -> "Freitag :)";
    case 6 -> "Samstag";
    case 7 -> "Sonntag";
    default -> "kein Wochentag";
};

System.out.println(output);
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

### String-Vergleich mit `switch`

Auch Strings können in einem `switch` verwendet werden:
```java
String wochentag = "Montag";
Integer res;

switch (wochentag) {
    case "Montag":
        res = 1;
        System.out.println("Heute ist Montag");
        break;
    case "Dienstag":
        res = 2;
        System.out.println("Heute ist Dienstag");
        break;
    default:
        res = -1;
        System.out.println("Heute ist irgend ein anderer Tag");
}

System.out.println("res (old Switch): " + res);
```

### Neue Variante mit `yield`
```java
res = switch (wochentag) {
    case "Montag" -> {
        System.out.println("Heute ist Montag");
        yield 1;
    }
    case "Dienstag" -> {
        System.out.println("Heute ist Dienstag");
        yield 2;
    }
    default -> {
        System.out.println("Heute ist irgend ein anderer Tag");
        yield -1;
    }
};

System.out.println("res (new Switch): " + res);
```

Mit dieser Einführung kannst du die `switch`-Verzweigung effektiv nutzen – sowohl in ihrer klassischen Form als auch mit modernen Erweiterungen wie `->` und `yield`.

