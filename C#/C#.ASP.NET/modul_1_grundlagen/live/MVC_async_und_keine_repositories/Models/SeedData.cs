using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcTodoApp.Data;
using MvcTodoApp.Models;
using System;
using System.Linq;

namespace MvcTodoApp.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (
            var context = new TodoDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TodoDbContext>>())
            )
        {
            // Look for any Todos.
            if (context.Todos.Any())
            {
                return;   // DB has already been seeded
            }
            new Todo();

            // seed DB with the following data
            context.Todos.AddRange(
                new Todo { Title = "Einkaufen gehen" },
                new Todo { Title = "Fitnessstudio" },
                new Todo { Title = ".NET lernen" }
            );

            context.SaveChanges();
        }
    }
}