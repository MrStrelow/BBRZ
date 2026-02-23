# Arrays und Zufallszahlen 🌍🎲

Verwende folgende Vorlage [(Link)](../L01_WaldErzeugen/Program.cs) und erweitere diese.

### Aufgabe 1 (am Zettel): Pen(C)il (Sharp)ener
* Lege einen *Zufallszahlengenerator* als ``Objekt`` *generator* der ``Klasse`` *Random* an.
    ```



    ```

* Lege einen *Zufallszahlengenerator* als ``Objekt`` *generator* der ``Klasse`` *Random* mit einem ``Seed`` an.
    ```



    ```

* Verwende den *Zufallszahlengenerator* und ziehe damit eine Kommazahl des ``Typs`` *double* und weise diesen ``Wert`` der ``Variable`` *bedingung* zu. Diese ``Variable`` soll Zahlen zwischen 15.6 (inklusive) und 115.6 (exclusive) halten.
    ```



    ```

* Frage mit einer ``Mehrfachverzweigung`` ab, ob die oben verwendete ``Variable`` *bedingung* zwischen 
    * 15.6 (inklusive) und 85.6 (exklusive), 
    * 85.6 (inklusive) und 110.6 (exklusive), und
    * 110.6 (inklusive) und 115.6 (exclusive) ist.

    Fülle die ``Zweige`` mit 
    * *cw("common");* 
    * *cw("rate");*
    * *cw("epic");*
    ```












    ```
* Verwende den *Zufallszahlengenerator* und ziehe damit zwei ganze Zahlen des ``Typs`` *int* und weise diese ``Werte`` den ``Variablen`` *x* und *y* zu. Diese ``Variablen`` soll Zahlen zwischen 10 (inklusive) und 25 (inklusive) halten.
    ```



    ```

---

### Aufgabe 2 (am Zettel): Finde die Fehler und behebe diese

*   Ausgabe mehrerer zufälliger ganzer Zahlen.

    ```csharp
    for (int x = 0; x < 100; x++)
    {
        Random generator = new Random(101);
        Console.WriteLine(generator.Next(0, 25));
    }
    ```
    ```





    ```

*   Zugriff auf Arrays mit zufälligem Index.
    ```csharp
    int [] zahlen = new int[10];
    Random generator = new Random(101);

    for (int x = 0; x < 3; x++)
    {
        int index = generator.Next(x, zahlen.Length + 1);
        Console.WriteLine(zahlen[index]);
    }
    ```
    ```






    ```

---

### 🙂 Aufgabe 3: Mangroven im Wasser 🌴
Aktuell können Bäume nur auf Erde (100% Chance) oder Gestein (10% Chance) wachsen. Die Anzahl der gepflanzten Gewächse wird durch `limitAnBaeumen` begrenzt.
Erweitere die `while`-Schleife in der Methode `PflanzeBaeume`. Wenn das zufällig ausgewählte Feld Wasser (`🟦`) ist, soll dort mit einer **Chance von 5%** eine Mangrove (`🌴`) entstehen. 
>**Hinweis:** Vergiss nicht in der ``Methode`` *SpeichereKarte* die ``Varablen`` zu ergänzen.

### 🙂 Aufgabe 4: Endlosschleifen
Ändere in der `Main`-Methode den Wert bei ``double prozentWaldAufKarte = 0.25;`` auf `0.85` (also 85%). Das Programm wird nie aufhören. Warum?

Das Problem wird folgendermaßen behoben:
1) Erstelle eine Methode `SetProzentWaldAufKarte(double wunschProzentBaeume, string[,] karte)`:
2) Zähle mithilfe von zwei verschachtelten `for`-Schleifen, wie viele Felder auf der Karte aus Erde (`🟫`) oder Stein (`🗻`) bestehen. Speichere das Ergebnis in ``anzahlSteineOderErde``.
3) Berechne die Gesamtanzahl der Felder (`anzahlOrte = breite * hoehe`).
4) Prüfe mit einer ``Verzweigung`` ob die gewünschte Anzahl an Bäumen (`anzahlOrte * wunschProzentBaeume`) größer als der zur Verfügung stehende Platz (`anzahlSteineOderErde`) ist.
5) Wenn ja: Gib eine Warnung über `Console.WriteLine` aus und gib den Prozentwert `0.8 * anzahlSteineOderErde / anzahlOrte` zurück (das reserviert 80% des nutzbaren Platzes).
6) Wenn nein: Gebt einfach den `wunschProzentBaeume` unverändert zurück.

### 🤔 Aufgabe 5: Sandinseln aufschütten 🟨
Die `Main`-Methode ruft eine Methode `SchuetteInselnAuf` auf und möchte, dass dort Sandinseln im Wasser entstehen.
1) Erstelle eine Methode `SchuetteInselnAuf`.
    ```csharp
    static string[,] SchuetteInselnAuf(string[,] karteOhneInseln, int limitAnInseln)
    ```
2) Verwende eine `while`-Schleife, die so lange läuft, bis der ``Parameter`` `limitAnInseln` erreicht ist. 
3) Wähle darin zufällige Koordinaten für die möglichen Sandinseln aus. Wenn an diesen Koordinaten Wasser (`🟦`) ist, überschreibe es mit dem Sand-Symbol (`🟨`) und erhöhe den Zähler für die fertiggestellten Inseln. Implementiere zuerst eine der folgenden Varianten. Danach entferne diese und probiere eine neue. 
    1) Sandinseln sollen nur im **link-oberen** Viertel der Karte entstehen können.
        ```
        ❌0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣6️⃣7️⃣
        0️⃣🟨🟨🟨🟨🟦🟦🟦🟦
        1️⃣🟨🟨🟨🟨🟦🟦🟦🟦
        2️⃣🟨🟨🟨🟨🟦🟦🟦🟦
        3️⃣🟨🟨🟨🟨🟦🟦🟦🟦
        4️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        5️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        6️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        7️⃣🟦🟦🟦🟦🟦🟦🟦🟦

        ```
    2) Sandinseln sollen nur im **recht-unteren** Viertel der Karte entstehen können.
        ```
        ❌0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣6️⃣7️⃣
        0️⃣🟦🟦🟦🟦🟨🟨🟨🟨
        1️⃣🟦🟦🟦🟦🟨🟨🟨🟨
        2️⃣🟦🟦🟦🟦🟨🟨🟨🟨
        3️⃣🟦🟦🟦🟦🟨🟨🟨🟨
        4️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        5️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        6️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        7️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        ```
    3) Sandinseln sollen nur in einem **Viertel symmetrisch um den Mittelpunkt** der Karte entstehen können. 
        ```
        ❌0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣6️⃣7️⃣
        0️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        1️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        2️⃣🟦🟦🟨🟨🟨🟨🟦🟦
        3️⃣🟦🟦🟨🟨🟨🟨🟦🟦
        4️⃣🟦🟦🟨🟨🟨🟨🟦🟦
        5️⃣🟦🟦🟨🟨🟨🟨🟦🟦
        6️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        7️⃣🟦🟦🟦🟦🟦🟦🟦🟦
        ```

4) Rufe diese Methode in eurer `Main`-Methode auf, **bevor** `PflanzeBaeume` ausgeführt wird. Übergebe dabei die berechnete `anzahlInseln` und verwendee die zurückgegebene Karte (*2D-string-Array*) mit den Inseln für das anschließende Pflanzen der Bäume.

### 😕 Aufgabe 6: 🌴 Palmen und Sandstrände 🏖️
Wenn in der Methode `PflanzeBaeume` das zufällige Feld aus **Sand** (`🟨`) besteht, soll dort ab sofort eine Palme (`🌴`) wachsen (erhöht auch hier die Zählvariable für die Bäume).  Zusätzlich müssen aber alle **direkt angrenzenden Felder** (Norden, Süden, Westen, Osten) ebenfalls in Sand umgewandelt werden, sofern diese noch innerhalb der Karte sind. Auch sollen benachbarte Palmen nicht von Sand überschrieben werden.

1) Erstelle eine Methode `string[,] ZeichneSandUmBaum(int xPalme, int yPalme, string[,] karte)`:
2) Füge in der ``Methode`` *PflanzeBaeume* innerhalb der ``Mehrfachverzweigung`` im ``Zweig`` für den Sand die ``Methode`` *ZeichneSandUmBaum(x, y, karteMitBaeumen)* auf.
3) Implementiert nun die Logik in `ZeichneSandUmBaum`: Prüft die 4 Nachbarfelder auf Gültigkeit (nicht über den Array-Rand hinauslesen!).
4) Wenn auf der Karte, das gelesene Symbol **keine** Palme (`🌴`) ist, überschreibt das Feld mit Sand (`🟨`).