Folgender *Code-Ausschnitt* funktionier nicht. Finde die Fehler, bessere diese aus und erkläre warum es Fehler sind.
```java
public static void main(String[] args) {
    String[][] muster = ...
    String[][] gedrehtesMuster = drehen(spieglenX(transponieren(muster)));
    // Fehler 1 - Es gibt die Fukntion drehen nicht.
}

// Fehler 2 - Zwei verschiedene Typen führen dazu, dass wir die Funktionen ``spieglenX(transponieren(muster))`` nicht schachteln können.
// Es erwartet sich spiegelnX dein Eingangsparameter String[]

// Ein String ist ein Array von Characters - deshalb gibt es hier ein Character[][][] anstatt String[][].

// Fehler 3.1 - String[] array es sollte 2d sein, also String[][] array.
static Character[][][] transponieren(String[] array) {
    Character[][][] result;
    ...
    return result;
}

// Fehler 3.2 - String[] array es sollte 2d sein, also String[][] array.
static string[][] spiegelnX(String[] array) {
    String[][] result;
    ...
    return result;
}