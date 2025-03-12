# Variablenumwandlung

## Aufgabe 1: Schachbrett-Koordinaten
Wir wollen auf einem Schachbrett zwei Punkte angeben, welches einen Zug darstellen soll. Aus unerklärlichen Gründen sollen wir die Distanz zwischen diesen Punkten berechnen und ausgeben. 

1. Verwende `scanner.nextLine()` um eine ganze Zeile einzulesen und trenne danach den eingelesenen ``String`` in die x und y Koordinaten. Wandle diese x und y Koordinaten in einen ``Integer`` um.

    * Verwende `userInputAlsString.split()` um den vom User eingegebenen ``String``in zwei `Strings` aufzutrennen. Dabei sollen folgende Trennsymbole erlaubt sein ` `, `/`, `-`, `🧱`, oder `🔺`. Gib dazu `userInputAlsString.split("[ /🔺-🧱]")` an (beliebige Reihenfolge). Die eckigen Klammern sind hier wichtig, da dies streng genommen eine eigene Sprache ist, welche ``RegEx`` (Regular Expressions) heißt. Diese lernen wir viel später in ``L10StringManipulation`` kennen. Weise das Ergebnis aus ``split`` einer Variable zu ``String[] mehrereKoordinaten = ... split aufruf...``. Mehrere Koordinaten ist nun ein so genanntes ``Array``. Dort ist die x und y Koordinate gespeichert.
    * Wandle nun die x und y koordinate in einen ``Integer`` um. Verwende dazu die ``parse`` Methoden. Die x koordinate wird mit ``mehrereKoordinaten[0]`` und die y koordinate mit ``mehrereKoordinaten[1]`` angesprochen. 
    * Verwende für die Distanzberechnung folgende Formel $\sqrt{(x_\text{end} - x_\text{start})^2 + (y_\text{end} - y_\text{start})^2}$. Verwende dazu für die Übersetzung in JAVA ``Math.sqrt`` für $\sqrt-$ und für $x^2$ ``Math.pow(x,2)``.
    *Die berechnete Distanz zwischen den beiden Punkten soll auf zwei Nachkommastellen gerundet und im deutschen Zahlenformat mit `,` als Dezimaltrennzeichen ausgegeben. Verwende dazu eine ``Variable`` vom ``Typ`` ``DecimalFormat``.

Beispielprogramm:
```
Wähle die Spielfigur [x y]: 3 5
Wähle die das Ziel [x y]: 5 1
Die Figur auf Position [x:3 y:5] wurde auf Position [x:5 y:1] geschoben. Distanz: 4,47
```

2. Verwende `scanner.nextInt()` um eine Zahl aus der Zeile einzulesen. Verwende zwei Aufrufe von `scanner.nextInt()` um die x und y Koordinate einzulesen, es soll jedoch alles in einer Zeile vom User eingegeben werden. Frage am Schluss noch den User wie es diesem:r geht mit `scanner.nextLine()`. Warum ignoriert der Computer diese Eingabe? 
>Hinweis: Eine Eingabe wird mit der Enter Taste eingegeben, und somit wird ein ``Line Feed\New Line`` als `\n` erzeugt. Was tut ``next`` vs. ``nextLine`` mit diesem Symbol?


```java
import java.util.Locale;
import java.util.Scanner;
import java.text.DecimalFormat;

public class SchachbrettDistanz {
    public static void main(String[] args) {
        
    }
}
```

#### Variante 2: Mit `nextLine()` und `split()`
```java
import java.util.Locale;
import java.util.Scanner;
import java.text.DecimalFormat;

public class SchachbrettDistanzMitSplit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        System.out.println("Bitte die Koordinaten eingeben (Format: x1-y1/x2+y2):");
        String input = scanner.nextLine();
        String[] teile = input.split("[/\-_+]");
        
        int x1 = Integer.parseInt(teile[0]);
        int y1 = Integer.parseInt(teile[1]);
        int x2 = Integer.parseInt(teile[2]);
        int y2 = Integer.parseInt(teile[3]);
        
        double distanz = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
        DecimalFormat df = (DecimalFormat) DecimalFormat.getInstance(Locale.GERMANY);
        df.applyPattern("0.00");
        
        System.out.println("Die Distanz beträgt: " + df.format(distanz));
    }
}
```

### Aufgabe
1. Analysiere, warum `scanner.nextLine();` nach den `nextInt()`-Aufrufen scheinbar keine Benutzereingabe erfasst. Was passiert mit dem Zeilenumbruch nach der letzten Ganzzahleinabe? Begründe deine Antwort.
2. Welche Methode (`nextInt()` oder `nextLine()` mit `split()`) ist in welchen Situationen vorteilhaft? Begründe deine Wahl.

