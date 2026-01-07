namespace FruehstuecksBestellungMVC.Models;

public class Table
{
    public int Id { get; set; }
    public string TableNumber { get; set; } // wäre eigentlich eine ID! wir wollen aber keine id mit bedeutung in der Datenbank haben.
    public int Seats { get; set; }
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}