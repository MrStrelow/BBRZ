using Microsoft.EntityFrameworkCore;
using MvcTodoApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency Injection: Hat zwei Anwendungen:
// * Wir verwenden DbContext _context im Controller und sagen hier es soll im Controller verfügbar sein.
// * Mit dem scope - app.Services.CreateScope().ServiceProvider.GetRequiredService<TodoDbContext>() können wir ein
//      Objekt des TodoDbContext nach vordefinierten Regeln erzeugen. Es kann hier mit:
//      * Singleton gesagt werden, es soll immer das gleiche Objekt geladen werden,
//      * Transient gesagt werden, es soll immer ein neues Objekt geladen werden,
//      * Scoped gesagt werden, es soll für jeden "scope" ein neues Objekt geladen werden. Der Scope kann z.B. ein http - request sein. 
//          z.B. für einen neuen http-Request wird ein neues Objekt erstellt.
//          Alle Objekte während dieses Requests und die Aufrufe in Controllern und sonstigen Klassen, verwenden die das gleiche Objekt.
//          Ein neuer Request erzeugt ein neues Objekt.

// Früher mit repositories:
//builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// Ein eigener Aufruf für den DbContext
builder.Services.AddDbContext<TodoDbContext>( 
    options => {// das hier würde fehlen wenn wir builder.Services.AddScoped<TodoDbContext>(); aufrufen würden
        options.UseSqlServer(builder.Configuration.GetConnectionString("TodoContext") ??
            throw new InvalidOperationException("Connection string 'TodoContext' not found."));
    },
    contextLifetime: ServiceLifetime.Scoped // verwendet scoped im hintergrund
);

//Dependency Injection. Wir regeistiregen hier SeedData um Objekte von
//SeedData zu erstellen und in andere Klassen (wie z.B. den Cotnroller) einzufügen.
builder.Services.AddTransient<SeedData>();

var app = builder.Build();

// Wir holen uns neue Objekte mit scope.ServiceProvider.GetRequiredService<SeedData>()
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<SeedData>();
    seeder.Initialize();
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