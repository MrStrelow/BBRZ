# Exercise 2: View-Refactoring & Resilience (Middleware & Logging)

In dieser Übung werden wir die monolithische View aus Exercise 1/2 aufbrechen und die Anwendung durch zentrales Fehlerhandling und Logging robuster machen.

## Teil A: Refactoring zu Partial Views

Die `Index.cshtml` ist aktuell überladen und vermischt Logik für verschiedene Bestellarten. Wir lagern diese in Partial Views aus.

### Schritt 1: Aufteilen des Bestellformulars

Erstellen Sie die Partial Views für die spezifischen Eingabefelder.

**Strategie:** Wir verwenden hier als Schnittstelle zwischen Index.cshtml und den partial Views eine Übergabe des kompletten ViewModels *Frühstücksmodel*.
*Hinweis:* Das erzeugt eine starke Kopplung zwischen Partial View und dem Haupt-ViewModel. In großen Architekturen würde man eigene ViewModels bevorzugen, aber für dieses Refactoring ist es der schnellste Weg, um Zugriff auf alle Listen (z.B. Tische) zu erhalten.

Erstellen Sie im Ordner `Views/Fruehstueck/` folgende Dateien:

**1. `_OrderSectionTakeIn.cshtml`**
**2. `_OrderSectionDelivery.cshtml`**

Und fügen Sie dort die vorher im `Index.cshtml` befindlichen html - Blöcke ein.

### Schritt 2: Anpassung der `Index.cshtml`
Ersetzen Sie die ausgelagerten Bereiche in der Haupt-View durch den Tag-Helper.
Da wir das **ganze Model** übergeben, nutzen wir das Attribut `model` (nicht `for`):

```cshtml
<partial name="_OrderSectionTakeIn" model="Model" />
<partial name="_OrderSectionDelivery" model="Model" />
```

### Schritt 3: Modularisierung der Rechnungsliste

Erstellen Sie drei Partials für die Anzeige der Rechnungen:
* `_BillItemRestaurant.cshtml`
* `_BillItemDelivery.cshtml`
* `_BillItemTakeAway.cshtml`

Ersetzen Sie die `if-else`-Logik in der `foreach`-Schleife der `Index.cshtml`:

---

## Teil B: Funktionierende Client-Side Validation

Wir wollen, dass Validierungsfehler (z.B. fehlender Kunde) sofort angezeigt werden, ohne dass die Seite neu lädt.

### Schritt 1: Skripte einbinden
Fügen Sie am Ende der `Index.cshtml` (und `ManageDelivery.cshtml`) den Scripts-Abschnitt hinzu:

```cshtml
@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

### Schritt 2: Validation Summary konfigurieren
Wir wollen eine Fehlerbox oben, die nur sichtbar ist, wenn Fehler auftreten.
Entfernen Sie alle `if (!ModelState.IsValid)` Abfragen um die Summary. Nutzen Sie stattdessen CSS.

**In der `Index.cshtml`:**
```cshtml
<div asp-validation-summary="All" class="alert alert-danger mb-3"></div>
```

**In der `wwwroot/css/site.css`:**
Fügen Sie diese Regel hinzu, um die Box initial zu verstecken (ASP.NET vergibt die Klasse `.validation-summary-valid`, wenn keine Fehler da sind):

```css
.validation-summary-valid {
    display: none !important;
}
```

---