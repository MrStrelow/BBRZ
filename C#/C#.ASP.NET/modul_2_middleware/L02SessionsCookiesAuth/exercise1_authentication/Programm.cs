using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.Services;
using FruehstuecksBestellungMVC.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; // Neu
using Microsoft.AspNetCore.Authorization; // Neu
using Microsoft.AspNetCore.Mvc.Authorization; // Neu

var builder = WebApplication.CreateBuilder(args);

// 1. Identity Services hinzufügen
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Passwort-Regeln für Entwicklung lockern (Optional)
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// 2. Globalen Filter: Alles schützen!
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));

// Register custom services
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<MenuService>();

var app = builder.Build();

// Bestehendes Error Handling für Production anpassen/entfernen, da unsere Middleware übernimmt
// sage dass der ErrorController sich um den Aufruf der ErrorView kümmert.
if (app.Environment.IsDevelopment())
{
    // Error/Error ist die Anweisung:
    // * das 1. Error bedeutet ErrorController verwenden
    // * das 2. Error bedeutet Error Methode im ErrorController verwenden
    app.UseExceptionHandler("/Error/Error"); // Fängt alle übrigen Exceptions
    app.UseHsts();
    //app.UseDeveloperExceptionPage(); // Zeigt Stacktrace im Browser
}

// --> HIER EINFÜGEN: Unsere Middleware <--
app.UseMiddleware<ExceptionHandlingMiddleware>();

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

// 3. Authentication Middleware hinzufügen (vor Authorization!)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Fruehstueck}/{action=Index}/{id?}");

app.Run();