using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcTodoApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency Injection. Wir verwenden DbContext _context im Controller und sagen hier es soll dort verfügbar sein.
builder.Services.AddDbContext<TodoDbContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoContext") ??
        throw new InvalidOperationException("Connection string 'TodoContext' not found."))
);

var app = builder.Build();

// Load some dummy data, in case DB is empty
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

app.UseStaticFiles(); // Statische Dateien (CSS, JS, Bilder) aus wwwroot bereitstellen

// Hier definieren wir unsere Routen. Die Reihenfolge ist wichtig!
// Die erste passende Route wird verwendet.

// Route 1: Eine sehr spezifische, statische Route.
// Diese Route matched NUR die URL /erledigte-todos
app.MapControllerRoute(
    name: "completed_todos",
    pattern: "erledigte-todos",
    defaults: new { controller = "Todo", action = "Completed" });

// Route 2: Eine Route mit einem Constraint (einer Einschränkung).
// Diese Route matched z.B. /todo/archiv/2023, aber nicht /todo/archiv/hallo
app.MapControllerRoute(
    name: "archive",
    pattern: "todo/archiv/{jahr:int}",  
    defaults: new { controller = "Todo", action = "Archive" });


// Route 3: Die "Default"-Route. Sie ist sehr flexibel und fängt die meisten
// Standard-Fälle ab (z.B. /Todo/Index, /Todo/Details/5).
// Sie sollte meistens am Ende stehen, da sie sehr "gierig" ist.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}");

app.Run();