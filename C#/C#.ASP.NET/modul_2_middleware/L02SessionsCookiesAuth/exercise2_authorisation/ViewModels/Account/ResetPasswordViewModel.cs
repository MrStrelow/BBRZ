using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels.Account;

public class ResetPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwörter stimmen nicht überein.")]
    public string ConfirmPassword { get; set; }

    public string Code { get; set; }
}