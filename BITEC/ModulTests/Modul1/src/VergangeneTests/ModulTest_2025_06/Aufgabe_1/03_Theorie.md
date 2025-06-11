1) Was ist der ``Typ`` des erzeugten ``Werte`` in folgendem Code:
```java
String[][][] daten = new String[10][5][15];
daten[0][0]          // 1. erzeugter Wert hat Typ String[]
daten[3][1][6][5]    // 2. erzeugter Wert hat Typ - Fehler: zu viele Dimensionen.
daten[1][5][1]       // 3. erzeugter Wert hat Typ - Fehler: Index 5 ist zu groß.
daten[6]             // 4. erzeugter Wert hat Typ - String[][]
dater[0][4][0]       // 5. erzeugter Wert hat Typ - Fehler: dater mit r ist keine bekannte Variable.
daten[0][5][0]       // 6. erzeugter Wert hat Typ - String
```