using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DeinProjektName.Controllers;

public class SetupController : Controller
{
    private readonly RoleManager<IdentityRole> _roleService;
    private readonly UserManager<IdentityUser> _userService;

    public SetupController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    {
        _roleService = roleManager;
        _userService = userManager;
    }

    // Aufrufbar über: /Setup/CreateTestAdmin
    public async Task<IActionResult> CreateTestAdmin()
    {
        // 1. Rollen erstellen, falls nicht existent
        string[] roleNames = { "Admin", "User" };
        foreach (var roleName in roleNames)
        {
            if (!await _roleService.RoleExistsAsync(roleName))
            {
                await _roleService.CreateAsync(new IdentityRole(roleName));
            }
        }

        // 2. Admin User suchen oder erstellen
        var adminEmail = "admin@restaurant.at";
        var adminUser = await _userService.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
            // Passwort hartcodiert für Testzwecke
            var result = await _userService.CreateAsync(adminUser, "Admin123!");
            if (!result.Succeeded) return Content("Fehler beim Erstellen des Users: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        // 3. User der Admin-Rolle hinzufügen
        if (!await _userService.IsInRoleAsync(adminUser, "Admin"))
        {
            await _userService.AddToRoleAsync(adminUser, "Admin");
        }

        // Optional: Auch der User-Rolle hinzufügen
        if (!await _userService.IsInRoleAsync(adminUser, "User"))
        {
            await _userService.AddToRoleAsync(adminUser, "User");
        }

        return Content($"Erfolg! User {adminEmail} ist nun Admin. Passwort: Admin123!");
    }
}