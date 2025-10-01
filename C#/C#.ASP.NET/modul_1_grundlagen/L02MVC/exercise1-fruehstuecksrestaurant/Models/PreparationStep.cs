namespace FruehstuecksBestellungMVC.Models;

public class PreparationStep
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int StepOrder { get; set; }
    public List<Dish>? Dishes { get; set; }
}