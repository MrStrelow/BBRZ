using MvcTodoApp.Data;
using MvcTodoApp.Models;

public class SeedData
{
    private readonly TodoDbContext _context;

    // context wird per dependency injection hier eingefügt
    public SeedData(TodoDbContext context)
    {
        _context = context;
    }

    public void Initialize()
    {
        if (_context.Todos.Any())
        {
            return;
        }

        _context.Todos.AddRange(
            new Todo { Title = "ASP.NET Core lernen", IsDone = false, CreatedAt = DateTime.Now.AddDays(-10) },
            new Todo { Title = "Einkaufen gehen", Description = "Milch, Brot, Eier", IsDone = true, CreatedAt = DateTime.Now.AddDays(-5) },
            new Todo { Title = "Projektmeeting vorbereiten", IsDone = false, CreatedAt = DateTime.Now.AddDays(-2) },
            new Todo { Title = "Altes Projekt archivieren", IsDone = true, IsArchived = true, CreatedAt = DateTime.Now.AddDays(-30) }
        );

        _context.SaveChanges();
    }
}