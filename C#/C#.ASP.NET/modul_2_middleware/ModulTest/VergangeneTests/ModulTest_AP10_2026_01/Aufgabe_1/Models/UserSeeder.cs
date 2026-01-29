using Microsoft.AspNetCore.Identity;

namespace FruehstuecksBestellungMVC.Data;

public static class UserSeeder
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // 1. Rollen sicherstellen
        string[] roleNames = { "Admin", "User" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // 2. Admin User anlegen (falls noch nicht da)
        var adminEmail = "admin@restaurant.at";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true // Wichtig, damit er als "bestätigt" gilt
            };

            // Erstellt den User mit Passwort
            await userManager.CreateAsync(adminUser, "Password123!");
            // Weist die Rolle zu
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        // 3. Normalen User anlegen (falls noch nicht da)
        var userEmail = "user@restaurant.at";
        var normalUser = await userManager.FindByEmailAsync(userEmail);

        if (normalUser == null)
        {
            normalUser = new IdentityUser
            {
                UserName = userEmail,
                Email = userEmail,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(normalUser, "Password123!");
            await userManager.AddToRoleAsync(normalUser, "User");
        }
    }
}