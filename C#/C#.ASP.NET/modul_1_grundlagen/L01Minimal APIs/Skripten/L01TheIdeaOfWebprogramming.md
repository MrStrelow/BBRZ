# Web-Programmierung mit ASP.NET: Von den Grundlagen bis zu MVC und SPA

## 1. Die Grundlage der Web-Kommunikation

Im Kern geht es bei der Web-Programmierung um die Kommunikation zwischen einem **Client** (normalerweise ein Webbrowser) und einem **Server**. Diese Kommunikation folgt einem Satz von Regeln oder **Protokollen**.

### TCP: Der zuverlässige Lieferservice

Stellen Sie sich das Internet wie einen riesigen Postdienst vor. Wenn Sie einen Brief senden, möchten Sie sicher sein, dass er vollständig und in der richtigen Reihenfolge ankommt. Das **Transmission Control Protocol (TCP)** ist wie ein Einschreiben für Daten. Es stellt sicher, dass alle vom Server gesendeten Datenpakete korrekt, in der richtigen Reihenfolge und ohne Fehler beim Client (und umgekehrt) ankommen. Es baut eine Verbindung auf und hält sie offen, bis alle Daten erfolgreich ausgetauscht wurden.

### UDP: Der schnelle Bote

Im Gegensatz dazu ist das **User Datagram Protocol (UDP)** wie das Senden einer Postkarte. Es ist viel schneller, da es weder die Zustellung noch die Reihenfolge garantiert. Es sendet die Datenpakete einfach los und hofft auf das Beste. Dies ist nützlich für Anwendungen, bei denen Geschwindigkeit wichtiger ist als 100%ige Zuverlässigkeit, wie z. B. Videostreaming oder Online-Spiele, wo ein verlorener Frame ein geringeres Problem darstellt als eine verzögerte Verbindung.

### HTTP: Die Sprache des Webs

Das **Hypertext Transfer Protocol (HTTP)** ist das primäre Protokoll, das zum Surfen im Web verwendet wird. Es ist ein Anfrage-Antwort-Protokoll, das auf TCP aufbaut. Das bedeutet:

1.  Der **Client** (Ihr Browser) sendet eine **HTTP-Anfrage** (Request) an den Server und fordert eine Ressource an (wie eine Webseite, ein Bild oder Daten).
2.  Der **Server** verarbeitet die Anfrage und sendet eine **HTTP-Antwort** (Response) zurück, die die angeforderte Ressource und einen **Statuscode** enthält, der das Ergebnis anzeigt.

Der entscheidende Punkt bei HTTP ist, dass der Client *immer* die Konversation initiiert. Der Server kann keine Daten an den Client senden, es sei denn, der Client hat sie zuerst angefordert.

### Ein tieferer Einblick: Protokolle und das OSI-Modell

Um zu verstehen, wie Protokolle wie HTTP und TCP zusammenspielen, werfen wir einen kurzen Blick auf das **OSI-Modell**. Es ist ein theoretisches Modell, das die Netzwerkkommunikation in sieben logische Schichten (Layer) unterteilt. Jede Schicht hat eine bestimmte Aufgabe und kommuniziert nur mit den Schichten direkt darüber und darunter.

Die 7 Schichten des OSI-Modells:
1.  **Bitübertragungsschicht (Physical Layer)**: Kümmert sich um die Hardware, z. B. Kabel, und die Übertragung von rohen Bits.
2.  **Sicherungsschicht (Data Link Layer)**: Stellt eine fehlerfreie Übertragung über ein Medium sicher (z. B. Ethernet).
3.  **Vermittlungsschicht (Network Layer)**: Ist für das Routing von Datenpaketen durch das Netzwerk zuständig (hier arbeitet das IP-Protokoll).
4.  **Transportschicht (Transport Layer)**: Stellt die End-zu-End-Kommunikation sicher. Hier finden wir **TCP**, das eine zuverlässige, verbindungsorientierte Übertragung garantiert.
5.  **Sitzungsschicht (Session Layer)**: Verwaltet die Sitzungen (Dialoge) zwischen den kommunizierenden Systemen.
6.  **Darstellungsschicht (Presentation Layer)**: Übersetzt die Daten in ein Standardformat und kümmert sich um Verschlüsselung und Komprimierung. **TLS/SSL** (die Technologie hinter HTTPS) arbeitet hier.
7.  **Anwendungsschicht (Application Layer)**: Stellt Dienste für Anwendungsprozesse bereit. **HTTP** ist ein Protokoll dieser Schicht.

**Zusammenhang:**
Wenn Ihr Browser eine Webseite über `https://` anfordert, passiert Folgendes (vereinfacht):
* Die **Anwendungsschicht** erzeugt eine HTTP-Anfrage.
* Diese wird an die **Darstellungsschicht** weitergegeben, wo sie mittels TLS/SSL verschlüsselt wird (das "S" in HTTPS).
* Die verschlüsselten Daten werden an die **Transportschicht** gesendet, die sie in TCP-Segmente verpackt und eine zuverlässige Verbindung zum Server sicherstellt.
* Die darunterliegenden Schichten kümmern sich um das Routing (IP) und die physische Übertragung.

Auf dem Server wird dieser Prozess in umgekehrter Reihenfolge durchlaufen. HTTP "sitzt" also auf der Anwendungsschicht und verlässt sich auf die darunterliegenden Schichten wie TCP und IP, um seine Nachrichten zuverlässig und verschlüsselt ans Ziel zu bringen.

### WebSockets: Wenn der Server zuerst sprechen muss

Was aber, wenn der Server dem Client Updates senden muss, ohne gefragt zu werden? Zum Beispiel in einer Chat-Anwendung oder einem Live-Börsenticker. Hier kommen **WebSockets** ins Spiel.

WebSockets bieten einen **dauerhaften, bidirektionalen** Kommunikationskanal über eine einzige TCP-Verbindung. Sobald die Verbindung hergestellt ist, können sowohl der Client als auch der Server jederzeit Daten aneinander senden.

Das `TCP-Websockets`-Projekt demonstriert dies. Der Server lauscht auf dem `/ws`-Endpunkt auf WebSocket-Anfragen. Sobald sich ein Client verbindet, kann der Server kontinuierlich Nachrichten empfangen und senden, bis die Verbindung geschlossen wird.

Hier ist ein Ausschnitt aus `L01Minimal APIs/TCP-Websockets/Program.cs`:
```csharp
// Ein Endpunkt, der nur auf WebSocket-Anfragen reagiert
app.Map("/ws", async context =>
{
    // Prüfen, ob es sich um eine WebSocket-Anfrage handelt
    if (context.WebSockets.IsWebSocketRequest)
    {
        // Verbindung annehmen
        using var webSocket = await context.WebSockets.AcceptWebSocketAsync();

        // Endlosschleife, um auf Nachrichten zu lauschen
        while (webSocket.State == System.Net.WebSockets.WebSocketState.Open)
        {
            // ... auf eine Nachricht warten und eine Antwort senden ...
        }
    }
});
```

## 2. HTTP im Detail verstehen

Da die meisten Webanwendungen auf HTTP basieren, ist es wichtig, seine Komponenten zu verstehen.

### HTTP-Methoden

HTTP-Methoden oder "Verben" definieren die Aktion, die der Client auf einer Ressource ausführen möchte. Die gebräuchlichsten sind:

* **GET**: Ruft eine Ressource ab. Das verwendet Ihr Browser, wenn Sie eine URL in die Adressleiste eingeben. GET-Anfragen sollten *sicher* (den Zustand des Servers nicht ändern) und *idempotent* (mehrfaches Aufrufen hat den gleichen Effekt wie einmaliges Aufrufen) sein. Dies ermöglicht es Browsern, die Ergebnisse sicher zwischenzuspeichern.
* **POST**: Sendet Daten an den Server, um eine neue Ressource zu erstellen. Zum Beispiel das Absenden eines Formulars zur Erstellung eines neuen Benutzerkontos.
* **PUT**: Ersetzt eine vorhandene Ressource durch neue Daten.
* **DELETE**: Löscht eine Ressource.

Die HTTP-Methoden bilden die Grundlage für die Interaktion mit Ressourcen im Web. Sie lassen sich hervorragend mit den aus Datenbanken/Datenstrukturen bekannten **CRUD**-Operationen (Create, Read, Update, Delete) vergleichen.

| HTTP-Methode | CRUD-Operation | Beschreibung & Anwendung auf Collections |
| :--- | :--- | :--- |
| **POST** | **C**reate (Erstellen) | Erstellt eine neue Ressource. Bei einer Collection (`/todos`) wird ein neues Element hinzugefügt. POST ist nicht idempotent; ein mehrfaches Senden erzeugt mehrere neue Ressourcen. |
| **GET** | **R**ead (Lesen) | Liest eine oder mehrere Ressourcen. `GET /todos` liest die gesamte Liste, `GET /todos/5` liest das spezifische Element mit der ID 5. GET ist sicher und idempotent. |
| **PUT** | **U**pdate (Aktualisieren) | Aktualisiert eine bestehende Ressource vollständig. `PUT /todos/5` ersetzt das gesamte To-Do mit der ID 5 durch die im Request-Body gesendeten Daten. PUT ist idempotent. |
| **DELETE** | **D**elete (Löschen) | Löscht eine Ressource. `DELETE /todos/5` entfernt das To-Do mit der ID 5. |

Das `HTTP-JSON`-Projekt implementiert eine einfache To-Do-Listen-API, die diese Methoden verwendet:
```csharp
// L01Minimal APIs/HTTP-JSON/Program.cs

// GET: Ein spezifisches To-Do anhand seiner ID abrufen
app.MapGet("/todos/{id}", ...);

// GET: Alle To-Dos abrufen
app.MapGet("/todos", ...);

// POST: Ein neues To-Do erstellen
app.MapPost("/todos", ...);

// PUT: Ein bestehendes To-Do aktualisieren
app.MapPut("/todos/{id}", ...);

// DELETE: Ein To-Do löschen
app.MapDelete("/todos/{id}", ...);
```

#### Standardisierung durch REST:
Die konsequente Nutzung dieser HTTP-Methoden für CRUD-Operationen ist ein Kernprinzip von **REST (Representational State Transfer)**. REST ist ein Architekturstil, der festlegt, wie Webdienste aufgebaut sein sollten, um skalierbar und wartbar zu sein. Eine RESTful-API nutzt URLs zur Identifizierung von Ressourcen (z.B. `/todos/5`) und HTTP-Verben zur Definition der Aktion, die auf dieser Ressource ausgeführt werden soll.

### HTTP-Statuscodes

Jede HTTP-Antwort enthält einen Statuscode, der dem Client mitteilt, wie die Anfrage verlaufen ist. Einige gängige Codes sind:

* **2xx (Erfolg)**:
    * `200 OK`: Die Anfrage war erfolgreich.
    * `201 Created`: Die Anfrage war erfolgreich, und eine neue Ressource wurde erstellt (oft als Antwort auf eine POST-Anfrage gesendet).
    * `204 No Content`: Der Server hat die Anfrage erfolgreich verarbeitet, hat aber keinen Inhalt zurückzugeben (oft für erfolgreiche PUT- oder DELETE-Anfragen gesendet).
* **3xx (Umleitung)**:
    * `302 Found`: Die angeforderte Ressource wurde vorübergehend verschoben. Der Browser folgt automatisch der neuen URL. Dies wird in `exercise1-fruehstueck_mit_minimal_api/Program.cs` nach dem Absenden eines Formulars verwendet.
* **4xx (Client-Fehler)**:
    * `400 Bad Request`: Der Server konnte die Anfrage aufgrund ungültiger Syntax nicht verstehen.
    * `404 Not Found`: Die angeforderte Ressource konnte auf dem Server nicht gefunden werden.
* **5xx (Server-Fehler)**:
    * `500 Internal Server Error`: Eine generische Fehlermeldung, die ausgegeben wird, wenn auf dem Server eine unerwartete Bedingung aufgetreten ist.

## 3. Webseiten erstellen: Statisch vs. Dynamisch

### Statisches HTML

Eine statische Website besteht aus einfachen HTML-, CSS- und JavaScript-Dateien, die auf dem Server gespeichert sind. Wenn ein Client eine Seite anfordert, sendet der Server einfach die entsprechende Datei unverändert. Dies ist schnell und einfach, aber nicht interaktiv.

### Dynamisches HTML

Die meisten modernen Webanwendungen müssen dynamische Inhalte anzeigen (z. B. benutzerspezifische Daten, Informationen aus einer Datenbank). Dies erfordert die Generierung von HTML im laufenden Betrieb. Es gibt zwei Hauptansätze dafür: serverseitiges Rendern und clientseitiges Rendern.

## 4. Architekturmuster für dynamische Web-Apps

### Das MVC-Muster (Model-View-Controller)

MVC ist ein traditionelles, serverseitiges Rendering-Muster, das eine Anwendung in drei miteinander verbundene Komponenten aufteilt:

* **Model**: Repräsentiert die Daten und die Geschäftslogik der Anwendung. In unseren Beispielen fungieren die Klassen wie `Customer`, `Dish` und der `RestaurantDbContext` als Model.
* **View**: Die Benutzeroberfläche. Im klassischen ASP.NET MVC sind dies `.cshtml`-Razor-Dateien. In unserem vereinfachten `HTTP-idee-von-MVC`-Projekt ist die `GenerateHtml`-Funktion für die Erstellung der HTML-Ansicht verantwortlich.
* **Controller**: Behandelt Benutzereingaben, interagiert mit dem Model und wählt eine View zum Rendern aus. Die `app.MapGet`- und `app.MapPost`-Endpunkte in unseren Minimal-API-Projekten fungieren als Controller-Logik.

Das `exercise3-fruehstueck_mit_mvc_ordnern`-Projekt zeigt eine typische MVC-Ordnerstruktur:
```
/FruehstuecksBestellungMVC
|-- /Controllers
|   |-- FruehstueckController.cs  // Behandelt Anfragen
|-- /Data
|   |-- RestaurantDbContext.cs    // Datenzugriff
|-- /Models
|   |-- Bill.cs, Customer.cs, ... // Datenstrukturen
|-- /Views
|   |-- /Fruehstueck
|   |   |-- Index.cshtml          // UI-Vorlage (obwohl in dieser Übung eine .cs-Datei)
|-- Program.cs                    // Einstiegspunkt der Anwendung
```

**Wie es funktioniert (MVC-Ablauf):**

1.  Der Browser sendet eine HTTP-Anfrage (z. B. `GET /todos`).
2.  Das ASP.NET-Routing leitet die Anfrage an eine Controller-Aktion weiter.
3.  Der Controller ruft Daten aus dem Model (der Datenbank) ab.
4.  Der Controller übergibt diese Daten an eine View.
5.  Die View-Engine auf dem Server generiert die endgültige HTML-Seite.
6.  Der Server sendet die vollständige HTML-Seite an den Browser zurück.

#### Strukturierung von MVC-Anwendungen: Eine Daumenregel

In der MVC-Architektur starten wir mit einer Daumenregel für die Strukturierung als ersten Schritt:

> **Pro Model ein Controller und (mindestens) eine View.**

Das bedeutet, wenn Sie ein `Product`-Model haben, würden Sie einen `ProductsController` erstellen, der Aktionen wie `Index` (alle Produkte anzeigen), `Details` (ein Produkt anzeigen), `Create` und `Edit` verwaltet. Jede dieser Aktionen hätte typischerweise eine korrespondierende View (z. B. `Index.cshtml`, `Details.cshtml`). Diese Struktur sorgt für eine klare Trennung der Zuständigkeiten (Separation of Concerns) und macht große Anwendungen wartbar.

**Warum das Frühstücks-Beispiel anders ist:**
In unserem `exercise3-fruehstueck_mit_mvc_ordnern` weichen wir von dieser Regel ab. Unser `RestaurantController` ist nicht nur für ein einziges Model zuständig. Die Hauptansicht (`Index`) ist eine Art **Dashboard** oder eine Übersichtsseite, die Daten aus vielen verschiedenen Models gleichzeitig benötigt: `Customer`, `Table`, `Menu`, `Dish` und `Bill`.

Für ein so kleines Beispiel wäre es übertrieben, für jedes dieser Models einen eigenen Controller und eigene Views zu erstellen, nur um diese eine Seite zu befüllen. Wir fassen die Logik daher in einem Controller zusammen.

**Wichtig:** Dies ist eine Vereinfachung für den Lerneffekt. In einer echten, größeren Restaurant-Anwendung gäbe es sehr wahrscheinlich:
* Einen `CustomersController` zur Verwaltung der Kunden.
* Einen `TablesController` zur Verwaltung der Tische.
* Der `RestaurantController` oder ein `DashboardController` wäre dann eine spezielle Komponente, die Daten von den anderen Controllern (oder den zugehörigen Services) abruft, um die Hauptübersicht darzustellen.

### Das SPA-Muster (Single Page Application)

SPAs sind ein modernerer, clientseitiger Rendering-Ansatz.

* Das **Backend** ist eine reine Daten-API, die Daten in einem maschinenlesbaren Format wie JSON zurückgibt (wie im `HTTP-JSON`-Projekt zu sehen).
* Das **Frontend** ist eine einzige HTML-Seite (`index.html`), die eine leistungsstarke JavaScript-Anwendung im Browser lädt. Diese JavaScript-Anwendung ist dafür verantwortlich, Daten von der API abzurufen und die Benutzeroberfläche dynamisch im Browser zu rendern.

Das `HTTP-idee-von-SPA`-Projekt versucht dies zu veranschaulichen:

* **Backend (`Program.cs`):** Definiert API-Endpunkte wie `/api/todos`, die nur JSON-Daten zurückgeben.
    ```csharp
    // L01Minimal APIs/HTTP-idee-von-SPA/Program.cs
    app.MapGet("/api/todos", () => todos.OrderBy(t => t.Key).Select(todo => new {id = todo.Key, title = todo.Value.Title }));
    ```
* **Frontend (`wwwroot`-Ordner):**
    * `index.html`: Eine minimale HTML-Hülle.
    * `style.css`: Stile für die Anwendung.
    * `script.js`: Der Kern der Anwendung. Es verwendet die `fetch`-API, um mit dem Backend zu kommunizieren, und manipuliert das DOM, um Daten anzuzeigen und Benutzerinteraktionen zu behandeln.

    ```javascript
    // L01Minimal APIs/HTTP-idee-von-SPA/wwwroot/script.js
    async function loadTodos() {
        const response = await fetch('/api/todos'); // JSON-Daten abrufen
        const todos = await response.json();

        todoList.innerHTML = ''; // Die alte Liste leeren
        todos.forEach(todo => {
            const li = createTodoElement(todo); // HTML-Elemente erstellen
            todoList.appendChild(li);           // Zur Seite hinzufügen
        });
    }
    ```

### MVC vs. SPA: Hauptunterschiede

| Merkmal | MVC (Serverseitiges Rendern) | SPA (Clientseitiges Rendern) |
| :--- | :--- | :--- |
| **Initiales Laden** | Langsamer, da der Server für jede Anfrage eine vollständige HTML-Seite generiert. | Schnelleres initiales Laden der Hauptseite, lädt dann Daten im Hintergrund. |
| **Seiten-Updates** | Erfordert für jede Interaktion ein vollständiges Neuladen der Seite. | Schnelle und nahtlose Updates ohne Neuladen der Seite. |
| **Backend-Rolle** | Behandelt Geschäftslogik und rendert HTML. | Dient hauptsächlich als Daten-API (z. B. RESTful-API). |
| **Frontend-Rolle** | Minimale Logik, zeigt hauptsächlich HTML vom Server an. | Komplexe Logik, behandelt Routing, Datenabruf und UI-Rendering. |
| **Beispielprojekte** | `HTTP-idee-von-MVC`, `exercise3-fruehstueck_mit_mvc_ordnern` | `HTTP-idee-von-SPA`, `HTTP-JSON` (der API-Teil) |

## 5. Formulare und Datenübermittlung

Ein entscheidender Punkt ist, dass Standard-HTML-Formulare nur zwei dieser Methoden unterstützen:
```html
<form action="/resource" method="get">...</form>
<form action="/resource" method="post">...</form>
```
Um die oben erwähnte Bedeutung von `PUT` und `DELETE` zu implementieren, ist **clientseitiges JavaScript zwingend erforderlich**. Mit der `fetch`-API kann man HTTP-Anfragen manuell erstellen und jede beliebige Methode verwenden:
```javascript
fetch('/todos/5', {
  method: 'DELETE' // Diese Methode ist mit reinem HTML nicht möglich
}).then(response => {
  // UI aktualisieren
});
```
Diese Notwendigkeit ist einer der Hauptgründe für die Entwicklung von SPAs, die eine reichhaltigere Interaktion ermöglichen, als es mit reinen HTML-Formularen möglich wäre.

### Traditionelle HTML-Formulare

Der einfachste Weg, Daten an einen Server zu senden, ist mit einem HTML-`<form>`.

```html
<form action='/todos' method='post'>
    <input type='text' name='title' placeholder='Was muss getan werden?' required />
    <input type='submit' value='Hinzufügen' />
</form>
```

Wenn der Benutzer auf den "Senden"-Button klickt, bündelt der Browser die Formulardaten und sendet sie in einer HTTP-Anfrage (`POST` in diesem Fall) an die angegebene `action`-URL. Dies führt immer zu einem vollständigen Neuladen der Seite.

### JavaScript (AJAX/Fetch)

SPAs verwenden JavaScript, um Daten ohne ein vollständiges Neuladen der Seite zu senden. Diese Technik wird oft AJAX (Asynchronous JavaScript and XML) genannt, obwohl wir heute `fetch` und JSON verwenden.

```javascript
// Aus L01Minimal APIs/HTTP-idee-von-SPA/wwwroot/script.js
addTodoForm.addEventListener('submit', async (e) => {
    e.preventDefault(); // Verhindert die standardmäßige Formularübermittlung und das Neuladen der Seite
    const title = newTodoTitleInput.value.trim();

    const response = await fetch('/api/todos', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ title: title })
    });

    if (response.ok) {
        // ... die UI dynamisch aktualisieren ...
    }
});
```

Dies bietet eine wesentlich flüssigere Benutzererfahrung, weshalb SPAs für hochgradig interaktive Anwendungen beliebt sind.

### HTTP-Methoden, Statuscodes und die Auswirkungen auf Caching
#### Was ist Caching?
Caching (auf Deutsch "zwischenspeichern") ist ein Prozess, bei dem eine Kopie einer Ressource (z.B. eine Webseite, ein Bild oder Daten) an einem temporären Speicherort abgelegt wird. Wenn dieselbe Ressource erneut angefordert wird, kann sie direkt aus diesem schnellen Zwischenspeicher (dem "Cache") geladen werden, anstatt sie erneut vom ursprünglichen Server anfordern zu müssen. Das Hauptziel ist, die Ladezeiten zu verkürzen, die Netzwerklast zu reduzieren und die wahrgenommene Geschwindigkeit einer Anwendung zu verbessern.
Wie bereits erwähnt, haben HTTP-Methoden eine definierte Semantik. Diese Semantik hat direkte Auswirkungen darauf, wie Browser und andere Zwischenstationen mit den Antworten umgehen können, insbesondere beim **Caching**.

* **GET-Anfragen sind cache-fähig**: Da eine `GET`-Anfrage als **sicher** (hat keine Seiteneffekte) und **idempotent** (mehrfache Ausführung führt zum selben Ergebnis) definiert ist, kann ihre Antwort gefahrlos zwischengespeichert werden. Wenn Sie `GET /todos/5` erneut aufrufen, kann der Browser oder ein Proxy die Antwort aus seinem Cache liefern, ohne den Server erneut kontaktieren zu müssen. Das spart Bandbreite und verbessert die Ladezeiten erheblich.
* **POST-Anfragen sind nicht cache-fähig**: Eine `POST`-Anfrage ist weder sicher noch idempotent. Sie soll jedes Mal eine neue Ressource erstellen. Würde man die Antwort auf eine `POST`-Anfrage cachen, könnte dies zu unerwünschtem Verhalten führen (z.B. würde ein Klick auf "Zurück" im Browser versuchen, das Formular erneut zu senden).
* **PUT- und DELETE-Anfragen**: Diese Methoden sind idempotent, aber nicht sicher. Sie verändern den Zustand auf dem Server. Während die Anfragen selbst nicht gecacht werden, bewirken sie, dass zwischengespeicherte `GET`-Antworten für dieselbe Ressource **ungültig** werden. Nach einem `PUT /todos/5` muss der Cache für `GET /todos/5` gelöscht werden, damit bei der nächsten Anfrage die aktualisierten Daten vom Server geholt werden. Hier ist je nach Bedarf zu handlen und eine Balance zwischen Geschwindigkeit und Korrektheit zu finden.

Server können das Caching-Verhalten mit **HTTP-Headern** steuern. Der `Cache-Control`-Header in einer Antwort kann dem Client genaue Anweisungen geben, z. B. wie lange (in Sekunden) eine Antwort im Cache bleiben darf (`max-age=3600`) oder ob sie überhaupt nicht gecacht werden soll (`no-cache`). Mehr dazu aber in zukünftigen Modulen.

#### Welche Statuscodes sind für das Caching relevant?
Obwohl das Caching-Verhalten hauptsächlich durch HTTP-Header (wie `Cache-Control` oder `Expires`) gesteuert wird, gibt es bestimmte Statuscodes, die eng mit diesem Prozess verbunden sind:

* **`200 OK` (Implizites Caching)**:
    Dieser Code bedeutet einfach "Anfrage erfolgreich". Er erzwingt kein Caching, aber die Antwort auf eine `GET`-Anfrage mit diesem Statuscode **kann** vom Browser gecacht werden, wenn die entsprechenden Caching-Header vom Server mitgesendet werden. Es ist die Standardantwort für eine Ressource, die potenziell zwischengespeichert werden kann.

* **`304 Not Modified` (Erzwingt die Nutzung des Caches)**:
    Dies ist der wichtigste Statuscode für effizientes Caching. Er funktioniert so:
    1.  Der Browser hat bereits eine Version der Ressource im Cache.
    2.  Wenn er die Ressource erneut anfordert, sendet er eine "bedingte Anfrage" an den Server (z.B. mit dem Header `If-Modified-Since`). Er fragt damit: "Gib mir die Ressource, aber nur, wenn sie sich seit meinem letzten Besuch geändert hat."
    3.  Wenn der Server feststellt, dass sich die Ressource **nicht** geändert hat, sendet er den Statuscode `304 Not Modified` zurück. Die Antwort hat **keinen Body**.
    4.  Dies ist das Signal für den Browser: "Deine Version ist noch aktuell. Nutze die Kopie aus deinem Cache." Das spart die Übertragung der gesamten Ressource und ist extrem effizient.

* **`301 Moved Permanently` (Erzwingt Caching der neuen URL)**:
    Dieser Code teilt dem Client mit, dass eine Ressource dauerhaft an eine neue URL umgezog