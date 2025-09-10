using MVCTodoApp.Models;
using System.Collections.Concurrent;

namespace MVCTodoApp.Repositories;

public class TodoRepositoryInMemory : ITodoRepository
{
    ConcurrentDictionary<int, Todo> _todos = new (
        new[]
        {
            new KeyValuePair<int, Todo>(1, new Todo { Id = 1, Title = "Einkaufen gehen" }),
            new KeyValuePair<int, Todo>(2, new Todo { Id = 2, Title = "Fitessstudio" }),
            new KeyValuePair<int, Todo>(3, new Todo { Id = 3, Title = ".Net lernen" })
        }
    );
//    todos.TryAdd(1, new Todo("einkaufen"));
//todos.TryAdd(2, new Todo("pumpi"));
//todos.TryAdd(3, new Todo("modul 2 test schreiben"));
//todos.TryAdd(4, new Todo("modul 3 test schreiben"));

    public void Add(Todo todo)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Todo> GetAll()
    {
        throw new NotImplementedException();
    }

    public Todo GetById(int id)
    {
        throw new NotImplementedException();
    }
}
