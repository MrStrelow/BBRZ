# Exercise 2: View-Refactoring & Resilience (Exceptions & Logging)

In dieser Übung werden wir die monolithische View aufbrechen, die Anwendung durch zentrales Fehlerhandling robuster machen und verschiedene Fehlerkategorien sauber implementieren.

## Teil A: Refactoring zu Partial Views

Die `Index.cshtml` ist aktuell überladen. Wir lagern Logik in wiederverwendbare Bausteine aus.

### Schritt 1: Aufteilen des Bestellformulars

Erstellen Sie im Ordner `Views/Fruehstueck/` folgende Dateien und übergeben Sie jeweils das **gesamte** ViewModel (`model="Model"`).

**Strategie:** Wir verwenden hier als Schnittstelle zwischen Index.cshtml und den partial Views eine Übergabe des kompletten ViewModels *Frühstücksmodel*.
*Hinweis:* Das erzeugt eine starke Kopplung zwischen Partial View und dem Haupt-ViewModel. In großen Architekturen würde man eigene ViewModels bevorzugen, aber für dieses Refactoring ist es der schnellste Weg, um Zugriff auf alle Listen (z.B. Tische) zu erhalten.

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
Stellen Sie sicher, dass am Ende der `Index.cshtml` die Partial View `_ValidationScriptsPartial` mit dem partial-tag geladen wird. Dieses .cshtml file ist im Ordner Shared anzulegen. Der Inhalt ist folgender.
```html
<script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js"></script>
```

### Schritt 3: Prüfe client side validation
Im fehlerfall soll folgendes in den requests sichtbar sein - keine Requests an den Server!:
![text](no request.png)

Im korrekten Fall ohne Fehler sollen dann Requests an den Server sichtbar sein:
![text](correct request.png)
 
 