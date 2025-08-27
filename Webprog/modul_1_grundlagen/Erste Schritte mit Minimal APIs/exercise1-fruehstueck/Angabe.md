# Angabe: Frühstücksrestaurant Webanwendung (Minimal API Variante)

## Projektübersicht

Dieses Projekt ist eine Webanwendung, die auf .NET basiert und die Funktionalität eines einfachen Bestellsystems für ein Frühstücksrestaurant abbildet. Im Gegensatz zu einem traditionellen MVC-Ansatz (Model-View-Controller) wird hier das moderne und schlanke **Minimal API** Framework von ASP.NET Core verwendet.

Die Anwendung ermöglicht es, über eine Weboberfläche Bestellungen für verschiedene Tische aufzugeben und eine laufend aktualisierte Liste aller bisherigen Rechnungen einzusehen.

## Kernfunktionalität der `Program.cs`

Die gesamte Logik der Webanwendung ist in der Datei `Program.cs` enthalten. Diese Datei ist für folgende Aufgaben zuständig:

1.  **Konfiguration und Service-Initialisierung**:
    * Zu Beginn werden alle notwendigen Dienste aus der ursprünglichen Konsolenanwendung instanziiert. Dazu gehören `DishService`, `MenuService`, `CustomerService` und `BillRepository`.
    * Es wird ebenfalls ein `Serilog`-Logger für die Ausgabe von Informationen in der Konsole konfiguriert.

2.  **Erstellung der Webanwendung**:
    * Ein `WebApplication`-Objekt wird erstellt, das als Host für die API-Endpunkte dient.

3.  **Definition der API-Endpunkte (Routen)**:
    Die Anwendung definiert zwei zentrale Endpunkte:

    * ### `GET /`
        * **Funktion**: Dies ist der Hauptendpunkt, der die Startseite der Anwendung bereitstellt.
        * **Ablauf**: Wenn ein Benutzer diese URL aufruft, generiert der Server dynamisch eine HTML-Seite. Diese Seite enthält:
            1.  Ein **Bestellformular** mit Eingabefeldern für Tischnummer, Kundenname und Menü-ID.
            2.  Eine **Liste aller bisherigen Rechnungen**, die durch den Aufruf von `billRepository.GetAllAsync()` aus der `bills.json`-Datei geladen wird.
        * **Technologie**: Der HTML-Code wird direkt im C#-Code mithilfe eines `StringBuilder`s erstellt und als Antwort an den Browser gesendet.

    * ### `POST /bestellen`
        * **Funktion**: Dieser Endpunkt ist dafür zuständig, die Daten aus dem Bestellformular entgegenzunehmen und zu verarbeiten.
        * **Ablauf**:
            1.  Die Anwendung liest die übermittelten Formulardaten (Tischnummer, Kundenname, Menü-ID) aus dem HTTP-Request aus.
            2.  Aus diesen Daten wird ein `TableOrderDto`-Objekt erstellt, welches die Struktur für eine neue Bestellung vorgibt.
            3.  Dieses DTO wird an die Methode `customerService.PlaceOrderAsync(order)` übergeben. Der `CustomerService` verarbeitet die Bestellung, erstellt eine Rechnung und speichert diese in der `bills.json`-Datei.
            4.  Nach erfolgreicher Verarbeitung wird der Benutzer automatisch wieder auf die Startseite (`/`) umgeleitet, wo die neue Rechnung in der Liste erscheint.

## Beschreibung der HTML-Oberfläche

Die vom Server generierte Webseite hat ein einfaches, zweispaltiges Layout, das vollständig mit HTML und grundlegendem CSS gestaltet ist.

### 1. Linke Spalte: Bestellformular

Diese Spalte enthält den Bereich, in dem neue Bestellungen aufgegeben werden können.

* **`<form action='/bestellen' method='post'>`**:
    * Das Formular sendet seine Daten per `POST`-Methode an den `/bestellen`-Endpunkt des Servers.

* **`<label for='...'>`**:
    * Jedes Eingabefeld hat eine zugehörige Beschriftung. Das `for`-Attribut verknüpft das Label mit dem `id`-Attribut des Eingabefeldes, was die Benutzerfreundlichkeit und Barrierefreiheit verbessert.

* **`<input type='...' id='...' name='...'>`**:
    * **Tischnummer**: Ein numerisches Eingabefeld (`type='number'`). Das `name='tableNumber'` Attribut ist entscheidend, da dieser Name serverseitig als Schlüssel zum Auslesen des Wertes verwendet wird.
    * **Kundenname**: Ein Texteingabefeld (`type='text'`) mit dem Namen `customerName`.
    * **Menü ID**: Ein weiteres numerisches Eingabefeld mit dem Namen `menuId`.

* **`<button type='submit'>`**:
    * Ein Klick auf diesen Button sendet das Formular an den Server.

### 2. Rechte Spalte: Rechnungsübersicht

Diese Spalte zeigt alle Rechnungen an, die bisher im System erfasst wurden.

* **`<h2>Bisherige Rechnungen</h2>`**: Eine Überschrift für den Bereich.
* **Bedingte Anzeige**:
    * Falls **keine Rechnungen** vorhanden sind (`bills.json` ist leer), wird der Text "Noch keine Rechnungen vorhanden." angezeigt.
    * **Andernfalls** wird für jede Rechnung eine eigene Box mit den Details gerendert.
* **`<ul>` und `<li>`**:
    * Jede Rechnung wird als unsortierte Liste (`<ul>`) dargestellt, um die Informationen klar zu strukturieren.
    * Jedes Detail der Rechnung (Tischnummer, Kunden, Menüs, Betrag) wird als eigenes Listenelement (`<li>`) angezeigt.

## Starten der Anwendung

Um die Anwendung auszuführen, führen Sie den folgenden Befehl im Hauptverzeichnis des Projekts aus:

```bash
dotnet run
```

Öffnen Sie anschließend einen Webbrowser und navigieren Sie zu der im Terminal angezeigten URL (z.B. `http://localhost:5000`).