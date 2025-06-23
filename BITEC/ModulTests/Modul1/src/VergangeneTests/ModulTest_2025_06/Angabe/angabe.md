# Modultest 1 - BITEC

Sie haben `180 Minuten` Zeit die Aufgaben zu lösen
* Sie können maximal 100 Punkte erreichen
* Es sind zur Prüfung zugelassen:
    * Taschenrechner (wenn erwünscht)
    * Transparente Wasserflasche
    * Papier, Geodreieck, Stifte, usw.
    * Am Computer sind alle Unterlagen sowie die Nutzung des Internets erlaubt.

Die Nutzung des Internets umfasst nicht
* Chatbots
* Veröffentlichung der Lösungen
* sonstige Kommunikation mit anderen Usern

Die Nutzung von allen anderen Dingen, muss vorher mit mir abgesprochen werden
(z.B. Nutzung von Ohropax), ansonsten wird dies als schummeln gewertet.
Die Folge des Schummeln ist eine Bewertung mit 0 Punkten.

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 15 nach dem Ende der Prüfung schicken)
* Viel Erfolg! :)

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., (Schulnotensystem)

---

## Aufgabe 1: Arrays [35 / 100 Punkte]

### Programmverständnis [20 / 35 Teilpunkte]
Gegeben ist folgender Code, welcher den ``Bubble Sort`` darstellt.

```java
package VergangeneTests.ModulTest_2025_06.Aufgabe_1;

import java.util.Arrays;

public class Programmieren_02 {
    static String ANSI_RESET = "\u001B[0m";
    static String ANSI_RED = "\u001B[31m";
    static String ANSI_BLUE = "\u001B[34m";
    static String ANSI_YELLOW = "\u001B[33m";
    static String colorOfOuterLoop = ANSI_RED;
    static String colorOfInnerLoop = ANSI_BLUE;

    public static void main(String[] args) {
        int[] zahlen = {53, 5, 2, 26, -86};

        for (int j = 10; j < zahlen.length + 18; j=j+2) {
            System.out.println(colorOfInnerLoop + "Durchgang: " + j + ANSI_RESET);

            for (int i = 0; i <= zahlen.length; j++) {
                if (zahlen[j] < zahlen[i + 1]) {
                    int platzhalter = zahlen[i];
                    zahlen[i + 1] = zahlen[j];
                    platzhalter = zahlen[i];
                }

                // Bunte - Ausgabe
                String zahlenColored = colorAt(
                        zahlen,
                        new int[]{i + 1, i},
                        new String[]{colorOfOuterLoop, colorOfOuterLoop},
                        ANSI_RESET
                );

                System.out.println(
                        "[" +
                                colorOfOuterLoop + "i=" + i + ANSI_RESET + ", " +
                                colorOfInnerLoop + "j=" + j + ANSI_RESET +
                                "]: " +
                                zahlenColored + ANSI_RESET
                );

            }
            System.out.println();
        }

        System.out.println("🏁".repeat(14));
        System.out.println(ANSI_YELLOW + Arrays.toString(zahlen) + ANSI_RESET);
    }

    static String colorAt(int[] zahlen, int[] posToColor, String[] colorOfPos, String baseColor) {
        String[] coloredZahlen = new String[zahlen.length];

        for (int i = 0; i < zahlen.length; i++) {
            coloredZahlen[i] = Integer.toString(zahlen[i]);
        }

        for (int i = 0; i < posToColor.length; i++) {
            coloredZahlen[posToColor[i]] = colorOfPos[i] + zahlen[posToColor[i]] + baseColor;
        }

        return baseColor + Arrays.toString(coloredZahlen);
    }
}
```

Dieses Programm erzeugt, wenn die Fehler behoben wurde folgenden Output:

<div style="text-align: left; ">
    <img src="output_bubbles_farben.png" alt="erwarteter output" style="width: 20%;">
</div>

1) Kopiere den gegebenen Programmcode in [Aufgabe_1/01_Programmveständnis.md](../Aufgabe_1/01_Programmverstaendnis.md). Suche dort Fehler im Code, markiere diese Durch den Text ``//Fehler in dieser Zeile! Begründung: TODO`` und erkläre warum es ein Fehler ist.
2) Beantworte außerhalb des Programmcodes in ``Aufgabe_1/01_Programmveständnis.md`` folgende Fragen:
    * Was ist die Aufgabe der äußeren For-Schleife?
    * Was ist die Aufgabe der inneren For-Schleife?
    * Was ist die Aufgabe der If-Anweisung?
    * Was ist die Aufgabe der Variable *platzhalter*?
    * Was würde passieren, wenn wir ohne *platzhalter* arbeiten würden? Also innerhalb der ``IF-Anweisung`` folgendes schreiben würden?
```java
zahlen[i] = zahlen[i+1];
zahlen[i+1] = zahlen[i];
```
3) Wir betrachten folgende animierte Grafik:
<table style="width:100%">
  <tr>
    <td style="vertical-align: top; padding-right: 10px; width: 50%;">
      <ul>
        <li>Ist es notwendig schwarz umrandete Zahlen mit anderen Zahlen zu vergleichen? Bergüne kurz warum oder warum nicht.</li>
        <li>Kann eine schwarz umrandete Zahl ignoriert werden? Begründe kurz warum oder warum nicht.</li>
        <li>Wird eine schwarz umrandete Zahl in dem oben gegebenen Code ignoriert? Begründe kurz warum oder warum nicht.</li>
      </ul>
    </td>
    <td style="vertical-align: top; padding-left: 10px; width: 50%;">
      <div style="text-align: center;">
        <img src="https://upload.wikimedia.org/wikipedia/commons/c/c8/Bubble-sort-example-300px.gif" alt="GIF von Bubble Sort welches auf Wikipedia den Ablauf des Algorithmus darstellt.">
      </div>
    </td>
  </tr>
</table>

---

### Programmieren [10 / 35 Teilpunkte]
Schreibe folgende Antworten als Kommentare im Java-File.
<table style="width:100%">
  <tr>
    <td style="vertical-align: top; padding-right: 10px; width: 50%;">
      Wir erinnern uns an folgende Grafik:
      <ul>
        <li>Was bedeutet, wenn eine Zahl schwarz umrandet wird?</li>
        <li>Ist dieses Verhalten in unserem Code vorhanden?</li>
        <li>Wenn nein, versuche diese Optimierung in das oben angegebene Programm einzubauen.</li>
        <li>Erkläre was hier optimiert wird.</li>
      </ul>
    </td>
    <td style="vertical-align: top; padding-left: 10px; width: 50%;">
      <div style="text-align: center;">
        <img src="https://upload.wikimedia.org/wikipedia/commons/c/c8/Bubble-sort-example-300px.gif" alt="GIF von Bubble Sort welches auf Wikipedia den Ablauf des Algorithmus darstellt.">
      </div>
    </td>
  </tr>
</table>

Erwarteter Output:
```
Durchgang: 0
[i=0, j=0]: [53, 5, 2, 26, -86]
[i=1, j=0]: [5, 53, 2, 26, -86]
[i=2, j=0]: [5, 2, 53, 26, -86]
[i=3, j=0]: [5, 2, 26, 53, -86]

Durchgang: 1
[i=0, j=1]: [5, 2, 26, -86, 53]
[i=1, j=1]: [2, 5, 26, -86, 53]
[i=2, j=1]: [2, 5, 26, -86, 53]

Durchgang: 2
[i=0, j=2]: [2, 5, -86, 26, 53]
[i=1, j=2]: [2, 5, -86, 26, 53]

Durchgang: 3
[i=0, j=3]: [2, -86, 5, 26, 53]

🏁🏁🏁🏁🏁🏁🏁🏁🏁🏁🏁🏁🏁🏁
[-86, 2, 5, 26, 53]
```

---

### Theorie [5 / 35 Teilpunkte]
Kopiere folgende Angabe nach [Aufgabe_1/03_Theorie.md](../Aufgabe_1/03_Theorie.md) und beantworte dort die folgenden Fragen.

1) Finde Fehler in dem folgenden Code. Beantworte dazu ``//Fehler! Begründung: TODO`` und lösche dazu ``//n. erzeugter Wert hat Typ: TODO oder``
2) Wenn kein Fehler in der Zeile ist, was ist der ``Typ`` des erzeugten ``Werte`` in folgendem Code. Beantworte dazu ``//n. erzeugter Wert hat Typ: TODO`` und lösche ``oder Fehler! Begründung: TODO``.
```java
String[][][] daten = new String[10][5][15];
daten[0][0]          // 1. erzeugter Wert hat Typ: TODO oder Fehler! Begründung: TODO
daten[3][1][6][5]    // 2. erzeugter Wert hat Typ: TODO oder Fehler! Begründung: TODO
daten[1][5][1]       // 3. erzeugter Wert hat Typ: TODO oder Fehler! Begründung: TODO
daten[6]             // 4. erzeugter Wert hat Typ: TODO oder Fehler! Begründung: TODO
dater[0][4][0]       // 5. erzeugter Wert hat Typ: TODO oder Fehler! Begründung: TODO
daten[0][5][0]       // 6. erzeugter Wert hat Typ: TODO oder Fehler! Begründung: TODO
```

**Hinweise:** 
* Falls es nicht im Kopf geht, versuche ``JAVA`` den ``Typ`` mit ``System.out.println`` ausgeben zu lassen. Recherchiere dazu im Internet.
* Achte auf korrekte Schreibweisen der Variablen und die Größe der Indices.

---

## Aufgabe 2: Userinput verarbeiten - RegEx, Schleifen und Scanner [50 Punkte]
### Programmverständnis [10 / 50 Teilpunkte]
Kopiere folgende Angabe nach [Aufgabe_2/01_Programmverständnis.md](../Aufgabe_2/01_Programmverstaendnis.md) und beantworte dort die folgenden Fragen.

Gegeben ist ein ``RegEx``. 
1) Suche und beschreibe die ``Operatoren`` und ``Multiziplizäten``welche hier verwendet wurden.
2) Beschreibe ca. was dieser ``RegEx`` darstellen soll.
```rx
^(ein-hundert|(20|30|40|50|60|70|80|90)|((ein|zwei|drei|vier|fünf|acht|neun|sechs|sieben)-und-(zwanzig|dreißig|vierzig|fünfzig|sechzig|siebzig|achtzig|neunzig))|((drei|vier|fünf|acht|neun|sech|sieb)-zehn)|(zwei|drei|vier|fünf|acht|neun|sechs|sieben)|(null|eins|zehn|elf|zwölf))+$
```

**Hinweis:** Verwende z.B. einen [Regex-Online-Checker](https://regex101.com/) um die erlaubten Texte zu überprüfen.

---

### Programmieren [30 / 50 Teilpunkte]
Kopiere den folgenden Programmcode nach [Aufgabe_2/Programmieren_02.java](../Aufgabe_2/Programmieren_02.java). 

```java
package VergangeneTests.ModulTest_2025_06.Aufgabe_2;

import java.util.Random;
import java.util.Scanner;

public class Programmieren_02 {
    public static void main(String[] args) {
        // Variablen Anlegen
        Random random = new Random();
        Scanner scanner = new Scanner(System.in);
        boolean playAgain = true;

        // Beginne mit Logik (Kontrollstrukturen)
        // spiele nochmals
        while (playAgain) {
            // Wir ziehen eine Zahl welche zufällig zwischen 0 und 100 (inklusive) ist.
            int zahlZuRaten = ... // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten logischen Ausdruck ein.
            int leben = 5 - 1;
            int versuche = 0;
            int zaehleVorkommenEinerZahl = 0;
            int zaehleVorkommenEinerZahlAlsText = 0;

            System.out.println("Eine Zahl zwischen 0 und 100 wurde gewählt. Rate die Zahl!");

            // Beginne mit Logik (Kontrollstrukturen)
            // Wiederholung der Spiellogik
            while (true) {
                // Wie darf der User seinen Versuch eingeben? Als Zahl oder nicht - ziehe dazu mit Random eine zufällige Zahl. 
                boolean erwartetZahl = ... // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten Ausdruck ein.

                // Wie erlauben eine Zahl mit 70% Wahrscheinlichkeit und eine Zahl als Text mit 30% Wahrscheinlichkeit.
                if (...) { // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten logischen Ausdruck ein.
                    // Wir wollen nun uns merken, dass wir eine Zahl gezogen haben. Wir setzen also die boolsche Variable erwartetZahl auf wahr.
                    erwartetZahl = ... // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten Ausdruck ein.

                    // Wir erhöhen unseren Zähler, dass eine Zahl vorgekommen ist ...
                    // TODO: Lösche dieses Kommenta und füge dort den korrekten Ausdruck ein.

                    // ... und setzen unseren Zähler, dass eine Zahl als Text vorgekommen ist, auf 0 zurück.
                    zaehleVorkommenEinerZahlAlsText = ... // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten Ausdruck ein.

                    // Wenn unser Zähler drei mal vorgekommen ist, dann überschreiben wir erwartetZahl mit falsch.
                    // Wir wollen deshalb eine Zahl als Text vom User haben.
                    if (...) { // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten logischen Ausdruck ein.
                        erwartetZahl = false;
                    }

                } else {
                    // Wir wollen nun uns merken, dass wir eine Zahl als Text gezogen haben. Wir setzen also die boolsche Variable erwartetZahl auf falsch.
                    erwartetZahl = ... // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten Ausdruck ein.

                    // Wir erhöhen unseren Zähler, dass eine Zahl als Text vorgekommen ist ...
                    // TODO: Lösche dieses Kommenta und füge dort den korrekten Ausdruck ein.

                    // ... und setzen unseren Zähler, dass eine Zahl vorgekommen ist, auf 0 zurück.
                    zaehleVorkommenEinerZahl = ... // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten Ausdruck ein.

                    // Wenn unser Zähler drei mal vorgekommen ist, dann überschreiben wir erwartetZahl mit wahr.
                    // Wir wollen deshalb eine Zahl vom User haben.
                    if (...) { // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten logischen Ausdruck ein.
                        erwartetZahl = true;
                    }
                }

                int guess;

                // Userinput
                // Wenn eine Zahl erwartet wird, dann
                if (...) { // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten logischen Ausdruck ein.
                    System.out.print("Gib eine Zahl ein [0-100]: ");

                    // guards für falschen Userinput - das Muster für eine Zahl kann mit in hasNextInt des Scanners abgefragt werden.
                    while (...) { // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten logischen Ausdruck ein.
                        System.out.print("Falscher userinput, bitte neu eingeben: ");
                        scanner.next();
                    }

                    guess = scanner.nextInt();

                // ansonsten, wird eine Zahl ausgeschrieben erwartet.
                } else {
                    System.out.print("Gib eine Zahl als WORT mit Bindestrichen ein [null bis ein-hundert] z.B. ein-und-sechzig: ");

                    String pattern = // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten Ausdruck ein. Dieser ist unten in der Angabe angegeben! Dieser muss nicht selbst ausgedacht werden.

                    // Verwende den RegEx pattern in der Methode hasNext um falschen Userinput abzugangen.
                    while (...) { // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten logischen Ausdruck ein.
                        System.out.print("Falscher userinput, bitte neu eingeben: ");
                        scanner.next();
                    }

                    // Hier kommt nun ein String vom User aus der Console zurück.
                    String zahlAlsString = ... // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten Ausdruck ein.

                    // wir sind pragmatisch. Wir lösen ALLE 100 Fälle mit einem Switch.
                    guess = switch (zahlAlsString) {
                        case ... // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten Ausdruck ein.
                    };
                }

                // Spiellogik: habe ich genug leben?
                if (...) { // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten logischen Ausdruck ein.
                    System.out.println("Du hast keine Leben mehr. Die Zahl war " + zahlZuRaten + ".");
                    break;
                }

                leben--;
                versuche++;

                // Spiellogik: wo bin ich mit meinem guess?
                if (...) { // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten logischen Ausdruck ein.
                    System.out.println("Die Zahl ist kleiner. Du hast noch " + (leben + 1) + " Leben.");

                } else if (...) { // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten logischen Ausdruck ein.
                    System.out.println("Die Zahl ist größer. Du hast noch " + (leben + 1) + " Leben.");

                } else if (...) { // TODO: Lösche dieses Kommentar, die drei Punkte und füge dort den korrekten logischen Ausdruck ein.
                    System.out.println("gewonnen. Die Zahl war " + zahlZuRaten + ". Es wurden " + versuche + " benötigt.");
                    break;
                }
            }

            // Logik um Spiel neu starten zu können
            System.out.print("Möchtest du nochmals spielen? [+/-]: ");
            playAgain = scanner.next().equals("+");
        }

        System.out.println("Spiel beendet. Danke fürs Spielen!");
        scanner.close();
    }
}
```

Die Benutzer:in muss eine geheime Zahl zwischen 0 und 100 erraten. Nach jeder Eingabe gibt das Programm Hinweise, ob die Zahl zu hoch oder zu klein ist. Die Benutzer:in hat 5 Leben. Wenn die Leben aufgebraucht sind, endet das Spiel mit einer Niederlage. **Der User wird zudem mit der Wahrscheinlichkeit von *30%* aufgefordert eine Zahl als Text einzugeben. Damit ist z.B. *"neun-und-fünfzig"* ist *59* gemeint. Jedoch gibt es hier ein paar Nachbesserungen.**
* Es soll jedoch nicht möglich sein, wenn eine Zahl teilbar durch 10 ist und diese größer als 10 ist, jedoch nicht 100 ist, diese als Text *z.B. fünfzig* eingeben zu können. Es soll immer diese als Zahl *z.B. 50* eingegeben werden.
* Außerdem soll sichergestellt werden, dass nicht drei mal hintereinander eine Zahl *z.B. 54* oder ein Zahl als Text *z.B. vier-und-fünfzig* eingegeben werden muss. **Detail: Falls bei der 4. Ziehung die Zahl *z.B. füngzig* kommt, können wir nicht *fünzig* eingeben. Hier ist es erlaubt zum 4. mal hintereinander eine Zahl einzugeben.**

**Hinweise:**
* Lege zwei Variablen an ``int zaehleVorkommenEinerZahl = 0;`` und ``int zaehleVorkommenEinerZahlAlsText = 0;``. Mit diesen können wir bis z.B. 4 zählen. Das würde bedeuten wir haben 4 mal hintereinander z.B. eine Eingabe der Zahl gehabt. Wenn das der Fall ist ändern wir die Ziehung von ``erwartetZahl=true;`` auf ``erwartetZahl=false;``.

Weiters soll folgendes gelten:
* **Geheime Zahl:**
  Das Programm wählt zu Beginn eine zufällige Zahl zwischen 0 und 100 (einschließlich) aus.
  Verwenden Sie dazu die Klasse `Random` aus dem Paket `java.util`. Um diese Klasse verwenden zu können, schreiben Sie `import java.util.Random;` am Anfang Ihres Programms. Erstellen Sie dann ein Objekt dieser Klasse, z.B. `Random random = new Random();`, und verwenden Sie die Methode `nextInt()`, um eine Zufallszahl zu generieren.

* **Userinput:**
  Ein:e Benutzer:in wird in jeder Runde aufgefordert, eine Zahl einzugeben. Die Eingabe muss überprüft werden, ob sie der geheimen Zahl entspricht. Verwenden Sie die Klasse `Scanner` aus dem Paket `java.util` um Eingaben aus dem Terminal einzulesen. Importieren Sie dazu `import java.util.Scanner;` und erstellen Sie ein `Scanner`-Objekt, z.B. `Scanner scanner = new Scanner(System.in);`. Mit `scanner.nextInt();` können Sie dann eine Ganzzahl einlesen.
  **Wichtig!:** Es soll dem User möglich sein auch wenn **falsche** Eingaben getätigt wurde, diese ausbessern zu können. Fordere dazu den User solange auf etwas einzugeben bis dieses dem erwarteten Muster entspricht.

* **RegEx für Erkennung der Zahlen als Text**: Es kann dieser ``Regex`` verwendet werden um z.B. ``fünf-und-dreißig`` zu erkennen.
```java
String nichtKombinierbar = "null|eins|zehn|elf|zwölf";
String ersterTeilDreizehnBisNeunZehn = "drei|vier|fünf|acht|neun";
String zweiterTeilDreihzehnBisNeunzehn = "sech|sieb";
String dreizehnBisNeunzehn = ersterTeilDreizehnBisNeunZehn + "|" + zweiterTeilDreihzehnBisNeunzehn;
String einerStellenOhneEins = "zwei|" + ersterTeilDreizehnBisNeunZehn + "|sechs|sieben";
String basisFuerZehnerStellen = "ein|" + einerStellenOhneEins;
String dreizehnBisNeunZehn = "(" + dreizehnBisNeunzehn + ")-zehn";
String zehnerStellen = "zwanzig|dreißig|vierzig|fünfzig|sechzig|siebzig|achtzig|neunzig";
String zehnerStellenAlsZahl = "20|30|40|50|60|70|80|90";
String kombinierterRest = "(" + basisFuerZehnerStellen + ")-und-(" + zehnerStellen + ")";
String hundert = "ein-hundert";

String pattern =
        "^" +
            hundert + "|" +
            "(" + zehnerStellenAlsZahl + ")|" +
            "(" + kombinierterRest + ")|" +
            "(" + dreizehnBisNeunZehn + ")|" +
            "(" + einerStellenOhneEins + ")|" +
            "(" + nichtKombinierbar + ")" +
        "$";
```

* **Interaktion mit Benutzer:innen:**
  Wenn die Eingabe zu hoch ist, gibt das Programm die Nachricht *"Die Zahl ist zu hoch!"* aus.
  Wenn die Eingabe zu niedrig ist, gibt das Programm die Nachricht *"Die Zahl ist zu klein!"* aus.
  Bei korrekter Eingabe zeigt das Programm *"Herzlichen Glückwunsch, Sie haben die Zahl erraten!"* an und beendet das Spiel.

* **Anzahl der Versuche:**
  Ein:e Benutzer:in hat `5` Leben. Bei jeder falschen Eingabe verliert diese:r ein Leben. Wenn die Leben aufgebraucht sind, endet das Spiel mit der Nachricht: *"Game Over! Die geheime Zahl war: ``<Geheime Zahl>``"*.

#### Erwarteter Output:
```
Eine Zahl zwischen 0 und 100 wurde gewählt. Rate die Zahl!
Gib eine Zahl als WORT mit Bindestrichen ein [null bis ein-hundert] z.B. ein-und-sechzig: 50
Falscher userinput, bitte neu eingeben: warum?
Falscher userinput, bitte neu eingeben: fünfzig
Die Zahl ist kleiner. Du hast noch 4 Leben.
Gib eine Zahl ein [0-100]: 25
Die Zahl ist größer. Du hast noch 3 Leben.
Gib eine Zahl als WORT mit Bindestrichen ein [null bis ein-hundert] z.B. ein-und-sechzig: sieben-und-dreißig
Die Zahl ist größer. Du hast noch 2 Leben.
Gib eine Zahl als WORT mit Bindestrichen ein [null bis ein-hundert] z.B. ein-und-sechzig: fünf-und-vierzig
Die Zahl ist kleiner. Du hast noch 1 Leben.
Gib eine Zahl ein [0-100]: neun-und-dreißig
Falscher userinput, bitte neu eingeben: 39
Du hast keine Leben mehr. Die Zahl war 40.
Möchtest du nochmals spielen? [+/-]: -
Spiel beendet. Danke fürs Spielen!
```

---

### Theorie [10 / 50 Teilpunkte]
1) Was ist der Unterschied zwischen einem ``If-Ausdruck`` und einer ``If-Anweisung``?
2) Denke an eine ``If-Verzweigung``. Was ist die ``logische Formel`` des ``else`` Zweigs, wenn die ``logische Formel`` für den ``if`` Zweig ``!(alter >= 25)`` ist?
3) Kann ein ``If-Ausdruck`` das gleiche Verhalten wie eine ``If-Anweisung`` haben? Vergleiche dazu folgenden Code.
```java
String antwort;

if (alter > 25) {
    antwort = "passt.";

} else {
    antwort = "passt nicht."
}

System.out.println(antwort);
```

vs.

```java
System.out.println(alter > 25 ? "passt" : "passt nicht");
```
---

## Aufgabe 3: Funktionen (Methoden) schreiben [15 Punkte]
### Programmverständnis [10 / 15 Teilpunkte]
Kopiere folgende Angabe nach [Aufgabe_3/01_Programmverständnis.md](../Aufgabe_3/01_Programmverstaendnis.md) und beantworte dort die folgenden Fragen.

Folgender *Code-Ausschnitt* funktionier nicht. Suche dort Fehler im Code, markiere diese Durch den Text ``//Fehler in dieser Zeile! Begründung: TODO`` und erkläre warum es ein Fehler ist.

```java
public static void main(String[] args) {
    String[][] muster = new String[5][5];
    
    // Hier wird das Muster erzeugt, es steht also im Muster was sinnvolles, nicht nur 5x5 null.
    ...
    
    String[][] gedrehtesMuster = drehen(spieglenX(transponieren(muster)));
}

// ein String ist ein Array von Characters - deshalb gibt es hier ein Character[][][] anstatt String[][]
static Character[][][] transponieren(String[] array) {
    Character[][][] result = new Character[array.length][array.length][array[0].length()];

    // Hier wird das Muster erzeugt, es steht also im Muster was sinnvolles, nicht nur 5x5 null.
    ...
    
    return result;
}

static String[][] spiegelnX(String[] array) {
    String[][] result = new String[array.length][array.length];

    // Hier wird das Muster erzeugt, es steht also im Muster was sinnvolles, nicht nur 5x5 null.
    ...

    return result;
}
```

**Anmerkung:** Die Antwort "wegen den drei Punkten" bzw. wegen den fehlenden main usw. wäre kreativ, ist aber hier nicht gemeint.

---

### Theorie [05 / 15 Teilpunkte]
Kopiere folgende Angabe nach [Aufgabe_3/03_Theorie.md](../Aufgabe_3/03_Theorie.md) und beantworte dort die folgenden Fragen.

* Braucht jede ``Funktion`` (Methode) eine ``return`` ``Keyword``??
* Wenn wir ``Funktionen`` schachteln ``int result = a(b(c()));`` ist es kein Problem wenn eine der ``Funktionen`` den ``Rückgabetyp`` ``void`` hat. Stimmt diese Aussage? Begründe wieso oder wieso nicht.

---