# ASP.NET Core Validation Cheat Sheet

Eine Übersicht über Client- und Server-Side Validierung, wichtige Attribute und Tag-Helper.

---

## 1. Die Konzepte

| Konzept | Ort | Beschreibung |
| :--- | :--- | :--- |
| **Server-Side** | C# (Controller) | **Sicherheit.** Zwingend erforderlich. Schützt vor Manipulation und direkten API-Aufrufen. Trigger: `ModelState.IsValid`. |
| **Client-Side** | JavaScript (Browser) | **User Experience (UX).** Optional. Gibt sofortiges Feedback ohne Page-Reload. Basiert auf jQuery Validation. |
| **Single Source** | ViewModel | Regeln werden **nur** im ViewModel definiert. ASP.NET generiert daraus Code für beide Seiten. |

---

## 2. ViewModel Attribute (Die Regeln)
Namespace: `using System.ComponentModel.DataAnnotations;`

Diese Attribute definieren die Validierungsregeln. Sie funktionieren (meistens) automatisch auf Client- und Server-Seite.

### Liste der wichtigsten Attribute
* **`[Required]`**: Feld darf nicht `null` oder leer sein.
* **`[StringLength(max, MinimumLength=min)]`**: Begrenzt die Zeichenlänge.
* **`[Range(min, max)]`**: Definiert Wertebereich für Zahlen.
* **`[EmailAddress]`**: Prüft auf gültiges E-Mail-Format.
* **`[Compare("AndereProperty")]`**: Vergleicht zwei Felder (z.B. Passwort wiederholen).
* **`[RegularExpression("Pattern")]`**: Prüft gegen Regex (z.B. PLZ, Telefon).
* **`[Display(Name="...")]`**: Kein Validator, aber wichtig für Label-Beschriftung.

### Code-Beispiel: ViewModel

```csharp
public class UserRegistrationModel
{
    [Required(ErrorMessage = "Benutzername ist Pflicht.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "3 bis 50 Zeichen.")]
    [Display(Name = "Dein Benutzername")]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Passwörter stimmen nicht überein.")]
    public string ConfirmPassword { get; set; }

    [Range(18, 99, ErrorMessage = "Nur für Volljährige (18+).")]
    public int Age { get; set; }
}
```

---

## 3. Tag-Helper (Die View)
Diese Helper in der `.cshtml` Datei verbinden das HTML mit dem C#-Model.

### Liste der wichtigsten Tag-Helper
* **`asp-for="Property"`**: 
    * Generiert `id`, `name`, `value`.
    * Generiert `data-val-*` Attribute für Client-Side Validation.
* **`asp-validation-for="Property"`**: 
    * Platzhalter (`<span>`) für die Fehlermeldung eines einzelnen Feldes.
* **`asp-validation-summary="All"`**: 
    * Zeigt eine Liste aller Fehler am Anfang des Formulars an.

### Code-Beispiel: View

```html
@model UserRegistrationModel

<form asp-action="Register" method="post">
    
    <div asp-validation-summary="All" class="text-danger"></div>

    <div class="form-group">
        <label asp-for="Username"></label>
        
        <input asp-for="Username" class="form-control" />
        
        <span asp-validation-for="Username" class="text-danger"></span>
    </div>

    <div class="form-group">
        <label asp-for="Age"></label>
        <input asp-for="Age" class="form-control" />
        <span asp-validation-for="Age" class="text-danger"></span>
    </div>

    <button type="submit">Registrieren</button>
</form>
```

---

## 4. Aktivierung der Client-Side Validation
Ohne diesen Schritt greift nur die Server-Validierung (Seite lädt neu bei Fehler).
Füge dies am Ende deiner View ein:

```html
@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```

---

## 5. Server-Side Check (Der Controller)
Dies ist der Sicherheitsanker. Auch wenn Client-Side Validation aktiv ist, muss der Server prüfen.

```csharp
[HttpPost]
public IActionResult Register(UserRegistrationModel model)
{
    // 1. Prüft, ob alle [Attribute] erfüllt sind
    if (!ModelState.IsValid)
    {
        // Fehlerfall: Zeige Formular erneut an (mit Fehlermeldungen)
        return View(model);
    }

    // 2. Alles valid -> Speichern
    // _userService.Save(model);

    return RedirectToAction("Success");
}
```

# Theorie: Views, Validation & Middleware

## 1. Partial Views

Partial Views dienen dazu, View-Code in wiederverwendbare Komponenten zu zerlegen (DRY-Prinzip).

### Datenübergabe Strategien

Es gibt zwei Hauptwege, Daten an ein Partial zu übergeben:

| Strategie | Syntax | Erklärung | Vor-/Nachteile |
| :--- | :--- | :--- | :--- |
| **Partial als Formular-Teil (`for`)** | `<partial for="Order" />` | Übergibt `Model.Order` und **behält das Prefix** bei. | **Pro:** Perfekt für Formulare. Inputs heißen automatisch `Order.TableId`.<br>**Contra:** Partial hat keinen Zugriff auf andere Daten (z.B. Dropdown-Listen im Eltern-Model). |
| **Full Model Passing (`model`)** | `<partial model="Model" />` | Übergibt das **gesamte** ViewModel der Hauptseite. | **Pro:** Einfacher Zugriff auf alle Listen und Daten.<br>**Contra:** Tight Coupling. Das Partial funktioniert nur mit diesem spezifischen ViewModel. Inputs müssen manuell präfigiert werden (`asp-for="Order.TableId"`). |

---

## 2. Client-Side Validation (Unobtrusive)

ASP.NET Core nutzt eine Technik namens "Unobtrusive JavaScript". Das bedeutet, wir schreiben kein JS, sondern dekorieren unser HTML mit Attributen.

### Ablauf
1.  **C# Model:** `[Required] public string Name { get; set; }`
2.  **Tag Helper:** `<input asp-for="Name">` generiert HTML: `<input data-val="true" data-val-required="Name muss rein">`.
3.  **JavaScript:** Die Bibliothek `jquery.validate.unobtrusive.js` liest diese `data-val`-Attribute beim Laden der Seite und aktiviert die Prüfregeln.

### CSS Steuerung
Damit die Validierung visuell funktioniert, verlässt sich die Bibliothek auf CSS-Klassen, die sie dynamisch tauscht:

* **`input-validation-error`**: Wird dem Input-Feld gegeben, wenn es ungültig ist (z.B. roter Rahmen).
* **`.validation-summary-valid`**: Wird dem Summary-Div gegeben, wenn alles OK ist. (Wir setzen hier oft `display: none`).
* **`.validation-summary-errors`**: Wird dem Summary-Div gegeben, wenn Fehler da sind. (Hier greift das `display: none` nicht mehr -> Box wird sichtbar).

---

# Theorie: Robustes Error-Handling & Architektur

Warum haben wir das Projekt so umgebaut? Hier sind die Hintergründe.

## 1. Exception Kategorien & Strategie

Nicht alle Fehler sind gleich. Wir unterscheiden strikt zwischen zwei Arten, um die User Experience (UX) zu optimieren.

### A. Business Exceptions (Fachliche Fehler)
* **Ursache:** Der User oder der Zustand der Daten verstößt gegen eine Regel (z.B. "Tisch belegt", "Konto überzogen").
* **Ziel:** Der User soll **nicht** bestraft werden (kein Absturz). Er soll auf der Seite bleiben und korrigieren können.
* **Technik:** * Wir werfen eine **eigene Exception** (`FruehstueckBusinessException`).
    * Unsere **Middleware** fängt *genau diese* Exception.
    * **Reaktion:** Redirect zurück zum Formular + Gelbe Warnbox.

### B. Technical Exceptions (Systemfehler)
* **Ursache:** Bugs, Serverausfall, Festplatte voll, Datenbank weg.
* **Ziel:** Die Anwendung ist in einem instabilen Zustand. Wir müssen abbrechen.
* **Technik:**
    * Wir werfen (oder fangen) normale `Exception`, `SqlException` etc.
    * Unsere Middleware ignoriert diese (oder hat keinen catch-Block dafür).
    * Die **Standard-ASP.NET-Middleware** (`UseExceptionHandler`) fängt diese am Ende auf.
    * **Reaktion:** Rote "Error"-Seite ("Bitte versuchen Sie es später erneut").

---

## 2. Middleware Pipeline

In ASP.NET Core durchläuft jeder Request eine Kette von Komponenten ("Pipeline"). 

**Unser Aufbau:**
1.  **`UseExceptionHandler` (Standard):** Das Sicherheitsnetz ganz außen. Fängt alles, was sonst niemand fängt (-> Rote Seite).
2.  **`ExceptionHandlingMiddleware` (Custom):** Sitzt weiter innen. Fängt *nur* unsere Business-Exceptions ab (-> Redirect zur Startseite).
3.  **`Routing` / `Controllers`:** Hier passiert die eigentliche Arbeit.

Wenn der Controller crasht, "fällt" der Fehler die Kette rückwärts hoch. Zuerst prüft unsere Middleware ("Ist es ein Business-Fehler?"). Wenn ja: behandeln. Wenn nein: durchlassen zur Standard-Middleware.

In ASP.NET Core durchläuft jeder Request eine "Pipeline". Middleware-Komponenten werden nacheinander aufgerufen.

**Beispielhafter Ablauf:**
`Request` -> `HttpsRedirection` -> `StaticFiles` -> `Routing` -> **`ExceptionHandlingMiddleware`** -> `Authorization` -> `Controller`

Wenn im `Controller` ein Fehler passiert, "fällt" dieser zurück durch die Pipeline. Da unsere `ExceptionHandlingMiddleware` den Aufruf in einen `try-catch` Block gehüllt hat (`await _next(context)`), kann sie den Fehler auf dem Rückweg fangen und behandeln.

---

## 3. Logging Strategie

Logging ist der "Flugschreiber" unserer Software. Wir nutzen verschiedene Levels für verschiedene Zielgruppen:

| Level | Wann nutzen? | Zielgruppe |
| :--- | :--- | :--- |
| **Information** | "Bestellung 123 angelegt", "Seite X aufgerufen" | Support / Business Analysten (Verstehen, was passiert ist). |
| **Warning** | "Validierung fehlgeschlagen", "Kunde nicht gefunden" (Business Exception) | Entwickler (Prüfen, ob User Probleme haben oder ob UX schlecht ist). Die App läuft weiter! |
| **Error** | "Datenbank Timeout", "Disk Full", "NullReference" | **DevOps / Admins**. Hier muss jemand handeln! Die App (oder der Request) ist abgestürzt. |

**Wichtig:** Im `catch`-Block einer technischen Exception (z.B. Bildupload) nutzen wir `LogError(ex, "...")`. Das speichert den **Stacktrace**. Das ist essentiell, um den Fehler später zu beheben.

Logging macht das Verhalten der App zur Laufzeit sichtbar.

### Log Levels
* **Trace/Debug:** Sehr detailliert, nur für Entwicklung.
* **Information:** Normaler Betriebsfluss (Request empfangen, Daten gespeichert).
* **Warning:** Unerwartetes Ereignis, aber kein Absturz (Falsches Passwort, Validierung fehlgeschlagen).
* **Error:** Fehler im aktuellen Request (Exception, DB nicht erreichbar).
* **Critical:** App stürzt ab oder systemweiter Ausfall.

### Best Practice
Nutzen Sie `Structured Logging`. Anstatt Strings zusammenzubauen:
```csharp
_logger.LogInformation("Bestellung {Id} von Kunde {Kunde} angelegt", order.Id, order.CustomerName);
```
Dies erlaubt Logging-Systemen (wie Serilog, Application Insights), nach spezifischen IDs zu filtern.


---







