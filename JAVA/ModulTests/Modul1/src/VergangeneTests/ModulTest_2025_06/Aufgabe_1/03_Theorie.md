Kopiere folgende Angabe nach [Aufgabe_1/Theorie_03.md](../Aufgabe_1/03_Theorie.md) und beantworte dort die folgenden Fragen.

1) Finde Fehler in dem folgenden Code. Beantworte dazu ``//Fehler! Begründung: TODO`` und lösche dazu ``//n. erzeugter Wert hat Typ: TODO oder``
2) Wenn kein Fehler in der Zeile ist, was ist der ``Typ`` des erzeugten ``Werte`` in folgendem Code. Beantworte dazu ``//n. erzeugter Wert hat Typ: TODO`` und lösche ``oder Fehler! Begründung: TODO``.

```java
String[][][] daten = new String[10][5][15];
daten[0][0]          // 1. erzeugter Wert hat Typ String[]
daten[3][1][6][5]    // 2. Fehler! Begründung: zu viele Dimensionen.
daten[1][5][1]       // 3. Fehler! Begründung: Index 5 ist zu groß.
daten[6]             // 4. erzeugter Wert hat Typ - String[][]
dater[0][4][0]       // 5. Fehler! Begründung: dater ist keine bekannte Variable.
daten[0][5][0]       // 6. erzeugter Wert hat Typ - String
```