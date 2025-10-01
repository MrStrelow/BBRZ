namespace FruehstuecksBestellungMVC.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}