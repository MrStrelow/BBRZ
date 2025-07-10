Absolut! Hier ist die Angabe für die letzte, vereinfachte Version des Projekts als reines Markdown-Dokument.

***

# Frühstücksrestaurant

**Kernkonzepte:**
* **Service- und Repository-Pattern** in einer einfachen Ausprägung.
* **Asynchrone Programmierung** mit `async`, `await`, `Task.WhenAll` und `Task.WhenAny`.
* **LINQ** für Datenabfragen und Analysen.
* **JSON-Serialisierung** als einfache Datenbank-Alternative.
* **Data Transfer Objects (DTOs)** für die Kommunikation zwischen den Schichten.

---

## Szenario

Das Restaurant **"Morgenstund'"** hat 3 Tische mit Platz für je maximal 4 Kunden. Es werden 3 verschiedene Frühstücksmenüs angeboten, die aus insgesamt 6 einzigartigen Gerichten bestehen. Jedes Gericht benötigt bestimmte Zutaten aus dem Lager. Wähle diese nach Belieben.

---

## Anforderungen & Architektur

### 1. Projektstruktur
Organisiere deinen Code in einer Konsolenanwendung mit den folgenden Ordnern:
* `/Entities`
* `/DTOs`
* `/Repositories`
* `/Services`

### 2. Datenschicht: Konkrete Repositories
Für jede Kern-Entität wird ein eigenes, konkretes Repository (Interface und Klasse) erstellt. Jedes Repository ist selbst für das Lesen und Schreiben seiner spezifischen JSON-Datei im Unterordner `/Data` verantwortlich.

* **`BillRepository`**: Verwaltet die `Bill`-Objekte (`bills.json`).
* **`MenuRepository`**: Verwaltet die `Menu`-Definitionen (`menus.json`).
* **`DishRepository`**: Verwaltet die `Dish`-Definitionen (`dishes.json`).
* **`StockRepository`**: Verwaltet den Lagerbestand der Zutaten (`stock.json`).

Alle datenzugreifenden Methoden müssen **asynchron** sein.

### 3. Logikschicht: Services
Die Services enthalten die Geschäftslogik und erstellen ihre Abhängigkeiten (andere Services oder Repositories) direkt in ihrem Konstruktor.

* **`DishService`**
    * **Aufgabe:** "Zubereitung" eines einzelnen Gerichts.
    * **Abhängigkeiten:** `DishRepository`, `StockRepository`.
    * **Logik:** Lädt die Gerichtsdaten, prüft die Zutaten im Lager und verringert deren Anzahl.

* **`MenuService`**
    * **Aufgabe:** Zusammenstellung eines kompletten Menüs.
    * **Abhängigkeiten:** `MenuRepository`, `DishService`.
    * **Logik:** Lädt eine Menü-Definition und ruft den `DishService` für jedes zugehörige Gericht auf. Nutze `Task.WhenAll`, um die Gerichte parallel "zuzubereiten".

* **`CustomerService`**
    * **Aufgabe:** Annahme und Verarbeitung einer Bestellung für einen ganzen Tisch.
    * **Abhängigkeiten:** `MenuService`, `BillRepository`.
    * **Logik:** Verarbeitet ein `OrderDto`, ruft den `MenuService` für jeden Kunden am Tisch auf, erstellt ein `Bill`-Objekt (Rechnung) und speichert dieses über das `BillRepository`.

* **`AnalyticsService`**
    * **Aufgabe:** Analyse der Verkaufsdaten.
    * **Abhängigkeiten:** `BillRepository`.
    * **Logik:** Ermittelt mittels **LINQ** den meistbesuchten Tisch und das meistverkaufte Menü aus allen gespeicherten Rechnungen.

### 4. Datenübertragungsobjekte (DTOs)
DTOs werden für die Kommunikation zwischen den Schichten verwendet.
* `OrderDto`: Wird an den `CustomerService` übergeben, um eine Bestellung aufzugeben.
* `RestaurantAnalyticsDto`: Wird vom `AnalyticsService` zurückgegeben, um die Ergebnisse darzustellen.

---

## Simulationsablauf in `Program.cs`

Die `Program.cs`-Datei dient als Einstiegspunkt und steuert die Simulation.

1.  **Initialisierung & Seeding:**
    * Erstelle Instanzen der benötigten Services (`CustomerService`, `AnalyticsService`).
    * Implementiere eine `Seed`-Methode, die die JSON-Dateien mit Anfangsdaten für Menüs, Gerichte und den Lagerbestand füllt, falls diese nicht existieren.

2.  **Bestellungen simulieren:**
    * Erstelle mehrere `OrderDto`-Objekte für verschiedene Tische.
    * Starte die Verarbeitung der Bestellungen parallel mit `Task.WhenAll`.
    * Verwende `Task.WhenAny`, um auf der Konsole auszugeben, welcher Tisch als erster seine komplette Bestellung erhalten hat.

3.  **Analyse durchführen:**
    * Nachdem alle Bestellungen verarbeitet wurden, rufe den `AnalyticsService` auf.
    * Gib die Analyse-Ergebnisse (meistbesuchter Tisch, beliebtestes Menü etc.) übersichtlich auf der Konsole aus.