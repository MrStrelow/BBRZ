# Übung: Das Frühstücksrestaurant mit EF Core

---

### Ordnerstruktur

```
/FruehstuecksrestaurantMore/
│
├── Controllers/              // (Falls es eine Web-API oder MVC-App ist)
│   └── RestaurantController.cs
│
├── Data/                     // Alles rund um die Datenbank
│   ├── Configurations/       // IEntityTypeConfiguration-Klassen
│   │   ├── DishConfiguration.cs
│   │   ├── CustomerConfiguration.cs
│   │   └── ...
│   ├── Migrations/           // (Wird von EF Core automatisch erstellt)
│   ├── RestaurantDbContext.cs  // Deine DbContext-Klasse
│   └── SeedData.cs           // Klasse zum Befüllen der DB mit Demodaten
│
├── DTOs/                     // Data Transfer Objects (falls benötigt)
│   └── AnalyticsDto.cs
│
├── Models/                   // Deine EF Core Entitäten (die du bereits hast)
│   ├── Customer.cs
│   ├── Dish.cs
│   ├── Ingredient.cs
│   ├── PreparationStep.cs
│   ├── Table.cs
│   └── Visit.cs
│
├── Services/                 // Klassen, die Geschäftslogik enthalten
│   └── AnalyticsService.cs
│   └── CustomerService.cs

│
├── appsettings.json
├── Program.cs
└── FruehstuecksrestaurantMore.csproj
```

---

### Übersicht der Tabellenbeziehungen

Basierend auf deinen Model-Klassen ergeben sich folgende Beziehungen, die Entity Framework Core in der Datenbank abbilden wird:

**Customer ↔ Visit (1:N)**
* Ein **Customer** kann viele **Visits** haben.
* Jeder **Visit** gehört zu genau einem **Customer**.
* **Technische Umsetzung:** Die `visits`-Liste in der `Customer`-Klasse und eine (wahrscheinlich als Shadow Property erstellte) `CustomerId`-Spalte in der `Visits`-Tabelle.

**Visit ↔ Table (N:1)**
* Jeder **Visit** findet an genau einem **Table** statt.
* Ein **Table** kann im Laufe der Zeit viele **Visits** haben.
* **Technische Umsetzung:** Die `table`-Eigenschaft in der `Visit`-Klasse erzeugt eine `TableId`-Fremdschlüsselspalte in der `Visits`-Tabelle.

**Visit ↔ Dish (M:N)**
* Ein **Visit** kann mehrere **Dishes** (bestellte Gerichte) umfassen.
* Ein **Dish** kann bei vielen verschiedenen **Visits** bestellt werden.
* **Technische Umsetzung:** EF Core wird automatisch eine **Zwischentabelle** (z.B. `DishVisit`) erstellen, die `DishId` und `VisitId` enthält, um diese Many-to-Many-Beziehung abzubilden.

**Dish ↔ PreparationStep (1:N)**
* Ein **Dish** hat viele **PreparationSteps** (Zubereitungsschritte).
* Jeder **PreparationStep** gehört zu genau einem **Dish**.
* **Technische Umsetzung:** Die `PreparationSteps`-Liste in `Dish` und die `MoreDish`-Navigationseigenschaft in `PreparationStep`, welche eine `MoreDishId`-Fremdschlüsselspalte (als Shadow Property) erzeugt.

**Dish ↔ Ingredient (M:N)**
* Ein **Dish** kann aus vielen **Ingredients** bestehen.
* Ein **Ingredient** kann in vielen verschiedenen **Dishes** verwendet werden.
* **Technische Umsetzung:** Genau wie bei `Visit` ↔ `Dish` wird EF Core hier eine **Zwischentabelle** (z.B. `DishIngredient`) erstellen, um die Beziehung abzubilden.


### Schritt 1: Projekt-Setup und Modelle

**Aufgabe:** Erstelle die grundlegenden Model-Klassen in einem `Models`-Ordner.

**Hinweise:**
* Installiere die notwendigen NuGet-Pakete: `Microsoft.EntityFrameworkCore.SqlServer` und `Microsoft.EntityFrameworkCore.Tools`.
* Erstelle die folgenden C#-Dateien. Achte auf die `ICollection`-Eigenschaften, die unsere Beziehungen definieren.

* Beispiele:
**`Models/Dish.cs`**
```csharp
namespace FruehstuecksrestaurantMore.Models;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    // 1:n-Beziehung -> Ein Gericht hat viele Zubereitungsschritte.
    public ICollection<PreparationStep> PreparationSteps { get; set; } = new List<PreparationStep>();

    // n:m-Beziehung -> Ein Gericht kann viele Zutaten haben.
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
```

**`Models/PreparationStep.cs`**
```csharp
namespace FruehstuecksrestaurantMore.Models;

public class PreparationStep
{
    public int Id { get; set; }
    public int StepNumber { get; set; }
    public string Instruction { get; set; }

    // Navigationseigenschaft zurück zum "Elternteil".
    // Der Fremdschlüssel `DishId` wird von EF Core als "Shadow Property" im Hintergrund verwaltet.
    public Dish MoreDish { get; set; }
}
```

**`Models/Ingredient.cs`**
```csharp
namespace FruehstuecksrestaurantMore.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }

    // n:m-Beziehung -> Eine Zutat kann in vielen Gerichten vorkommen.
    public ICollection<Dish> MoreDishes { get; set; } = new List<Dish>();
}
```

...

---

### Schritt 2: Konfiguration der Beziehungen mit `IEntityTypeConfiguration`

**Aufgabe:** Definiere die Regeln für deine Modelle mit der Fluent API. Dies ist der saubere Weg, um die Konfiguration von den Modellen zu trennen.

**Hinweise:**
* Erstelle einen neuen Ordner `Data/Configurations`.
* Lege für jede Entität eine eigene Konfigurationsklasse an.

**`Data/Configurations/DishConfiguration.cs`**
```csharp
using FruehstuecksrestaurantMore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksrestaurantMore.Data.Configurations;

public class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
        builder.Property(d => d.Price).HasColumnType("decimal(18,2)");

        // 1:N zu PreparationStep: Ein Gericht hat viele Schritte.
        builder.HasMany(d => d.PreparationSteps)
            .WithOne(ps => ps.MoreDish);

        // M:N zu Ingredient: Ein Gericht hat viele Zutaten und umgekehrt.
        // EF Core erstellt die Zwischentabelle automatisch.
        builder.HasMany(d => d.Ingredients)
            .WithMany(i => i.MoreDishes);
    }
}
```

**`Data/Configurations/PreparationStepConfiguration.cs`**
```csharp
using FruehstuecksrestaurantMore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksrestaurantMore.Data.Configurations;

public class PreparationStepConfiguration : IEntityTypeConfiguration<PreparationStep>
{
    public void Configure(EntityTypeBuilder<PreparationStep> builder)
    {
        builder.HasKey(ps => ps.Id);
        builder.Property(ps => ps.Instruction).IsRequired();

        // Hier definieren wir die Rückbeziehung. EF Core wird den Fremdschlüssel
        // als Shadow Property `MoreDishId` anlegen.
        builder.HasOne(ps => ps.MoreDish)
            .WithMany(d => d.PreparationSteps)
            .IsRequired();
    }
}
```

**`Data/Configurations/IngredientConfiguration.cs`**
```csharp
using FruehstuecksrestaurantMore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksrestaurantMore.Data.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Name).IsRequired().HasMaxLength(100);
    }
}
```
...
---

### Schritt 3: Der `DbContext`

**Aufgabe:** Erstelle die `DbContext`-Klasse, welche die Verbindung zur Datenbank darstellt und unsere Konfigurationen lädt.

**`Data/RestaurantDbContext.cs`**
```csharp
using FruehstuecksrestaurantMore.Models;
using Microsoft.EntityFrameworkCore;

namespace FruehstuecksrestaurantMore.Data;

public class RestaurantDbContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<PreparationStep> PreparationSteps { get; set; }
    ...
    ...

    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Diese Zeile scannt das Projekt nach allen IEntityTypeConfiguration-Klassen
        // und wendet sie automatisch an.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantDbContext).Assembly);
    }
}
```

---

### Schritt 4: Migrationen und die Shadow Property

**Aufgabe:** Erstelle die Datenbank aus deinem Code und überprüfe die `Shadow Property`.

**1. Migration erstellen:** Öffne die **Package Manager Console** (oder ein Terminal im Projektverzeichnis) und führe aus:
```powershell
Add-Migration InitialCreate
```

**2. Shadow Property überprüfen:** Öffne die neu erstellte Migrationsdatei im `Migrations`-Ordner. Suche nach der `CreateTable`-Methode für `PreparationSteps`. Du wirst sehen, dass EF Core den Fremdschlüssel `MoreDishId` automatisch hinzugefügt hat, obwohl er in deiner C#-Klasse nicht existiert!

**Ausschnitt aus der Migrationsdatei:**
```csharp
migrationBuilder.CreateTable(
    name: "PreparationSteps",
    columns: table => new
    {
        Id = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        StepNumber = table.Column<int>(type: "int", nullable: false),
        Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
        // HIER IST SIE! Die von EF Core erstellte Shadow Property als Fremdschlüssel.
        MoreDishId = table.Column<int>(type: "int", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_PreparationSteps", x => x.Id);
        table.ForeignKey(
            name: "FK_PreparationSteps_Dishes_MoreDishId",
            column: x => x.MoreDishId,
            principalTable: "Dishes",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    });
```

**3. Datenbank erstellen:** Führe den folgenden Befehl aus, um die Datenbank zu erstellen:
```powershell
Update-Database
```

--- 

### Schritt 3: Der Analytics Service

**Aufgabe:** Erstelle einen Service, der Geschäftsanalysen durchführt. Dieser Service soll direkt mit dem `DbContext` arbeiten.

**Anforderungen an die Analyse:**
1.  Finde den Tisch (`Table`), der den höchsten Gesamtumsatz generiert hat.
2.  Finde das Gericht (`Dish`), das am häufigsten bestellt wurde.

**Hinweise:**
* Erstelle eine DTO-Klasse `DTOs/AnalyticsDto.cs`, um das Ergebnis der Analyse sauber zu strukturieren.
* Erstelle die Service-Klasse `Services/AnalyticsService.cs`.
* Für die Umsatzanalyse musst du über die `Visits` gehen, die `dishes` jedes Besuchs miteinbeziehen (`Include`), deren Preise summieren und das Ergebnis nach Tischen gruppieren (`GroupBy`).
* Für die Analyse des beliebtesten Gerichts ist die `SelectMany`-Methode sehr nützlich, um eine flache Liste aller bestellten Gerichte zu erhalten.

**Code-Skelett für `DTOs/AnalyticsDto.cs`:**
```csharp
namespace FruehstuecksrestaurantMore.DTOs;

public class RestaurantAnalyticsDto
{
    public int TableWithHighestRevenueId { get; set; }
    public decimal HighestRevenue { get; set; }
    public string MostPopularDish { get; set; }
}
```

**Code-Skelett für `Services/AnalyticsService.cs`:**
```csharp
using FruehstuecksrestaurantMore.Data;
using FruehstuecksrestaurantMore.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FruehstuecksrestaurantMore.Services;

public class AnalyticsService
{
    private readonly RestaurantDbContext _context;

    public AnalyticsService(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<RestaurantAnalyticsDto> GetRestaurantAnalyticsAsync()
    {
        // --- HIER DEINE LINQ-ABFRAGE FÜR DEN TISCH MIT DEM HÖCHSTEN UMSATZ ---
        // Gruppiere die Besuche nach Tisch, summiere die Preise aller Gerichte
        // und finde den höchsten Wert.
        var tableRevenue = // ... deine Abfrage hier ...

        // --- HIER DEINE LINQ-ABFRAGE FÜR DAS BELIEBTESTE GERICHT ---
        // Nutze SelectMany, um alle bestellten Gerichte zu bekommen,
        // gruppiere sie nach Namen und zähle sie.
        var mostPopularDish = // ... deine Abfrage hier ...


        // Gib das Ergebnis im DTO zurück.
        return new RestaurantAnalyticsDto
        {
            // ... Zuweisungen ...
        };
    }
}
```


---

### Schritt 5: Die Kartesische Explosion demonstrieren

**Aufgabe:** Schaue in die ``CustomerService`` Klasse und lies den Code Zeile für Zeile durch. Versuche dann mit 

**Hinweise:**
* Zuerst brauchen wir Daten. Erstelle eine `SeedData`-Klasse (siehe vorheriges Beispiel) und fülle die Datenbank mit einem Gericht, das viele Zutaten und Schritte hat.
* Verwende `.ToQueryString()`, um das generierte SQL zu sehen.

**Beispiel in `CustomerServices.cs`:**
```csharp
// Angenommen, der DbContext ist bereits konfiguriert und Seeding ist erfolgt.

Console.WriteLine("\n--- PROBLEM: Abfrage mit Kartesischer Explosion ---");
var queryProblem = _context.Customers
    // 1:N Join (Kunde -> Besuche)
    .Include(c => c.visits)
        // M:N Join (Besuche -> Gerichte)
        .ThenInclude(v => v.dishes)
            // 1:N Join (Gerichte -> Zubereitungsschritte)
            .ThenInclude(d => d.PreparationSteps)
    // Ein weiterer, paralleler Join vom Gericht aus
    .Include(c => c.visits)
        .ThenInclude(v => v.dishes)
            // M:N Join (Gerichte -> Zutaten)
            .ThenInclude(d => d.Ingredients)
    .Where(c => c.Name == customerName);
```

