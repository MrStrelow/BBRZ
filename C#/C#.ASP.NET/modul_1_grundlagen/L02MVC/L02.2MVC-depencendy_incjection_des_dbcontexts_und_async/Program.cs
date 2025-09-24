using MvcTodoApp.Data;
using MvcTodoApp.Models;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}");

app.Run();