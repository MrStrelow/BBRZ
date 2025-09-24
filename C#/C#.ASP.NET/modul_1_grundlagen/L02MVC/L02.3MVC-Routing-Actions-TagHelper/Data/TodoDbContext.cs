using Microsoft.EntityFrameworkCore;
using MvcTodoApp.Models;

namespace MvcTodoApp.Data;

public class TodoDbContext : DbContext
{
    // DbSets für die neuen Entitäten
    public DbSet<Todo> Todos { get; set; }
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }
}
