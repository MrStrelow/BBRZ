public class Bill : IEntity
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime BillDate { get; set; }
    public int VisitId { get; set; }
    public Visit? Visit { get; set; }
}