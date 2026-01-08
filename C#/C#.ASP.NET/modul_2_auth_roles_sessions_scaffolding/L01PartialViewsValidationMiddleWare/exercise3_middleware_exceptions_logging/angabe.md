# Exercise 3: View-Refactoring & Resilience (Exceptions & Logging)

## Business Exceptions (Service -> Middleware)

Diese Fehler treten auf, wenn die Daten zwar formal korrekt sind (z.B. ID ist eine Zahl), aber fachlich keinen Sinn ergeben (z.B. ID existiert nicht). Wir wollen den User mit einer **gelben Warnung** auf der Seite behalten.

### Schritt 1: Custom Exception erstellen
Erstellen Sie `Exceptions/FruehstueckBusinessException.cs` (erbt von `Exception`).

### Schritt 2: Middleware implementieren
Erstellen Sie `Middleware/ExceptionHandlingMiddleware.cs` (siehe Theorie).
* Catch `FruehstueckBusinessException` -> Redirect zu `Index` mit `?error=...`.
* Catch `Exception` -> *Ignorieren* (damit die Standard-Error-Page greift) oder Redirect zu `/Error/Error`.

### Schritt 3: Implementierung im `CustomerService`
Implementieren Sie folgende **drei Szenarien** im Service. Werfen Sie jeweils eine `FruehstueckBusinessException` mit sprechender Nachricht.

#### Szenario 1: Daten-Inkonsistenz (Der Klassiker)
In `CreateOrderAsync`: Prüfen Sie, ob der Kunde (`_context.Customers.FindAsync`) wirklich existiert.
* *Fehler:* "Der angegebene Kunde konnte in der Datenbank nicht gefunden werden."

#### Szenario 2: Status-Prüfung (Storno)
In `UpdateDeliveryAsync`: Prüfen Sie vor dem Stornieren (`IsCanceled = true`), ob die Bestellung bereits ausgeliefert wurde (`ActualDeliveryDate != null`).
* *Fehler:* "Bereits ausgelieferte Bestellungen können nicht mehr storniert werden."

#### Szenario 3: Geschäftsregel (Der Unglückstisch)
Mangels komplexerer businesslogik hier eine komische Businessregel. In `CreateOrderAsync` (Zweig `TakeIn`): Wir simulieren eine Geschäftsregel. Tisch Nummer (id) 13 darf niemals gebucht werden.
* *Code:* `if (orderDto.TableId == 13) throw new FruehstueckBusinessException("Tisch 13 ist wegen Aberglaube gesperrt.");`
* *Fehler:* "Tisch 13 ist gesperrt."

---

## Teil D: Kategorie 3 - Technical Exceptions (System Absturz)

Diese Fehler sind unerwartet (Bug, Server-Ausfall). Der User kann nichts tun. Er soll auf die **rote Error-Page** geleitet werden.

### Aufgabe
Wir simulieren einen technischen Defekt beim Bildupload in `UpdateDeliveryAsync`. Diesr passiert mit einer Wahrscheinlichkeit von 50% wenn ein Bild hochgeladen wird.

1.  Fügen Sie einen `try-catch` Block um den File-Stream-Code beim Speichern des Bildes hinzu.
2.  Werfen Sie im `catch`-Block (oder zu Testzwecken direkt) eine **neue, generische Exception**:
    * *Code:* `throw new Exception("Simulierter Disk-Write-Error: Festplatte voll.");`
3.  Beobachten Sie das Verhalten:
    * Die `ExceptionHandlingMiddleware` fängt dies **nicht** im Business-Block.
    * Die Exception fällt durch zur Standard-Middleware (`UseExceptionHandler`).
    * Der Browser zeigt die Seite `/Error/Error` (oder Developer Page) an.

---

## Teil E: Logging

Integrieren Sie `ILogger` und protokollieren Sie die drei Kategorien unterschiedlich:

1.  **Input Validation:** Loggen Sie im `FruehstueckController`, wenn `ModelState.IsValid == false` ist. -> **LogWarning**
2.  **Business Exception:** Loggen Sie in der `Middleware` im ersten Catch-Block. -> **LogWarning**
3.  **Technical Exception:** Loggen Sie im `CustomerService` (im catch beim Bildupload) den echten Exception-Stacktrace. -> **LogError**