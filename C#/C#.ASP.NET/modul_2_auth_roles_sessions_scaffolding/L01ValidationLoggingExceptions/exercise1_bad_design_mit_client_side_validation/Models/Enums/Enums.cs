using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.Models.Enums;

public enum VisitType
{
    [Display(Name = "Im Restaurant")]
    TakeIn,
    [Display(Name = "Abholung (Take Away)")]
    TakeAway
}

public enum OrderType
{
    [Display(Name = "Im Restaurant")]
    TakeIn,

    [Display(Name = "Abholung (Take Away)")]
    TakeAway,

    [Display(Name = "Lieferung")]
    Delivery
}