# Modultest 1 - BITEC BT02/03

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

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 10:15 schicken)
* Viel Erfolg! :)

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., (Schulnotensystem)

---

## Arrays [35 / 100 Punkte]

### Programmverständnis [10 / 25 Teilpunkte]
Gegeben ist folgender Code, welcher den ``Bubble Sort`` darstellt. 

```csharp
package VergangeneTests.ModulTest_2025_06.Aufgabe_1;

import java.lang.reflect.Array;
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
        int platzhalter;

        for (int j = zahlen.length - 1; j > 0; j--) {
            System.out.println(colorOfInnerLoop + "Durchgang: " + j + ANSI_RESET);
            
            for (int i = zahlen.length - 1; i > 0; i--) {
                String zahlenColored = colorAt(
                    zahlen,
                    new int[]{i-1, i},
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

                if (zahlen[i-1] > zahlen[i]) {
                    platzhalter = zahlen[i+1];
                    zahlen[i+1] = zahlen[i-1];
                    zahlen[i-1] = platzhalter;
                }
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

1) Finde die Fehler in diesem Code und bessere diesen aus und markiere diesen. 
2) Beantworte im ``Programmcode`` mit ``Kommentaren`` folgenden Fragen:
    * Was ist die Aufgabe der äußeren For-Schleife?
    * Was ist die Aufgabe der inneren For-Schleife?
    * Was ist die Aufgabe der If-Anweisung?
    * Was ist die Aufgabe der Variable *platzhalter*?
    * Was würde passieren wenn wir ohne *platzhalter* arbeiten würden? Also innerhalb der ``IF-Anweisung`` folgendes schreiben würden?
```java

zahlen[i] = zahlen[i-1];
zahlen[i-1] = zahlen[i];
```

---

### Programmieren [10 / 25 Teilpunkte]
<table style="width:100%">
  <tr>
    <td style="vertical-align: top; padding-right: 10px; width: 50%;">
      Wir erinnern uns an folgende Grafik:
      <ul>
        <li>Was bedeutet wenn eine Zahl schwarz umrandet wird?</li>
        <li>Ist dieses Verhalten in unserem Code vorhanden?</li>
        <li>Wenn nein, versuche diese Optimierung in das oben angegebene Programm einzubauen.</li>
      </ul>
    </td>
    <td style="vertical-align: top; padding-left: 10px; width: 50%;">
      <div style="text-align: center;">
        <img src="https://upload.wikimedia.org/wikipedia/commons/c/c8/Bubble-sort-example-300px.gif" alt="GIF von Bubble Sort welches auf Wikipedia den Ablauf des Algorithmus darstellt.">
      </div>
    </td>
  </tr>
</table>

**Hinweis:** Denke pragmatisch, falls es nicht mit dem angegebene Code möglich ist. Gibt es wo anders eine andere Schreibweise des Codes weche verwendet werden kann?

**Bonus:** Beschreibe den Code der *colorAt* ``Methode``. Versuche zudem die Zahlen im ``Array`` *zahlen* in *Cyan* einzufärben, aber die eckigen *Klammern* und *Beistriche* nicht einzufärben (*ANSI_RESET*).
<div style="display: flex; flex-wrap: wrap; align-items: center; gap: 5px;">
  [
  <div style="color:cyan">53</div>,
  <div style="color:cyan">5</div>,
  <div style="color:cyan">2</div>,
  <div style="color:cyan">26</div>,
  <div style="color:cyan">-86</div>
  ]
</div>

Erwarteter Output:
```
Durchgang: 4
[i=4, j=4]: [53, 5, 2, 26, -86]
[i=3, j=4]: [53, 5, 2, -86, 26]
[i=2, j=4]: [53, 5, -86, 2, 26]
[i=1, j=4]: [53, -86, 5, 2, 26]

Durchgang: 3
[i=3, j=3]: [-86, 53, 5, 2, 26]
[i=2, j=3]: [-86, 53, 2, 5, 26]
[i=1, j=3]: [-86, 2, 53, 5, 26]

Durchgang: 2
[i=2, j=2]: [-86, 2, 53, 5, 26]
[i=1, j=2]: [-86, 2, 53, 5, 26]

Durchgang: 1
[i=1, j=1]: [-86, 2, 53, 5, 26]

🏁🏁🏁🏁🏁🏁🏁🏁🏁🏁🏁🏁🏁🏁
[-86, 2, 53, 5, 26]
```

---

### Theorie [5 / 35 Teilpunkte]
1) Was ist der ``Typ`` des erzeugten ``Werte`` in folgendem Code:
```java
String[][][][][] daten = new String[10][5][15][8][2];
daten[0][0][0][0]    // 1. erzeugter Wert.
daten[3][1][6][5]    // 2. erzeugter Wert.
daten[0][0][0]       // 3. erzeugter Wert.
daten[0]             // 4. erzeugter Wert.
daten[0][0][0][0][0] // 5. erzeugter Wert.
```

**Hinweis:** Falls es nicht im Kopf geht, versuche ``JAVA`` den ``Typ`` ausgeben zu lassen. Recherchiere dazu im Internet.

---

## Userinput verarbeiten - RegEx, Schleifen und Scanner [60 Punkte]
### Programmverständnis [10 / 60 Teilpunkte]


---

### Programmieren [40 / 60 Teilpunkte]
Der Benutzer muss eine geheime Zahl zwischen 0 und 100 erraten. Nach jeder Eingabe gibt das Programm Hinweise, ob die Zahl zu hoch oder zu klein ist. Der Benutzer hat 5 Leben. Wenn die Leben aufgebraucht sind, endet das Spiel mit einer Niederlage. Der User wird zudem mit der Wahrscheinlichkeit von *50%* aufgefordert eine Zahl als Text einzugeben. Damit ist z.B. *"neun-und-fünfzig"* ist *59* gemeint.

**Hinweis:** Erstelle das Programm schrittweise. Zuerst das Programm ohne die *50%* Wahrscheinlichkeit. Danach versuche diese hinzuzufügen. Denke zudem pragmatisch. Was ist der einfachste, jedoch anstrengende Weg, wenn der User *ein-und-dreißig* eingibt eine ``Variable`` mit ``Wert`` *Integer* zu erzeugen? Wie machen wir es für alle 100 Fälle? 

Weiters soll folgendes gelten:
* **Geheime Zahl:**
  Das Programm wählt zu Beginn eine zufällige Zahl zwischen 0 und 100 (einschließlich) aus.
  Verwenden Sie dazu die Klasse `Random` aus dem Paket `java.util`. Um diese Klasse verwenden zu können, schreiben Sie `import java.util.Random;` am Anfang Ihres Programms. Erstellen Sie dann ein Objekt dieser Klasse, z.B. `Random random = new Random();`, und verwenden Sie die Methode `nextInt()`, um eine Zufallszahl zu generieren.

* **Userinput:**
  Ein:e Benutzer:in wird in jeder Runde aufgefordert, eine Zahl einzugeben. Die Eingabe muss überprüft werden, ob sie der geheimen Zahl entspricht. Verwenden Sie die Klasse `Scanner` aus dem Paket `java.util` um Eingaben aus dem Terminal einzulesen. Importieren Sie dazu `import java.util.Scanner;` und erstellen Sie ein `Scanner`-Objekt, z.B. `Scanner scanner = new Scanner(System.in);`. Mit `scanner.nextInt();` können Sie dann eine Ganzzahl einlesen.
  **Wichtig!:** Es soll dem User möglich sein auch wenn **falsche** Eingaben getätigt wurde, diese ausbessern zu können. Fordere dazu den User solange auf etwas einzugeben bis dieses dem erwarteten Muster entspricht.

* **Interaktion mit Benutzer:innen:**
  Wenn die Eingabe zu hoch ist, gibt das Programm die Nachricht *"Die Zahl ist zu hoch!"* aus.
  Wenn die Eingabe zu niedrig ist, gibt das Programm die Nachricht *"Die Zahl ist zu klein!"* aus.
  Bei korrekter Eingabe zeigt das Programm *"Herzlichen Glückwunsch, Sie haben die Zahl erraten!"* an und beendet das Spiel.

* **Anzahl der Versuche:**
  Ein:e Benutzer:in hat `5` Leben. Bei jeder falschen Eingabe verliert diese:r ein Leben. Wenn die Leben aufgebraucht sind, endet das Spiel mit der Nachricht: *"Game Over! Die geheime Zahl war: ``<Geheime Zahl>``"*.

* **`optional`**: Gib am Ende die Anzahl der Versuche aus, die ein:e Benutzer:in benötigt um die Zahl zu erraten. Füge eine Möglichkeit hinzu, das Spiel nach einem Durchgang erneut zu starten.

### Testfälle:
```
Geben Sie Ihre Schätzung ein:
> aäsdjw
Die Eingabe ist ungültig. Sie haben noch 5 Leben.

Geben Sie Ihre Schätzung ein:
> 50
Die Zahl ist zu hoch! Sie haben noch 4 Leben.

Geben Sie Ihre Schätzung ein:
> 25
Die Zahl ist zu klein! Sie haben noch 3 Leben.

Geben Sie Ihre Schätzung ALS WORT ein:
> siebenunddreißig
Die Eingabe ist ungültig. Sie haben noch 3 Leben.

Geben Sie Ihre Schätzung ALS WORT ein:
> sieben-und-dreißig
Die Zahl ist zu hoch! Sie haben noch 2 Leben.

Geben Sie Ihre Schätzung ein:
> 30
Die Zahl ist zu klein! Sie haben noch 1 Leben.

Geben Sie Ihre Schätzung ein:
> 35
Game Over! Die geheime Zahl war: 33
```

---

### Theorie [10 / 60 Teilpunkte]
* a) Was ist der Unterschied zwischen einer ``If-Verzweigung`` und einer ``If-Bedingung``?
* b) Gegeben ist eine ``If-Verzweigung`` (if mit else). Was ist die ``logische Formel`` des ``else`` Zweigs, wenn die ``logische Formel`` für den ``if`` Zweig ``alter > 25`` ist?
* c) Kann eine ``If-Verzweigung`` das gleiche Verhalten wie eine ``If-Bedingung`` haben? Vergleiche dazu folgenden Code.
```csharp
if (false) 
{
    Console.WriteLine("If-Zweig")
} 
else 
{
    Console.WriteLine("Else-Zweig")
}
```

vs.

```csharp
if (false) 
{
    Console.WriteLine("If-Bedingung")
} 

if (true) 
{
    Console.WriteLine("Auch eine IF-Bedingung")
}
```

---

## Funktionen (Methoden) schreiben [30 Punkte]
### Programmverständnis [10 / 30 Teilpunkte]


---

### Programmieren [20 / 30 Teilpunkte]


---