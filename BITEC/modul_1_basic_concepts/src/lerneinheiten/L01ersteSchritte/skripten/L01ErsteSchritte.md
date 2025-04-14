## Erste Schritte in Java

#### Welche Begriffe werden hier verwendet?
[`Programm`](../../../glossar.md#programm), [`Main-Methode`](../../../glossar.md#main-methode), [`Wert`](../../../glossar.md#wert), [`Variable`](../../../glossar.md#Variable), [`Typ`](../../../glossar.md#Typ), [`String`](../../../glossar.md#String), [`Integer`](../../../glossar.md#integer), [`Double`](../../../glossar.md#double), [`Boolean`](../../../glossar.md#boolean), [`deklarieren`](../../../glossar.md#deklarieren), [`initialisieren`](../../../glossar.md#initialisieren), [`definieren`](../../../glossar.md#definieren), [`Zuweisungsoperator`](../../../glossar.md#Zuweisungsoperator)

---

Java ist eine objektorientierte Sprache, welche dadurch am Anfang Dinge verwendet, welche wir noch nicht erklärt haben.
Das bedeutet, wir müssen für unsere ersten Programme folgendes berücksichtigen:

1. Wir müssen unser File, welches den Programmcode enthält, in einem Projekt anlegen.
   Dort wird der Ordner `src`, was "source" also "Quelle" bedeutet, von IntelliJ angelegt.
   Nur innerhalb dieses `src`-Ordners können wir Files erstellen, in denen wir programmieren können.
2. Wir haben ein File angelegt. Dieses ist eine Klasse mit dem Namen `L01ErsteSchritte`.
   Das wird oben mit `public class L01ErsteSchritte` gemacht. Was die orange gefärbten `public` und `class` machen, ist vorerst nicht wichtig.
   Eine Klasse ist für uns erstmal nur eine Umgebung, in der wir den Namen des Programms festhalten.
   In den geschwungenen Klammern wird eine neue Umgebung geschaffen, in der wir weiter arbeiten können. Das gilt auch für zukünftige Programmkonstrukte.
3. Wir erstellen innerhalb der neuen Umgebung, in der Klasse, eine neue Umgebung, in der wir nun programmieren können.
   Das ist die Methode mit dem Namen `main`. Wieder, was die orange gefärbten `public static void` machen, wird in ein paar Monaten besprochen.
   Das `String[] args` ist so weit auch nicht essenziell. Für uns ist es ein Mechanismus, mit dem wir weiter unten in diesem File von "der Außenwelt" Informationen bekommen können.
   Wir brauchen, um mit dem Programmieren anfangen zu können, eine Klasse mit einem beliebigen Namen und eine Methode, die `main` heißt.
   Diese muss GENAU so aussehen wie jene unten. Also `public static void main(String[] args)`. Wird z.B. das `String[] args` gelöscht, bekommen wir Fehler.

```java
public class L01ErsteSchritte {
    public static void main(String[] args) {
        // ... hier Programmieren wir. 
        // Zudem sind die zwei hintereinander geschriebene // ein Kommentar, welches keinen Programmcode darstellt.
    }
}
```

Hier ist nun der Punkt, an dem wir etwas machen können.
Ein häufiges erstes Programm in einer Programmiersprache ist, "Hello World" auszugeben.
Das soll sicherstellen, dass die Sprache bzw. das Setup der Umgebung funktioniert.
Falls hier Fehler auftreten, ist wahrscheinlich bei der Installation des Java Development Kits (`JDK`) oder dem Erstellen der Files (z.B. dieses liegt nicht im `src`-Ordner) etwas schiefgelaufen.

Programme werden von `oben nach unten` gelesen und führen die weiter unten geschriebenen "Befehle" vor jenen aus, welche davor stehen.

Hier geben wir nun etwas auf die Konsole aus. Das wird mit dem Befehl `System.out.println();` gemacht.
Wenn wir "Befehle" verwenden, ist immer in den runden Klammern `()` das reinzuschreiben, was wir dem Befehl geben wollen.
In unserem Fall ist es der `Wert` "Hello World". Ein `Wert` ist ein von der Programmiersprache akzeptierter , welchen wir im Speicher des Programmes finden. Um einen solchen `Wert` für eine spätere Verwendung "ansprechbar" zu machen, müssen wir diesen Wert in eine `Variable` schreiben. 

Tipp: Verwende das Snippet/Kürzel `sout`, um `System.out.println();` zu erhalten. Das erspart dir, die vielen Worte jedes Mal zu tippen.

```java
public class L01ErsteSchritte {
    public static void main(String[] args) {
        System.out.println("Hello World"); // Tippe sout und Intellij wird es dir in System.out.println(); umwandeln.
    }
}
```

Wir wollen aber mehr als nur das machen. In Programmiersprachen gibt es, unter anderem, folgende wichtige Konstrukte:

* `Variablen`, 
* `Verzweigungen`, 
* `Operatoren` und 
* `Schleifen` sind für uns momentan am wichtigsten.

Wir gehen hier auf `Variablen` ein. Diese sind der Baustein aller weiteren Konstrukte, welche wir verwenden.
Eine Variable ist ein Platzhalter für Werte. Anstatt also zu sagen "Hello World", können wir dieses Wort in einer Variable speichern.
Es ist nun zu beachten, welchen `Typ` die `Variable` hat.
Beispielsweise sind `Typen` von Variablen folgende:

- `String`: das sind Wörter (z.B. "Hello World").
- `Integer`: das sind ganze Zahlen (z.B. `-5` und `568`).
- `Double`: das sind Kommazahlen (z.B. `-9.6` und `7.0`).
- `Boolean`: das kann den Wert `true` oder `false` annehmen.

Wir müssen also dem `Programm` irgendwie sagen, dass wir eine Variable anlegen und diese den Typ `String` hat.
Wir machen das so:

```java
public class L01ErsteSchritte {
    public static void main(String[] args) {
        String meinNeuDefinierterString; // Deklariert bzw. definiert

        // Achtung! wird eine Deklarierte Variable verwendet, lässt dies der Compiler nicht zu. 
        // Wir dürfen das Programm nicht "bauen lassen"

        System.out.println("Hello World"); // wir verwenden hier diese Variable, ohne dieser einen Wert zugewiesen zu haben.
    }
}
```

Hier haben wir zuerst den `Typ` hingeschrieben und danach den Namen, welchen wir frei festlegen können.
In Java wird ein "Befehl" mit einem Strichpunkt abgeschlossen.
Wir nennen die obige Zeile im Programm `eine Variable deklarieren` bzw. `definieren`. Beides bedeutet für uns diese wird angelegt, ohne einen Wert festzulegen. Wir werden es hier aber immer `definieren` nennen.

Wenn wir nun diese Variable `initialisieren` wollen, also einen `Wert` festlegen wollen, machen wir das so:

```java
public class L01ErsteSchritte {
    public static void main(String[] args) {
        String meinNeuDeklarierterString;       // definieren
        meinNeuDeklarierterString = "Hello";    // initialisieren
    }
}
```

Hier sprechen wir die `Variable` mit ihrem `Namen` an und weisen ihr einen `Wert` zu.
Strings werden innerhalb von Anführungszeichen `""` geschrieben. Wenn diese vergessen werden, gibt es einen Fehler.

Wenn wir nun direkt eine `Variable` mit `Wert` anlegen wollen, geht das natürlich auch.
Wir nennen das "eine Variable definieren" und es geht folgendermaßen:

```java
public class L01ErsteSchritte {
    public static void main(String[] args) {
        String meinNeuDefinierterString = "World"; // definieren + initialisieren
    }
}
```

Das `=` hier wird `Zuweisungsoperator` genannt. `Operatoren` sind "Befehle", welche es erlauben, `Werte` oder `Variablen` zu kombinieren.
Wir kombinieren also die leere Variable mit Namen `meinNeuDefinierterString` mit dem Wert "World".
Weitere Operatoren sind `.`, `+`, `-`, `*`, `/`, `++`, `--`, `&&`, `||`.
Wir werden diese uns aber zu einem späteren Zeitpunkt anschauen.

Hier verbinden wir die `Variablen` miteinander und fügen dazwischen noch ein Leerzeichen ein:

```java
public class L01ErsteSchritte {
    public static void main(String[] args) {
        String meinNeuDeklarierterString;       // definieren
        meinNeuDeklarierterString = "Hello";    // initialisieren

        String meinNeuDefinierterString = "World"; // definieren + initialisieren

        String meinKombinierterString = meinNeuDefinierterString + " " + meinNeuDeklarierterString; // mit Operator verbinden

        System.out.println(meinKombinierterString);
    }
}
```

Die `Variable` `meinKombinierterString` können wir nun ausgeben.