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

double m = (s1 + s2 + s3 + s4 + s5) / 5.0;
Console.WriteLine($"Die durchschnittliche Temperatur ist: {m}");

int c = (s1 < 0.9 * m || s1 > 1.1 * m ? 1 : 0) +
        (s2 < 0.9 * m || s2 > 1.1 * m ? 1 : 0) +
        (s3 < 0.9 * m || s3 > 1.1 * m ? 1 : 0) +
        (s4 < 0.9 * m || s4 > 1.1 * m ? 1 : 0) +
        (s5 < 0.9 * m || s5 > 1.1 * m ? 1 : 0);
Console.WriteLine($"Anzahl abweichender Sensoren: {c}");

bool a = 2 <= c;
Console.WriteLine($"Alarm? - {a}");
```

1) **Gib die Auswertungsreihenfolge an. Erzeuge ``Werte`` entlang der ``Auswertungsreihenfolge`` wenn ein ``Operator`` die benachbarten ``Werte`` bzw. ``Variablen`` verarbeitet.**

    * **Schritt 1.**- ``Werte`` der ``Variablen`` berechnen und einsetzen 
        * **Mittelwert `m` berechnen:**
            * Zuerst wird die Summe in der Klammer berechnet:
                `m = (15 + 16 + (-4968) + 15 + 15) / 5.0`
            * `m = (-4907) / 5.0`
            * Das Ergebnis ist: `m = -981.4`

        * **Einsetzen:** 
            * Wir ersetzen alle Variablen (`s1` bis `s5` und `m`) durch ihre ``Werte``.

            ```csharp
            int c = (15 < 0.9 * -981.4 || 15 > 1.1 * -981.4 ? 1 : 0) +
                    (16 < 0.9 * -981.4 || 16 > 1.1 * -981.4 ? 1 : 0) +
                    (-4968 < 0.9 * -981.4 || -4968 > 1.1 * -981.4 ? 1 : 0) +
                    (15 < 0.9 * -981.4 || 15 > 1.1 * -981.4 ? 1 : 0) +
                    (15 < 0.9 * -981.4 || 15 > 1.1 * -981.4 ? 1 : 0);
            ```

    2) Ausführugnsreihenfolge:
    * ``Klammern`` binden stärker als alles andere, ``arithmetische Operatoren`` binden stärker als ``vergleichs Operatorn``, diese binden stärker als ``logische Operatoren``, diese binden stärker als der ``ternäre Operator`` (``If-Ausdruck``). 
    * ``Mutiplikation`` bindet stärker als ``Addition``.
    
    1) Beginne links, es öffnet sicheine Klammer - Betrachte **benachbarte Operatoren** innerhalb einer Klammer solange bis **eindeutig ein stärkster übrig bleibt**. Das heißt links und rechts vom stärksten Operator sind schwächerer. ``Vergleichoperator`` *<* und ``logischer Operator`` *||* binden schwächer als ``arithmetischer Operator`` _*_: *0.9 * -981.4* ist *-883.26*.
        ```csharp 
        int c = (15 < 0.9 * -981.4 || 15 > 1.1 * -981.4 ? 1 : 0) +
        ```
        wird zu...
        ```csharp 
        int c = (15 < -883.26 || 15 > 1.1 * -981.4 ? 1 : 0) +
                ...;
        ```

    2) ``Vergleichoperator`` *<* bindet stärker als ``logischer Operator`` *||*: *15 < -883.26* ist *false*.
        ```csharp 
        int c = (15 < -883.26 || 15 > 1.1 * -981.4 ? 1 : 0) +
                ...;
        ```
        wird zu...
        ```csharp
        int c = (false || 15 > 1.1 * -981.4 ? 1 : 0) +
                ...;
        ```

    3) ``logischer Operator`` *||* bindet schwächer als ``Vergleichsoperator`` *>*: Machen wir *15 > 1.1*? Nein! Daneben ist aber ein ``arithmetischer Operator`` _*_, welcher stärker als beide bindet. Gibt es daneben noch einen stärker bindenden ``Operator``? Nein, ``ternärere Operator`` bindet schwächer als ``arithmetischer Operator`` _*_. Deshalb: *1.1 * -981.4* ist *-1079.54*.
        ```csharp
        int c = (false || 15 > 1.1 * -981.4 ? 1 : 0) +
                ...;
        ```
        wird zu...
        ```csharp
        int c = (false || 15 > -1079.54 ? 1 : 0) +
                ...;
        ```
    4) ``Vergleichoperator`` *>* bindet stärker als ``ternärer Operator`` *?:*, danach ist die ``Klammer`` zu: *15 > -1079.54* ist *true*.
        ```csharp
        int c = (false || 15 > -1079.54 ? 1 : 0) +
                ...;
        ```
        wird zu...
        ```csharp
        int c = (false || true ? 1 : 0) +
                ...;
        ```

    4) ``logischer Operator`` *||* bindet stärker als ``ternärer Operator`` *?:*, danach ist die ``Klammer`` zu: *false || true* ist *true*.
        ```csharp
        int c = (false || true ? 1 : 0) +
                ...;
        ```
        wird zu...
        ```csharp
        int c = (true ? 1 : 0) +
                ...;
        ```

    4) Es gibt nur mehr den ``ternärer Operator`` *?:*, danach ist die ``Klammer`` zu: *true ? 1 : 0* ist *1*. 
        ```csharp
        int c = (true ? 1 : 0) +
                ...;
        ```
        wird zu...
        ```csharp
        int c = (1) +
                ...;
        ```

    5) In der ``Klammer`` ist nur mehr ein ``Wert``. Es schließt sich die ``Klammer``.
        ```csharp
        int c = (1) +
                ...;
        ```
        wird zu...
        ```csharp
        int c = 1 + ...;
        ```
     6) Alle ``Klammern`` sind gleich augebaut. Wiederhole 1)-5) mit anderen ``Werten``. Das Ergebnis ist.
        ```csharp
        int c = (wahr ? 1 : 0) + (wahr ? 1 : 0) + (wahr ? 1 : 0) + (wahr ? 1 : 0) + (wahr ? 1 : 0);
        ```
        und wird zu...
        ```csharp
        int c = 1 + 1 + 1 + 1 + 1;
        ```
        und wird zu...
        ```csharp
        int c = 5;
        ```
---

2) **Wird ein Alarm ausgelöst? Wie viele Sensoren sin außerhalb der Toleranz? Vergleiche dein Ergebnis mit dem des Programms.**

    Ja es wird ein Alarm ausgelöst. Es sind 5 Sensoren außerhalb der Toleranz.

3) **Sind die Sensorwerte bedenklich? Soll ein Alarm überhaupt ausgelöst werden, wenn ein Sensor eine große Abweichung hat? Wir wollten doch sicher sein, dass erst wenn zwei Sensoren stark abweichen, ein Alarm ausgelöst wird.**

    **Ja, absolut.** Der Wert `temperatureWien1100 = -4968` ist ein extremer Ausreißer im Vergleich zu den anderen Werten, die alle im Bereich 15-16 liegen. Dies deutet stark auf einen Sensorfehler, denn ein komplettes einfrieren des 10. Bezirks wäre nicht plausibel. **Gefühlsmäßig sollte hier jedoch kein Alarm ausgelöst werden, da es nur ein Sensor ist der Abweicht, nicht die mindestens 2 welche wir im Kopf hatten.** 
    >Das Problem ist der Mittelwert. Wir müssen hier was anderes verwenden.

4) Schreib das Programm um und gib den ``Variablen`` sinnvolle Namen.

    ```csharp
    int temperatureWien1210 = 15;
    int temperatureWien1220 = 16;
    int temperatureWien1100 = -4968;
    int temperatureTulln = 15;
    int temperatureMoedling = 15;

    double averageTemperature = (temperatureWien1210 + temperatureWien1220 + temperatureWien1100 + temperatureTulln + temperatureMoedling) / 5.0;
    Console.WriteLine($"Die durchschnittliche Temperatur ist: {averageTemperature}");

    int howManySensorsSignalAlarm = 0;
    howManySensorsSignalAlarm += Math.Abs(temperatureWien1210 - averageTemperature) > 0.1 * Math.Abs(averageTemperature) ? 1 : 0;
    howManySensorsSignalAlarm += Math.Abs(temperatureWien1220 - averageTemperature) > 0.1 * Math.Abs(averageTemperature) ? 1 : 0;
    howManySensorsSignalAlarm += Math.Abs(temperatureWien1100 - averageTemperature) > 0.1 * Math.Abs(averageTemperature) ? 1 : 0;
    howManySensorsSignalAlarm += Math.Abs(temperatureTulln - averageTemperature) > 0.1 * Math.Abs(averageTemperature) ? 1 : 0;
    howManySensorsSignalAlarm += Math.Abs(temperatureMoedling - averageTemperature) > 0.1 * Math.Abs(averageTemperature) ? 1 : 0;
    Console.WriteLine($"Anzahl abweichender Sensoren: {howManySensorsSignalAlarm}");

    bool isAlarmTriggered = 2 <= howManySensorsSignalAlarm;
    Console.WriteLine($"Alarm? - {isAlarmTriggered}");
    ```

5) Ist hier ein ``If-Ausdruck`` oder eine ``If-Anweisung`` sinnvoller? 

    Im Originalcode wird ein **If-Ausdruck** (in C# als ternärer Operator `?:` bekannt) verwendet: `(Bedingung ? 1 : 0)`.
    * **Vorteil:** Er ist sehr kompakt.
    * **Nachteil:** Bei mehrfacher Aneinanderreihung, wie im Beispiel, wird der Code schnell unübersichtlich und schwer lesbar.
    
    Es ist jedoch auch mit einer ``If-Verzweigung`` schwer lesbar und sehr viel Code. Es ist also beides nicht ideal. Gehen wir zur Aufgabe 3 um eine viel angenehmere Lösung zu sehen.

6) Gib die ``Variablen`` in ein ``Array`` und arbeite mit einer ``If-Anweisung`` innerhalb einer ``Schleife`` um doppelten Code zu vermeiden. Überdenke die Antwort auf 2., was ist lesbarer? 

    ```csharp
    // Sensorwerte in einem Array zusammenfassen
    int[] temperature = { 15, 16, -4968, 15, 15 };

    // Mittelwert berechnen
    double averageTemperature = temperature.Sum() / (double)temperature.Length;
    Console.WriteLine($"Mittelwert: {averageTemperature}");

    // Grenzen für die Abweichung definieren
    double lowerBound = 0.9 * averageTemperature;
    double upperBound = 1.1 * averageTemperature;

    // Zähler für abweichende Sensoren
    int howManySensorsSignalAlarm = 0;

    // Jeden Sensorwert überprüfen
    foreach (int value in temperature)
    {
        // Liegt der Wert außerhalb des Toleranzbereichs?
        // oder anders gesagt, liegt der wert NICHT innerhalb des Toleranzbereichs.
        if ( !(lowerBound < value && value < upperBound) )
        {
            howManySensorsSignalAlarm++; // Wenn ja, Zähler erhöhen
        }
    }

    Console.WriteLine($"Anzahl abweichender Sensoren: {howManySensorsSignalAlarm}");

    bool isAlarmTriggered = howManySensorsSignalAlarm >= 2;
    Console.WriteLine($"Alarm? - {isAlarmTriggered}");
    ```