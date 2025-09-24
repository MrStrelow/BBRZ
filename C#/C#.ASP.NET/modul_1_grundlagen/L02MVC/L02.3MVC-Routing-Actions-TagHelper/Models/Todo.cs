using System.ComponentModel.DataAnnotations;

namespace MvcTodoApp.Models;

public record Todo
{
    public int Id { get; init; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsDone { get; set; }
    public bool IsArchived { get; set; }
    public DateTime CreatedAt { get; set; }
}