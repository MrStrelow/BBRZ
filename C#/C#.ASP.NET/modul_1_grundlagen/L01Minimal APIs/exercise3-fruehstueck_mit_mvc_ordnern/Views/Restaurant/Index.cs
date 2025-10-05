using System.Globalization;
using System.Text;

namespace View.Restaurant;
public class Index
{
    public string Html { get; private set; }

    public Index(
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
        sb.AppendLine("        <form action=\"/Index/Restaurant\" method=\"post\">");

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

        Html = sb.ToString();
    }
}