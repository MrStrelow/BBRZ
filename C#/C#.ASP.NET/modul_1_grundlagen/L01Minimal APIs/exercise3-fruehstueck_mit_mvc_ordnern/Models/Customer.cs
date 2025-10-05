public class Customer : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}