using System.ComponentModel.DataAnnotations;

namespace MvcTodoApp.Models;

public record Todo
{
    public int Id { get; init; }

    [Required(ErrorMessage = "Der Titel ist ein Pflichtfeld.")]
    [StringLength(100, ErrorMessage = "Der Titel darf maximal 100 Zeichen lang sein.")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Beschreibung")]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [Display(Name = "Erledigt?")]
    public bool IsDone { get; set; }

    [Display(Name = "Archiviert?")]
    public bool IsArchived { get; set; }

    [Display(Name = "Erstellt am")]
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }
}