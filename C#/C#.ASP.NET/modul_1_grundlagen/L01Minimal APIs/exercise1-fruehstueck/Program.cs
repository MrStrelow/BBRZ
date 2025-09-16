using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MorgenstundRestaurant.DTOs;
using MorgenstundRestaurant.Exceptions;
using MorgenstundRestaurant.Repositories;
using MorgenstundRestaurant.Services;
using Serilog;
using System.Text;

// --- 1. Konfiguration und Service Instanziierung (aus Ihrem Projekt) ---
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Guten Morgen! Das Frühstücksrestaurant 'Morgenstund' öffnet als Webanwendung.");

var dishService = new DishService();
var menuService = new MenuService(dishService);
var customerService = new CustomerService(menuService);
var billRepository = new BillRepository(); // Benötigt, um Rechnungen anzuzeigen

// --- 2. Webanwendung erstellen ---
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// --- 3. Endpunkt für die Hauptseite (GET-Request) ---
// Zeigt das Bestellformular und alle bisherigen Rechnungen an.
app.MapGet("/", async (HttpContext context) =>
{
    var htmlBuilder = new StringBuilder();
    htmlBuilder.Append(@"
        <!DOCTYPE html>
        <html lang='de'>
        <head>
            <meta charset='UTF-8'>
            <title>Frühstücksrestaurant Morgenstund</title>
            <style>
                body { font-family: sans-serif; display: flex; gap: 40px; padding: 20px; }
                div { flex: 1; padding: 20px; border: 1px solid #ccc; border-radius: 8px; }
                h1, h2 { color: #333; }
                form { display: flex; flex-direction: column; gap: 10px; }
                input, button { padding: 10px; font-size: 16px; }
                button { cursor: pointer; background-color: #007bff; color: white; border: none; }
                ul { list-style-type: none; padding: 0; }
                li { background-color: #f4f4f4; margin-bottom: 8px; padding: 10px; border-radius: 4px; }
                .bill-header { font-weight: bold; }
                .error { color: red; margin-bottom: 10px; }
            </style>
        </head>
        <body>
            <div>
                <h1>Neue Bestellung aufgeben</h1>
                <form action='/bestellen' method='post'>
                    <label for='tableNumber'>Tischnummer:</label>
                    <input type='number' id='tableNumber' name='tableNumber' required>
                    
                    <label for='customerName'>Kundenname:</label>
                    <input type='text' id='customerName' name='customerName' required>

                    <label for='menuId'>Menü ID:</label>
                    <input type='number' id='menuId' name='menuId' required>
                    
                    <button type='submit'>Bestellung aufgeben</button>
                </form>
            </div>
            <div>
                <h2>Bisherige Rechnungen</h2>
    ");

    var bills = await billRepository.GetAllAsync(); // TODO: hier eigentlich über einen service! nicht ein repository!
    if (!bills.Any())
    {
        htmlBuilder.Append("<p>Noch keine Rechnungen vorhanden.</p>");
    }
    else
    {
        foreach (var bill in bills.OrderBy(b => b.TableNumber))
        {
            htmlBuilder.Append("<ul>");
            htmlBuilder.Append($"<li><span class='bill-header'>Tisch Nr:</span> {bill.TableNumber}</li>");
            htmlBuilder.Append($"<li><span class='bill-header'>Kunden:</span> {string.Join(", ", bill.CustomerNames)}</li>");
            htmlBuilder.Append($"<li><span class='bill-header'>Menüs:</span> {string.Join(", ", bill.OrderedMenus)}</li>");
            htmlBuilder.Append($"<li><span class='bill-header'>Betrag:</span> {bill.TotalAmount:C}</li>");
            htmlBuilder.Append("</ul><hr>");
        }
    }

    htmlBuilder.Append(@"
            </div>
        </body>
        </html>"
    );

    await context.Response.WriteAsync(htmlBuilder.ToString());
});

// --- 4. Endpunkt zum Verarbeiten der Bestellung (POST-Request) ---
app.MapPost("/bestellen", async (HttpContext context) =>
{
    var form = await context.Request.ReadFormAsync();

    // Formulardaten in ein DTO umwandeln
    var order = new TableOrderDto
    {
        TableNumber = int.Parse(form["tableNumber"]),
        CustomerOrders = new List<OrderDto>
        {
            new OrderDto
            {
                CustomerName = form["customerName"],
                MenuId = int.Parse(form["menuId"])
            }
        }
    };

    // Den vorhandenen CustomerService aufrufen, um die Bestellung zu verarbeiten
    try
    {
        await customerService.PlaceOrderAsync(order);
    }
    catch (OrderProcessingException ex)
    {
        Log.Error(ex, "Fehler bei der Auftragsverarbeitung für Tisch {TableNumber}.", order.TableNumber);
        // Optional: Fehler an den Benutzer zurückgeben
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Ein unerwarteter Fehler ist aufgetreten bei Tisch {TableNumber}.", order.TableNumber);
        // Optional: Fehler an den Benutzer zurückgeben
    }

    // Zurück zur Startseite umleiten, um die Aktualisierung zu sehen
    context.Response.Redirect("/");
});

app.Run();