using FruehstuecksBestellungMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.Models;

public class TakeAway
{
    public int Id { get; set; }

    public DateTime PickupTime { get; set; } = DateTime.Now;
    public Customer? Customer { get; set; }
    public Bill? Bill { get; set; }
    public Order? Orders { get; set; }
}