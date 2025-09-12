# Übungsangabe: Erstellen und Testen einer To-Do-Listen-API

## Ziel

In dieser Übung werden Sie eine einfache To-Do-Listen-API, die mit .NET Minimal APIs erstellt wurde, analysieren, ausführen und testen. Das Ziel ist es, ein grundlegendes Verständnis für die Erstellung von Endpoints, den Umgang mit verschiedenen HTTP-Methoden (GET, POST, PUT, DELETE) und die Verarbeitung von Routen- und Query-Parametern zu erlangen.

## Voraussetzungen

* [.NET 9 SDK](https://dotnet.microsoft.com/download) und kein https.
* Ein Werkzeug zum Testen von APIs -> wir verwenden ein File mit Endung .http (http-json.http).

## Code-Übersicht

Der bereitgestellte Code (`Program.cs`) implementiert eine komplette Web-API in einer einzigen Datei. Die wichtigsten Bestandteile sind:

* **Datenspeicher**: Ein `ConcurrentDictionary<int, string>` dient als einfacher, temporärer In-Memory-Speicher für unsere To-Do-Einträge. In einer echten Anwendung wäre dies eine Datenbank.
* **Web Application Builder**: `WebApplication.CreateBuilder(args)` und `builder.Build()` richten den Webserver und die Anwendungskonfiguration ein.
* **HTTP-Endpunkte**: Methoden wie `app.MapGet()`, `app.MapPost()`, `app.MapPut()` und `app.MapDelete()` definieren die API-Endpunkte. Sie verknüpfen eine URL und eine HTTP-Methode mit einer C#-Lambda-Funktion, die die Anfrage verarbeitet.
* **Record `Todo`**: Ein einfacher Datentyp, der die Struktur der JSON-Daten für das Erstellen und Aktualisieren von To-Dos definiert.

## Aufgaben

### 1. Projekt ausführen

1.  Speichern Sie den bereitgestellten C#-Code in einer Datei namens `Program.cs`.
2.  Öffnen Sie ein Terminal im selben Verzeichnis.
3.  Führen Sie den Befehl `dotnet run` aus.
4.  Die API ist nun unter den in der Konsole angezeigten Adressen (z.B. `http://localhost:5123`) erreichbar.

### 2. API-Endpunkte testen

Verwenden Sie eine `.http`-Datei, um die folgenden Anfragen an Ihre laufende Anwendung zu senden.

#### A. Alle To-Dos abrufen (GET)

Testen Sie den Endpunkt zum Abrufen aller Einträge, inklusive der optionalen Query-Parameter.

* **Anfrage 1 (Standard):**
    * **Methode:** `GET`
    * **URL:** `/todos`
    * **Erwartetes Ergebnis (Status 200 OK):** Eine JSON-Liste der To-Dos, nach ID aufsteigend sortiert.

* **Anfrage 2 (Absteigend sortiert):**
    * **Methode:** `GET`
    * **URL:** `/todos?sort=desc`
    * **Erwartetes Ergebnis (Status 200 OK):** Eine JSON-Liste der To-Dos, nach ID absteigend sortiert.

* **Anfrage 3 (Limitiert):**
    * **Methode:** `GET`
    * **URL:** `/todos?limit=2`
    * **Erwartetes Ergebnis (Status 200 OK):** Nur die ersten beiden To-Dos der sortierten Liste.

#### B. Ein spezifisches To-Do abrufen (GET)

* **Anfrage 1 (Erfolgreich):**
    * **Methode:** `GET`
    * **URL:** `/todos/2`
    * **Erwartetes Ergebnis (Status 200 OK):** Der Text des To-Dos: `"Fitnessstudio"`

* **Anfrage 2 (Nicht gefunden):**
    * **Methode:** `GET`
    * **URL:** `/todos/99`
    * **Erwartetes Ergebnis (Status 404 Not Found):** Eine Fehlermeldung wie `"Kein To-Do mit ID 99 gefunden."`

#### C. Ein neues To-Do erstellen (POST)
* **Anfrage 0 - Händisch einen Post Request abschicken**
verwende dazu
```
@baseurl = http://localhost:DEINPORT

POST {{baseurl}}/todos
Content-Type: application/json

{
  "Title" : "uhm das ist nur ein test für den POST-Request - aber ein wenig ander!"
}

```
Klicke hier rechts auf POST in der Visual Studio Umgebung und wähle Senden aus. Es sollte ein 2xx Code im Response Header zurückkommen.

* **Anfrage 1 (Erfolgreich):**
    * **Methode:** `POST`
    * **URL:** `/todos`
    * **Body (JSON):**
        ```json
        {
            "title": "API testen"
        }
        ```
    * **Erwartetes Ergebnis (Status 201 Created):** Ein JSON-Objekt, das das neue To-Do mit seiner ID enthält (z.B. `{ "id": 4, "title": "API testen" }`). Überprüfen Sie mit einem `GET`-Aufruf, ob der Eintrag wirklich hinzugefügt wurde.

* **Anfrage 2 (Fehlerfall):**
    * **Methode:** `POST`
    * **URL:** `/todos`
    * **Body (JSON):**
        ```json
        {
            "title": ""
        }
        ```
    * **Erwartetes Ergebnis (Status 400 Bad Request):** Eine Fehlermeldung wie `"Der Titel darf nicht leer sein."`

#### D. Ein To-Do aktualisieren (PUT)

* **Anfrage 1 (Erfolgreich):**
    * **Methode:** `PUT`
    * **URL:** `/todos/1`
    * **Body (JSON):**
        ```json
        {
            "title": "Wocheneinkauf erledigen"
        }
        ```
    * **Erwartetes Ergebnis (Status 204 No Content):** Keine Daten im Body. Überprüfen Sie mit `GET /todos/1`, ob der Titel erfolgreich geändert wurde.

* **Anfrage 2 (Nicht gefunden):**
    * **Methode:** `PUT`
    * **URL:** `/todos/99`
    * **Body (JSON):** `{ "title": "Wird nicht funktionieren" }`
    * **Erwartetes Ergebnis (Status 404 Not Found):**

#### E. Ein To-Do löschen (DELETE)

* **Anfrage 1 (Erfolgreich):**
    * **Methode:** `DELETE`
    * **URL:** `/todos/3`
    * **Erwartetes Ergebnis (Status 204 No Content):** Keine Daten im Body. Überprüfen Sie mit `GET /todos`, ob der Eintrag entfernt wurde.

* **Anfrage 2 (Nicht gefunden):**
    * **Methode:** `DELETE`
    * **URL:** `/todos/99`
    * **Erwartetes Ergebnis (Status 404 Not Found):**


## Vorlage
```csharp
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var todos = new Dictionary<int, Todo>();
todos.TryAdd(1, new Todo("einkaufen"));
todos.TryAdd(2, new Todo("pumpi"));
todos.TryAdd(3, new Todo("modul 2 test schreiben"));
todos.TryAdd(4, new Todo("modul 3 test schreiben"));

// Lege Endpoints fest - Welche http requests erkenne ich?
// CRUD

// Create
app.MapPost();

// Read
app.MapGet(
    // die anfrage (query)
    // /todos?sort=desc&limit=3 oder
    // /todos?sort=desc oder
    // /todos?limit=3
    // soll in diesem endpoint funktioniern
    "/todos", 
    (string? sort, int? limit) => { // wichtig: ? nicht vergessen
        // wenn sort nicht null ist und sort = asc, dann antwort aufsteigend sortieren, wenn desc absteigend.
        // wenn limit nicht null ist, dann limitiere antwort auf limit viele todos.
        // return nicht vergessen!
    }
);

app.MapGet(...);


// Update
app.MapPut(...);

// Delete
app.MapDelete(...);

app.Run();

//  records sind unveränderbar - immutable
public record Todo(string Title);
```