# Angabe: Fr�hst�cksrestaurant Webanwendung (Minimal API Variante)

## Projekt�bersicht

Dieses Projekt ist eine Webanwendung, die auf .NET basiert und die Funktionalit�t eines einfachen Bestellsystems f�r ein Fr�hst�cksrestaurant abbildet. Im Gegensatz zu einem traditionellen MVC-Ansatz (Model-View-Controller) wird hier das moderne und schlanke **Minimal API** Framework von ASP.NET Core verwendet.

Die Anwendung erm�glicht es, �ber eine Weboberfl�che Bestellungen f�r verschiedene Tische aufzugeben und eine laufend aktualisierte Liste aller bisherigen Rechnungen einzusehen.

## Kernfunktionalit�t der `Program.cs`

Die gesamte Logik der Webanwendung ist in der Datei `Program.cs` enthalten. Diese Datei ist f�r folgende Aufgaben zust�ndig:

1.  **Konfiguration und Service-Initialisierung**:
    * Zu Beginn werden alle notwendigen Dienste aus der urspr�nglichen Konsolenanwendung instanziiert. Dazu geh�ren `DishService`, `MenuService`, `CustomerService` und `BillRepository`.
    * Es wird ebenfalls ein `Serilog`-Logger f�r die Ausgabe von Informationen in der Konsole konfiguriert.

2.  **Erstellung der Webanwendung**:
    * Ein `WebApplication`-Objekt wird erstellt, das als Host f�r die API-Endpunkte dient.

3.  **Definition der API-Endpunkte (Routen)**:
    Die Anwendung definiert zwei zentrale Endpunkte:

    * ### `GET /`
        * **Funktion**: Dies ist der Hauptendpunkt, der die Startseite der Anwendung bereitstellt.
        * **Ablauf**: Wenn ein Benutzer diese URL aufruft, generiert der Server dynamisch eine HTML-Seite. Diese Seite enth�lt:
            1.  Ein **Bestellformular** mit Eingabefeldern f�r Tischnummer, Kundenname und Men�-ID.
            2.  Eine **Liste aller bisherigen Rechnungen**, die durch den Aufruf von `billRepository.GetAllAsync()` aus der `bills.json`-Datei geladen wird.
        * **Technologie**: Der HTML-Code wird direkt im C#-Code mithilfe eines `StringBuilder`s erstellt und als Antwort an den Browser gesendet.

    * ### `POST /bestellen`
        * **Funktion**: Dieser Endpunkt ist daf�r zust�ndig, die Daten aus dem Bestellformular entgegenzunehmen und zu verarbeiten.
        * **Ablauf**:
            1.  Die Anwendung liest die �bermittelten Formulardaten (Tischnummer, Kundenname, Men�-ID) aus dem HTTP-Request aus.
            2.  Aus diesen Daten wird ein `TableOrderDto`-Objekt erstellt, welches die Struktur f�r eine neue Bestellung vorgibt.
            3.  Dieses DTO wird an die Methode `customerService.PlaceOrderAsync(order)` �bergeben. Der `CustomerService` verarbeitet die Bestellung, erstellt eine Rechnung und speichert diese in der `bills.json`-Datei.
            4.  Nach erfolgreicher Verarbeitung wird der Benutzer automatisch wieder auf die Startseite (`/`) umgeleitet, wo die neue Rechnung in der Liste erscheint.

## Beschreibung der HTML-Oberfl�che

Die vom Server generierte Webseite hat ein einfaches, zweispaltiges Layout, das vollst�ndig mit HTML und grundlegendem CSS gestaltet ist.

### 1. Linke Spalte: Bestellformular

Diese Spalte enth�lt den Bereich, in dem neue Bestellungen aufgegeben werden k�nnen.

* **`<form action='/bestellen' method='post'>`**:
    * Das Formular sendet seine Daten per `POST`-Methode an den `/bestellen`-Endpunkt des Servers.

* **`<label for='...'>`**:
    * Jedes Eingabefeld hat eine zugeh�rige Beschriftung. Das `for`-Attribut verkn�pft das Label mit dem `id`-Attribut des Eingabefeldes, was die Benutzerfreundlichkeit und Barrierefreiheit verbessert.

* **`<input type='...' id='...' name='...'>`**:
    * **Tischnummer**: Ein numerisches Eingabefeld (`type='number'`). Das `name='tableNumber'` Attribut ist entscheidend, da dieser Name serverseitig als Schl�ssel zum Auslesen des Wertes verwendet wird.
    * **Kundenname**: Ein Texteingabefeld (`type='text'`) mit dem Namen `customerName`.
    * **Men� ID**: Ein weiteres numerisches Eingabefeld mit dem Namen `menuId`.

* **`<button type='submit'>`**:
    * Ein Klick auf diesen Button sendet das Formular an den Server.

### 2. Rechte Spalte: Rechnungs�bersicht

Diese Spalte zeigt alle Rechnungen an, die bisher im System erfasst wurden.

* **`<h2>Bisherige Rechnungen</h2>`**: Eine �berschrift f�r den Bereich.
* **Bedingte Anzeige**:
    * Falls **keine Rechnungen** vorhanden sind (`bills.json` ist leer), wird der Text "Noch keine Rechnungen vorhanden." angezeigt.
    * **Andernfalls** wird f�r jede Rechnung eine eigene Box mit den Details gerendert.
* **`<ul>` und `<li>`**:
    * Jede Rechnung wird als unsortierte Liste (`<ul>`) dargestellt, um die Informationen klar zu strukturieren.
    * Jedes Detail der Rechnung (Tischnummer, Kunden, Men�s, Betrag) wird als eigenes Listenelement (`<li>`) angezeigt.

## Starten der Anwendung

Um die Anwendung auszuf�hren, f�hren Sie den folgenden Befehl im Hauptverzeichnis des Projekts aus:

```bash
dotnet run
```

�ffnen Sie anschlie�end einen Webbrowser und navigieren Sie zu der im Terminal angezeigten URL (z.B. `http://localhost:5000`).