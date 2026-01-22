# Exercise 1: Implementierung von Rollen und Autorisierung

In diesem Schritt erweitern wir die Authentifizierung um konkrete Berechtigungen (Autorisierung). Ziel ist es, administrative Bereiche zu schützen und sicherzustellen, dass nicht jeder User alles sehen darf.

---

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

## 3. Testen & Verifizieren

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