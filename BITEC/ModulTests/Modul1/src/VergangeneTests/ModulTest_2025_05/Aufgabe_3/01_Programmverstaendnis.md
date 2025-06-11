Folgender *Code-Ausschnitt* funktionier nicht. Finde den Fehler, bessere diesen aus und erkläre warum es ein Fehler ist.
```java
...

public static void main(String[] args) {
    String[][] muster = ...
    String[][] zweiMalGedrehtesMuster = drehen(drehen(muster));
}

static String[][] drehen(String[][] array) { // Der Rückgabetyp void wurde durch String[][] ersetzt.
    ...
}
...
```