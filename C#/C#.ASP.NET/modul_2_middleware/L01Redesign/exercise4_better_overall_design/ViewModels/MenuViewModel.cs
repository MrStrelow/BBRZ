using FruehstuecksBestellungMVC.DTOs;
using FruehstuecksBestellungMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels
{
    public class MenuViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Der Name darf nicht leer sein.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Der Name muss zwischen 2 und 100 Zeichen lang sein.")]
        public string Name { get; set; }

        public IEnumerable<int> SelectedDishIds { get; set; } = new List<int>();

        public IEnumerable<Dish> AvailableDishes { get; set; } = new List<Dish>();

        public MenuDto ToDto()
        {
            return new MenuDto
            {
                Name = this.Name, 
                DishIds = SelectedDishIds
            };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Hier könnte komplexe, eigenschaftsübergreifende Logik stehen.
            // lassen wir es leer, da wir dort nix tun müssen.
            yield break;
        }
    }
}