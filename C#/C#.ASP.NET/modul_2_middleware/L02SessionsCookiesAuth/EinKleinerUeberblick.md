# Authentifizierung & Sicherheit in Web-Apps: Ein Leitfaden

Dieses Dokument fasst die Unterschiede zwischen Cookie-Auth (ASP.NET Identity) und Token-Auth (JWT) zusammen, erklärt die kryptographischen Grundlagen und warnt vor veralteten Session-Praktiken.

---

## 1. Grundbegriffe: Hashing vs. Verschlüsselung

Bevor wir über Login reden, müssen wir zwei mathematische Konzepte unterscheiden.

### A. Verschlüsselung (Encryption)
* **Prinzip:** Daten werden in einen "Tresor" gesperrt.
* **Richtung:** **Zweiweg** (Hin und Zurück). Man kann aus dem Geheimtext wieder den Klartext machen, wenn man den Schlüssel hat.
* **Art:** In ASP.NET Core Identity wird meist **symmetrische Verschlüsselung** (AES) genutzt.
    * *Symmetrisch:* Es gibt nur **einen** Schlüssel (auf dem Server). Der Server schließt den Tresor zu und schließt ihn später wieder auf.
* **Zweck:** Geheimhaltung. Niemand (auch nicht der Client) soll lesen können, was drin steht.

### B. Hashing & Signatur
* **Prinzip:** Daten werden durch den Fleischwolf gedreht.
* **Richtung:** **Einweg**. Man kann aus dem Hash ("Rührei") nicht wieder den Ursprungstext ("Ei") machen.
* **Eigenschaft:** Ändert sich auch nur ein Bit an den Daten, kommt ein komplett anderer Hash heraus.
* **Zweck:** Integrität (Unversehrtheit). Beweisen, dass Daten nicht verändert wurden.
* **Die Signatur:** Eine Kombination aus Hashing und einem **Geheimnis (Secret)**.
    * Formel: `Hash(Daten + Secret) = Signatur`.

---

## 2. Der Klassiker: Cookie Authentifizierung
*(Standard in ASP.NET Core MVC)*

Dies ist der empfohlene Weg für "normale" Webseiten, bei denen Frontend und Backend zusammengehören (Server-Side Rendering).

### Funktionsweise ("Der Garderoben-Chip")
1.  **Login:** User sendet Passwort.
2.  **Server:** Prüft Passwort. Erstellt ein Ticket mit den User-Daten (`User=Max, Role=Admin`).
3.  **Verpackung:** Der Server **verschlüsselt** dieses Ticket mit seinem Server-Key (AES).
4.  **Transport:** Der verschlüsselte Salat (`CfDJ8...`) wird als **Cookie** zum Browser geschickt.
5.  **Request:** Browser sendet das Cookie automatisch bei jedem Klick zurück.
6.  **Server:** Entschlüsselt das Cookie und weiß wieder, wer der User ist.

### Sicherheit
* **Lesbarkeit:** Der Client sieht nur Datenmüll. Er kann nicht lesen, wer eingeloggt ist (Verschlüsselung).
* **Fälschung:** Der Client kann kein gültiges Cookie erstellen, da ihm der Server-Key zum Verschlüsseln fehlt.
* **Diebstahlschutz:**
    * `HttpOnly`: Verhindert Zugriff per JavaScript (Schutz vor XSS).
    * `Secure`: Übertragung nur per HTTPS.
    * `SameSite`: Schutz vor CSRF-Angriffen.

---

## 3. Der Moderne: JWT (JSON Web Token)
*(Standard für SPAs und Mobile Apps)*

Dies wird genutzt, wenn Client (z.B. React/Angular) und Server (API) getrennt sind oder der Client "Stateless" sein muss (Mobile App).

### Funktionsweise ("Der Ausweis")
Ein JWT ist **nicht verschlüsselt**, sondern **signiert**. Er besteht aus 3 Teilen: `Header . Payload . Signature`.

1.  **Login:** Server prüft Passwort.
2.  **Erstellung:** Server erstellt ein JSON: `{ "sub": "Max", "role": "Admin" }`.
3.  **Signatur:** Der Server berechnet die Unterschrift:
    * `Hash(Header + Payload + SERVER_SECRET) = Signatur`
4.  **Transport:** Der Server sendet den String `Header.Payload.Signatur` an den Client.
5.  **Speicherung:** Der Client speichert den Token (idealerweise im HttpOnly Cookie, oft aber im LocalStorage).

### Sicherheit
* **Lesbarkeit:** **Jeder kann es lesen!** Es ist nur Base64-codiert. Ein Hacker kann den Token nehmen, decodieren und sieht: "Aha, User ID 5".
    * *Regel:* Niemals Passwörter oder Geheimnisse in ein JWT packen!
* **Fälschung:** Warum kann ich mich nicht zum Admin machen?
    * Hacker ändert Payload zu: `{ "sub": "Max", "role": "SuperAdmin" }`.
    * Hacker muss nun die **Signatur** neu berechnen, damit der Server es akzeptiert.
    * Formel: `Hash(Neue_Payload + ???)`.
    * Ihm fehlt das `SERVER_SECRET` (das "???").
    * Er kann keine gültige Signatur erzeugen. Der Server lehnt den gefälschten Token ab.

---

## 4. Vergleichstabelle

| Feature | Cookie Auth (MVC Identity) | JWT (Token Auth) |
| :--- | :--- | :--- |
| **Format** | Binärer "Datensalat" (Verschlüsselt AES) | JSON String (Signiert HMAC) |
| **Lesbarkeit Client** | Nein (Nur Server kann lesen) | **Ja** (Klartext nach Base64-Decode) |
| **Sicherheit** | Setzt auf Encryption & Hashing | Setzt auf Hashing & Signatur |
| **Server State** | Stateless* (Server entschlüsselt on-the-fly) | Stateless (Server prüft Signatur) |
| **Speicherort** | Browser Cookie Jar | LocalStorage oder Cookie |
| **Domain** | Gebunden an Domain (Same Origin) | Domain-übergreifend möglich |
| **Ideal für** | Server-Side Apps (MVC, Razor Pages) | SPAs (React, Vue), Mobile Apps |

*\*Hinweis: ASP.NET Core Identity Cookies sind selbst-beinhaltend (stateless), nutzen aber die Datenbank für Sicherheits-Checks (z.B. SecurityStamp).*

---

## 5. ⚠️ Exkurs: Der VERALTETE Weg (Session-Missbrauch)

In älteren Web-Technologien (z. B. PHP Sessions, Classic ASP) war es üblich, den Login-Status direkt in der Session (Server-RAM) zu speichern. In modernem .NET ist dies ein **Anti-Pattern**.

### ❌ Wie man es NICHT mehr macht (Bad Practice)
Hierbei wird der Server-Arbeitsspeicher als "Beweis" für den Login missbraucht.

```csharp
// VERALTET & SCHLECHT
[HttpPost]
public IActionResult Login(string username, string password) 
{
    if (CheckPassword(username, password)) 
    {
        // FEHLER: Manuelles Setzen von Session-Variablen für Auth
        HttpContext.Session.SetString("IsLoggedIn", "true");
        HttpContext.Session.SetString("Username", username);
        return RedirectToAction("Dashboard");
    }
    return View();
}

// Späterer Check (manuell und fehleranfällig)
public IActionResult Dashboard() 
{
    // FEHLER: Check gegen RAM
    if (HttpContext.Session.GetString("IsLoggedIn") != "true") 
    {
        return RedirectToAction("Login");
    }
    return View();
}
```

### Warum ist das schlecht? (Die 3 Nachteile)
1.  **Verlust bei Neustart:** Sessions liegen standardmäßig im **RAM**. Startest du den Server neu (z. B. für ein Update), wird der RAM geleert -> **Alle User fliegen sofort raus.**
2.  **Probleme in der Cloud (Skalierung):** Wenn deine App auf zwei Servern (A und B) läuft, liegt die Session nur im RAM von Server A. Landet der nächste Klick des Users bei Server B, kennt dieser die Session nicht -> **User ist ausgeloggt.**
3.  **Speicherfresser:** Jeder aktive User belegt dauerhaft Arbeitsspeicher auf dem Server, auch wenn er gerade nichts tut.

### ✅ Der moderne Weg (Identity / Claims)
Anstatt den Server-RAM zu füllen, packen wir die Informationen **verschlüsselt in das Cookie** selbst.

```csharp
// RICHTIG: Den Authentication-Service nutzen (Program.cs: AddIdentity)
[HttpPost]
public async Task<IActionResult> Login(string username, string password) 
{
    // Erstellt ein verschlüsseltes Cookie ("ClaimsPrincipal"), 
    // das alle Infos enthält. Der Server-RAM bleibt leer.
    var result = await _signInManager.PasswordSignInAsync(username, password, ...);
    
    if (result.Succeeded) return RedirectToAction("Dashboard");
}

// Schutz per Attribut (kein manueller Check nötig)
[Authorize] 
public IActionResult Dashboard() { ... }
```

---

## 6. Angriffsszenarien & Schutz

### Szenario: "Ich kopiere den Token/Cookie von Max" (Diebstahl / Hijacking)
Wenn ein Hacker das Artefakt stiehlt, **ist** er Max. Das System kann das nicht unterscheiden (Bearer-Prinzip).
* **Schutz:** HTTPS (Verschlüsselung der Leitung), HttpOnly (Verstecken vor JS), kurze Laufzeiten (Sliding Expiration).

### Szenario: "Ich ändere meine Rolle im Token" (Fälschung)
* **Bei Cookie:** Unmöglich, da Hacker nicht verschlüsseln kann (fehlt AES Key).
* **Bei JWT:** Unmöglich, da Hacker nicht signieren kann (fehlt HMAC Secret).

### Szenario: "Ich logge mich von woanders ein und ändere das Passwort"
Der alte, gestohlene Token/Cookie ist zeitlich noch gültig (z.B. 30 Minuten).
* **Lösung:** `SecurityStamp`.
* Bei jeder kritischen Änderung (Passwort, Rolle) ändert der Server den Stempel in der Datenbank.
* Bei jedem Request prüft Identity (Default: alle 30 Min, konfigurierbar): `Stempel im Token == Stempel in DB?`
* Wenn nein: Sofortiger Logout, Token wird abgelehnt.