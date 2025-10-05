public class Visit : IEntity
{
    public int Id { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime? ExitTime { get; set; }
    public int TableId { get; set; }
    public Table? Table { get; set; }
    public Bill? Bill { get; set; }
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}