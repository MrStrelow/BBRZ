using Microsoft.AspNetCore.Identity.UI.Services;

namespace FruehstuecksBestellungMVC.Services;

public class MockEmailSender : IEmailSender
{
    private readonly ILogger<MockEmailSender> _logger;

    public MockEmailSender(ILogger<MockEmailSender> logger)
    {
        _logger = logger;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        _logger.LogWarning($"--------------------------------------------------");
        _logger.LogWarning($"EMAIL AN: {email}");
        _logger.LogWarning($"BETREFF: {subject}");
        _logger.LogWarning($"INHALT: {htmlMessage}");
        _logger.LogWarning($"--------------------------------------------------");
        return Task.CompletedTask;
    }
}