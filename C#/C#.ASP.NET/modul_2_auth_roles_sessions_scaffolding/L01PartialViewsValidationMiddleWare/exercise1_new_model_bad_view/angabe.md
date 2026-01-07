# Exercise 3: View-Refactoring & Resilience (Exceptions & Logging)

In dieser Übung werden wir die monolithische View aufbrechen, die Anwendung durch zentrales Fehlerhandling robuster machen und verschiedene Fehlerkategorien sauber implementieren.

## Teil A: Refactoring zu Partial Views

Die `Index.cshtml` ist aktuell überladen. Wir lagern Logik in wiederverwendbare Bausteine aus.

### Schritt 1: Aufteilen des Bestellformulars

Erstellen Sie im Ordner `Views/Fruehstueck/` (oder `Views/Fruehstueck/Partials/`) folgende Dateien und übergeben Sie jeweils das **gesamte** ViewModel (`model="Model"`).

**1. `_OrderSectionTakeIn.cshtml`**
```cshtml
@model FruehstueckViewModel

<div id="sectionTakeIn" class="mb-3" style="display:none;">
    <label asp-for="Order.TableId" class="form-label"></label>
    <select asp-for="Order.TableId" class="form-select" asp-items="Model.Tables">
        <option value="">-- Bitte Tisch wählen --</option>
    </select>
    <span asp-validation-for="Order.TableId" class="text-danger"></span>
</div>
```

**2. `_OrderSectionDelivery.cshtml`**
(Übernehmen Sie hier den HTML-Code für den Liefer-Bereich. Achten Sie auf `asp-validation-for` Spans bei jedem Feld.)

### Schritt 2: Anpassung der `Index.cshtml`

Ersetzen Sie die entsprechenden Blöcke in der `Index.cshtml` durch:
```cshtml
<partial name="_OrderSectionTakeIn" model="Model" />
<partial name="_OrderSectionDelivery" model="Model" />
```

### Schritt 3: Modularisierung der Rechnungsliste

Erstellen Sie Partials für die Rechnungen (`_BillItemRestaurant.cshtml`, `_BillItemDelivery.cshtml`, `_BillItemTakeAway.cshtml`) und rufen Sie diese dynamisch in der Schleife auf.

---

## Teil B: Kategorie 1 - Input Validation (Model & Controller)

Diese Fehler ("Email fehlt") sollen rot am Feld angezeigt werden, ohne Neuladen der Seite.

### Schritt 1: Validation Summary konfigurieren
Wir wollen eine Fehlerbox oben, die nur sichtbar ist, wenn Fehler auftreten.
Entfernen Sie alle `if (!ModelState.IsValid)` Abfragen um die Summary in der `Index.cshtml`.

```cshtml
<div asp-validation-summary="All" class="alert alert-danger mb-3"></div>
```

Fügen Sie in der `wwwroot/css/site.css` hinzu:
```css
.validation-summary-valid {
    display: none !important;
}
```

### Schritt 2: Scripts
Stellen Sie sicher, dass am Ende der `Index.cshtml` die Partial View `_ValidationScriptsPartial` geladen wird.

---

## Teil C: Kategorie 2 - Business Exceptions (Service -> Middleware)

Diese Fehler (Datenbank-Logik) sollen den User mit einer **gelben Warnung** auf der Formularseite halten.

### Schritt 1: Custom Exception
Erstellen Sie `Exceptions/FruehstueckBusinessException.cs` (erbt von `Exception`).

### Schritt 2: Middleware
Erstellen Sie `Middleware/ExceptionHandlingMiddleware.cs`.
* Catch `FruehstueckBusinessException`:
    * Loggen als **Warning**.
    * Redirect zur `Index`-Seite mit Fehler als Query-Parameter (`?error=...`).
* **Kein** catch für normale Exceptions (diese sollen zur Standard-Fehlerseite durchfallen).

Registrieren Sie die Middleware in `Program.cs` **nach** `UseExceptionHandler` (falls vorhanden) und **vor** `UseRouting`.

### Schritt 3: Service-Logik (`CustomerService`)
Werfen Sie `FruehstueckBusinessException` in folgenden Fällen:
1.  **Kunde nicht gefunden:** In `CreateOrderAsync`, wenn `FindAsync` null liefert.
2.  **Aberglaube:** In `CreateOrderAsync` (TakeIn), wenn `TableId == 13`.
3.  **Storno-Regel:** In `UpdateDeliveryAsync`, wenn versucht wird, eine gelieferte Bestellung zu stornieren.

---

## Teil D: Kategorie 3 - Technical Exceptions (System Absturz)

Diese Fehler sind unerwartet. Der User soll auf die **rote Error-Page** geleitet werden.

### Aufgabe
Wir simulieren einen sporadischen Hardware-Fehler ("Disk Full") beim Bildupload in `UpdateDeliveryAsync`.

Fügen Sie im `CustomerService` folgenden Code ein:

```csharp
// Bild speichern
if (vm.DeliveryImage != null)
{
    try
    {
        // Simulation eines Fehlers (50% Wahrscheinlichkeit)
        if (new Random().NextDouble() < 0.5)
        {
            throw new Exception("Simulation einer vollen Disk.");
        }

        var folderName = "delivery_proofs";
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
        if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

        // ... Code zum Speichern der Datei ...
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Kritischer Fehler beim Bildupload.");
        throw; // Fehler weiterwerfen, damit die Middleware ihn NICHT fängt, sondern die Error-Page kommt
    }
}
```

---

## Teil E: Logging

Integrieren Sie `ILogger` und protokollieren Sie:

1.  **LogWarning:** In der Middleware, wenn eine BusinessException gefangen wird.
2.  **LogError:** Im `CustomerService` catch-Block beim Bildupload (bevor `throw` aufgerufen wird).
3.  **LogInformation:** Bei erfolgreichem Abschluss einer Bestellung.