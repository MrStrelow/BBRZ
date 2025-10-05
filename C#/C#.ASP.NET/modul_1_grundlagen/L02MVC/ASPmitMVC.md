# Zusammenfassung der ASP.NET Core MVC Konzepte

Dieses Dokument fasst die Kernkonzepte zusammen, die in unserer Konversation über den Aufbau einer Todo-Anwendung mit ASP.NET Core MVC behandelt wurden.

---

## 1. Grundlagen von ASP.NET Core MVC

### Routing
Das Routing ist der Mechanismus, der eine eingehende URL einer bestimmten Controller-Action-Methode zuordnet. Es wird in der `Program.cs` konfiguriert.

- **Konfiguration:** Erfolgt über `app.MapControllerRoute()`.
- **Muster (Pattern):** Definiert, wie eine URL aufgebaut ist. Parameter werden in `{}` geschrieben.
  - `"{controller=Todo}/{action=Index}/{id?}"`
    - `{controller=Todo}`: Der erste Teil der URL ist der Controller. Wenn er fehlt, wird `Todo` als Standard verwendet. ASP.NET sucht dann nach einer Klasse namens `TodoController`.
    - `{action=Index}`: Der zweite Teil ist die Action (Methode). Wenn er fehlt, wird `Index` als Standard verwendet.
    - `{id?}`: Ein optionaler Parameter (wegen dem `?`), typischerweise für eine ID.
- **Parameter-Quellen:** Parameter für Actions können aus verschiedenen Quellen stammen:
  1. **Routen-Werte:** Direkt aus dem URL-Muster (z.B. die `5` in `/Todo/Details/5`).
  2. **Query-String:** Werte nach dem `?` in der URL (z.B. `query` und `sortBy` in `/Todo?query=lernen&sortBy=alpha`).
  3. **Formular-Daten:** Werte, die via HTTP POST von einem HTML-Formular gesendet werden.

### Das Model-View-Controller (MVC) Pattern
MVC ist ein Architekturmuster, das die Anwendung in drei miteinander verbundene Teile trennt, um die "Separation of Concerns" (Trennung der Belange) zu gewährleisten.

- **Model:** Repräsentiert die Daten und die Geschäftslogik der Anwendung. In unserem Fall ist das die `Todo`-Klasse. Es weiß nichts über die Darstellung (View) oder die Anwendungssteuerung (Controller).
- **View:** Ist für die Darstellung der Daten zuständig, also die Benutzeroberfläche (UI). In ASP.NET Core sind das die `.cshtml`-Dateien, die HTML generieren. Sie sollte keine Geschäftslogik enthalten.
- **Controller:** Fungiert als Vermittler zwischen Model und View. Er empfängt Benutzereingaben, interagiert mit dem Model, um Daten zu verarbeiten, und wählt dann die passende View aus, um dem Benutzer eine Antwort zu senden.

---

## 2. Controller und Action Results

Ein Controller ist eine C#-Klasse, die auf `Controller` endet und öffentliche Methoden, sogenannte **Actions**, enthält. Jede Action ist ein Endpunkt, der auf eine HTTP-Anfrage reagieren kann. Das Ergebnis einer Action wird als `ActionResult` zurückgegeben.

### Wichtige Controller-Attribute

- **`[HttpGet]`**: Kennzeichnet eine Action, die nur auf HTTP GET-Anfragen reagiert. Oft optional, da es der Standard ist.
- **`[HttpPost]`**: Kennzeichnet eine Action, die nur auf HTTP POST-Anfragen reagiert (z.B. beim Absenden eines Formulars).
- **`[ValidateAntiForgeryToken]`**: Ein Sicherheitsattribut, das Cross-Site Request Forgery (CSRF)-Angriffe verhindert. Es stellt sicher, dass ein POST-Request von einem Formular stammt, das von deiner eigenen Anwendung generiert wurde.
- **`[FromRoute]`, `[FromQuery]`**: Attribute, um explizit anzugeben, woher ein Action-Parameter gebunden werden soll (aus der Route oder dem Query-String).

### Wichtige `ActionResult`-Typen

- **`View(model)`**: Rendert eine `.cshtml`-View und gibt sie als HTML zurück. Optional kann ein Model-Objekt an die View übergeben werden.
  - **Verwendung:** Zum Anzeigen von Webseiten für den Benutzer.
- **`RedirectToAction("ActionName", new { id = 5 })`**: Führt eine clientseitige Weiterleitung (HTTP 302) zu einer anderen Action aus. Parameter können als anonymes Objekt übergeben werden.
  - **Verwendung:** Nach einer erfolgreichen POST-Operation (z.B. Create, Edit), um das "Post-Redirect-Get"-Pattern umzusetzen und doppelte Formularsendungen zu verhindern.
- **`NotFound()`**: Gibt einen HTTP 404 Fehler zurück.
  - **Verwendung:** Wenn eine angeforderte Ressource (z.B. ein Todo mit einer bestimmten ID) nicht gefunden wurde.
- **`BadRequest()`**: Gibt einen HTTP 400 Fehler zurück.
  - **Verwendung:** Wenn die Anfrage des Clients fehlerhaft ist (z.B. eine ID fehlt, wo eine erwartet wird).
- **`Content("text")`**: Gibt reinen Text-Inhalt zurück.
  - **Verwendung:** Für einfache Text-Antworten oder zum Debuggen.
- **`Ok()` / `Json()`**: Gibt HTTP 200 mit optionalen JSON-Daten zurück. Wichtig für Web-APIs.

---

## 3. Model und Data Annotations (Attribute)

Das Model definiert die Struktur der Daten. Wir haben es als C# `record` implementiert, was ideal für daten-fokussierte, oft unveränderliche Objekte ist. **Data Annotations** sind Attribute, die Metadaten zu den Model-Properties hinzufügen.

- **`[Required]`**: Validierungs-Attribut. Gibt an, dass das Feld ausgefüllt sein muss.
- **`[StringLength(max)]`**: Validierungs-Attribut. Setzt eine maximale Zeichenlänge.
- **`[Display(Name = "...")]`**: UI-Attribut. Definiert einen benutzerfreundlichen Namen für ein Feld, der von Tag Helpern (z.B. `<label>`) verwendet wird.
- **`[DataType(...)]`**: UI-Attribut. Gibt dem System einen Hinweis, wie ein Feld dargestellt werden soll. Z.B. `DataType.MultilineText` erzeugt eine `<textarea>` anstelle eines `<input>`.
- **`[Bind(...)]`**: Sicherheitsattribut im Controller, das explizit festlegt, welche Properties aus einem ankommenden Request an das Model gebunden werden dürfen, um "Mass Assignment"-Angriffe zu verhindern.

---

## 4. Views und Tag Helper

Views (`.cshtml`) verwenden die **Razor**-Syntax, um C#-Code und HTML zu mischen. **Tag Helper** sind serverseitige Komponenten, die HTML-Elemente in Razor-Views erstellen und bearbeiten. Sie sehen aus wie normale HTML-Attribute, beginnen aber mit `asp-`.

### Wichtige Tag Helper

- **`<a asp-controller="..." asp-action="..." asp-route-id="...">`**:
  - **Verwendung:** Erzeugt einen `href`-Link, der dynamisch auf Basis des Routingsystems generiert wird. `asp-route-{parametername}` fügt Routenparameter hinzu. Sehr robust gegenüber Änderungen am Routing.
- **`<form asp-action="..." method="...">`**:
  - **Verwendung:** Erzeugt ein HTML-Formular, das auf eine bestimmte Controller-Action zeigt. Fügt automatisch ein verstecktes Feld mit einem Anti-Forgery-Token hinzu, wenn `method="post"` verwendet wird (wichtig für `[ValidateAntiForgeryToken]`).
- **`<label asp-for="PropertyName">`**:
  - **Verwendung:** Erzeugt ein `<label>`-Tag. Der Inhalt des Labels wird automatisch aus dem `[Display(Name=...)]`-Attribut des Models geholt.
- **`<input asp-for="PropertyName">` / `<textarea asp-for="PropertyName">`**:
  - **Verwendung:** Erzeugt ein Eingabefeld. `id`, `name` und `value` werden automatisch an die Model-Property gebunden. Liest auch Data Annotations, um clientseitige Validierungsattribute (`data-val-*`) hinzuzufügen.
- **`<span asp-validation-for="PropertyName">`**:
  - **Verwendung:** Erzeugt ein `<span>`-Tag, das als Platzhalter für Validierungsfehlermeldungen dient, die von diesem Feld stammen.
- **`<div asp-validation-summary="All|ModelOnly">`**:
  - **Verwendung:** Zeigt eine zusammenfassende Liste aller Validierungsfehler an, entweder für alle Properties (`All`) oder nur Fehler, die nicht an ein bestimmtes Property gebunden sind (`ModelOnly`).

---

## 5. Daten zwischen Controller und View übergeben: ViewBag

Manchmal muss man kleine, temporäre Daten vom Controller an die View übergeben, die nicht Teil des Haupt-Models sind (z.B. der aktuelle Suchbegriff oder ein Sortierstatus).

- **Was es ist:** `ViewBag` ist ein dynamisches Objekt (`dynamic`). Man kann ihm beliebige Eigenschaften zur Laufzeit hinzufügen, ohne sie vorher zu definieren.
- **Verwendung im Controller:**
  - `ViewBag.CurrentQuery = "mein Suchbegriff";`
- **Verwendung in der View:**
  - `<input value="@ViewBag.CurrentQuery">`
- **Wann verwenden?** Nur für einfache, nicht-essenzielle Daten. Für die Hauptdaten der View sollte immer ein stark typisiertes Model verwendet werden, da es IntelliSense und Compile-Zeit-Prüfung bietet, was `ViewBag` nicht tut.

---

## 6. LINQ und Listen-Operationen

Wir haben zwei wichtige LINQ-Methoden zur Abfrage von Listen verwendet:

- **`.FirstOrDefault(bedingung)`**:
  - **Gibt zurück:** Das **erste gefundene Element**, das die Bedingung erfüllt, oder `null` (bzw. den Standardwert des Typs), wenn nichts gefunden wird.
  - **Beispiel:** `_todos.FirstOrDefault(t => t.Id == id);` -> Holt das `Todo`-Objekt selbst.
- **`.FindIndex(bedingung)`**:
  - **Gibt zurück:** Den **Index (Position)** des ersten gefundenen Elements oder `-1`, wenn nichts gefunden wird.
  - **Beispiel:** `_todos.FindIndex(t => t.Id == todo.Id);` -> Holt die Position des Todos, um es in der Liste zu ersetzen.