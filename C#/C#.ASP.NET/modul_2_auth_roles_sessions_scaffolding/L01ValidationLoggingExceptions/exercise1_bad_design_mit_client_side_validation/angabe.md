# Aufgabenstellung: Erweiterung der Frühstücksbestellung (Delivery & TakeAway)

Ziel ist es, das bestehende ASP.NET Core MVC Projekt so zu erweitern, dass neben dem Restaurantbesuch (TakeIn) auch Lieferungen (Delivery) und Abholungen (TakeAway) unterstützt werden.

---

## Schritt 1: Anpassung der Datenmodelle (Models)

Zuerst müssen die Grundlagen für die neuen Bestellarten in der Datenbank geschaffen werden.

### 1.1 Enum für Bestellart erstellen
Erstelle im Ordner `Models/Enums` ein neues Enum `OrderType`, um die Unterscheidung zu ermöglichen.

```csharp
using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.Models.Enums;

public enum OrderType
{
    [Display(Name = "Im Restaurant")]
    TakeIn,
    [Display(Name = "Abholung (Take Away)")]
    TakeAway,
    [Display(Name = "Lieferung")]
    Delivery
}
```

### 1.2 Neue Entitäten anlegen
Erstelle zwei neue Klassen im `Models` Ordner.

**Delivery.cs**
```csharp
using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.Models;

public class Delivery
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    
    // Navigation
    public Order? Order { get; set; }
    public Customer? Customer { get; set; }
    public Bill? Bill { get; set; }

    // Lieferdetails
    public DateTime? ExpectedDeliveryDate { get; set; }
    public DateTime? ActualDeliveryDate { get; set; }

    [Required]
    public string DeliveryAddress { get; set; }
    public string? DeliveryEmail { get; set; }
    public string? DeliveryPhone { get; set; }
    public string? DeliveryComment { get; set; }
    
    // Für das Beweisfoto
    public string? DeliveryImagePath { get; set; }
    public bool IsCanceled { get; set; }
}
```

**TakeAway.cs**
```csharp
namespace FruehstuecksBestellungMVC.Models;

public class TakeAway
{
    public int Id { get; set; }
    public DateTime PickupTime { get; set; } = DateTime.Now;
    
    // Navigation
    public Customer? Customer { get; set; }
    public Bill? Bill { get; set; }
    public Order? Orders { get; set; } // Property Name ist 'Orders' (1:1 Beziehung)
}
```

### 1.3 Bestehendes Model `Bill` anpassen
Eine Rechnung gehört nun nicht mehr zwingend zu einem `Visit`. Öffne `Models/Bill.cs`.

```csharp
public class Bill
{
    // ... bestehende Felder (Id, TotalAmount, BillDate) ...

    // WICHTIG: VisitId muss nullable werden!
    public int? VisitId { get; set; }
    public Visit? Visit { get; set; }

    // Neue Referenzen hinzufügen
    public int? DeliveryId { get; set; }
    public Delivery? Delivery { get; set; }

    public int? TakeAwayId { get; set; }
    public TakeAway? TakeAway { get; set; }
}
```

### 1.4 DbContext aktualisieren
Registriere die neuen Tabellen in `Data/ApplicationDbContext.cs`.

```csharp
public DbSet<Delivery> Deliveries { get; set; }
public DbSet<TakeAway> TakeAways { get; set; }
```

---

## Schritt 2: ViewModels und Validierung

Wir benötigen ViewModels, die je nach Bestelltyp unterschiedliche Pflichtfelder validieren.

### 2.1 OrderViewModel anpassen
Öffne `ViewModels/OrderViewModel.cs`.
1.  Füge die Property `OrderType Type` hinzu.
2.  Füge Properties für Lieferdaten hinzu (`DeliveryAddress`, `DeliveryEmail`, etc.).
3.  Implementiere `IValidatableObject`, um bedingte Validierung durchzuführen.

```csharp
public class OrderViewModel : IValidatableObject
{
    public OrderType Type { get; set; } = OrderType.TakeIn;
    
    // ... CustomerId ...
    
    public int? TableId { get; set; } // Darf jetzt null sein!

    // Lieferfelder
    [RegularExpression(@"^[a-zA-ZäöüÄÖÜß\s\.\-]+\s\d+[a-zA-Z]?$", ErrorMessage = "Gültige Adresse mit Hausnummer erforderlich.")]
    public string? DeliveryAddress { get; set; }
    
    [EmailAddress]
    public string? DeliveryEmail { get; set; }
    
    [Phone]
    public string? DeliveryPhone { get; set; }
    
    public DateTime? ExpectedDeliveryDate { get; set; }

    // ... MenuIds, DishIds ...

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        // 1. Wenn Type == TakeIn -> TableId ist Pflicht
        if (Type == OrderType.TakeIn && !TableId.HasValue)
        {
             yield return new ValidationResult("Tisch ist Pflicht.", new[] { nameof(TableId) });
        }

        // 2. Wenn Type == Delivery -> Address, Email, Phone, Date sind Pflicht
        if (Type == OrderType.Delivery)
        {
            if (string.IsNullOrEmpty(DeliveryAddress)) yield return new ValidationResult("Adresse fehlt", new[] { nameof(DeliveryAddress) });
            // ... checks für Email, Phone ...
            
            // 3. Lieferdatum darf nicht in der Vergangenheit liegen
            if (ExpectedDeliveryDate.HasValue && ExpectedDeliveryDate.Value < DateTime.Now.AddMinutes(-5))
            {
                yield return new ValidationResult("Datum darf nicht in der Vergangenheit liegen.", new[] { nameof(ExpectedDeliveryDate) });
            }
        }
    }
}
```

### 2.2 ViewModel für Management erstellen
Erstelle `ViewModels/DeliveryManagementViewModel.cs` für die "Lieferung verwalten" Seite.
* Enthält: `DeliveryId`, `OrderId`, `ActualDeliveryDate`, `DeliveryComment`.
* Enthält `IFormFile DeliveryImage` für den Upload.
* Enthält `IsCanceled` (bool) und `ExistingImagePath` (string).
* **Validierung:** `ActualDeliveryDate` darf nicht in der Zukunft liegen.

---

## Schritt 3: Logik im Service Layer

### 3.1 DTO anpassen
Erweitere `DTOs/OrderDto.cs` um die gleichen Felder wie das ViewModel (Type, Address, etc.), damit der Controller die Daten an den Service übergeben kann.

### 3.2 CustomerService erweitern
Öffne `Services/CustomerService.cs`. Die Methode `CreateOrderAsync` muss nun unterscheiden:

```csharp
public async Task CreateOrderAsync(OrderDto orderDto)
{
    // 1. Kunde laden, Menüs/Dishes laden, Preise berechnen
    // 2. Order und Bill Objekte erstellen (aber noch nicht speichern)

    if (orderDto.Type == OrderType.TakeIn)
    {
        // Visit erstellen, Table laden
        // Visit.Bill = bill; Visit.Orders.Add(order);
        // context.Visits.Add(visit);
    }
    else if (orderDto.Type == OrderType.Delivery)
    {
        // Delivery erstellen mit Adresse aus DTO
        // Delivery.Bill = bill; Delivery.Order = order;
        // context.Deliveries.Add(delivery);
    }
    else if (orderDto.Type == OrderType.TakeAway)
    {
        // TakeAway erstellen
        // TakeAway.Bill = bill; TakeAway.Orders = order;
        // context.TakeAways.Add(takeaway);
    }
    
    await _context.SaveChangesAsync();
}
```

Füge zudem `UpdateDeliveryAsync(DeliveryManagementViewModel vm)` hinzu:
* Lädt die Delivery inkl. Order.
* **Storno:** Wenn `vm.IsCanceled` true ist und `ActualDeliveryDate` noch null ist -> setze `delivery.IsCanceled = true`.
* **Update:** Setze `ActualDeliveryDate` und `Comment`.
* **Bild:** Wenn `vm.DeliveryImage` != null -> Speichere Datei in `wwwroot/images/proofs` und setze Pfad in DB.

---

## Schritt 4: Controller anpassen

Öffne `Controllers/FruehstueckController.cs`.

### 4.1 Daten laden (WICHTIG!)
Die Methode `PopulateViewModelAsync` muss dringend angepasst werden, sonst bleiben die Listen in der Ansicht leer. Sie müssen **alle** Pfade laden (Eager Loading).

```csharp
private async Task PopulateViewModelAsync(FruehstueckViewModel viewModel)
{
    // ... Menus, Dishes, Customers laden ...

    viewModel.Bills = await _context.Bills
        // 1. Visit Includes
        .Include(b => b.Visit).ThenInclude(v => v.Table)
        .Include(b => b.Visit).ThenInclude(v => v.Orders).ThenInclude(o => o.Menus)
        .Include(b => b.Visit).ThenInclude(v => v.Orders).ThenInclude(o => o.Dishes)
        
        // 2. NEU: Delivery Includes
        .Include(b => b.Delivery).ThenInclude(d => d.Customer)
        .Include(b => b.Delivery).ThenInclude(d => d.Order).ThenInclude(o => o.Menus)
        .Include(b => b.Delivery).ThenInclude(d => d.Order).ThenInclude(o => o.Dishes)

        // 3. NEU: TakeAway Includes
        .Include(b => b.TakeAway).ThenInclude(t => t.Customer)
        .Include(b => b.TakeAway).ThenInclude(t => t.Orders).ThenInclude(o => o.Menus)
        .Include(b => b.TakeAway).ThenInclude(t => t.Orders).ThenInclude(o => o.Dishes)
        
        .OrderByDescending(b => b.BillDate)
        .ToListAsync();
}
```

### 4.2 Actions
* `Bestellen (POST)`: Muss `[Bind(Prefix="Order")]` verwenden. Bei Fehlern (`!ModelState.IsValid`) View neu laden.
* `ManageDelivery (GET)`: Lädt Delivery anhand ID, erstellt ViewModel und gibt View zurück.
* `UpdateDelivery (POST)`: Ruft Service auf.

---

## Schritt 5: Views anpassen

### 5.1 Index.cshtml
* **Radio Buttons:** Füge Radio Buttons für `Order.Type` hinzu.
* **JavaScript:** Schreibe eine Funktion `toggleFields()`, die je nach Radio-Button die `div`s für Tisch-Auswahl (`#sectionTakeIn`) oder Adress-Eingabe (`#sectionDelivery`) ein-/ausblendet.
* **Rechnungsliste:** Passe das Accordion an.
    * Prüfe: `if (bill.Delivery != null)` -> Zeige Lieferinfos & Button "Verwalten".
    * Prüfe: `else if (bill.TakeAway != null)` -> Zeige Abholinfos.
    * Sonst: Zeige Tischinfos.
    * **Bestellinhalt:** Um die Gerichte anzuzeigen, erstellen Sie eine Variable `orders`, die sich je nach Typ die richtige Order-Liste holt, um Code-Duplizierung zu vermeiden.

### 5.2 ManageDelivery.cshtml
Erstelle diese View neu.
* Formular muss `enctype="multipart/form-data"` haben.
* Anzeige der statischen Daten (Kunde, Bestelldatum).
* Input für `ActualDeliveryDate` (max="heute").
* Input `type="file"` für das Bild.
* **Stornieren:** Ein Button (rot), der via JavaScript `confirm()` aufruft und ein Hidden Field `IsCanceled` auf `true` setzt. Dieser Button darf nur sichtbar/aktiv sein, wenn `Model.ActualDeliveryDate` noch null ist.