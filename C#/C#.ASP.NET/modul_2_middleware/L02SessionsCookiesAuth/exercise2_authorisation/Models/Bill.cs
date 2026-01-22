namespace FruehstuecksBestellungMVC.Models;

public class Bill
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime BillDate { get; set; }

    public int? VisitId { get; set; }
    public Visit? Visit { get; set; }

    public int? DeliveryId { get; set; }
    public Delivery? Delivery { get; set; }

    public int? TakeAwayId { get; set; }
    public TakeAway? TakeAway { get; set; }
}