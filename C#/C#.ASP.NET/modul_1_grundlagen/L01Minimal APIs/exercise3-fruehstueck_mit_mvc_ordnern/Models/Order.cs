public class Order : IEntity
{
    public int Id { get; set; }
    public DateTime OrderTime { get; set; }
    public int VisitId { get; set; }
    public Visit? Visit { get; set; }
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public ICollection<Menu> Menus { get; set; } = new List<Menu>();
}