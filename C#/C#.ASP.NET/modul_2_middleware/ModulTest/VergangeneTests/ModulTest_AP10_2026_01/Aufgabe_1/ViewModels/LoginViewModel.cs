using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "E-Mail ist erforderlich.")]
    [EmailAddress(ErrorMessage = "Keine gültige E-Mail-Adresse.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Passwort ist erforderlich.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}