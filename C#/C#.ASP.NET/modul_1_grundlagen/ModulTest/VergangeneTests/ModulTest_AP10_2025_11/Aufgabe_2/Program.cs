using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantContext")));

// Register custom services
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<DishService>();

var app = builder.Build();

// sage dass der ErrorController sich um den Aufruf der ErrorView kümmert.
if (!app.Environment.IsDevelopment())
{
    // Error/Error ist die Anweisung:
    // * das 1. Error bedeutet ErrorController verwenden
    // * das 2. Error bedeutet Error Methode im ErrorController verwenden
    app.UseExceptionHandler("/Error/Error");

    app.UseHsts();
}

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        await SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Fruehstueck}/{action=Index}/{id?}");

app.Run();