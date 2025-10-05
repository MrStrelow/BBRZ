public class Table : IEntity
{
    public int Id { get; set; }
    public string TableNumber { get; set; } = string.Empty;
    public int Seats { get; set; }
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}