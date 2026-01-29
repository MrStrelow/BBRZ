using FruehstuecksBestellungMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FruehstuecksBestellungMVC.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Login Versuch
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Fruehstueck");
            }

            ModelState.AddModelError(string.Empty, "Ungültiger Login-Versuch.");
        }

        // Bei Fehler View neu anzeigen (Validation Summary zeigt Fehler)
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Fruehstueck");
    }

    // Einfache AccessDenied Anzeige
    public IActionResult AccessDenied()
    {
        return Content("Zugriff verweigert. Ihnen fehlen die notwendigen Rechte.");
    }
}