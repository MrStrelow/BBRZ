using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.Services;
using FruehstuecksBestellungMVC.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; // Neu

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));

// --- NEU: Identity Configuration ---
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
    // Vereinfachte Regeln für Testzwecke
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

// --- NEU: Accessor für Service-Check ---
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<MenuService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Error");
    app.UseHsts();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Seeding Logik (User & Rollen)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // 1. Business Data Seeding
        await SeedData.Initialize(services);
        await UserSeeder.Initialize(services);

        // 2. Identity Seeding (Admin & User)
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

        // Rollen erstellen
        string[] roleNames = { "Admin", "User" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Admin User erstellen
        var adminEmail = "admin@restaurant.at";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
            await userManager.CreateAsync(adminUser, "Password123!");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        // Normal User erstellen
        var userEmail = "user@restaurant.at";
        var normalUser = await userManager.FindByEmailAsync(userEmail);
        if (normalUser == null)
        {
            normalUser = new IdentityUser { UserName = userEmail, Email = userEmail };
            await userManager.CreateAsync(normalUser, "Password123!");
            await userManager.AddToRoleAsync(normalUser, "User");
        }
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

// --- NEU: Authentication muss VOR Authorization kommen ---
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Fruehstueck}/{action=Index}/{id?}");

app.Run();