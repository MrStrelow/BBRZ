namespace FruehstuecksBestellungMVC.Models;

public class Visit
{
    public int VisitId { get; set; }
    public DateTime VisitTime { get; set; }

    public int TableId { get; set; }
    public Table? Table { get; set; }

    public Bill? Bill { get; set; }
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}