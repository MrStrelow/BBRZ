using FruehstuecksBestellungMVC.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruehstuecksBestellungMVC.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInService;
    private readonly UserManager<IdentityUser> _userService;
    private readonly RoleManager<IdentityRole> _roleService; // Neu
    private readonly IEmailSender _emailSender; // Neu

    public AccountController(
         SignInManager<IdentityUser> signInService,
         UserManager<IdentityUser> userService,
         RoleManager<IdentityRole> roleService,
         IEmailSender emailSender)
    {
        _signInService = signInService;
        _userService = userService;
        _roleService = roleService;
        _emailSender = emailSender;
    }

    [HttpGet]
    [AllowAnonymous] // Jeder darf die Login-Seite sehen... sonst wirds schwer.
    public IActionResult Login() => View(); // Kurze Schreibweise mit Lambda Operator. Statt
    // public IActionResult Login()
    // {
    //     return View();
    // }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string username, string password)
    {
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

    // --- NEU: REGISTRIERUNG ---
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userService.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Sicherstellen, dass die Rolle "User" existiert
                if (!await _roleService.RoleExistsAsync("User"))
                {
                    await _roleService.CreateAsync(new IdentityRole("User"));
                }

                // User immer der Rolle "User" zuweisen
                await _userService.AddToRoleAsync(user, "User");

                await _signInService.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Fruehstueck");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    // --- NEU: PASSWORD RECOVERY ---
    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPassword() => View();

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userService.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var token = await _userService.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { token, email = model.Email }, Request.Scheme);

                // Send Email (Logged in Console)
                await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                    $"Bitte setze dein Passwort zurück indem du <a href='{callbackUrl}'>hier klickst</a>.");

                return View("ForgotPasswordConfirmation");
            }
            // Aus Sicherheitsgründen zeigen wir immer die Bestätigung an, auch wenn User nicht existiert
            return View("ForgotPasswordConfirmation");
        }
        return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPasswordConfirmation() => View();

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPassword(string token = null, string email = null)
    {
        if (token == null || email == null) return BadRequest("Token oder Email fehlt.");
        return View(new ResetPasswordViewModel { Code = token, Email = email });
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = await _userService.FindByEmailAsync(model.Email);
        if (user == null) return RedirectToAction("ResetPasswordConfirmation");

        var result = await _userService.ResetPasswordAsync(user, model.Code, model.Password);
        if (result.Succeeded)
        {
            return RedirectToAction("ResetPasswordConfirmation");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPasswordConfirmation() => View();


    [HttpGet]
    [AllowAnonymous]
    public IActionResult AccessDenied() => View();


    // --- ANGEPASST: TEST ADMIN ---
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> CreateTestAdmin()
    {
        // 1. Rollen erstellen falls nicht vorhanden
        string[] roleNames = { "Admin", "User" };
        foreach (var roleName in roleNames)
        {
            if (!await _roleService.RoleExistsAsync(roleName))
            {
                await _roleService.CreateAsync(new IdentityRole(roleName));
            }
        }

        // 2. Admin User anlegen
        var user = new IdentityUser { UserName = "admin@test.at", Email = "admin@test.at" };
        // Check if exists
        if (await _userService.FindByEmailAsync(user.Email) == null)
        {
            var result = await _userService.CreateAsync(user, "admin");
            if (result.Succeeded)
            {
                await _userService.AddToRoleAsync(user, "Admin");
                return Content("User 'admin@test.at' (Passwort: 'admin') wurde erstellt und der Rolle 'Admin' zugewiesen.");
            }
            return Content("Fehler: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        return Content("User existiert bereits.");
    }
}