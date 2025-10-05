using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Initialisiert unserer Dictionary mit Testdaten beim Start.
RestaurantDbContext.Initialize();

// http-methode: GET mit Ressource /Restaurant/Index
// Generiert und liefert die Haupt-HTML-Seite mit dem Formular und der Rechnungsliste.
app.MapGet(
    "/Restaurant/Index", 
    () =>
    {
        // Wir übergeben der View, Models.
        var view = View(
            title: "Restaurant - das ist eine Zusatzinfo welche nicht in ein Modle passt...",
            RestaurantDbContext.Customers,
            RestaurantDbContext.Menus,
            RestaurantDbContext.Tables,
            RestaurantDbContext.Dishes,
            RestaurantDbContext.Bills
        );

        return Results.Content(view, "text/html", Encoding.UTF8);
    }
);


// POST /Restaurant/Index
// Verarbeitet die Formulardaten und erstellt eine neue Bestellung.
app.MapPost(
    "/Restaurant/Index",
    async (HttpContext context) =>
    {
        // Wir schauen uns den request body des http-post an.
        var form = await context.Request.ReadFormAsync();

        // Formulardaten auslesen
        int.TryParse(form["customerId"], out var customerId);
        int.TryParse(form["tableId"], out var tableId);
        var selectedMenuIds = form["selectedMenuIds"].Select(int.Parse).ToList();
        var selectedDishIds = form["selectedDishIds"].Select(int.Parse).ToList();
        
        // Daten aus dem dbContext holen
        var customer = RestaurantDbContext.Customers.FirstOrDefault(c => c.Id == customerId);
        var table = RestaurantDbContext.Tables.FirstOrDefault(t => t.Id == tableId);
        var menus = RestaurantDbContext.Menus.Where(m => selectedMenuIds.Contains(m.Id)).ToList();
        var dishes = RestaurantDbContext.Dishes.Where(d => selectedDishIds.Contains(d.Id)).ToList();

        if(customer == null || table == null || (!menus.Any() && !dishes.Any()))
            return Results.BadRequest("Kunde, Tisch oder Auswahl ungültig.");
        
        // Neue Entitäten erstellen
        var visit = new Visit 
        { 
            Id = RestaurantDbContext.GetNextId("Visits"), 
            EntryTime = DateTime.UtcNow, 
            Table = table,
            TableId = table.Id,
            Customers = { customer } 
        };
        
        var order = new Order 
        { 
            Id = RestaurantDbContext.GetNextId("Orders"), 
            OrderTime = DateTime.UtcNow, 
            Visit = visit,
            VisitId = visit.Id,
            Menus = menus, 
            Dishes = dishes 
        };
        visit.Orders.Add(order);
        
        decimal totalAmount = menus.Sum(m => m.Price) + dishes.Sum(d => d.Price);
        
        var bill = new Bill 
        { 
            Id = RestaurantDbContext.GetNextId("Bills"), 
            TotalAmount = totalAmount, 
            BillDate = DateTime.UtcNow, 
            Visit = visit,
            VisitId = visit.Id
        };

        visit.Bill = bill;

        // Neue Entitäten in der In-Memory-dbContext "speichern"
        RestaurantDbContext.Visits.Add(visit);
        RestaurantDbContext.Orders.Add(order);
        RestaurantDbContext.Bills.Add(bill);

        return Results.Redirect("/Restaurant/Index");
    }
).DisableAntiforgery();

// Baue das dynamische html-file, wir nennen es View.
// Wir werden es aber nie wieder so machen. Es ist nur einfacher die Idee zu kommunizieren.
// Diese Arbeit wird in Zukunft von Frameworks wie ASP.NETs MVC übernommen.
// Es wird absichtlich hier die Listen übergeben und nicht direkt der statische RestaurantDbContext aufgefuren.
// Wir werden es in MVC ASP.NET nämlich auch so machen.
// Hier kommen die Models rein die wir verwenden (und später die ViewModels).
string View(
    string title,
    List<Customer> customers,
    List<Menu> menus,
    List<Table> tables,
    List<Dish> dishes,
    List<Bill> bills
)
{
    var sb = new StringBuilder();
    var deCulture = new CultureInfo("de-DE");

    // HTML-Header
    sb.AppendLine("<!DOCTYPE html>");
    sb.AppendLine("<html lang=\"de\">");
    sb.AppendLine("<head>");
    sb.AppendLine("    <meta charset=\"utf-8\">");
    sb.AppendLine("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
    sb.AppendLine($"    <title>{title}</title>");
    sb.AppendLine("    <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css\" rel=\"stylesheet\">");
    sb.AppendLine("</head>");
    sb.AppendLine("<body>");
    sb.AppendLine("<div class=\"container mt-5\">");
    sb.AppendLine($"    <h1 class=\"mb-4\">{title}</h1>");

    // Bestellformular-Sektion
    sb.AppendLine("    <div class=\"form-section mb-5\">");
    sb.AppendLine("        <h2 class=\"mb-3\">Neue Bestellung aufgeben</h2>");
    sb.AppendLine("        <form action=\"/Restaurant/Index\" method=\"post\">");

    // -- Dropdowns für Kunden und Tische --
    sb.AppendLine("            <div class=\"row\">");
    sb.AppendLine("                <div class=\"col-md-6 mb-3\">");
    sb.AppendLine("                    <label for=\"customerId\" class=\"form-label\">Kunde</label>");
    sb.AppendLine("                    <select name=\"customerId\" class=\"form-select\">");
    foreach (var customer in customers)
    {
        sb.AppendLine($"                        <option value=\"{customer.Id}\">{customer.Name}</option>");
    }
    sb.AppendLine("                    </select>");
    sb.AppendLine("                </div>");
    sb.AppendLine("                <div class=\"col-md-6 mb-3\">");
    sb.AppendLine("                    <label for=\"tableId\" class=\"form-label\">Tisch Nr.</label>");
    sb.AppendLine("                    <select name=\"tableId\" class=\"form-select\">");
    foreach (var table in tables)
    {
        sb.AppendLine($"                        <option value=\"{table.Id}\">{table.TableNumber}</option>");
    }
    sb.AppendLine("                    </select>");
    sb.AppendLine("                </div>");
    sb.AppendLine("            </div>");

    // -- Checkbox-Listen für Menüs und Gerichte --
    sb.AppendLine("            <div class=\"row\">");
    sb.AppendLine("                <div class=\"col-md-6 mb-3\">");
    sb.AppendLine("                    <label class=\"form-label\">Menüs auswählen</label>");
    sb.AppendLine("                    <div class=\"border rounded p-3 bg-light\" style=\"max-height: 200px; overflow-y: auto;\">");
    foreach (var menu in menus)
    {
        sb.AppendLine("                        <div class=\"form-check\">");
        sb.AppendLine($"                            <input class=\"form-check-input\" type=\"checkbox\" name=\"selectedMenuIds\" value=\"{menu.Id}\" id=\"menu-{menu.Id}\">");
        sb.AppendLine($"                            <label class=\"form-check-label\" for=\"menu-{menu.Id}\">{menu.Name} ({menu.Price.ToString("C", deCulture)})</label>");
        sb.AppendLine("                        </div>");
    }
    sb.AppendLine("                    </div>");
    sb.AppendLine("                </div>");
    sb.AppendLine("                <div class=\"col-md-6 mb-3\">");
    sb.AppendLine("                    <label class=\"form-label\">Einzelne Gerichte (A la carte)</label>");
    sb.AppendLine("                    <div class=\"border rounded p-3 bg-light\" style=\"max-height: 200px; overflow-y: auto;\">");
    foreach (var dish in dishes)
    {
        sb.AppendLine("                        <div class=\"form-check\">");
        sb.AppendLine($"                            <input class=\"form-check-input\" type=\"checkbox\" name=\"selectedDishIds\" value=\"{dish.Id}\" id=\"dish-{dish.Id}\">");
        sb.AppendLine($"                            <label class=\"form-check-label\" for=\"dish-{dish.Id}\">{dish.Name} ({dish.Price.ToString("C", deCulture)})</label>");
        sb.AppendLine("                        </div>");
    }
    sb.AppendLine("                    </div>");
    sb.AppendLine("                </div>");
    sb.AppendLine("            </div>");

    sb.AppendLine("            <button type=\"submit\" class=\"btn btn-primary mt-3\">Bestellung aufgeben</button>");
    sb.AppendLine("        </form>");
    sb.AppendLine("    </div>");

    // Rechnungsübersicht-Sektion
    sb.AppendLine("    <div class=\"list-section\">");
    sb.AppendLine("        <h2 class=\"mb-3\">Bisherige Rechnungen</h2>");

    // -- Akkordeon für Rechnungen --
    if (!bills.Any())
    {
        sb.AppendLine("        <div class=\"alert alert-info\" role=\"alert\">Noch keine Rechnungen vorhanden.</div>");
    }
    else
    {
        sb.AppendLine("        <div class=\"accordion\" id=\"billsAccordion\">");
        foreach (var bill in bills.OrderByDescending(b => b.BillDate))
        {
            var customerName = bill.Visit?.Customers?.FirstOrDefault()?.Name ?? "N/A";
            var tableNumber = bill.Visit?.Table?.TableNumber ?? "N/A";

            sb.AppendLine("            <div class=\"accordion-item\">");
            sb.AppendLine($"                <h2 class=\"accordion-header\" id=\"heading-{bill.Id}\">");
            sb.AppendLine($"                    <button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapse-{bill.Id}\">");
            sb.AppendLine($"                        <strong>Rechnung #{bill.Id}</strong> &nbsp;- Tisch {tableNumber} - {customerName} - Betrag: {bill.TotalAmount.ToString("C", deCulture)}");
            sb.AppendLine("                    </button>");
            sb.AppendLine("                </h2>");
            sb.AppendLine($"                <div id=\"collapse-{bill.Id}\" class=\"accordion-collapse collapse\" data-bs-parent=\"#billsAccordion\">");
            sb.AppendLine("                    <div class=\"accordion-body\">");
            sb.AppendLine($"                        <p><strong>Datum:</strong> {bill.BillDate.ToString("g", deCulture)}</p>");
            sb.AppendLine("                        <h6>Bestellung:</h6>");
            sb.AppendLine("                        <ul>");
            if (bill.Visit != null)
            {
                foreach (var order in bill.Visit.Orders)
                {
                    foreach (var menu in order.Menus) { sb.AppendLine($"                            <li>{menu.Name} (Menü)</li>"); }
                    foreach (var dish in order.Dishes) { sb.AppendLine($"                            <li>{dish.Name} (Gericht)</li>"); }
                }
            }
            sb.AppendLine("                        </ul>");
            sb.AppendLine("                    </div>");
            sb.AppendLine("                </div>");
            sb.AppendLine("            </div>");
        }
        sb.AppendLine("        </div>");
    }
    sb.AppendLine("    </div>");

    // HTML-Footer
    sb.AppendLine("</div>");
    sb.AppendLine("<script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js\"></script>");
    sb.AppendLine("</body>");
    sb.AppendLine("</html>");

    return sb.ToString();
}


app.Run();

// ############################### DbContext (ist die Schnittstelle zur "Datenbakn") ###############################
// In Programmieren nannten wir es ein Unit of Work Pattern von vielen Repositories.
// Wir hatten je Entitiy (Customer, Ingredient, ...) ein Repository. Hier ist es nun eine Zusammenfassung von Repositories.
// Hier wird kein echtes Unit of Work Pattern implementiert - Aufrufe mehrerer Repositoreis mit Transaktionen versehen -> commit und rollback ist möglich.
// Es ist einfach eine Klasse mit Listen.
// In Zukunft verwenden wir hier EF-Core -> was aus Programmieren zumindest vom Namen her bekannt sein sollte.
public static class RestaurantDbContext
{
    public static List<Customer> Customers { get; private set; } = new();
    public static List<Ingredient> Ingredients { get; private set; } = new();
    public static List<PreparationStep> PreparationSteps { get; private set; } = new();
    public static List<Table> Tables { get; private set; } = new();
    public static List<Dish> Dishes { get; private set; } = new();
    public static List<Menu> Menus { get; private set; } = new();
    public static List<Visit> Visits { get; private set; } = new();
    public static List<Order> Orders { get; private set; } = new();
    public static List<Bill> Bills { get; private set; } = new();

    // kurze Schreibweise für einen Aufruf der Methode Seed in der Methode Initialze.
    // Könnte auch direkt der Code con Seed hier in Initialize stehen.
    // Es passiert oft mehr als nur Seed in dem Initialize. Deshalb hier die Unterscheidung.
    // Ist aber ein unnötiges Detail.
    public static void Initialize() => Seed();

    // Hilfsmethode zur Vergabe fortlaufender IDs
    // Verwendet noch nicht bekannte Syntax und Generizität.
    // Ist nicht Testrelevant, jedoch für besonders interessierte hier der Code.
    public static int GetNextId(string nameOfEntity)
    {
        return nameOfEntity switch
        {
            "Customers" => CalculateNextId(Customers),
            "Bills" => CalculateNextId(Bills),
            "Dishes" => CalculateNextId(Dishes),
            "Ingredients" => CalculateNextId(Ingredients),
            "Menus" => CalculateNextId(Menus),
            "Orders" => CalculateNextId(Orders),
            "PreparationSteps" => CalculateNextId(PreparationSteps),
            "Tables" => CalculateNextId(Tables),
            "Visits" => CalculateNextId(Visits),

            // default case:
            _ => throw new ArgumentException($"Der Schlüssel '{nameOfEntity}' ist keine valide Entität.", nameof(nameOfEntity))
        };
    }

    private static int CalculateNextId<T>(IEnumerable<T> collection) where T : IEntity
    {
        var maxId = collection.Select(item => item.Id).DefaultIfEmpty(0).Max();
        return maxId + 1;
    }

    // Befüllt die Datenbank mit den Daten aus der SeedData-Vorlage
    private static void Seed()
    {
        // -- Customers --
        Customers.AddRange(new Customer[]
        {
            new Customer { Id = 1, Name = "Anna Weber" },
            new Customer { Id = 2, Name = "Markus Huber" }
        });

        // -- Ingredients --
        var ingredientList = new List<Ingredient>
        {
            new Ingredient { Id = 1, Name = "Salz" }, new Ingredient { Id = 2, Name = "Pfeffer" }, new Ingredient { Id = 3, Name = "Olivenöl" },
            new Ingredient { Id = 4, Name = "Butter" }, new Ingredient { Id = 5, Name = "Ei" }, new Ingredient { Id = 6, Name = "Milch" },
            new Ingredient { Id = 7, Name = "Mehl" }, new Ingredient { Id = 8, Name = "Zucker" }, new Ingredient { Id = 9, Name = "Brot" },
            new Ingredient { Id = 10, Name = "Semmel" }, new Ingredient { Id = 11, Name = "Toast" }, new Ingredient { Id = 12, Name = "Croissant" },
            new Ingredient { Id = 13, Name = "Bagel" }, new Ingredient { Id = 14, Name = "Schinken" }, new Ingredient { Id = 15, Name = "Speck (Bacon)" },
            new Ingredient { Id = 16, Name = "Wurst (Sausage)" }, new Ingredient { Id = 17, Name = "Käse (Gouda)" }, new Ingredient { Id = 18, Name = "Frischkäse" },
            new Ingredient { Id = 19, Name = "Mozzarella" }, new Ingredient { Id = 20, Name = "Feta" }, new Ingredient { Id = 21, Name = "Räucherlachs" },
            new Ingredient { Id = 22, Name = "Tomate" }, new Ingredient { Id = 23, Name = "Gurke" }, new Ingredient { Id = 24, Name = "Zwiebel" },
            new Ingredient { Id = 25, Name = "Paprika" }, new Ingredient { Id = 26, Name = "Avocado" }, new Ingredient { Id = 27, Name = "Spinat" },
            new Ingredient { Id = 28, Name = "Champignons" }, new Ingredient { Id = 29, Name = "Kartoffel" }, new Ingredient { Id = 30, Name = "Blattsalat" },
            new Ingredient { Id = 31, Name = "Rucola" }, new Ingredient { Id = 32, Name = "Orange" }, new Ingredient { Id = 33, Name = "Zitrone" },
            new Ingredient { Id = 34, Name = "ErdbContexteere" }, new Ingredient { Id = 35, Name = "Heidelbeere" }, new Ingredient { Id = 36, Name = "Banane" },
            new Ingredient { Id = 37, Name = "Apfel" }, new Ingredient { Id = 38, Name = "Naturjoghurt" }, new Ingredient { Id = 39, Name = "Honig" },
            new Ingredient { Id = 40, Name = "Kaffeebohnen" }
        };

        Ingredients.AddRange(ingredientList);

        // -- PreparationSteps --
        var stepList = new List<PreparationStep>
        {
            new PreparationStep { Id = 1, Description = "Gemüse waschen und trocknen", StepOrder = 1 }, new PreparationStep { Id = 2, Description = "In Scheiben schneiden", StepOrder = 2 },
            new PreparationStep { Id = 3, Description = "In kleine Würfel schneiden", StepOrder = 2 }, new PreparationStep { Id = 4, Description = "Eier in einer Schüssel verquirlen", StepOrder = 1 },
            new PreparationStep { Id = 5, Description = "Speck in der Pfanne knusprig anbraten", StepOrder = 1 }, new PreparationStep { Id = 6, Description = "Brot goldbContextraun toasten", StepOrder = 1 },
            new PreparationStep { Id = 7, Description = "Kaffeebohnen frisch mahlen", StepOrder = 1 }, new PreparationStep { Id = 8, Description = "Kaffee aufbrühen", StepOrder = 2 },
            new PreparationStep { Id = 9, Description = "Früchte auspressen", StepOrder = 1 }, new PreparationStep { Id = 10, Description = "Butter in einer Pfanne schmelzen", StepOrder = 1 },
            new PreparationStep { Id = 11, Description = "Auf einem Teller anrichten", StepOrder = 10 }, new PreparationStep { Id = 12, Description = "Mit frischen Kräutern garnieren", StepOrder = 11 },
            new PreparationStep { Id = 13, Description = "Mit Salz und Pfeffer würzen", StepOrder = 9 }, new PreparationStep { Id = 14, Description = "Aufstrich gleichmäßig verteilen", StepOrder = 3 },
            new PreparationStep { Id = 15, Description = "Zutaten schichten", StepOrder = 4 }, new PreparationStep { Id = 16, Description = "Im Ofen bei 180°C backen", StepOrder = 5 },
            new PreparationStep { Id = 17, Description = "Ei für 3 Minuten pochieren", StepOrder = 3 }, new PreparationStep { Id = 18, Description = "Gemüse in der Pfanne sautieren", StepOrder = 3 },
            new PreparationStep { Id = 19, Description = "Früchte in mundgerechte Stücke schneiden", StepOrder = 1 }, new PreparationStep { Id = 20, Description = "Alle Zutaten in einer Schüssel vermengen", StepOrder = 4 }
        };

        PreparationSteps.AddRange(stepList);

        // -- Tables --
        Tables.AddRange(new Table[]
        {
            new Table { Id = 1, TableNumber = "S1", Seats = 8 }, new Table { Id = 2, TableNumber = "S2", Seats = 4 },
            new Table { Id = 3, TableNumber = "G1", Seats = 4 }, new Table { Id = 4, TableNumber = "G2", Seats = 4 },
            new Table { Id = 5, TableNumber = "B1", Seats = 6 }
        });

        // -- Dishes --
        var wienerFruehstueck = new Dish { Id = 1, Name = "Wiener Frühstück", Price = 8.50m, Ingredients = { ingredientList[9], ingredientList[3], ingredientList[13], ingredientList[16] }, PreparationSteps = { stepList[10] } };
        var englishBreakfast = new Dish { Id = 2, Name = "English Breakfast", Price = 14.00m, Ingredients = { ingredientList[4], ingredientList[14], ingredientList[15], ingredientList[10], ingredientList[27] }, PreparationSteps = { stepList[4], stepList[5], stepList[17], stepList[10] } };
        var avocadoToast = new Dish { Id = 3, Name = "Avocado Toast mit pochiertem Ei", Price = 11.50m, Ingredients = { ingredientList[10], ingredientList[25], ingredientList[4], ingredientList[32], ingredientList[0], ingredientList[1] }, PreparationSteps = { stepList[5], stepList[16], stepList[12], stepList[10], stepList[11] } };
        var lachsBagel = new Dish { Id = 4, Name = "Lachs-Bagel", Price = 12.00m, Ingredients = { ingredientList[12], ingredientList[20], ingredientList[17], ingredientList[23] }, PreparationSteps = { stepList[5], stepList[1], stepList[13], stepList[14], stepList[10] } };
        var joghurtBowl = new Dish { Id = 5, Name = "Joghurt Bowl mit Früchten", Price = 9.00m, Ingredients = { ingredientList[37], ingredientList[38], ingredientList[33], ingredientList[34], ingredientList[35] }, PreparationSteps = { stepList[18], stepList[19], stepList[10] } };
        var bauernomelett = new Dish { Id = 6, Name = "Bauernomelett", Price = 10.50m, Ingredients = { ingredientList[4], ingredientList[28], ingredientList[23], ingredientList[14], ingredientList[0], ingredientList[1] }, PreparationSteps = { stepList[2], stepList[4], stepList[3], stepList[17], stepList[12], stepList[10] } };
        var croissantDeluxe = new Dish { Id = 7, Name = "Croissant Deluxe", Price = 7.50m, Ingredients = { ingredientList[11], ingredientList[13], ingredientList[16], ingredientList[21] }, PreparationSteps = { stepList[1], stepList[14], stepList[15], stepList[10] } };
        var caprese = new Dish { Id = 8, Name = "Caprese-Sticks", Price = 6.00m, Ingredients = { ingredientList[21], ingredientList[18], ingredientList[2], ingredientList[1] }, PreparationSteps = { stepList[0], stepList[1], stepList[14], stepList[10], stepList[11] } };
        var kaffeeCrema = new Dish { Id = 9, Name = "Kaffee Crema", Price = 3.50m, Ingredients = { ingredientList[39] }, PreparationSteps = { stepList[6], stepList[7] } };
        var frischGepressterOJ = new Dish { Id = 10, Name = "Frisch gepresster Orangensaft", Price = 4.50m, Ingredients = { ingredientList[31] }, PreparationSteps = { stepList[8] } };

        Dishes.AddRange(new[] { wienerFruehstueck, englishBreakfast, avocadoToast, lachsBagel, joghurtBowl, bauernomelett, croissantDeluxe, caprese, kaffeeCrema, frischGepressterOJ });

        // -- Menus --
        Menus.AddRange(new Menu[]
        {
            new Menu { Id = 1, Name = "Menü 'Klassiker'", Price = 11.00m, Dishes = { wienerFruehstueck, kaffeeCrema } },
            new Menu { Id = 2, Name = "Menü 'Vital'", Price = 14.50m, Dishes = { joghurtBowl, frischGepressterOJ } }
        });
    }
}

// ############################### Models (beinhaltet vorerst die Entities) ###############################
public interface IEntity
{
    int Id { get; set; }
}

public class Bill : IEntity
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime BillDate { get; set; }
    public int VisitId { get; set; }
    public Visit? Visit { get; set; }
}

public class Customer : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}

public class Dish : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ICollection<Menu> Menus { get; set; } = new List<Menu>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public ICollection<PreparationStep> PreparationSteps { get; set; } = new List<PreparationStep>();
}

public class Ingredient : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}

public class Menu : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

public class Order : IEntity
{
    public int Id { get; set; }
    public DateTime OrderTime { get; set; }
    public int VisitId { get; set; }
    public Visit? Visit { get; set; }
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public ICollection<Menu> Menus { get; set; } = new List<Menu>();
}

public class PreparationStep : IEntity
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int StepOrder { get; set; }
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}

public class Table : IEntity
{
    public int Id { get; set; }
    public string TableNumber { get; set; } = string.Empty;
    public int Seats { get; set; }
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}

public class Visit : IEntity
{
    public int Id { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime? ExitTime { get; set; }
    public int TableId { get; set; }
    public Table? Table { get; set; }
    public Bill? Bill { get; set; }
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
