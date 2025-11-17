# Modultest 1

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

## Data Definition Language (DDL) mit EF-Core Model First umsetzen [40 / 100 Punkte]

![UML-Diagramm der Models]()

### Programmverständnis [10 / 40 Teilpunkte]

1) Finde die Fehler in den folgenden ``Model``-Definitionen. Es wird an einer Stelle kein ``Primary Key`` nach Konvention spezifiziert und eine ``1:n-Beziehung`` ist nicht vollständig implementiert.
2) Erkläre, wieso diese Fehler bei der Erstellung einer ``Migration`` zu Problemen führen bzw. nicht das gewünschte Datenbankschema erzeugen.

```csharp
// TODO: Finde die Fehler in diesem Code
public class Category
{
    // FEHLER 1: 
    public int CategoryKey { get; set; }
    public string Name { get; set; }

    // FEHLER 2:
}

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    
    public int CategoryId { get; set; }
    // FEHLER 3:
}
```

---

### Programmieren [20 / 40 Teilpunkte]
Implementiere das oben gezeigte ``UML-Diagramm`` und erstelle dazu den ``Model``-Folder sowie die Datenbank.

1) Erstelle die notwendigen ``Model``-Klassen (z.B. *Product*, *Category*) im `Models`-Ordner.
2) Konfiguriere den ``DbContext`` in der *Program.cs*.
3) Erstelle eine erste ``Migration`` (z.B. *InitialCreate*) mittels `dotnet ef migrations add` und führe `dotnet ef database update` aus, um die Tabellen in der Datenbank anzulegen.
4) Erstelle eine ``SeedData``-Klasse (z.B. *SeedData.cs*), um die Datenbank mit initialen Daten zu befüllen.
5) Führe eine ``Update``-Operation auf einen bestehenden Datensatz aus (z.B. ändere einen Preis) und speichere die Änderungen (`await _context.SaveChangesAsync()`).
6) Ändere ein ``Model`` (füge eine neue ``Eigenschaft`` hinzu) und erstelle eine neue ``Migration``, um die Datenbank zu aktualisieren.
7) Überprüfe (z.B. im ``SQL Server Object Explorer``), ob die Daten aus Schritt 4 nach der Migration aus Schritt 6 noch vorhanden sind.

---

### Theorie [10 / 40 Teilpunkte]
1) Was ist der Unterschied zwischen ``Shadow Properties`` und regulären ``Properties``, die in der ``Model``-Klasse definiert sind?
2) Welche wesentlichen Erleichterungen bietet ``EF Core`` beim Datenzugriff im Vergleich zu `ADO.NET`?
3) Wir haben 5 ``Migrations`` erstellt. Die letzte (`..._Migration5`) war ein Fehler. Welcher ``dotnet ef``-Befehl ist notwendig, um diese letzte ``Migration`` sicher zu entfernen?
4) Wie lautet der Befehl, um den Datenbankstand einer *vergangenen* ``Migration`` (z.B. `..._Migration3`) wiederherzustellen?
5) Was ist die Funktion der `Up()`- und `Down()`-Methoden in den von `dotnet ef migrations add` generierten ``.cs``-Dateien?

---

## Async Data Manipulation Language (DML) mit EF Core umsetzen [60 / 100 Punkte]
### Programmverständnis [20 / 60 Teilpunkte]
Finde und erkläre die (mindestens 5) konzeptionellen und syntaktischen Fehler im folgenden Code-Snippet.

```csharp
// TODO: Finde die Fehler

// Controller
public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;
    public ProductController(ApplicationDbContext context) { _context = context; }

    // Fehler 1
    public IActionResult Index(int categoryId)
    {
        // Fehler 2
        var products = _context.Products.Where(p => p.CategoryId == categoryId).ToList(); 
        
        // Fehler 3
        return View(products); 
    }

    // Fehler 4
    public async Task<IActionResult> Create(Product product)
    {
        _context.Products.Add(product);
        // Fehler 5
        return RedirectToAction(nameof(Index));
    }
}

// View (Index.cshtml)
// Fehler 6
@foreach (var product in Model) 
{
    <p>@product.Name</p>
}
```

---

### Programmieren [30 / 60 Teilpunkte]
Führe folgende Abfragen (Queries) im `FruehstueckController` (oder einem neuen ``Controller``) `async` aus.

1) Erstelle eine `async`-Methode, die alle Einträge (`select *`) der `Dishes`-Tabelle abruft (`await _context.Dishes.ToListAsync()`).
2) Erstelle eine `async`-Methode, die einen `where`-Filter anwendet (z.B. alle `Dishes` über 10€), das Ergebnis auf ein ``DTO`` projiziert (`select`) und die Liste `async` zurückgibt (`...ToListAsnyc()`).
3) Implementiere eine `async`-Abfrage, die einen `join` mit `Include()` (z.B. `Bills` mit `Visit`) durchführt.
4) Implementiere eine `async`-Abfrage, die einen `join` mit `Include()` und `ThenInclude()` (z.B. `Bills` -> `Visit` -> `Orders`) durchführt.

#### Erwarteter Output:
Screenshots der Abfrageergebnisse (z.B. im Browser oder Debugger) oder die vom EF-Core-Logging generierten ``SQL-Queries``.

---

### Theorie [10 / 60 Teilpunkte]
1) Müssen wir in ``EF Core`` rohe ``SQL-Queries`` schreiben? Was schreiben wir stattdessen (z.B. im `CustomerService`) und was ist der Vorteil?
2) Erkläre den Unterschied zwischen `Include()` und `ThenInclude()` anhand eines Beispiels (z.B. `Visit` -> `Orders` -> `Dishes`).
3) Was muss bei `async`-Methoden in Verbindung mit `DbSet<T>` (z.B. `_context.Bills`) beachtet werden? (Stichworte: `Task<T>`, `await`, `...Async()`).