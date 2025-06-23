1) Kopiere den gegebenen Programmcode in [Aufgabe_1/01_Programmveständnis.md](../Aufgabe_1/01_Programmverstaendnis.md). Suche dort Fehler im Code, markiere diese Durch den Text ``//Fehler in dieser Zeile! Begründung: TODO`` und erkläre warum es ein Fehler ist.

```java
package VergangeneTests.ModulTest_2025_05.Aufgabe_1;

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

        for (int j = 10; j < zahlen.length + 18; j=j+2) { // komisch, aber das sortierte Array am Ende ist durch diese Schleife nicht falsch. Falls es as Fehler beim Test angegeben wird und richtig begründet wird, zählt es auch als korrekte Antwort.
            System.out.println(colorOfInnerLoop + "Durchgang: " + j + ANSI_RESET);

            for (int i = 0; i <= zahlen.length; j++) {  // Fehler in dieser Zeile! Begründung: Wir scheißen übers Ziel hinaus und vergleichen viele Zahlen, wenn i = zahlen.length ist, dann haben wir einen Index der nicht existiert. Auch i = zahlen.length - 1 ist noch zu groß, denn wir vergleichen mit <=. Es muss deshalb i < zahlen.length - 1; oder i <= zahlen.length - 2 stehen. Auch wird fälschlicherweise j anstatt i um eins erhöht.
                if (zahlen[j] < zahlen[i + 1]) { // Fehler in dieser Zeile! Begründung: Wir wollen Zahlen welche links im Array sind mit dessen rechten Nachbarn vergleichen. Danach tauschen wir falls der linke Nachbar größer ist, diesen mit dem rechten Nachbarn. Wir brauchen deshalb zahlen[i] > zahlen[i + 1]. 
                    int platzhalter = zahlen[i + 1]; 
                    zahlen[i + 1] = zahlen[i];
                    platzhalter = zahlen[i]; // Fehler in dieser Zeile! Begründung: Wir müssen zahlen[i] auf den platzhalter setzen, nicht umgekehrt.
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

2)  Beantworte außerhalb des Programmcodes in ``Aufgabe_1/01_Programmveständnis.md`` folgende Fragen:
    **Die Begriffe lehnen sich an der Animation in der Angabe an.**
   * Was ist die Aufgabe der äußeren For-Schleife?
     * Wiederhole die rote "Bubble" für mindestens jede Zahl ein mal.

   * Was ist die Aufgabe der inneren For-Schleife?
     * Die Bubble steigt auf - schiebe die rote "Bubble" nach rechts, bis zum Ende des Arrays.

   * Was ist die Aufgabe der If-Anweisung?
     * Die größere Zahl soll rechts in der roten "Bubble" stehen.

   * Was ist die Aufgabe der Variable *platzhalter*?
     * Platzhalter wird benötigt, um keine Werte beim Tausch zu verlieren.

   * Was würde passieren, wenn wir ohne *platzhalter* arbeiten würden? Also innerhalb der ``IF-Anweisung`` folgendes schreiben würden?
     * ``i = 0`` und die zahlen sind ein Array welches wir als ``[3,5]`` darstellen. Wenn wir ``zahlen[i+1]``, was ``5`` ist, mit ``=`` auf ``zahlen[i]`` setzen verlieren wir die ``3``. Wir haben dann ``[3,3]`` und haben die ``5`` verloren. Danach tauschen wir ``3`` mit ``3``. Unser Ziel war aber aus ``[3,5]`` die ``[5,3]`` zu machen. 
```java
zahlen[i] = zahlen[i+1];
zahlen[i+1] = zahlen[i];
```

3) Wir betrachten folgende animierte Grafik:
* Ist es notwendig schwarz umrandete Zahlen mit anderen Zahlen zu vergleichen? Bergüne kurz warum oder warum nicht.
  * Nein. Die schwarz umrandete Zahl ist eine Zahl welche bereits an der richtigen Stelle ist.

* Kann eine schwarz umrandete Zahl ignoriert werden? Begründe kurz warum oder warum nicht.
  * Ja. Eine Zahl welche bereits an der richtigen Stelle ist, muss nicht mehr umsortiert werden.

* Wird eine schwarz umrandete Zahl in dem oben gegebenen Code ignoriert? Begründe kurz warum oder warum nicht.
  * Nein. Wir gehen in der for-Schleife immer alle Zahlen ab. Das ist durch die Schleifenbedingung der inneren Schleife ``i < zahlen.length - 1`` festgelegt.