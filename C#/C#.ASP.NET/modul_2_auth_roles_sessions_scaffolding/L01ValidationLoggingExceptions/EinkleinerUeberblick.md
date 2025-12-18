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