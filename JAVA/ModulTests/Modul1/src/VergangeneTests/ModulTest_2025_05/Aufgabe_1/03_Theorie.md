Kopiere folgende Angabe nach [Aufgabe_1/Theorie_03.md](../Aufgabe_1/03_Theorie.md) und beantworte dort die folgenden Fragen.

1) Finde Fehler in dem folgenden Code. Beantworte dazu ``//Fehler! Begründung: TODO`` und lösche dazu ``//n. erzeugter Wert hat Typ: TODO oder``
2) Wenn kein Fehler in der Zeile ist, was ist der ``Typ`` des erzeugten ``Werte`` in folgendem Code. Beantworte dazu ``//n. erzeugter Wert hat Typ: TODO`` und lösche ``oder Fehler! Begründung: TODO``.
```java
String[][][][][] daten = new String[10][5][15][8][2];
daten[0][0][0][0]    // 1. erzeugter Wert hat Typ: String[]
daten[3][1][6][5]    // 2. erzeugter Wert hat Typ: String[]
Daten[0][0][0]       // 3. Fehler! Begründung: Die Variable Daten gibt es nicht.
daten[0]             // 4. erzeugter Wert hat Typ: String[][][][]
String[][][][][] daten[0][0][0][0][0] // 3. Fehler! Begründung: Die Variable daten ist bereits initialisiert. Der Typ String[][][][][] darf deshalb nicht ein 2. mal beim aufruf der Variable verwendet werden.
```