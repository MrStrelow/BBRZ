using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.Middleware;
using FruehstuecksBestellungMVC.Services;
using Microsoft.AspNetCore.Identity.UI.Services; // Nötig für IEmailSender interface
using Microsoft.AspNetCore.Identity; // Neu
using Microsoft.AspNetCore.Authorization; // Neu
using Microsoft.AspNetCore.Mvc.Authorization; // Neu
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Identity Services anpassen
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Passwort-Regeln (wie gehabt)
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;

    // Für Password Recovery nötig:
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders(); // <--- WICHTIG HINZUFÜGEN für Reset Tokens

//2.Globalen Filter: Alles schützen!
builder.Services.AddControllersWithViews(options =>
{
   var policy = new AuthorizationPolicyBuilder()
                   .RequireAuthenticatedUser()
                   .Build();
   options.Filters.Add(new AuthorizeFilter(policy));
});

// HIER legst du fest, was passiert, wenn man nicht authentifiziert ist:
builder.Services.ConfigureApplicationCookie(options =>
{
    // Wenn der User nicht eingeloggt ist -> leite hierhin um:
    options.LoginPath = "/Account/Login";
    //options.LoginPath = "/Account/AccessDenied"; // was ist der unterschied wenn ich das einkommentiere?

    // Wenn der User eingeloggt ist, aber nicht die Rechte hat (z.B. kein Admin) -> leite hierhin um:
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));

// Register custom services
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<MenuService>();

// Mock Email Service registrieren
builder.Services.AddTransient<IEmailSender, MockEmailSender>();

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