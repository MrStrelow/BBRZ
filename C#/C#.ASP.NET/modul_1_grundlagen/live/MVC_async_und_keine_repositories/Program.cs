using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MvcTodoApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// TODO: dependency injection des db contexts.
builder.Services.AddDbContext<TodoDbContext>(); 
//options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoContext") ??
        //throw new InvalidOperationException("Connection string 'TodoContext' not found."));

var app = builder.Build();

// TOOD: einfügen der dummy daten mithilfe einer SeedData (eigens erstellt) Klasse.

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}");


app.Run();
