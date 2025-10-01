namespace FruehstuecksBestellungMVC.Models;

public class Visit
{
    public int Id { get; set; }
    public DateTime EntryTime { get; set; }
    // während des aufenthalts ist das ende noch nicht bekannt.
    // Wir gehen davon aus, dass durch eine maske der besuch eingetragen wird,
    // und nicht im nachhinein erst eingetragen wird. 
    // Deshalb, DateTime? ExitTime und DateTime EntryTime
    // (in der config noch mehr dazu)
    public DateTime? ExitTime { get; set; } 
    public int TableId { get; set; }
    public Table? Table { get; set; }

    public Bill? Bill { get; set; }
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}