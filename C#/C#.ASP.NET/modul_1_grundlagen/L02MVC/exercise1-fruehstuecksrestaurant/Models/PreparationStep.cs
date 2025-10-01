namespace FruehstuecksBestellungMVC.Models;

public class PreparationStep
{
    public int PreparationStepId { get; set; }
    public string Description { get; set; } = string.Empty;
    public int StepOrder { get; set; }
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}