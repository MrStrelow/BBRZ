using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MvcTodoApp.Models;


namespace MvcTodoApp.Data;
public class TodoDbContext : DbContext
{
    // DbSets für die neuen Entitäten
    public DbSet<Todo> Todos { get; set; }

    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Database=TodoAsync;Trusted_Connection=True;Trust Server Certificate=True");
    }
}