Folgender *Code-Ausschnitt* funktionier nicht. Finde den Fehler, bessere diesen aus und erkläre warum es ein Fehler ist.
```java
...

public static void main(String[] args) {
    String[][] muster = new String[5][5];

    // Hier wird das Muster erzeugt, es steht also im Muster was sinnvolles, nicht nur 5x5 null.
    ...

    String[][] zweiMalGedrehtesMuster = drehen(drehen(muster));
}

static void drehen(String[][] array) { // Der Rückgabetyp void wurde durch String[][] ersetzt.
    ...
}
...
```