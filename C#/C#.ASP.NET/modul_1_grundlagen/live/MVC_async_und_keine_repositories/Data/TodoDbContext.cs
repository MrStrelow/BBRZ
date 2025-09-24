using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MVCTodoApp.Models;


namespace MVCTodoApp.Data;
public class TodoDbContext : DbContext
{
    // DbSets für die neuen Entitäten
    public DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=C432-LT-A7A3\SQLEXPRESS;Database=TodoAsync;User ID=sa;Password=qwertz011235;Trust Server Certificate=True");
    }
}