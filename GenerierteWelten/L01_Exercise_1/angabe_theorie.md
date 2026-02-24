# Arrays und Zufallszahlen 🌍🎲

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

* Verwende folgenden Linearen Kongruenzgenerator $x_{i+1} = [(k \cdot x_i + d) \;\; \text{mod}\;\; m] + n$ und berechne die ersten 3 Pseudozufallszahlen für $k = 5$, $d = 7$, $m = 16$, $n = 10$ und $x_0=101$. Verwende einen Taschenrechner oder schreibe ein kurzes C#-Programm.

    | $i$ | Aktueller Wert ($x_i$) | Neuer Wert ($x_{i+1}$) |
    | :--- | :--- | :--- |
    | **0** |       |                               |
    | **1** |       |                               |
    | **2** |       |                               |


* Verwende folgenden Linearen Kongruenzgenerator $x_{i+1} = [(k \cdot x_i + d) \;\; \text{mod}\;\; m] + n$ mit den Konstanten $k = 5$, $d = 7$, $m = 16$, $n = 10$ und $x_0=101$. Füllen den vorgegebenen C#-Code mit den in der Formel verwendeten Konstanten und Seed aus. Es soll der gleiche ``Seed`` und der gleiche Bereich der Zufallszahlen im Programmcode und Formel sein.
    ```csharp
    Random generator = new Random(  );
    Console.WriteLine(generator.next(  ,  ));
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