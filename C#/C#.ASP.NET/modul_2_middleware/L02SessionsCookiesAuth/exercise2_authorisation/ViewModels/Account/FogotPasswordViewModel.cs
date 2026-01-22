using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels.Account;

public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}