using System.Text.Encodings.Web;
using FruehstuecksBestellungMVC.Exceptions;

namespace FruehstuecksBestellungMVC.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Ruft den Controller auf
            await _next(context);
        }
        catch (FruehstueckBusinessException ex)
        {
            // Fall 1: Ein erwarteter Fehler (Business Logic)
            _logger.LogWarning(ex, "Business-Fehler aufgetreten: {Message}", ex.Message);

            // Wir leiten den Benutzer zurück zur Startseite (oder woher er kam)
            // und hängen den Fehler als Query-Parameter an (einfachste Lösung)
            var errorMsg = UrlEncoder.Default.Encode(ex.Message);
            context.Response.Redirect($"/Fruehstueck/Index?error={errorMsg}");
        }
        // KEIN catch(Exception)! Wir lassen echte Abstürze "hochblubbern" -> für die standard middle ware.
    }
}