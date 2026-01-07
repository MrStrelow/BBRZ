using FruehstuecksBestellungMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FruehstuecksBestellungMVC.Controllers
{
    public class ErrorController : Controller
    {
        // Die Bedeutung des Attributes besprechen wir später
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Stellen Sie sicher, dass Ihr ErrorViewModel hier verfügbar ist
            // (z.B. durch Anlegen der Models/ErrorViewModel.cs Datei)
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            // Verwendet die View /Views/Shared/Error.cshtml
            return View(errorViewModel);
        }
    }
}