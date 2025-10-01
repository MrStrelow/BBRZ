namespace FruehstuecksBestellungMVC.Models;

public class Bill
{
    public int BillId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime BillDate { get; set; }

    public int VisitId { get; set; }
    public Visit? Visit { get; set; }
}