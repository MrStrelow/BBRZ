using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FruehstuecksBestellungMVC.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInService;
    private readonly UserManager<IdentityUser> _userService;

    public AccountController(SignInManager<IdentityUser> signInService, UserManager<IdentityUser> userService)
    {
        _signInService = signInService;
        _userService = userService;
    }

    [HttpGet]
    [AllowAnonymous] // Wichtig: Jeder darf die Login-Seite sehen
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string username, string password)
    {
        // Einfacher Login-Versuch
        var result = await _signInService.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Ungültiger Login-Versuch");
            return View();
        }

        return RedirectToAction("Index", "Fruehstueck");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInService.SignOutAsync();
        return RedirectToAction("Login");
    }

    // Hilfsmethode um schnell User anzulegen (nur für Entwicklung!)
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> CreateTestUser()
    {
        var user = new IdentityUser { UserName = "admin" };
        var result = await _userService.CreateAsync(user, "admin");

        if (!result.Succeeded)
        {
            return Content("Fehler: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }
            
        return Content("User 'admin' mit Passwort 'admin' erstellt.");

    }
}