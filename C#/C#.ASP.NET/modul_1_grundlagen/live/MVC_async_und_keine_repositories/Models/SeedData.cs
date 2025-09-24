using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcTodoApp.Data;
using MvcTodoApp.Models;
using System;
using System.Linq;

namespace MvcMovie.Models;

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

            // seed DB with the following data
            context.Todos.AddRange(
                new Todo { Title = "ASP.NET Core lernen", IsDone = false, CreatedAt = DateTime.Now.AddDays(-10) },
                new Todo { Title = "Einkaufen gehen", Description = "Milch, Brot, Eier", IsDone = true, CreatedAt = DateTime.Now.AddDays(-5) },
                new Todo { Title = "Projektmeeting vorbereiten", IsDone = false, CreatedAt = DateTime.Now.AddDays(-2) },
                new Todo { Title = "Altes Projekt archivieren", IsDone = true, IsArchived = true, CreatedAt = DateTime.Now.AddDays(-30) }
            );

            context.SaveChanges();
        }
    }
}