Ausführungsreihenfolge von Ausdrücken

## Zugriffskontrolle mit Zeitbeschränkung
Ein Benutzer erhält Zugriff, wenn er entweder **Admin ist** oder **sich zwischen 8:00 und 18:00 Uhr anmeldet UND von einer erlaubten IP-Adresse kommt**.

```csharp
bool isAdmin = false;
int currentHour = 18;
bool ipAllowed = true;

bool access = isAdmin || (currentHour >= 8 && currentHour <= 18 && ipAllowed);
```

### Auswertungsreihenfolge und Begründung

Die Auswertung folgt den Operator-Vorrangregeln in C#. Die höchste Priorität haben Klammern, danach folgen arithmetische Operatoren (hier nicht vorhanden), danach Vergleichsoperatoren (`>=`, `<=`) und dann die logischen Operatoren (`&&` vor `||`).

1.  **Klammer `()`**: Der Ausdruck in der Klammer wird zuerst ausgewertet: `(currentHour >= 8 && currentHour <= 18 && ipAllowed)`.
2.  * *Relationaler Operator `>=`**: Innerhalb der Klammer hat `>=` (zusammen mit `<=`) Vorrang vor `&&`. Es wird von links nach rechts ausgewertet: `currentHour >= 8` -> `18 >= 8` ergibt `true`.
3.  **Relationaler Operator `<=`**: Als Nächstes wird `currentHour <= 18` -> `18 <= 18` ausgewertet, was ebenfalls `true` ergibt.
4.  **Logisches UND `&&` (links)**: Der Ausdruck innerhalb der Klammer ist nun `(true && true && ipAllowed)`. Das linke `&&` wird zuerst ausgewertet: `true && true` ergibt `true`.
5.  **Logisches UND `&&` (rechts)**: Der Ausdruck ist nun `(true && ipAllowed)`. `ipAllowed` ist `true`, also `true && true` ergibt `true`. Das Ergebnis der Klammer ist `true`.
6.  **Logisches ODER `||`**: Zuletzt wird der Operator außerhalb der Klammer ausgewertet: `isAdmin || true`. `isAdmin` ist `false`, also `false || true` ergibt `true`.

### Schrittweise Auswertung und Ergebnis

* **Initial:** `access = isAdmin || (currentHour >= 8 && currentHour <= 18 && ipAllowed);`
***Werte einsetzen: ** `access = false || (18 >= 8 && 18 <= 18 && true);`
***Schritt 1(`>=`):** `access = false || (true && 18 <= 18 && true);`
***Schritt 2(`<=`):** `access = false || (true && true && true);`
***Schritt 3(linkes `&&`):** `access = false || (true && true);`
***Schritt 4(rechtes `&&`):** `access = false || true;`
***Schritt 5(`||`):** `access = true;`

Der Wert von `access` ist **`true`**.

---

## Frachtzulassung basierend auf Gewicht und Gefahrgut
Ein Paket darf **nur transportiert werden**, wenn es entweder **kein Gefahrgut ist** oder **unter 50 kg wiegt UND eine Sondergenehmigung hat**.

```csharp
bool isHazardous = true;
bool hasPermit = false;
double weight = 50;

bool transportAllowed = !isHazardous || (weight < 50 && hasPermit);
```

### Auswertungsreihenfolge und Begründung

Die Auswertungspriorität ist: Klammern `()`, nicht Operator `!`, arithmetische Operatoren (nicht vorhanden), Vergleichsoperatoren `<`, logisches AND `&&`, und zuletzt logisches OR `||`.

1.  **Klammer `()`**: Der Ausdruck `(weight < 50 && hasPermit)` wird zuerst ausgewertet.
2.  **Relationaler Operator `<`**: Innerhalb der Klammer wird `weight < 50` -> `50 < 50` ausgewertet, was `false` ergibt.
3.  **Logisches UND `&&`**: Der Ausdruck in der Klammer ist nun `(false && hasPermit)`. Da der erste Operand `false` ist, ist das Ergebnis `false` (Kurzschlussauswertung). Die Klammer ergibt `false`.
4.  **Logisches NICHT `!`**: Der Ausdruck ist nun `!isHazardous || false`. Der unäre Operator `!` hat Vorrang vor `||`. `!isHazardous` -> `!true` ergibt `false`.
5.  **Logisches ODER `||`**: Zuletzt wird `false || false` ausgewertet, was `false` ergibt.

### Schrittweise Auswertung und Ergebnis

* **Initial:** `transportAllowed = !isHazardous || (weight < 50 && hasPermit);`
***Werte einsetzen: ** `transportAllowed = !true || (50 < 50 && false);`
***Schritt 1(`<`):** `transportAllowed = !true || (false && false);`
***Schritt 2(`&&`):** `transportAllowed = !true || false;`
***Schritt 3(`!`):** `transportAllowed = false || false;`
***Schritt 4(`||`):** `transportAllowed = false;`

Der Wert von `transportAllowed` ist **`false`**.

---

## Even/Odd-Check - Schachbrett
Bestimme die Reihenfolge der Auswertung für den folgenden Ausdruck:

```csharp
int x = 17;
int y = 24;

bool isWhite = (x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1);
```

### Auswertungsreihenfolge und Begründung

Die Reihenfolge ist: Klammern `()`, arithmetischer Modulo `%`, Gleichheit `==`, logisches UND `&&`, logisches ODER `||`.

1.  **Linke Klammer `(x % 2 == 0 && y % 2 == 0)`**:
    1.  `x % 2` -> `17 % 2` ergibt `1`.
    2.  `y % 2` -> `24 % 2` ergibt `0`.
    3.  Der Ausdruck wird zu `(1 == 0 && 0 == 0)`.
    4.  `1 == 0` ergibt `false`.
    5.  `0 == 0` ergibt `true`.
    6.  Der Ausdruck wird zu `(false && true)`.
    7.  `false && true` ergibt `false`.
2.  **Rechte Klammer `(x % 2 == 1 && y % 2 == 1)`**:
    1.  `x % 2` -> `17 % 2` ergibt `1`.
    2.  `y % 2` -> `24 % 2` ergibt `0`.
    3.  Der Ausdruck wird zu `(1 == 1 && 0 == 1)`.
    4.  `1 == 1` ergibt `true`.
    5.  `0 == 1` ergibt `false`.
    6.  Der Ausdruck wird zu `(true && false)`.
    7.  `true && false` ergibt `false`.
3.  **Logisches ODER `||`**: Der Gesamtausdruck ist nun `false || false`, was `false` ergibt.

### Schrittweise Auswertung und Ergebnis

* **Initial:** `isWhite = (x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1);`
* **Werte einsetzen:** `isWhite = (17 % 2 == 0 && 24 % 2 == 0) || (17 % 2 == 1 && 24 % 2 == 1);`
* **Schritt 1 (Modulo-Operationen):** `isWhite = (1 == 0 && 0 == 0) || (1 == 1 && 0 == 1);`
* **Schritt 2 (Gleichheits-Operationen):** `isWhite = (false && true) || (true && false);`
* **Schritt 3 (UND-Operationen):** `isWhite = false || false;`
* **Schritt 4 (ODER-Operation):** `isWhite = false;`

Der Wert von `isWhite` (im Text `istFeldWeiß` genannt) ist **`false`**.

---

## Sensorabweichung

```csharp
int s1 = 15;
int s2 = 16;
int s3 = -4968;
int s4 = 15;
int s5 = 15;

double m = (s1 + s2 + s3 + s4 + s5) / 4.0; // Fehler im Originalcode: Sollte durch 5.0 geteilt werden.

int c = (s1 < 0.9 * m || s1 > 1.1 * m ? 1 : 0) +
        (s2 < 0.9 * m || s2 > 1.1 * m ? 1 : 0) +
        (s3 < 0.9 * m || s3 > 1.1 * m ? 1 : 0) +
        (s4 < 0.9 * m || s4 > 1.1 * m ? 1 : 0) +
        (s5 < 0.9 * m || s5 > 1.1 * m ? 1 : 0);

bool alarm = (2 <= c && c <= 4);
```

### Antworten auf die Zusatzfragen

* **Programm mit sinnvollen Namen umschreiben:**
    ```csharp
    int sensor1Value = 15;
    int sensor2Value = 16;
    int sensor3Value = -4968;
    int sensor4Value = 15;
    int sensor5Value = 15;

    // HINWEIS: Hier wurde der Fehler korrigiert und durch 5.0 geteilt.
    double averageValue = (double)(sensor1Value + sensor2Value + sensor3Value + sensor4Value + sensor5Value) / 5.0;

    int deviationCount = 0;
    deviationCount += Math.Abs(sensor1Value - averageValue) > 0.1 * Math.Abs(averageValue) ? 1 : 0;
    deviationCount += Math.Abs(sensor2Value - averageValue) > 0.1 * Math.Abs(averageValue) ? 1 : 0;
    deviationCount += Math.Abs(sensor3Value - averageValue) > 0.1 * Math.Abs(averageValue) ? 1 : 0;
    deviationCount += Math.Abs(sensor4Value - averageValue) > 0.1 * Math.Abs(averageValue) ? 1 : 0;
    deviationCount += Math.Abs(sensor5Value - averageValue) > 0.1 * Math.Abs(averageValue) ? 1 : 0;

    bool isAlarmTriggered = (deviationCount >= 2 && deviationCount <= 4);
    ```
    *Anmerkung: Die Logik zur Abweichungsprüfung wurde ebenfalls verbessert, um mit positiven und negativen Mittelwerten korrekt umzugehen, indem der Absolutbetrag der Abweichung verglichen wird.*

* **If-Ausdruck oder If-Anweisung?**
    Für diese spezielle Aufgabe, bei der ein Wert (1 oder 0) basierend auf einer Bedingung direkt zu einer Summe addiert wird, ist der **If-Ausdruck (ternärer Operator `?:`)** sinnvoller. Er ist kompakter und ausdrucksstärker. Eine If-Anweisung wäre länger:
    ```csharp
    if (s1 < 0.9 * m || s1 > 1.1 * m) {
        c = c + 1;
    }
    // ... dies müsste 5x wiederholt werden.
    ```

* **Sind die Sensorwerte bedenklich?**
    **Ja, absolut.** Der Wert `s3 = -4968` ist ein extremer Ausreißer im Vergleich zu den anderen Werten, die alle im Bereich 15-16 liegen. Dies deutet stark auf einen Sensorfehler oder eine massive Störung hin. Gefühlsmäßig sollte hier definitiv ein Alarm ausgelöst werden.

* **Was passiert bei 5 abweichenden Sensoren?**
    Gemäß der ursprünglichen Logik `bool alarm = (2 <= c && c <= 4);` wird der Alarm **nicht ausgelöst**, wenn `c` den Wert 5 annimmt, da `5 <= 4` `false` ist. Dies ist ein **schwerwiegender Logikfehler**. Ein System sollte bei einer solch katastrophalen Abweichung (alle Sensoren melden Fehler) erst recht alarmieren. Eine bessere Logik wäre `c >= 2`, um bei 2 oder mehr abweichenden Sensoren auszulösen.

### Auswertungsreihenfolge und Ergebnis (basierend auf Originalcode)

1.  **Berechnung von `m`**:
    1.  Klammer `(s1 + s2 + s3 + s4 + s5)`: `15 + 16 - 4968 + 15 + 15` ergibt `-4907`.
    2.  Division: `-4907 / 4.0` ergibt `m = -1226.75`.

2.  **Berechnung von `c`**: Für jede der 5 Zeilen passiert Folgendes:
    1.  `0.9 * m` ergibt `-1104.075`.
    2.  `1.1 * m` ergibt `-1349.425`.
    3.  Die Bedingung lautet `(sensorWert < -1104.075 || sensorWert > -1349.425)`.
    4.  **Für s1 (15):** `15 < -1104.075` (false) `||` `15 > -1349.425` (**true**) -> `true`. Ternärer Ausdruck ergibt `1`.
    5.  **Für s2 (16):** `16 < -1104.075` (false) `||` `16 > -1349.425` (**true**) -> `true`. Ergibt `1`.
    6.  **Für s3 (-4968):** `-4968 < -1104.075` (**true**) `||` ... -> `true`. Ergibt `1`.
    7.  **Für s4 (15):** Ergibt `1`.
    8.  **Für s5 (15):** Ergibt `1`.
    9.  Addition: `c = 1 + 1 + 1 + 1 + 1` ergibt `c = 5`.

3.  **Berechnung von `alarm`**:
    1.  Ausdruck: `(2 <= c && c <= 4)`
    2.  Werte einsetzen: `(2 <= 5 && 5 <= 4)`
    3.  `2 <= 5` ergibt `true`.
    4.  `5 <= 4` ergibt `false`.
    5.  `true && false` ergibt `false`.

Der Wert von `alarm` ist **`false`**.