using MVCTodoApp.Models;
using System.Collections.Concurrent;

namespace MVCTodoApp.Repositories;

public class TodoRepositoryInMemory : ITodoRepository
{
    private static readonly ConcurrentDictionary<int, Todo> _todos = new (
        new[]
        {
            new KeyValuePair<int, Todo>(1, new Todo { Id = 1, Title = "Einkaufen gehen" }),
            new KeyValuePair<int, Todo>(2, new Todo { Id = 2, Title = "Fitessstudio" }),
            new KeyValuePair<int, Todo>(3, new Todo { Id = 3, Title = ".Net lernen" })
        }
    );

    public void Add(Todo todo)
    {
        var newId = _todos.IsEmpty ? 1 : _todos.Keys.Max() + 1;
        todo.Id = newId;
        _todos.TryAdd(key: newId, value: todo);
    }

    public void Delete(int id)
    {
        _todos.TryRemove(id, out _);
    }

    public IEnumerable<Todo> GetAll()
    {
        return _todos.Values.OrderBy(todo => todo.Id);
    }

    public Todo GetById(int id)
    {
        _todos.TryGetValue(id, out var todo);
        return todo;
    }
}
