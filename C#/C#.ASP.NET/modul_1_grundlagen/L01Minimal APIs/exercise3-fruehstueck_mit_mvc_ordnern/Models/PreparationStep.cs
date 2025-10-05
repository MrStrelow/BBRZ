public class PreparationStep : IEntity
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int StepOrder { get; set; }
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
