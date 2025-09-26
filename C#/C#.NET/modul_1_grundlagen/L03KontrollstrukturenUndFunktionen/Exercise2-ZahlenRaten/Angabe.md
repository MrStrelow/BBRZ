Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Schleifen
* Verzweigungen
* User-Input
* Operatoren (besonders logische)

Welche ``Denkweisen`` üben wir hier?
* Wie steuere ich eine ``Schleife`` mit ``logischen Bedingungen``?

Bei Unklarheiten hier nachlesen:
* [welche Kontrollstrukturen soll ich verwenden?](../Skripten/L03.1Kontrollstrukturen.md)

## Zahlen raten

Der Benutzer muss eine geheime Zahl zwischen 0 und 100 am Terminal erraten. Nach jeder Eingabe gibt das Programm Hinweise, ob die Zahl zu hoch oder zu klein ist. Der Benutzer hat 5 Leben. Wenn die Leben aufgebraucht sind, endet das Spiel mit einer Niederlage.

Weiters soll folgendes gelten:

* **Geheime Zahl:**
    Das Programm wählt zu Beginn eine zufällige Zahl zwischen 0 und 100 (einschließlich) aus.
    Verwenden Sie dazu die Klasse `Random` aus dem Namespace `System`. Normalerweise ist dieser Namespace standardmäßig verfügbar. Erstellen Sie ein Objekt dieser Klasse, z.B. `Random random = new Random();`, und verwenden Sie die Methode `Next()`, um eine Zufallszahl zu generieren: `int geheimeZahl = random.Next(0, 101);` (dies generiert eine Zahl von 0 bis 100, da der obere Grenzwert exklusiv ist).

* **Userinput:**
    Ein:e Benutzer:in wird in jeder Runde aufgefordert, eine Zahl einzugeben. Die Eingabe muss überprüft werden, ob sie der geheimen Zahl entspricht. Verwenden Sie `Console.ReadLine()`, um die Eingabe des Benutzers als Text (String) zu lesen. Anschließend muss dieser String in eine Ganzzahl umgewandelt werden. Verwende dazu `int.TryParse()` für eine robustere Fehlerbehandlung. Beispiel: 
    ```csharp
    int guess;
    while (!int.TryParse(Console.ReadLine(), out guess))
    {
        Console.WriteLine("Bitte eine gültige Zahl eingeben! Gib eine Zahl ein [0-100]: ");
    }
    ```

* **Interaktion mit Benutzer:innen:**
    Wenn die Eingabe zu hoch ist, gibt das Programm die Nachricht *"Die Zahl ist zu hoch!"* aus.
    Wenn die Eingabe zu niedrig ist, gibt das Programm die Nachricht *"Die Zahl ist zu klein!"* aus.
    Bei korrekter Eingabe zeigt das Programm *"Herzlichen Glückwunsch, Sie haben die Zahl erraten!"* an und beendet das Spiel.

* **Anzahl der Versuche:**
    Ein:e Benutzer:in hat `5` Leben. Bei jeder falschen Eingabe verliert diese:r ein Leben. Wenn die Leben aufgebraucht sind, endet das Spiel mit der Nachricht: *"Game Over! Die geheime Zahl war: <Geheime Zahl>"*.

* **`optional`**: Gib am Ende die Anzahl der Versuche aus, die ein:e Benutzer:in benötigt um die Zahl zu erraten. Füge eine Möglichkeit hinzu, das Spiel nach einem Durchgang erneut zu starten.

## Hilfestellung:

* Nutzen Sie eine `Schleife` (z.B. eine `while`-Schleife), um die Eingaben zu prüfen, bis die Zahl erraten wurde oder die Leben aufgebraucht sind. Eine `while`-Schleife eignet sich gut, wenn die Anzahl der Wiederholungen unbekannt ist.

* Verwenden Sie `Random random = new Random(); int geheimeZahl = random.Next(0, 101);`.
    **Achtung!** `random.Next(0, 101)` generiert eine Zahl von 0 bis 100 (also inklusive 0 und inklusive 100, da der zweite Parameter exklusiv ist).

* `int leben = 5;` (Zählt, wie viele Leben ein:e Benutzer:in hat).

* Nutzen Sie `Console.ReadLine()` gefolgt von `int.Parse()` oder `int.TryParse()`, um Eingaben aus dem Terminal einzulesen und in eine Zahl umzuwandeln.

### Testfälle:
```
Willkommen beim Zahlen-Ratespiel!
Ich habe eine geheime Zahl zwischen 0 und 100 ausgewählt.
Sie haben 5 Leben. Viel Glück!
 
Geben Sie Ihre Schätzung ein: 
> 50
Die Zahl ist zu hoch! Sie haben noch 4 Leben.
 
Geben Sie Ihre Schätzung ein: 
> 25
Die Zahl ist zu klein! Sie haben noch 3 Leben.
 
Geben Sie Ihre Schätzung ein: 
> 37
Die Zahl ist zu hoch! Sie haben noch 2 Leben.
 
Geben Sie Ihre Schätzung ein: 
> 30
Die Zahl ist zu klein! Sie haben noch 1 Leben.
 
Geben Sie Ihre Schätzung ein: 
> 35
Game Over! Die geheime Zahl war: 33
```