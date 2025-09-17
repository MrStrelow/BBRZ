using MvcTodoApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ITodoRepository, TodoRepository>();

var app = builder.Build();

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