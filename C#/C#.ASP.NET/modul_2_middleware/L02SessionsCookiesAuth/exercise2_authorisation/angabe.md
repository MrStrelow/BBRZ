# Übung: Authentifizierung + Autorisierung (mehr rollen)

## Zielsetzung
Erweitern Sie das bestehende Frühstücks-Bestellsystem um eine Benutzerverwaltung. Das Ziel ist es, die Anwendung so abzusichern, dass nur authentifizierte Nutzer Zugriff haben. Zusätzlich sollen spezifische Geschäftsregeln basierend auf Rollen (`Admin` vs. `User`) implementiert werden.

---

## Teil A: Aufgabenstellung

### Hinweis:
Die datenbank sollte aus der vorherigen übung schon mit der authentication versehen worden sein. Falls nicht, vergiss nicht die änderungen durch Identity.Efcore in die datenbank zu übernehmen! Davor muss auch das nuget packet installiert werden für Idenity.EfCore. Siehe unten.

### 1. Identity Konfiguration & Globaler Schutz
Die Anwendung ist aktuell für jeden zugänglich. Das soll geändert werden.
* Konfigurieren Sie **ASP.NET Core Identity** in der `Program.cs`.
* **Globaler Login-Zwang:** Sorgen Sie dafür, dass **alle** Controller und Actions standardmäßig eine Authentifizierung erfordern (nutzen Sie `AddControllersWithViews` Optionen).
* Stellen Sie sicher, dass Login, Registrierung und Fehlerseiten (`[AllowAnonymous]`) erreichbar bleiben.

### 2. Registrierung & Login
* Erstellen Sie einen `AccountController` (falls noch nicht vorhanden) und die passenden ViewModels.
* Implementieren Sie **Login**, **Logout** und **Registrierung**.
* Neue User erhalten automatisch die Rolle **"User"**.
* Implementieren Sie **Passwort vergessen** mit einem `MockEmailSender` (Log-Ausgabe statt echter E-Mail).

### 3. Rollenmanagement
* Erstellen Sie eine Hilfs-Methode `/Account/CreateTestUser`.
* Diese soll einen User `admin@test.at` (PW: `admin`) erstellen und der Rolle **"Admin"** zuweisen.

### 4. Geschäftsregeln (Autorisierung)
* **User:** Darf bestellen, aber **KEINE Lieferung (Delivery)**.
* **Admin:** Darf alles bestellen.
* **Implementierung:** Prüfung im `FruehstueckController`. Bei Verstoß: `ModelState`-Fehler anzeigen (kein Redirect, GUI bleibt gleich).
* **Access Denied:** Unbefugte Zugriffe (401/403) sollen auf eine freundliche `/Account/AccessDenied` Seite leiten.

---

## Teil B: Technische Referenz & Code-Änderungen

### 0. Übersicht: Neu zu erstellende Dateien
Diese Dateien müssen Sie neu anlegen, um die Funktionalitäten abzubilden:

* **Services/**
    * `MockEmailSender.cs`
* **ViewModels/**
    * `RegisterViewModel.cs`
    * `ForgotPasswordViewModel.cs`
    * `ResetPasswordViewModel.cs`
* **Views/Account/**
    * `Register.cshtml`
    * `AccessDenied.cshtml`
    * `ForgotPassword.cshtml`
    * `ForgotPasswordConfirmation.cshtml`
    * `ResetPassword.cshtml`
    * `ResetPasswordConfirmation.cshtml`

*(Der `AccountController.cs` und `Login.cshtml` existieren ggf. bereits als Rumpf und müssen erweitert werden.)*

---

### 1. Konfiguration in `Program.cs`

Fügen Sie diese Blöcke in der `Program.cs` ein, um Identity zu laden, Cookies zu konfigurieren und den globalen Filter zu setzen.

```csharp
// 1. Identity Services & Token Provider (für Passwort Reset)
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders(); 

// 2. Cookie Einstellungen (Redirects anpassen)
builder.Services.ConfigureApplicationCookie(options => {
    // Nicht eingeloggt (401) -> AccessDenied (statt Login, um User-Confusion zu vermeiden)
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

### 2. Neue Klassen & Services

#### ViewModels
Erstellen Sie im Ordner `ViewModels`:
* `RegisterViewModel.cs`: (Email, Password, ConfirmPassword)
* `ForgotPasswordViewModel.cs`: (Email)
* `ResetPasswordViewModel.cs`: (Email, Password, ConfirmPassword, Code)

#### MockEmailSender
Erstellen Sie `Services/MockEmailSender.cs` (implementiert `IEmailSender`), um E-Mails nur in den Logger zu schreiben, statt zu senden.

### 3. Logik im `FruehstueckController` (Die Liefersperre)

Die Geschäftslogik, dass normale User keine Lieferungen aufgeben dürfen, wird direkt beim `POST` der Bestellung geprüft.

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
        await PopulateViewModelAsync(vm); // Falls Methode vorhanden
        vm.Order = orderViewModel;
        return View("Index", vm);
    }
    
    // ... Speichern Logik ...
}
```

### 4. AccountController Übersicht

Der `AccountController` benötigt folgende Actions:
* `Login` (Get/Post)
* `Logout` (Post)
* `Register` (Post): Nach `CreateAsync` muss `_userManager.AddToRoleAsync(user, "User")` aufgerufen werden.
* `AccessDenied`: Gibt einfach die View zurück.
* `CreateTestUser`: Prüft/Erstellt Rolle "Admin" und weist User zu.
* `ForgotPassword` / `ResetPassword`: Standard Identity Logik.

### 5. Views
Erstellen Sie im Ordner `Views/Account`:
* `Login.cshtml` (mit Links zu "Passwort vergessen" & "Registrieren")
* `Register.cshtml`
* `AccessDenied.cshtml` (Wichtig: Muss Link zum Login enthalten!)
* `ForgotPassword.cshtml` & `Confirmation`
* `ResetPassword.cshtml` & `Confirmation`

### 6. Datenbank
Vergessen Sie nicht, die neuen Tabellen anzulegen:
```powershell
Add-Migration AddIdentityTables
Update-Database
```