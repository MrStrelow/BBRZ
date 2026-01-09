using FruehstuecksBestellungMVC.Models;

namespace FruehstuecksBestellungMVC.DTOs;

public class MenuDto
{
    public string Name { get; set; }
    public IEnumerable<int> DishIds = new List<int>();
}
