# Userinteraktion mit der Klasse Scanner

Wir wollen uns in diesem Dokument den Scanner Typ (Klasse) anschauen. Diese erlaubt uns, mit dem User auf der Konsole zu interagieren. Die Konsole ist die Eingabeaufforderung, wo wir normalerweise das Programm starten (`javac` und `java` Befehl). Wir haben in einer Entwicklungsumgebung (IDE - hier IntelliJ) ebenfalls eine Konsole. Das ist der Ort, wo wir Ausgaben des Programmes bis jetzt hingeschrieben haben (`System.out.println`).

Wir können mit dem Scanner nun diesen Ort nutzen, um dort den User eine Eingabe eingeben zu lassen. Wir legen dazu eine Variable `myScanner` an.

Hier sehen wir unser bekanntes "Dreierlei" bzw. wenn wir den Zuweisungsoperator zählen "Viererlei":

`<Typ> <nameDerVariable> <Zuweisungsoperator> <Wert>`

Hier sieht die Art, wie wir den `<Wert>` zuweisen, aber unbekannt aus. Wir haben es schon mal gesehen, aber je öfter, desto besser.

Die rechte Seite des Zuweisungsoperators `=` ist schon ein Konzept aus der Objektorientierung. Wir verwenden das Keyword `new`, um eine neue Variable anzulegen, gefolgt vom Typ der Variable.

In den Klammern können wir noch nähere Spezifikationen vollziehen. (Für jene, welche schon objektorientiert programmiert haben: Hier legen wir ein Objekt `myScanner` an, welches den Konstruktor der Klasse `Scanner` aufruft und diesem ein Argument `System.in` gibt.)

Das lässt vermuten, dass wir nicht nur die Konsole als "Ort der Eingabe" festlegen können, sondern auch z. B. ein Textfile, Word usw.

```java
Scanner myScanner = new Scanner(System.in);
```

Wir können nun den User eine Eingabe tätigen lassen. Dies geschieht mit der Variable `myScanner` und mit dem Zugriffsoperator `.`.

```java
myScanner.nextLine();
```

Dies wartet, bis der User einen Text in die Konsole eingibt und mit der Enter-Taste bestätigt. Geben Sie also eine Zeichenkette in die unten angezeigte Konsole ein.

Um dies ein wenig "schöner" zu gestalten, können wir vorher eine Ausgabe des Programmes erzeugen:

```java
System.out.println("Bitte gib eine Eingabe ein, und bestätigen Sie mit <Enter>: ");
myScanner.nextLine();
```

Dies erlaubt uns, eine ganze Zeile einzulesen. Wir lesen somit alles ein, was der User eingegeben hat, bis wir `"\n"` lesen. Dies ist das Symbol für einen Zeilenumbruch, welches wir durch das Drücken von `<Enter>` erzeugen.

Wir haben aber keine Zuweisung vollzogen. Da `nextLine` eine Methode ist und eine Rückgabe vom Typ `String` erzeugt, können wir diese einer Variable vom Typ `String` zuweisen.

Also... noch einmal:

```java
System.out.println("Bitte gib nocheinmal eine Eingabe ein, und bestätigen Sie mit <Enter>: ");
String meineEingabe = myScanner.nextLine();
```

### Verwendung von Benutzereingaben

Da wir nun die Eingabe des Users einer Variable zugewiesen haben, können wir diese später für weitere Zwecke verwenden.

```java
System.out.println("Deine Eingabe war: " + meineEingabe);
```

## Unterschied zwischen `next` und `nextLine`

Wenn wir uns nun anschauen, welche Methoden alle in `myScanner` vorhanden sind, sehen wir, dass es zwei Arten von `next`-Methoden gibt:

- `next`
- `next<Typ>`
- `nextLine`

Was ist der Unterschied? Probieren wir Folgendes:

```java
System.out.println("Bitte gib nocheinmal eine Eingabe ein, und bestätigen Sie mit <Enter>: ");
meineEingabe = myScanner.next();
```

Auf den ersten Blick scheint nichts anders zu sein, aber versuchen wir nun folgendes:

```java
System.out.println("Bitte gib zwei Zahlen getrennt durch die Leertaste ein z.B. 'a b', und bestätigen Sie mit <Enter>: ");
String meineErsteEingabe = myScanner.next();
String meineZweiteEingabe = myScanner.next();

System.out.println("Meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);
```

## Verhalten von `next` und `nextLine`

Wir sehen nun den Unterschied! Die Methode `nextLine` liest so lange, bis das Haltesymbol `"\n"` vorkommt. Jedoch wird hier das `"\n"` nicht im String gespeichert. Es wird verworfen und der Cursor in die nächste Zeile gesetzt.

Die Methode `next` liest bis zu einem Leerzeichen oder einem `"\n"`, verwirft das `"\n"` aber nicht! Es kann also vorkommen, dass wenn wir `next` und `nextLine` hintereinander verwenden, dadurch ein ungewolltes Verhalten entsteht.

> **Anmerkung:** Genau genommen ist jede Art von Leerzeichen - also Tabulator `\t`, Feed `\f`, Carriage Return `\r` - in dem Muster des Haltesymbols der Methode `next` enthalten.

### Anpassung des Trennzeichens

Wir können dieses Trennzeichen/Haltesymbol für unsere Zwecke anpassen! In diesem Fall ist es `ZZzZZ`.

```java
myScanner.useDelimiter("ZZzZZ");
```

> **Fortgeschritten:** Das anzugebende Muster kann durch eine sogenannte Regular Expression - RegEx - angegeben werden. Wir können damit fast beliebige Textmuster abfragen! Ein Beispiel dafür wäre das Extrahieren von Vor- und Nachnamen aus E-Mail-Adressen.

#### Achtung!

Hier wird nur mehr das Symbol `ZZzZZ` als Haltesymbol verwendet. `"\n"` wird nicht mehr als Trennzeichen genutzt, da wir dieses nicht spezifiziert haben. Wir müssen also, wenn wir `a` und `b` einlesen wollen, `ZZzZZ` hinter `a` und `b` schreiben!

### Verhalten des Scanners mit angepasstem Delimiter

Wenn wir die vorherige Aufgabe mit dem neuen Haltesymbol `ZZzZZ` wiederholen, sollte folgendes passieren:

```java
System.out.println("Bitte gib nochmal zwei Zahlen welches das Haltesymbol ZZzZZ hat ein z.B. 'aZZzZZbZZzZZ', und bestätigen Sie mit <Enter>: ");
meineErsteEingabe = myScanner.next();
meineZweiteEingabe = myScanner.next();

System.out.println("Meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);
```

### Unerwartetes Verhalten durch vorherige Eingaben

Wir sehen jedoch, dass auf einmal `"\na"` in der Variable `meineErsteEingabe` vorkommt. Wir haben noch ein unbearbeitetes `"\n"` von der vorherigen Eingabe "herumliegen". Dieses matcht nun auch für die Methode `next`, da wir den Delimiter so spezifiziert haben, dass dieser nur mehr bei dem Muster `ZZzZZ` hält. Dies ist ein ungewolltes Verhalten!

#### Lösung: `nextLine` zum Bereinigen nutzen

Wenn der Scanner nach `ZZzZZ` oder `\n` halten soll, müssen wir das angeben. Damit wir nicht wieder vom vorherigen Beispiel ein `"\n"` mitnehmen, da wir den Delimiter verändert haben, lesen wir mit einem leeren `nextLine()`-Call alle verbleibenden Zeichen ein und verwerfen sie:

```java
myScanner.nextLine();
```

#### Erneute Eingabe mit angepasstem Delimiter

```java
myScanner.useDelimiter("ZZzZZ|\n");
System.out.println("Bitte gib nochmal zwei Zahlen getrennt durch ZZzZZ ein z.B. 'aZZzZZb', und bestätigen Sie mit <Enter>: ");
meineErsteEingabe = myScanner.next();
meineZweiteEingabe = myScanner.next();

System.out.println("Meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);
```

### Unerwartetes Verhalten bei `next` gefolgt von `nextLine`

Ein weiteres Problem tritt auf, wenn `next` und `nextLine` direkt hintereinander verwendet werden:

```java
System.out.println("Komische Eingabe: ");
meineErsteEingabe = myScanner.next();

System.out.println("Komische zweite Eingabe welche aber übersprungen wird!: ");
meineZweiteEingabe = myScanner.nextLine();
```

Hier wird die Eingabe folgendermaßen aufgeteilt:
- Der eingegebene Text wird bis zum `"\n"` der Variable `meineErsteEingabe` zugewiesen.
- `nextLine` springt aber auch auf das Symbol `"\n"`, ohne weiteren Text einzulesen.
- Bedeutet: Die Variable `meineZweiteEingabe` wird mit `"\n"` belegt, denn eine leere Zeile, welche nur das Symbol `"\n"` besitzt, ist auch eine gültige Zeile.

Um dieses ungewollte Verhalten zu verhindern, müssen wir nach `next` ein `nextLine` einfügen, um das verbleibende `"\n"` zu verwerfen:

```java
System.out.println("Unkomische Eingabe: ");
meineErsteEingabe = myScanner.next();
myScanner.nextLine();

System.out.println("Unkomische zweite Eingabe welche nicht mehr übersprungen wird: ");
meineZweiteEingabe = myScanner.nextLine();
```

## Umgang mit `next` und `nextLine`

Hier wird die Eingabe folgendermaßen aufgeteilt:
- Der eingegebene Text wird bis zum `\n` der Variable `meineErsteEingabe` zugewiesen.
- `nextLine` springt aber auch auf das Symbol `\n`, ohne weiteren Text einzulesen.
- Bedeutet: Die Variable `meineZweiteEingabe` wird mit `\n` belegt, denn eine leere Zeile, welche nur das Symbol `\n` besitzt, ist auch eine gültige Zeile.

Um dieses ungewollte Verhalten zu verhindern, müssen wir:
1) `next` für `meineErsteVariable` verwenden
2) `nextLine` für das übrig gebliebene `\n`
3) `nextLine` für den Text, welchen wir `meineZweiteVariable` zuweisen wollen

### Richtige Nutzung:

```java
System.out.println("Unkomische Eingabe: ");
meineErsteEingabe = myScanner.next();
myScanner.nextLine();

System.out.println("Unkomische zweite Eingabe welche nicht mehr übersprungen wird: ");
meineZweiteEingabe = myScanner.nextLine();
```

## Alternative: Immer `nextLine` verwenden

Eine Variante, welche ein solches Verhalten vermeidet, ist **IMMER** `nextLine` zu verwenden und danach die Variablen entsprechend zu verarbeiten.

```java
System.out.println("Meine ganzzahlige Eingabe, welche aber als 'String' mit 'nextLine' eingelesen wird.");
Integer myInteger = Integer.parseInt(myScanner.nextLine());
```

## Mehrere Eingaben auf einmal verarbeiten

Hier nutzen wir ein Array (`split()`), um mehrere Werte aus einer Zeile zu extrahieren:

```java
System.out.println("Meine doppelte Eingabe 'a b', welche ich danach bearbeite");
String ganzzeiligeEingabe = myScanner.nextLine();

String[] mehrereStrings = ganzzeiligeEingabe.split(" ");
meineErsteEingabe = mehrereStrings[0];
meineZweiteEingabe = mehrereStrings[1];

System.out.println("Meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);
```

## Scanner schließen

Am Schluss müssen wir den Scanner schließen. Dies bedeutet, dass die Verbindung zur Konsole aufgegeben und beendet wird.
Falls wir an einem Server arbeiten oder ein dauerhaft laufendes Programm nutzen, würde ansonsten immer mehr Speicher für offene Verbindungen verwendet.

```java
myScanner.close();
```

### **Achtung!**

- Wenn der Scanner geschlossen wird, kann die Konsole nicht mehr verwendet werden!
- Auch ein neues Anlegen eines Scanners mit `new Scanner(System.in)` funktioniert dann nicht mehr!
- Also **nur den Scanner schließen, wenn er nicht mehr benötigt wird!**

## "Has" Methoden des Scanners
TODO

