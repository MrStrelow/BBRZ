using FruehstuecksBestellungMVC.DTOs;
using FruehstuecksBestellungMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels
{
    public class DishViewModel : IValidatableObject
    {
        // Attribute für die Validierung der Id
        [Required(ErrorMessage = "Eine ID wird für die Detailansicht benötigt.")]
        [Range(1, int.MaxValue, ErrorMessage = "Die ID muss ein gültiger Wert sein.")]
        public int? Id { get; set; }

        // Logische Attribute für die 'Create'-Action
        [Required(ErrorMessage = "Der Name darf nicht leer sein.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Der Name muss zwischen 2 und 100 Zeichen lang sein.")]
        public string Name { get; set; }

        [Range(0.01, 1000, ErrorMessage = "Der Preis muss zwischen 0.01 und 1000 liegen.")]
        public decimal Price { get; set; }

        public ICollection<PreparationStep> Preparationstep { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }


        public DishDto ToDto()
        {
            return new DishDto
            {
                Name = this.Name
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