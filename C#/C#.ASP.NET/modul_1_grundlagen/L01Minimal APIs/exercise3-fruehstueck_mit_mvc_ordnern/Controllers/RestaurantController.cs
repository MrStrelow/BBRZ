using System.Text;

public class RestaurantController
{
    private readonly WebApplication _app;

    public RestaurantController(WebApplication app)
    {
        _app = app;
    }

    // http-methode: GET mit Ressource /Index/Restaurant
    // Generiert und liefert die Haupt-HTML-Seite mit dem Formular und der Rechnungsliste.
    public void RegisterIndexGet()
    {
        _app.MapGet(
            "/Index/Restaurant", 
            () =>
            {
                var view = new View.Restaurant.Index(
                    title: "Restaurant - das ist eine Zusatzinfo welche nicht in ein Modle passt...",
                    RestaurantDbContext.Customers,
                    RestaurantDbContext.Menus,
                    RestaurantDbContext.Tables,
                    RestaurantDbContext.Dishes,
                    RestaurantDbContext.Bills
                ).Html;

                return Results.Content(view, "text/html", Encoding.UTF8);
            }
        );
    }

    // POST /Index/Restaurant
    // Verarbeitet die Formulardaten und erstellt eine neue Bestellung.
    public void RegisterIndexPost()
    {
        _app.MapPost(
            "/Index/Restaurant",
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

                if (customer == null || table == null || (!menus.Any() && !dishes.Any()))
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

                return Results.Redirect("/Index/Restaurant");
            }
        ).DisableAntiforgery();
    }
}
