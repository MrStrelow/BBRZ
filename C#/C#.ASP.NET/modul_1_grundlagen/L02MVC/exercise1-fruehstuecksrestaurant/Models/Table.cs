namespace FruehstuecksBestellungMVC.Models;

public class Table
{
    public int TableId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}