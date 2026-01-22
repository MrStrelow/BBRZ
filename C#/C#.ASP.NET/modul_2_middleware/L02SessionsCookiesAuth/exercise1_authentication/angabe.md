# Exercise 1: Implementierung von Rollen und Autorisierung

In diesem Schritt erweitern wir die Authentifizierung um konkrete Berechtigungen (Autorisierung). Ziel ist es, administrative Bereiche zu schützen und sicherzustellen, dass nicht jeder User alles sehen darf.

---

### 0. Vorbereitung
1) Installiere die Verbindung zur Datenbank mit Login/Authenitcation/Authorisation.
```bash
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```
2) Ändere im ApplicationContext die Ist-Beziehung auf folgendes:
```csharp
public class ApplicationDbContext : IdentityDbContext
{
    ...
}
```

3) Konfiguriere die Services im Programm.cs.
```csharp
using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.Services;
using FruehstuecksBestellungMVC.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; // Neu
using Microsoft.AspNetCore.Authorization; // Neu
using Microsoft.AspNetCore.Mvc.Authorization; // Neu

var builder = WebApplication.CreateBuilder(args);
... // Was für passwort regegl will ich? AddIdentity
... // Erlaube iene Zugriffsverhinderung wenn nicht eingeloggt -> genaueres wird im Controller festgelegt!mit z.B. [AllowAnonymous] Attribut.

... 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
... // Authentication Middleware hinzufügen (VOR Authorization)

app.Run();
```


## 1. Rollen anlegen ("Admin")
Damit wir zwischen normalen Nutzern und Administratoren unterscheiden können, müssen wir das Rollen-System von ASP.NET Core Identity nutzen.

**Aufgabe:**
Sorgen Sie dafür, dass beim Start der Anwendung (in `Program.cs` oder einer Seeding-Methode) überprüft wird, ob die Rolle **"Admin"** existiert.
* Falls nein: Erstellen Sie die Rolle.
* Weisen Sie einem Ihrer Test-User (z. B. `admin@test.at`) diese Rolle zu.

*Hinweis: Nutzen Sie dazu den `RoleManager<IdentityRole>` und den `UserManager<IdentityUser>`.*

---

## 2. Controller schützen
Aktuell sind alle Seiten für jeden (auch anonyme User) sichtbar. Das soll geändert werden.

**Aufgabe:**
Versehen Sie den `DishController` (oder spezifische Actions darin, wie Create/Edit/Delete) mit dem `[Authorize]`-Attribut.
* Stellen Sie sicher, dass für kritische Aktionen (z. B. Löschen oder Bearbeiten) die Rolle "Admin" vorausgesetzt wird.
* Für die Detailansicht (`Details`) soll zumindest ein eingeloggter User erforderlich sein.

---

## 3. View
Erstelle eine View welche den Login und passwort übernimmt und an den Controller schickt.
Dieses html soll ohne login erreichbar sein!

---

## 4. Änderunen in die Datenbank übernehmen
Es werden neue Tabellen in der Datenbank angelegt. Verwende update, add migration, etc. um diese in der Datenbank zu übernehmen.

## 5. Testen & Verifizieren

Führen Sie die folgenden Tests durch, um sicherzustellen, dass die Sicherheitsmechanismen greifen.

### Test A: Zugriff ohne Login
1.  Stellen Sie sicher, dass Sie **ausgeloggt** sind.
2.  Versuchen Sie, die Detailseite eines Gerichts direkt über die URL aufzurufen (passen Sie den Port ggf. an):
    * `http://localhost:5091/Dish/Details/1`
3.  **Erwartetes Ergebnis:** Sie dürfen die Seite **nicht** sehen. Stattdessen sollten Sie automatisch zur Login-Seite (`/Identity/Account/Login`) weitergeleitet werden.

### Test B: Persistenz des Auth-Cookies (Server-Neustart)
Hier überprüfen wir, ob das Cookie wirklich unabhängig vom Server-RAM funktioniert (Statelessness bzgl. Session-State).

1.  Starten Sie die Anwendung.
2.  Loggen Sie sich mit einem gültigen User ein.
3.  Navigieren Sie zu einer geschützten Seite (z. B. `Dish/Details/1`).
4.  **Stoppen Sie das Programm** (Beenden Sie das Debugging in Visual Studio / Stoppen Sie den Server).
5.  **Starten Sie das Programm neu.**
6.  Laden Sie die Seite im Browser neu (F5).
7.  **Erwartetes Ergebnis:**
    * Sie sind **immer noch eingeloggt**.
    * Der Server hat das Cookie entschlüsselt und akzeptiert, obwohl er neu gestartet wurde.
    * Dies beweist, dass die Authentifizierungsinformationen im Cookie (Client) gespeichert sind und nicht im flüchtigen RAM des Servers verloren gegangen sind.