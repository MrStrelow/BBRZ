## Pakete einlagern
Das Programm basiert auf zwei ``Dictionaries`` (lager und produkte) und einer Variable für die Kapazität. Die Kapazität schränkt das lager nicht direkt ein, sondern lässt ein hinzufügen zu diesen einfach nicht mehr zu.

* **`produkte` (Dictionary):** Ein Nachschlagewerk, das alphanumerische Produkt-IDs (SKUs) auf ihre grafische Darstellung (Emoji) abbildet. Dieses Dictionary ist zu Beginn des Programms fest definiert.
    * **Schlüssel:** `string` (Die eindeutige Produkt-ID, z.B. "AT-UMBR-RD-01")
    * **Wert:** `string` (Das entsprechende Emoji, z.B. "🌂")
    * Verwende folgende Produkte
        ```
        ID: AT-UMBR-RD-01 -> Produkt: 🌂
        ID: DE-EXTING-2KG -> Produkt: 🧯
        ID: EU-BASKET-LG -> Produkt: 🧺
        ID: AT-BROOM-W-05 -> Produkt: 🧹
        ID: CH-RAZOR-M3 -> Produkt: 🪒
        ID: DE-SOAP-LAV-1 -> Produkt: 🧼
        ID: AT-MIRROR-SQR -> Produkt: 🪞
        ID: EU-TOILET-C1 -> Produkt: 🚽
        ID: DE-PLUNGER-01 -> Produkt: 🪠
        ID: CH-RING-DMND -> Produkt: 💍
        ```

* **`lager` (Dictionary):** Die zentrale Datenstruktur, die den Inhalt des Lagers repräsentiert. Leere Plätze werden *nicht* gespeichert; die Anzahl der Einträge entspricht der Anzahl der belegten Plätze.
    * **Schlüssel:** `long` (Die vom Benutzer vergebene, eindeutige Paketnummer)
    * **Wert:** `string` (Die Produkt-ID des eingelagerten Artikels)

* **`lagerGroesse` (Variable):** Eine `int`-Variable, die die maximale Kapazität des Lagers speichert. Sie wird zu Beginn vom Benutzer festgelegt.

## Programablauf

1.  **Initialisierung:**
    * Definieren Sie das `produkte`-Dictionary mit mindestens 10 verschiedenen Produkten und deren IDs.
    * Geben Sie zu Beginn eine Liste aller verfügbaren Produkte mit ihren IDs aus.
    * Fragen Sie den Benutzer, wie groß das Lager sein soll, und speichern Sie diesen Wert in der `lagerGroesse`-Variable.
    * Initialisieren Sie das `lager`-Dictionary als leeres Dictionary.

2.  **Hauptschleife:**
    Das Programm soll in einer Endlosschleife laufen, bis der Benutzer die Aktion `beenden` wählt. In jeder Iteration der Schleife sollen folgende Schritte ausgeführt werden:

    * **Bestand anzeigen:** Generieren Sie dynamisch eine Textausgabe des aktuellen Lagerbestands.
        * Gehen Sie die `Values` (Produkt-IDs) des `lager`-Dictionaries durch. Schlagen Sie für jede ID das zugehörige Emoji im `produkte`-Dictionary nach und geben Sie es aus.
        * Berechnen Sie die Anzahl der freien Plätze (`leerePlaetze = lagerGroesse - lager.Count`).
        * Geben Sie entsprechend viele "leere Paket"-Symbole (📦) aus.
        * Das Ergebnis sollte immer zuerst alle belegten Plätze und danach alle leeren Plätze zeigen.

    * **Aktion abfragen:** Fragen Sie den Benutzer, welche Aktion er ausführen möchte (`einlagern`, `auslagern` oder `beenden`).

3.  **Aktionslogik:**

    * **`einlagern`:**
        1.  Prüfen Sie, ob das Lager voll ist (`lager.Count >= lagerGroesse`). Wenn ja, geben Sie eine Fehlermeldung aus und fahren Sie fort.
        2.  Fragen Sie den Benutzer nach der **Paketnummer** und der **Produkt-ID** (in einer Zeile, durch Leerzeichen getrennt).
        3.  Validieren Sie die Eingabe:
            * Ist die Paketnummer bereits als Schlüssel im `lager`-Dictionary vorhanden?
            * Existiert die eingegebene Produkt-ID als Schlüssel im `produkte`-Dictionary?
        4.  Wenn alle Prüfungen erfolgreich sind, fügen Sie einen neuen Eintrag zum `lager`-Dictionary hinzu: `{ Paketnummer, Produkt-ID }`.

    * **`auslagern`:**
        1.  Fragen Sie den Benutzer nach der **Paketnummer**, die entfernt werden soll.
        2.  Versuchen Sie, den Eintrag mit dieser Paketnummer aus dem `lager`-Dictionary zu entfernen.
        3.  Geben Sie eine Erfolgsmeldung aus, wenn die Paketnummer gefunden und entfernt wurde. Andernfalls geben Sie eine Fehlermeldung aus, dass die Nummer nicht gefunden wurde.

    * **`beenden`:**
        1.  Geben Sie eine Abschiedsnachricht aus und beenden Sie das Programm.


Beispiel:
```
Willkommen bei der Lagerverwaltung!
Verfügbare Produkte:
  ID: AT-UMBR-RD-01 -> Produkt: 🌂
  ID: DE-EXTING-2KG -> Produkt: 🧯
  ID: EU-BASKET-LG -> Produkt: 🧺
  ID: AT-BROOM-W-05 -> Produkt: 🧹
  ID: CH-RAZOR-M3 -> Produkt: 🪒
  ID: DE-SOAP-LAV-1 -> Produkt: 🧼
  ID: AT-MIRROR-SQR -> Produkt: 🪞
  ID: EU-TOILET-C1 -> Produkt: 🚽
  ID: DE-PLUNGER-01 -> Produkt: 🪠
  ID: CH-RING-DMND -> Produkt: 💍

Wie groß ist das Lager [ganze Zahl]? 5

Aktueller Lagerbestand:
📦 📦 📦 📦 📦
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
Geben Sie Paketnummer und Produkt-ID an [Paketnummer Produkt-ID]: 1245 AT-UMBR-RD-01
Produkt 🌂 erfolgreich auf Paketnummer 1245 eingelagert.

Aktueller Lagerbestand:
🌂 📦 📦 📦 📦
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
Geben Sie Paketnummer und Produkt-ID an [Paketnummer Produkt-ID]: 4578 AT-MIRROR-SQR
Produkt 🪞 erfolgreich auf Paketnummer 4578 eingelagert.

Aktueller Lagerbestand:
🌂 🪞 📦 📦 📦
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
Geben Sie Paketnummer und Produkt-ID an [Paketnummer Produkt-ID]: 78984556 DE-EXTING-2KG
Produkt 🧯 erfolgreich auf Paketnummer 78984556 eingelagert.

Aktueller Lagerbestand:
🌂 🪞 🧯 📦 📦
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
Geben Sie Paketnummer und Produkt-ID an [Paketnummer Produkt-ID]: 1d whatisthis
Fehler: Ungültige Eingabe. Format: [Zahl] [Text]

Aktueller Lagerbestand:
🌂 🪞 🧯 📦 📦
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
Geben Sie Paketnummer und Produkt-ID an [Paketnummer Produkt-ID]: 1827 whatisthis
Fehler: Unbekannte Produkt-ID 'whatisthis'.

Aktueller Lagerbestand:
🌂 🪞 🧯 📦 📦
Wählen Sie eine Aktion (einlagern, auslagern, beenden): auslagern 1245
Unbekannte Aktion. Bitte versuchen Sie es erneut.

Aktueller Lagerbestand:
🌂 🪞 🧯 📦 📦
Wählen Sie eine Aktion (einlagern, auslagern, beenden): auslagern
Geben Sie die Paketnummer ein, die ausgelagert werden soll: 1245
Paket 1245 erfolgreich ausgelagert.

Aktueller Lagerbestand:
🪞 🧯 📦 📦 📦
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
Geben Sie Paketnummer und Produkt-ID an [Paketnummer Produkt-ID]: 4578 EU-TOILET-C1
Fehler: Paketnummer bereits vergeben!

Aktueller Lagerbestand:
🪞 🧯 📦 📦 📦
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
Geben Sie Paketnummer und Produkt-ID an [Paketnummer Produkt-ID]: 45782020 EU-TOILET-C1
Produkt 🚽 erfolgreich auf Paketnummer 45782020 eingelagert.

Aktueller Lagerbestand:
🚽 🪞 🧯 📦 📦
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
Geben Sie Paketnummer und Produkt-ID an [Paketnummer Produkt-ID]: 6598 DE-PLUNGER-01
Produkt 🪠 erfolgreich auf Paketnummer 6598 eingelagert.

Aktueller Lagerbestand:
🚽 🪞 🧯 🪠 📦
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
Geben Sie Paketnummer und Produkt-ID an [Paketnummer Produkt-ID]: 159263 DE-PLUNGER-01
Produkt 🪠 erfolgreich auf Paketnummer 159263 eingelagert.

Aktueller Lagerbestand:
🚽 🪞 🧯 🪠 🪠
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
Geben Sie Paketnummer und Produkt-ID an [Paketnummer Produkt-ID]: 15 DE-PLUNGER-01
Lager ist voll. Einlagern nicht möglich.

Aktueller Lagerbestand:
🚽 🪞 🧯 🪠 🪠
```