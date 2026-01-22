# Übung: Authentifizierung + Autorisierung (mehr rollen)

### Hinweis:
Die datenbank sollte aus der vorherigen übung schon mit der authentication versehen worden sein. Falls nicht, vergiss nicht die änderungen durch Identity.Efcore in die datenbank zu übernehmen! Davor muss auch das nuget packet installiert werden für Idenity.EfCore. Siehe unten.

## Zielsetzung
Erweitern Sie das bestehende Frühstücks-Bestellsystem um eine Benutzerverwaltung.
Das Ziel ist eine Absicherung der Anwendung, sodass **alle** Bereiche einen Login erfordern (außer Login/Registrierung selbst).

Es sollen zwei Rollen eingeführt werden:
1.  **Admin:** Darf alle Bestellarten nutzen, insbesondere auch **Lieferungen (Delivery)**.
2.  **User:** Darf Bestellungen aufgeben (Abholung, Restaurant), jedoch **KEINE Lieferungen und bestehende auch nicht manipulieren**.

---

## Teil A: Aufgabenstellung

### 1. Identity Konfiguration & Globaler Schutz
Die Anwendung ist aktuell für jeden zugänglich. Das soll geändert werden.
* Konfigurieren Sie **ASP.NET Core Identity** in der `Program.cs`.
* **Globaler Login-Zwang:** Sorgen Sie dafür, dass **alle** Controller und Actions standardmäßig eine Authentifizierung erfordern (nutzen Sie `AddControllersWithViews` Optionen).
* Stellen Sie sicher, dass Login, Registrierung und Fehlerseiten (`[AllowAnonymous]`) für unangemeldete Nutzer erreichbar bleiben.

### 2. Registrierung & Login (Authentication)
Erstellen Sie einen `AccountController` für die Verwaltung der Zugänge.

* **Registrierung:**
    * Erstellen Sie eine View `Register.cshtml`.
    * Verwenden Sie für das Formular ein neues **`RegisterViewModel`** (beinhaltet Email, Password, ConfirmPassword).
    * Neue Benutzer sollen nach der Registrierung automatisch eingeloggt und der Rolle **"User"** zugewiesen werden.
* **Login:**
    * Erstellen Sie die View `Login.cshtml` mit Verlinkungen zur Registrierung und zum "Passwort vergessen"-Bereich.
* **Passwort vergessen:**
    * Implementieren Sie den Prozess zum Zurücksetzen des Passworts.
    * Erstellen Sie dafür die ViewModels **`ForgotPasswordViewModel`** (nur Email) und **`ResetPasswordViewModel`** (Email, Token, neues Passwort).
    * **Mock Email:** Da kein echter SMTP-Server existiert, implementieren Sie das Interface `IEmailSender` als Klasse **`MockEmailSender`**. Diese soll den Reset-Link lediglich in die Konsole (`ILogger`) schreiben, statt eine echte E-Mail zu senden.

### 3. Rollenmanagement & Test-Daten
* Erstellen Sie eine Hilfs-Methode `/Account/CreateTestUser`.
* Diese soll einen User `admin@test.at` (PW: `admin`) erstellen und der Rolle **"Admin"** zuweisen.

### 4. Geschäftsregeln (Autorisierung)
Setzen Sie die Geschäftslogik im `FruehstueckController` um:

* **Szenario:** Ein eingeloggter **User** (ohne Admin-Rechte) versucht, eine Bestellung vom Typ **Delivery** abzusenden.
* **Reaktion:** Die Bestellung darf **nicht** gespeichert werden. Stattdessen soll das Formular erneut angezeigt werden (`return View(...)`) mit einer entsprechenden Fehlermeldung im `ModelState`. Die GUI (Buttons) soll dabei unverändert bleiben.
* **Admin:** Darf Lieferungen ohne Einschränkung bestellen.
* **Access Denied:** Unbefugte Zugriffe (z. B. URL-Manipulation) sollen auf eine freundliche View `AccessDenied.cshtml` (im Ordner Account) umgeleitet werden.

---

## Teil B: Technische Referenz & Code-Änderungen

### 0. Übersicht: Neu zu erstellende Dateien
Diese Dateien müssen Sie neu anlegen:

* **Services/**
    * `MockEmailSender.cs` (Implementiert `IEmailSender`)
* **ViewModels/**
    * `RegisterViewModel.cs`
    * `ForgotPasswordViewModel.cs`
    * `ResetPasswordViewModel.cs`
* **Views/Account/**
    * `Register.cshtml`
    * `Login.cshtml`
    * `AccessDenied.cshtml`
    * `ForgotPassword.cshtml` & `ForgotPasswordConfirmation.cshtml`
    * `ResetPassword.cshtml` & `ResetPasswordConfirmation.cshtml`

### 1. Konfiguration in `Program.cs`

Fügen Sie diese Blöcke in der `Program.cs` ein.

```csharp
// 1. Identity Services & Token Provider (für Passwort Reset)
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = false; // Vereinfachung für Übung
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders(); 

// 2. Cookie Einstellungen (Redirects anpassen)
builder.Services.ConfigureApplicationCookie(options => {
    // Nicht eingeloggt (401) -> AccessDenied 
    options.LoginPath = "/Account/AccessDenied"; 
    // Keine Rechte (403) -> AccessDenied
    options.AccessDeniedPath = "/Account/AccessDenied";
});


// 3. Globaler Filter (Controller Optionen)
// Dies sperrt die gesamte Anwendung ab, außer Actions mit [AllowAnonymous]
builder.Services.AddControllersWithViews(options => {
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// 4. Mock Email Service registrieren
builder.Services.AddTransient<IEmailSender, MockEmailSender>();
```

### 2. Logik im `FruehstueckController` (Die Liefersperre)

Die Geschäftslogik wird beim `POST` der Bestellung geprüft.

```csharp
[HttpPost]
public async Task<IActionResult> Bestellen([Bind(Prefix = "Order")] OrderViewModel orderViewModel)
{
    // --- AUTORISIERUNGS-CHECK ---
    if (orderViewModel.Type == OrderType.Delivery)
    {
        // Wenn User NICHT Admin ist -> Fehler
        if (!User.IsInRole("Admin"))
        {
            ModelState.AddModelError("", "Fehler: Sie haben keine Berechtigung für Lieferungen.");
        }
    }
    // -----------------------------

    if (!ModelState.IsValid) 
    {
        // View neu laden (Bestellung wird NICHT gespeichert)
        var vm = new FruehstueckViewModel();
        await PopulateViewModelAsync(vm); 
        vm.Order = orderViewModel;
        return View("Index", vm);
    }
    
    // ... Speichern Logik ...
}
```

### 3. Datenbank Migration
Vergessen Sie nicht, die neuen Identity-Tabellen anzulegen:
```powershell
Add-Migration AddIdentityTables
Update-Database
```