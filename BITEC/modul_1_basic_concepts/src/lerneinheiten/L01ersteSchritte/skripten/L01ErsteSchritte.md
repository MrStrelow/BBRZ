# Erste Schritte in Java und Intellij

#### Welche Begriffe werden hier verwendet?
[`Java`](../../../glossar.md#programm), [`Projekt`](../../../glossar.md#programm), [`Programm`](../../../glossar.md#programm), [`Programmiersprache`](../../../glossar.md#programm), [`Main-Methode`](../../../glossar.md#main-methode), [`Entwicklungsumgebung`](../../../glossar.md#main-methode),  [`Intellij`](../../../glossar.md#wert), [`Fehler`](../../../glossar.md#wert), [`Warnung`](../../../glossar.md#wert), [`Wert`](../../../glossar.md#wert), [`Variable`](../../../glossar.md#Variable), [`Typ`](../../../glossar.md#Typ), [`String`](../../../glossar.md#String), [`Integer`](../../../glossar.md#integer), [`Double`](../../../glossar.md#double), [`Boolean`](../../../glossar.md#boolean), [`deklarieren`](../../../glossar.md#deklarieren), [`initialisieren`](../../../glossar.md#initialisieren), [`definieren`](../../../glossar.md#definieren), [`Zuweisungsoperator`](../../../glossar.md#Zuweisungsoperator)

---

## Wie erstelle ich ein Programm?
Unser Ziel fürs erste ist es ein ``Dokument`` zu erstellen, in welchen wir Programmieren können. Da ``Java`` eine objektorientierte ``Programmiersprache`` ist und wir nicht sofort mit objektorientierung beginnen, werden "Dinge" verwendet welche wir vorerste "auswendig lernen" müssen. Die Anzahl dieser hält sich jedoch in Grenzen. 

Um unsere Programme zu schreiben verwenden eine ``Entwicklungsumgebung`` mit Namen ``Intellij``. Wir starten diese und legen dort ein ``Projekt`` an. Ein Projekt ist eine Ansammlung von ``Dokumenten`` in welchen wir Programmieren.

1. Nach dem Start von Intellij sollte ein Fenster geöffnet werden welches einen Button "New Project" hat. 
<p align="center" alt="Hier sollte ein Bild sein welches ein 'neues Projekt auswaehlen' beschreibt">
  <img src="figures/01_neues_projekt_auswählen.png" />
</p>

2. Wähle danach einen Namen für das Projekt und mit einem Pfad den Ort wo dieses am Computer abgelegt wird. Drücke rechts auf das Ordner-Symbol um eine von Windows erzeugte Übersicht zu bekommen.
<p align="center" alt="Hier sollte ein Bild sein welches ein 'neues Projekt anlegen' beschreibt">
  <img src="figures/02_neues_projekt_anlegen.png" />
</p>

3. Wir ignorieren den Text in dem ``Dokument`` *Main.java* und drücken das *grüne Dreieck* rechts oben (oder Shift + F10). Wir führen damit ein ``Programm`` aus. Da wir von ``Intellij`` ein vorgefertigtes bekommen haben, müssen wir nicht zuerst eines schreiben um testen zu können ob ``Intellij`` mit ``Java`` funktioniert. Wir nenen ein solches Testprogramm ``Hello World Programm``. Nach ein paar Sekunden muss unten der im Bild rot *markierte Text* in der ``Konsole`` ausgegeben werden.
<p align="center" alt="Hier sollte ein Bild sein welches ein 'Test programm starten' beschreibt">
  <img src="figures/03_test_programm.png" />
</p>

4. Wir **löschen** nun das ``Dokument`` *Main.java* in der *Projektübersicht* links. Wir legen dies nun neu an und entfernen damit den vorgefertigten Code. Markiere das ``Dokument`` Dürcke dazu die *ENTF* Taste (oder *DEL* auf englisch) auf der Tastatur.
<p align="center" alt="Hier sollte ein Bild sein welches ein 'Projekt übersicht' beschreibt">
  <img src="figures/04_projekt_übersicht.png" />
</p>

5. Wir sehen den ORdner `src` was "source" also "Quelle" bedeutet. Nur innerhalb dieses `src`-Ordners können wir Files erstellen, in denen wir programmieren können.  Wir legen nun innerhalb des `src`-Ordners eine Datei mit der Endung *.java* an (siehe Bild). Dort schreiben wir in die erste Zeile *public class L01ErsteSchritte {}*. Was die orange gefärbten "Dinge" `public` und `class` machen, ist vorerst nicht wichtig. Eine Klasse ist für uns nur eine Umgebung, in der wir den Namen des ``Dokuments`` festhalten. In den *geschwungenen Klammern* wird eine neue Umgebung geschaffen, in welcher wir neues "Dinge" verwenden können.
<p align="center" alt="Hier sollte ein Bild sein welches ein 'neues Dokument anlegen' beschreibt">
  <img src="figures/05_dokument_anlegen.png" />
</p> 

6. Wir erstellen innerhalb der neuen Umgebung *public class L01ErsteSchritte {}*, eine neue Umgebung *public static void main(String[] args) {}*. Nur dort werden wir programmiern. Bezeichnet wird dies eine Methode mit dem Namen `main`. Wieder, was die orange gefärbten *public static void* machen, ist nicht relevant. 

Wir sehen nun folgendes in unserem ``Dokument``.

```java
public class L01ErsteSchritte {                 // Klasse welche genau wie das Dokument heißt (ohne .java).
    public static void main(String[] args) {    // main-Methode
        // ... hier Programmieren wir. 
        // Zudem sind die zwei hintereinander geschriebene // ein Kommentar, welches keinen Programmcode darstellt.
    }
}
```

**Anmerkung:** *String[] args* bietet uns eine Möglichkeit mit "der Außenwelt" zu kommunizieren. Das bedeutet, wenn wir ein Programm ausführen fließt information vom Aufrufer in das Programm hinein.

Wir merken uns:
> Wir erstellen nur ``Dokumente`` in denen wir *programmieren* nur innerhalb des ``src`` Ordners.

> Der Name des ``Dokuments`` und das Wort neben *public class* muss gleich sein.

> Wir *programmieren* vorerst nur innerhalb der ``main-Methode`` welche sich in einer Klasse befindet.

> Text welcher mit *//* oder */**/* startet ist ein ``Kommentar``. Dieses Text ist dadurch nicht Teil der ``Programmiersprache``. 


### Was bedeuten rote Buchstaben und rot- bzw. gelb-gezackte linien?
Wir schauen uns folgendes Bild an:
<p align="center" alt="Hier sollte ein Bild sein welches ein 'Fehler und Warnungen' beschreibt">
  <img src="figures/06_fehler_und_warnungen.png" />
</p> 

Der Computer will uns hier folgendes mitteilen:
> Der geschreibene Text ist nicht Teil der ``Programmiersprache`` wenn der Text **<span style="color:red">rot</span>** geschrieben wird.

> Der geschreibene Text teil der ``Programmiersprache``, ist aber *fehlerhaft* wenn der Text **<span style="color: red; text-decoration: underline;"></span>** geschrieben wird.

> Warnungen sind


## Was mach ich in einem Programm?
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

Die `Variable` `meinKombinierterString` können wir nun ausgeben.´

### Empfehlung: Lege ich jede Übung oder Mitschrift ein Projekt an?  