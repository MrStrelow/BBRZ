public class Dish : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ICollection<Menu> Menus { get; set; } = new List<Menu>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public ICollection<PreparationStep> PreparationSteps { get; set; } = new List<PreparationStep>();
}