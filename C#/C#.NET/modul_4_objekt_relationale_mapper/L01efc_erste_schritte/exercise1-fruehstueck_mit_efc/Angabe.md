# Übung: Umstellung des "Morgenstund" Restaurants auf EF Core

**Ziel:** Das bestehende Projekt, das Daten in JSON-Dateien speichert, wird so umgebaut, dass es eine SQL-Server-Datenbank mit Entity Framework Core verwendet. Du wirst den gesamten Prozess von der Modellerstellung bis zur Ausführung der Anwendungslogik gegen die Datenbank durchlaufen.

---

### Schritt 1: Projekt-Setup und NuGet-Pakete

**Aufgabe:** Bereite dein Projekt für die Verwendung von Entity Framework Core vor.

**Hinweise:**
* Du benötigst zwei zentrale NuGet-Pakete für die SQL Server-Anbindung und die EF Core Tools.
* Verwende die **Package Manager Console** in Visual Studio.
* Die Befehle lauten `Install-Package Microsoft.EntityFrameworkCore.SqlServer` und `Install-Package Microsoft.EntityFrameworkCore.Tools`.

---

### Schritt 2: Das Datenmodell anpassen (Entities)

**Aufgabe:** Passe die bestehenden Entitäten (`Dish`, `Menu`, `StockItem`) so an, dass sie von EF Core korrekt in einer relationalen Datenbank abgebildet werden können.

**Hinweise:**
* Jede Tabelle benötigt einen Primärschlüssel. Füge eine `Id`-Eigenschaft hinzu, wo sie fehlt (z.B. in `StockItem`). Du kannst das `[Key]`-Attribut verwenden, um dies explizit zu machen.
* Eine `List<int> DishIds` ist für eine Datenbankbeziehung ungeeignet. Ersetze diese durch eine echte Navigationseigenschaft für eine n:m-Beziehung. Der passende Typ dafür ist `ICollection<Dish>`.

---

### Schritt 3: Der DbContext

**Aufgabe:** Erstelle eine zentrale `DbContext`-Klasse, welche die Verbindung zur Datenbank verwaltet und die Tabellen deines Modells repräsentiert.

**Hinweise:**
* Erstelle einen neuen Ordner `Data` und darin eine Klasse `RestaurantDbContext`.
* Diese Klasse muss von `DbContext` erben.
* Definiere für jede Entität eine `DbSet<T>`-Eigenschaft.
* Überschreibe die `OnConfiguring`-Methode, um die Datenbankverbindung zu konfigurieren. Verwende `optionsBuilder.UseSqlServer(...)` und gib deinen Connection String an.
* Überschreibe die `OnModelCreating`-Methode. Hier wirst du später die Stammdaten anlegen.

**Code-Snippet als Vorlage:**
```csharp
public class RestaurantDbContext : DbContext
{
    // Hier deine DbSet-Eigenschaften...

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Hier die UseSqlServer-Konfiguration...
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Hier kommt später das Seeding...
    }
}
```

---

### Schritt 4: Datenbank-Migrationen erstellen und anwenden

**Aufgabe:** Erstelle basierend auf deinem `DbContext` das Datenbankschema und wende es auf eine SQL-Server-Datenbank an.

**Hinweise:**
* Verwende die **Package Manager Console**.
* Stelle sicher, dass dein Projekt im "Default project"-Dropdown ausgewählt ist.
* Der Befehl zum Erstellen einer Migration lautet `Add-Migration <MigrationsName>`. Wähle einen passenden Namen wie `InitialCreate`.
* Der Befehl zum Anwenden der Migration lautet `Update-Database`.

---

### Schritt 5: Stammdaten einfügen (Seeding)

**Aufgabe:** Füge den initialen Lagerbestand (`StockItem`) als Stammdaten direkt in die Migration ein.

**Hinweise:**
* Gehe zurück in die `OnModelCreating`-Methode deines `DbContext`.
* Verwende die Methode `modelBuilder.Entity<StockItem>().HasData(...)`.
* Du musst für jeden Datensatz explizit einen Primärschlüssel (`Id`) angeben.

---

### Schritt 6: Repositories mit LINQ neu schreiben

**Aufgabe:** Ersetze die bestehende Logik in allen Repository-Klassen. Anstatt aus JSON-Dateien zu lesen, sollen sie nun LINQ-Abfragen gegen den `RestaurantDbContext` ausführen.

**Hinweise:**
* Jede Methode in den Repositories sollte eine eigene, kurzlebige Instanz des `DbContext` erstellen. Das `using`-Statement ist hierfür ideal: `using var context = new RestaurantDbContext();`.
* Verwende `async`-Methoden und die asynchronen EF Core-Pendants wie `ToListAsync()`, `FirstOrDefaultAsync()`, `SaveChangesAsync()`.
* Für reine Leseoperationen ist `.AsNoTracking()` eine wichtige Performance-Optimierung.
* Um verknüpfte Daten zu laden (z.B. die Gerichte eines Menüs), benötigst du die `.Include()`-Methode.

---

### Schritt 7: Program.cs umbauen

**Aufgabe:** Passe die `Program.cs` so an, dass beim ersten Start der Anwendung die dynamischen Daten (Gerichte und Menüs) in die Datenbank geschrieben werden. Bei weiteren Starts sollen keine doppelten Einträge erstellt werden.

**Hinweise:**
1.  Erstelle eine neue `async Task SeedDatabaseAsync()`-Methode in `Program.cs`.
2.  Innerhalb dieser Methode:
    * Erstelle eine `DbContext`-Instanz.
    * Stelle sicher, dass die Datenbank existiert und alle Migrationen angewendet sind. Der Befehl hierfür ist `context.Database.MigrateAsync()`.
    * Prüfe, ob bereits Daten vorhanden sind, bevor du neue anlegst. Eine LINQ-Methode wie `.AnyAsync()` ist hierfür perfekt.
    * Wenn keine Daten vorhanden sind:
        * Erstelle neue `Dish`- und `Menu`-Objekte.
        * Füge sie mit `context.Dishes.AddRange(...)` und `context.Menus.AddRange(...)` hinzu.
        * **Wichtig:** Um die n:m-Beziehung zu erstellen, weise die `Dish`-Objekte direkt der `Dishes`-Collection des `Menu`-Objekts zu.
        * Speichere alles mit `await context.SaveChangesAsync()`.
3.  Rufe deine neue `SeedDatabaseAsync()`-Methode am Anfang der `Main`-Methode auf.

**Code-Snippet für die Seeding-Logik:**
```csharp
async Task SeedDatabaseAsync()
{
    using var context = new RestaurantDbContext();
    
    // 1. Sicherstellen, dass die DB existiert
    await context.Database.MigrateAsync(); 

    // 2. Prüfen, ob schon Daten da sind
    if (await context.Dishes.AnyAsync())
    {
        return; // Überspringen
    }

    // 3. Neue Objekte erstellen
    var dish1 = new Dish { /* ... */ };
    var dish2 = new Dish { /* ... */ };
    
    // 4. Objekte hinzufügen
    context.Dishes.AddRange(dish1, dish2);
    await context.SaveChangesAsync(); // Wichtig, damit IDs generiert werden

    // 5. Menüs mit den Gerichten verknüpfen
    var menu1 = new Menu { Name = "Frühstücksklassiker", Dishes = { dish1, dish2 } };
    context.Menus.Add(menu1);
    await context.SaveChangesAsync();
}
```