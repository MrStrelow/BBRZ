# Erste Schritte bei der Serverseitigen Validierung

Wir gehen von der [Exercise 1](../exercise1-fruehstuecksrestaurant-ohne-validation/Angabe.md) aus und verwenden die [Lösung](../exercise1-fruehstuecksrestaurant-ohne-validation/) dieser. Falls das eigene Projekt fehlerfrei ist, kann auch dieses verwendet werden.

Unsere Webanwendung nimmt aktuell jede Bestellung an, auch wenn sie unvollständig oder ungültig ist. In dieser Übung erweitern wir den `FruehstueckController`, um Benutzereingaben serverseitig zu validieren. Zusätzlich passen wir die `Index.cshtml`-View an, damit dem Benutzer klare und hilfreiche Fehlermeldungen angezeigt werden.

## Übersicht der Änderungen

1.  **Controller (`FruehstueckController.cs`)**: Die `Bestellen`-Action wird um eine Validierungslogik erweitert. Erinnere dich an ``Guard Clauses``. Wir prüfen, ob alle notwendigen Daten für eine Bestellung vorhanden sind.
2.  **View (`Index.cshtml`)**: Die View wird so angepasst, dass sie die vom Controller übermittelten Validierungsfehler in einer übersichtlichen Box anzeigt.

---

## Anforderungen an die Implementierung

### 1. Serverseitige Validierung im `FruehstueckController`

Passen Sie die `[HttpPost]`-Action `Bestellen` an, um die folgenden Validierungsregeln zu implementieren, *bevor* der `_customerService` aufgerufen wird:

* **Regel 1: Kunde muss ausgewählt sein**: Prüfen Sie, ob die übergebene `customerId` größer als 0 ist. Wenn nicht, ist die Auswahl ungültig.
* **Regel 2: Tisch muss ausgewählt sein**: Prüfen Sie, ob die übergebene `tableId` größer als 0 ist.
* **Regel 3: Mindestens eine Auswahl**: Prüfen Sie, ob die Listen `selectedMenuIds` **und** `selectedDishIds` beide leer sind. Eine gültige Bestellung muss mindestens ein Menü oder ein Gericht enthalten.
* **Regel 4**: Prüfen Sie am Ende mit `if (!ModelState.IsValid)`, ob Fehler aus **Regel 1-3** hinzugefügt wurden bzw. falls ein nicht korrekter ``http-post`` Request gestellt wurde. Einige nicht korrekten ``http-post`` Request sehen sie in der *wrong_posts.http* Datei. Request 3 ist der Wichtigste dort. Senden Sie diesen um zu sehen was passiert. Vergiss nicht den Port des Servers in die http-Datei einzutragen! Gesendet wird der Request, welcher nicht über das Webinterface ausgeführt wird mit einem Rechtsklick in der Datei und dann senden. **Wichtig**: Es muss ``[ValidateAntiForgeryToken]`` überall vorher entfernt werden, damit wir *wrong_posts.http* verwenden können. Dieses ``Attribut`` führt dazu, dass alle ``http-post`` Requests abgelehnt werden, welche nicht von der View erstellten Website erzeugt werden. 
    * **Wichtig**: Im Fehlerfall darf **kein** `RedirectToAction` ausgeführt werden. Stattdessen müssen Sie die `Index`-View erneut anzeigen, damit die Fehler sichtbar werden. Rufen Sie `return View("Index", model);` auf, nachdem Sie die notwendigen Daten für die View (Menüs, Tische etc.) erneut geladen haben (Inhalt wie bei der ``[HttpGet] Index(...)`` Methode). Dies stellt sicher, dass die Fehlermeldungen erhalten bleiben.
    * Füge bei **Regel 1-3** folgendes hinzu. Wenn eine oder mehrere dieser Regeln verletzt werden, fügen Sie eine entsprechende Fehlermeldung zum `ModelState`-Objekt hinzu. Verwenden Sie `ModelState.AddModelError("", "Ihre Fehlermeldung hier");`. Das ist vergleichbar mit einem ``throw new Exception("This guard-clause prevented further execution!")`` oder einem ``return;`` bei ``Guard-Clauses``.

### 2. Darstellung der Fehlermeldung in der View (``Index.cshtml``)
Damit die im ModelState gespeicherten Fehler dem Benutzer angezeigt werden, müssen Sie die Index.cshtml-Datei anpassen.

Fügen Sie direkt nach dem öffnenden ``<form>``-Tag einen ASP.NET Core Tag Helper hinzu, der die Validierungsfehler zusammenfasst.

Dieser Tag Helper liest automatisch die Fehler aus dem ModelState aus und rendert sie als HTML.

Sie können die Anzeige optional in eine if-Abfrage packen, damit die Fehlerbox nur erscheint, wenn tatsächlich Fehler vorhanden sind.

Beispielcode:
```csharp
<form asp-controller="Fruehstueck" asp-action="Bestellen" method="post">
    @if (!ViewData.ModelState.IsValid)
    {
        <div class="alert alert-danger">
            <strong>Bitte korrigieren Sie die folgenden Fehler:</strong>
            <div asp-validation-summary="All" class="text-danger"></div>
        </div>
    }

    @* ... der Rest Ihres Formulars (Kunden-Dropdown, Tische, Menüs etc.) ... *@

</form>
```