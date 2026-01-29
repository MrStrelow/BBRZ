# Modultest 2

Sie haben `180 Minuten` Zeit die Aufgaben zu lösen
* Sie können maximal 100 Punkte erreichen
* Es sind zur Prüfung zugelassen:
    * Taschenrechner (wenn erwünscht)
    * Transparente Wasserflasche
    * Papier, Geodreieck, Stifte, usw.
    * Am Computer sind alle Unterlagen sowie die Nutzung des Internets erlaubt.

Die Nutzung des Internets umfasst nicht
* Chatbots
* Veröffentlichung der Lösungen
* sonstige Kommunikation mit anderen Usern

Die Nutzung von allen anderen Dingen, muss vorher mit mir abgesprochen werden
(z.B. Nutzung von Ohropax), ansonsten wird dies als schummeln gewertet. 
Die Folge des Schummeln ist eine Bewertung mit 0 Punkten.

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 15 minuten nach Ende des Tests zu schicken)
* Viel Erfolg! :)

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., (Schulnotensystem)

---

## Vorbereitung (bevor die Prüfung startet)
* **Wie öffne ich die Vorlage?**
    1) git clone 
    
---

## **Aufgabe_1:** Authentifizierung, Autorizierung, Validierung und Server-Side Exception Handling [100 / 100 Punkte]

### Programmverständnis [20 / 100 Teilpunkte]
In folgendem ``Controller`` und ``View`` haben sich Fehler eingeschlichen. Finde und behebe diese. Erkläre warum es ein Fehler oder ein konzeptionell falscher Ansatz ist.

1) ``Controler`` und ``View``
```csharp
[HttpPost]
public IActionResult Register(UserRegistrationModel model)
{
    // irgendwas sollte doch hier abgefrat werden...

    // Speichern des Users in die Datenbank
    _db.Users.Add(model);
    _db.SaveChanges();

    return RedirectToAction("Success");
}
```

```csharp
<form asp-action="Register" method="post">
    <label>Alter:</label>
    <input type="number" name="Age" min="18" required />
    <button type="submit">Registrieren</button>
</form>
```

2) ``Controller``
Nur eingeloggte Admins sollen die Actions dieses Controllers verwenden können, aber eine Login-Seite soll für alle bereitgestellt werden.
```csharp
[Authorize(Roles = "Admin")]
public class AdminPanelController : Controller
{
    private readonly IUserService _userService;

    public AdminPanelController(IUserService userService) 
    { 
        _userService = userService; 
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult DeleteUser(int id)
    {
        _userService.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Login()
    {
        return View();
    }
}
```

3) ``Controller``
```csharp
[HttpGet]
public IActionResult GetSensitiveData(int id)
{
    try
    {
        var data = _repository.GetData(id);
        if (data == null) throw new Exception("Daten nicht gefunden für ID: " + id);
        return Ok(data);
    }
    catch (Exception ex)
    {
        // Fehler direkt an den Client zurückgeben, damit das Frontend weiß was los ist
        return StatusCode(500, new { 
            Error = "Ein Fehler ist aufgetreten", 
            Details = ex.Message,
            Stack = ex.StackTrace 
        });
    }
}
```

---

### Programmieren [60 / 100 Teilpunkte]
Installiere falls nicht schon vorhanden:
```bash
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```

Im ``Projekt`` *Aufgabe_2* befindet sich funktionierender ``Code``. Damit dieses fehlerfrei startet muss eine ``Datenbank`` mit Namen *TemporaryExamDb* erstellt und befüllt werden. Siehe [Vorbereitung](#vorbereitung-bevor-die-prüfung-startet). (Es kann jeder Name verwendet werden, jedoch muss die ``Datenbank`` welche in *appsettings.json* verwendet wird, am ``SQL-Server`` existieren.)

Führe folgendes im ``Terminal`` aus. 
```bash
dotnet ef migrations add Auth
dotnet ef database update
```

# Prüfung: Authentifizierung, Validierung und Error-Handling

Vervollständige das Programm in den angegebenen Ebenen durch folgende ``Klassen`` und ``Konfigurationen``. Ziel ist es, das System um eine Benutzerverwaltung zu erweitern und Business-Regeln abzusichern.

### Programmverständnis & Implementierung [40 Punkte]

* ``Program.cs`` & ``ApplicationDbContext``: 
    * Konfiguriere den ``Service-Container`` für **ASP.NET Core Identity**. Verwende den vorhandenen ``ApplicationDbContext`` als Store.
    * Konfiguriere die ``Password-Policy``: Es sind keine alphanumerischen Zeichen oder Großbuchstaben zwingend erforderlich (*RequireNonAlphanumeric = false*, *RequireUppercase = false*).
    * Stelle sicher, dass der ``DbContext`` von ``IdentityDbContext`` erbt, um Benutzer und Rollen speichern zu können.

* ``Models`` (Datenmodell):
    * Erweitere die Klasse ``Order`` um eine Verknüpfung zum ``IdentityUser`` (Property *UserId* und Navigation Property *User*).

* ``LoginViewModel``:
    * Erstelle dieses ``ViewModel`` im Ordner *ViewModels*.
    * Es soll die ``Eigenschaften`` *Email* und *Password* beinhalten.
    * Implementiere **Client-Side Validation** über ``Attribute``:
        * *Email*: Muss eine gültige E-Mail-Adresse sein und ist erforderlich.
        * *Password*: Ist erforderlich und muss als Datentyp *Password* gekennzeichnet sein.

* ``AccountController``:
    * Implementiere die ``Action`` *Login* (GET): Diese gibt die ``View`` *Login* zurück.
    * Implementiere die ``Action`` *Login* (POST):
        * Nimmt ein ``LoginViewModel`` entgegen.
        * Prüft den ``ModelState``.
        * Verwendet den ``SignInManager``, um den Benutzer einzuloggen (*PasswordSignInAsync*).
        * Bei Erfolg: Weiterleitung zur Startseite (``FruehstueckController``, Action *Index*).
        * Bei Misserfolg: Füge dem ``ModelState`` einen generischen Fehler hinzu ("Ungültiger Login") und zeige die View erneut an.
    * Implementiere die ``Action`` *Logout*: Meldet den Benutzer ab und leitet zur Startseite weiter.

* ``CustomerService``:
    * Erweitere die bestehende ``Methode`` *CreateOrderAsync*.
    * Implementiere folgende **Business-Regel**: Bestellungen mit einem Gesamtwert von über **50.00 EUR** dürfen nur von Benutzern mit der Rolle **"Admin"** getätigt werden.
    * Um dies zu prüfen, injiziere den ``IHttpContextAccessor`` oder übergebe das ``User``-Objekt (ClaimsPrincipal) an die Methode.
    * Wenn die Validierung fehlschlägt, wirf eine ``FruehstueckBusinessException`` mit der Nachricht "Bestellungen über 50€ erfordern Admin-Rechte.".

* ``FruehstueckController``:
    * Passe die ``Action`` *Bestellen* an.
    * Fange die vom Service geworfene ``FruehstueckBusinessException`` ab.
    * Füge die Fehlermeldung dem ``ModelState`` hinzu und gib die ``View`` *Index* mit den bisherigen Eingaben zurück, damit der Benutzer den Fehler korrigieren kann.
    * Schütze die ``Action`` *ManageDelivery* mit dem ``Attribut`` *[Authorize(Roles = "Admin")]*, sodass nur Administratoren Lieferungen bearbeiten dürfen.

* ``View`` (Login.cshtml):
    * Erstelle eine View, die das ``LoginViewModel`` verwendet.
    * Zeige Eingabefelder für *Email* und *Password*.
    * Binde die **Client-Side Validation Scripts** (*_ValidationScriptsPartial*) ein, damit Validierungsfehler sofort im Browser angezeigt werden, ohne einen Server-Request zu senden.

* ``_Layout.cshtml`` (View):
    * Erweitere die Navigationsleiste (Navbar).
    * Prüfe, ob der Benutzer authentifiziert ist (nutze ``User.Identity.IsAuthenticated`` oder den ``SignInManager``).
    * **Wenn eingeloggt:** Zeige den Text "Hallo [Username]" und einen **Logout-Button** an. Dieser Button muss einen POST-Request an die Logout-Action senden.
    * **Wenn nicht eingeloggt:** Zeige einen Link zur **Login-Seite** an.

* ``ManageDelivery.cshtml`` (View):
    * Erweitere die Anzeige der Bestelldetails.
    * Es soll sichtbar sein, **welcher User** (E-Mail-Adresse) diese Bestellung getätigt hat. Falls kein User zugeordnet ist (z.B. Altlasten), zeige "Gast" an.
---

### Theorie [20 / 100 Teilpunkte]
1) Was ist der Unterschied zwischen ``Authentifizierung`` und ``Autorisierung``?
2) Was sind ``Claims`` in *.NET*?
3) Was ist ein ``Cookie``? Wie funktioniert die ``Cookie-Authentifizierung``?
4) Was ist ``JWT`` (JSON Web Token) und was ist anders als bei der ``Cookie-Authentifizierung``?
5) Was ist eine ``Middleware``?
6) Ist es ein Problem für die ``Authentifizierung`` wenn ich mein *serverseitig verschlüsseltes* ``Cookie`` bei der ``Cookie-Authentifizierung`` jemanden anderen gebe?
7) Ist es ein Problem für die ``Authentifizierung`` wenn ich mein vom server signiertes ``Token`` bei der ``JWT-Authentifizierung`` jemanden anderen gebe?
8) Was tut das ``[Authorize]``-Attribut, was das ``[AllowAnonymous]``-``Attribut`` über einer ``Action`` im ``Controller``?
9) Was passiert, wenn mehrere ``[Authorize]``-``Attribute`` über einer ``Action`` verwendet werden? Gelten alle gleichzeitg? Nur das 1.? Keines?
10) Was ist der Unterschied zwischen ``Role-based`` und ``Policy-based`` ``Authorization``?
11) Ist ``Autorisierung`` ohne ``Authentifizierung`` möglich?
12) Wie binde ich Logging in einem eigens geschriebenen Service ein? Schreibe ich hier ``new Logger`` bei den ``Eigenschaften`` oder wird mir ``ILogger`` über den ``Konstruktor`` des ``Services`` von außen gegeben? 
13) Welche ``Log-Level`` gibt es und wann nutze ich welches?
14) Kann ich selbst ``Exceptions`` erstellen? Wie kann ich *fachliche* Fehler von *technischen* Fehlern unterscheiden?
15) Sollen *DSGVO* relevante Daten (Passwörter, Kreditkarten, Gesundheitsdaten) im ``Service`` geloggt werden?
16) Wann verwende ich nur ``throw;`` in einem ``catch`` Block?
