using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MvcTodoApp.Data;
using MvcTodoApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// TODO: dependency injection des db contexts.
builder.Services.AddDbContext<TodoDbContext>(); 
//options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoContext") ??
        //throw new InvalidOperationException("Connection string 'TodoContext' not found."));

var app = builder.Build();

// Einfügen der dummy daten mithilfe einer (eigens erstellten) SeedData Klasse.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}


app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}");


app.Run();
