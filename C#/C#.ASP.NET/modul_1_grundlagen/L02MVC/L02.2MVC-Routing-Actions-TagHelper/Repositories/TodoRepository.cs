using MvcTodoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcTodoApp.Repositories;

public class TodoRepository : ITodoRepository
{
    private static readonly List<Todo> _todos = new List<Todo>
    {
        new Todo { Id = 1, Title = "ASP.NET Core lernen", IsDone = false, CreatedAt = DateTime.Now.AddDays(-10) },
        new Todo { Id = 2, Title = "Einkaufen gehen", Description = "Milch, Brot, Eier", IsDone = true, CreatedAt = DateTime.Now.AddDays(-5) },
        new Todo { Id = 3, Title = "Projektmeeting vorbereiten", IsDone = false, CreatedAt = DateTime.Now.AddDays(-2) },
        new Todo { Id = 4, Title = "Altes Projekt archivieren", IsDone = true, IsArchived = true, CreatedAt = DateTime.Now.AddDays(-30) }
    };

    private static int _nextId = _todos.Any() ? _todos.Max(t => t.Id) + 1 : 1;

    public IEnumerable<Todo> GetAll()
    {
        return _todos.Where(t => !t.IsArchived);
    }

    public IEnumerable<Todo> GetArchived()
    {
        return _todos.Where(t => t.IsArchived);
    }

    public Todo? GetById(int id)
    {
        return _todos.FirstOrDefault(t => t.Id == id);
    }

    public void Add(Todo todo)
    {
        // 'with' Ausdruck erstellt eine Kopie von todo mit den neuen Werten der Eigenschaften Id und CreatedAt.
        // Wir dfür 'init' Properties genötigt, da wir diese nun nicht merh erändern können.
        // Erinnere dich an den Copy Konstruktor! Ist das gleiche, nur ein wenig anders.
        
        // wir verwenden _nextId, welches eine If-Expression im hintergrund hat. Dort steht immer der um 1 inkrementierte wert drinnen.
        var newTodo = todo with { CreatedAt = DateTime.Now }; 
        _todos.Add(newTodo);
    }

    public void Update(Todo todo)
    {
        var toBeUpdated = _todos[todo.Id];
        var updatedTodo = toBeUpdated with { Id = toBeUpdated.Id, CreatedAt = toBeUpdated.CreatedAt };
        _todos[updatedTodo.Id] = updatedTodo;
    }

    public void Delete(int id)
    {
        var todo = GetById(id);
        if (todo is not null)
        {
            _todos.Remove(todo);
        }
    }
}