namespace MvcTodoApp.Models;

public record Todo
{
    public int Id { get; init; }
    public string Title { get; init; }
}