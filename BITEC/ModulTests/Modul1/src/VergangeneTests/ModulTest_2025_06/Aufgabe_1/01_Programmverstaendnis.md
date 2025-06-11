1) Finde die Fehler in diesem Code und bessere diesen aus und markiere diesen.

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

        for (int j = 10; j < zahlen.length + 18; j=j+2) { // komisch aber passt.
            System.out.println(colorOfInnerLoop + "Durchgang: " + j + ANSI_RESET);

            for (int i = 0; i <= zahlen.length; j++) { // i < zahlen.length - 1; i++)
                if (zahlen[j] < zahlen[i + 1]) { // zahlen[i] > zahlen[i + 1]
                    int platzhalter = zahlen[i]; // int platzhalter = zahlen[i + 1];
                    zahlen[i + 1] = zahlen[j];   // zahlen[i + 1] = zahlen[i];
                    platzhalter = zahlen[i];     // zahlen[i] = platzhalter;
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
2) Beantworte im ``Programmcode`` mit ``Kommentaren`` folgenden Fragen:
Begriffe: Die Begriffe lehnen sich am Gif in der VergangeneTests.ModulTest_2025_05.Angabe an.
   * Was ist die Aufgabe der äußeren For-Schleife?
     * Wiederhole die rote "Bubble" für mindestens jede Zahl ein mal.
   * Was ist die Aufgabe der inneren For-Schleife?
     * Die Bubble steigt auf - schiebe die rote "Bubble" nach rechts, bis zum Ende des Arrays.
   * Was ist die Aufgabe der If-Anweisung?
     * Die größere Zahl soll rechts in der roten "Bubble" stehen.
   * Was ist die Aufgabe der Variable *platzhalter*?
     * Platzhalter wird benötigt, um keine Werte beim Tausch zu verlieren.
   * Was würde passieren, wenn wir ohne *platzhalter* arbeiten würden? Also innerhalb der ``IF-Anweisung`` folgendes schreiben würden?
     * ``i = 0`` und die zahlen sind ein array welches wir als ``[3,5]`` darstellen. Wenn wir ``zahlen[i+1]``, was ``5`` ist, mit ``=`` auf ``zahlen[i]`` setzen verlieren wir die ``3``. Wir haben dann ``[3,3]`` und haben die ``5`` verloren. Danach tauschen wir ``3`` mit ``3``.
```java
zahlen[i] = zahlen[i+1];
zahlen[i+1] = zahlen[i];
```
