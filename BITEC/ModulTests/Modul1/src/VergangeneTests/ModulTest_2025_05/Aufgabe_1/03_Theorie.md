1) Was ist der ``Typ`` des erzeugten ``Werte`` in folgendem Code:
```java
String[][][][][] daten = new String[10][5][15][8][2];
daten[0][0][0][0]    // 1. erzeugter Wert hat Typ: String[]
daten[3][1][6][5]    // 2. erzeugter Wert hat Typ: String[]
daten[0][0][0]       // 3. erzeugter Wert hat Typ: String[][]
daten[0]             // 4. erzeugter Wert hat Typ: String[][][][]
daten[0][0][0][0][0] // 5. erzeugter Wert hat Typ: String
```