# Übung: Rollenbasierte Autorisierung (User vs. Admin) und Passwort-Reset

In dieser Übung erweitern wir das System um zwei Rollen: **"User"** und **"Admin"**. Wir implementieren unterschiedliche Berechtigungen für Bestellungen und fügen Sicherheitsfeatures wie Registrierung und Passwort-Wiederherstellung hinzu.

---

## 1. Registrierung für neue Benutzer
Bisher haben wir nur mit festen Test-Usern gearbeitet. Nun soll sich jeder registrieren können.

**Aufgabe:**
* Stellen Sie sicher, dass die **Registrierungsseite** (`/Identity/Account/Register`) erreichbar ist und funktioniert.
* Neue Benutzer, die sich hier registrieren, sollen standardmäßig **keine** Admin-Rechte haben (automatisch Rolle "User" oder gar keine Rolle, je nach Implementierung, aber keinesfalls "Admin").

---

## 2. Erstellung des "Test-Admins" (Seeding per Knopfdruck)
Um das Testen zu erleichtern, erstellen wir eine schnelle Möglichkeit, einen Administrator anzulegen.

**Aufgabe:**
* Erstellen Sie in einem Controller (z. B. `HomeController` oder `AdminController`) eine Action `CreateTestAdmin`.
* Verlinken Sie diese Action temporär auf der Startseite oder im Footer.
* **Logik dieser Action:**
    1.  Prüfen, ob die Rolle **"Admin"** und die Rolle **"User"** existieren. Falls nicht -> Erstellen (`RoleManager`).
    2.  Prüfen, ob ein User mit der E-Mail `admin@restaurant.at` existiert.
    3.  Falls nicht -> User erstellen und ihm **beide Rollen** ("User" und "Admin") zuweisen.
    4.  Falls er schon existiert -> Sicherstellen, dass er die Rolle "Admin" hat.

---

## 3. Autorisierung der Bestellungen (Die Geschäftslogik)
Hier implementieren wir die eigentliche Unterscheidung.

**Szenario:**
* **Rolle "User":** Darf normale Bestellungen aufgeben (z. B. Abholung / Dine-In), aber **keine** Lieferungen (Delivery) anlegen.
* **Rolle "Admin":** Darf **alle** Arten von Bestellungen aufgeben, auch Lieferungen.

**Wichtige Einschränkung (Constraint):**
Die Benutzeroberfläche (GUI/Views) darf **NICHT** verändert werden!
* Der Button/Link für "Lieferung" (Delivery) muss für den normalen User **sichtbar bleiben**.
* Wir verstecken den Button nicht. Wir lassen den User klicken, aber der Server muss ihn stoppen.

**Aufgabe:**
1.  Identifizieren Sie die Controller-Action, die für das Speichern/Anlegen einer **Lieferung** zuständig ist (z. B. `OrdersController.CreateDelivery` oder ähnlich).
2.  Schützen Sie diese spezifische Action mit dem `[Authorize]`-Attribut.
3.  Konfigurieren Sie das Attribut so, dass **nur** Benutzer mit der Rolle **"Admin"** Zugriff haben.
    * *Beispiel-Syntax:* `/'''csharp [Authorize(Roles = "Admin")] /'''`
4.  Normale Bestellungen (Create Order) sollen für alle eingeloggten Benutzer (`[Authorize]`) möglich sein.

---

## 4. Passwort-Wiederherstellung (Forgot Password)
Ein professionelles System benötigt einen Prozess, falls ein User sein Passwort vergisst.

**Aufgabe:**
* Aktivieren Sie die Token-Provider in Ihrer `Program.cs` bei der Identity-Konfiguration:
    `/'''csharp builder.Services.AddIdentity<...>().AddDefaultTokenProviders()... /'''`
* Stellen Sie sicher, dass in der Login-Maske ein Link "Passwort vergessen?" existiert.
* Hinterlegen Sie einen (Dummy-) `IEmailSender`, damit die Anwendung keinen Fehler wirft, wenn sie versucht, eine E-Mail zu senden (für diese Übung reicht es, den Reset-Link in die Konsole zu loggen, statt eine echte E-Mail zu senden).

---

## 5. Test-Szenarien

Führen Sie folgende Tests durch, um die Implementierung zu verifizieren:

### Test A: Der "Delivery"-Versuch als normaler User
1.  Registrieren Sie einen neuen Benutzer "Max".
2.  Loggen Sie sich als Max ein.
3.  Klicken Sie auf den Button für "Lieferung bestellen" (er ist ja noch sichtbar).
4.  Füllen Sie das Formular aus und senden Sie es ab.
5.  **Erwartetes Ergebnis:** Sie erhalten eine **"Access Denied"** (Zugriff verweigert) Seite (HTTP 403) oder werden zum Login umgeleitet (je nach Konfiguration). Die Bestellung darf **nicht** in der Datenbank gespeichert werden.

### Test B: Der "Delivery"-Versuch als Admin
1.  Klicken Sie Ihren "Test-Admin erstellen" Button.
2.  Loggen Sie sich als `admin@restaurant.at` ein.
3.  Versuchen Sie erneut, eine Lieferung aufzugeben.
4.  **Erwartetes Ergebnis:** Die Bestellung funktioniert problemlos.

### Test C: Passwort Reset
1.  Loggen Sie sich aus.
2.  Klicken Sie auf "Passwort vergessen".
3.  Geben Sie die E-Mail eines existierenden Users ein.
4.  Überprüfen Sie die Konsole (oder das Log), ob ein Reset-Token/Link generiert wurde (da wir keinen echten Mailserver haben).