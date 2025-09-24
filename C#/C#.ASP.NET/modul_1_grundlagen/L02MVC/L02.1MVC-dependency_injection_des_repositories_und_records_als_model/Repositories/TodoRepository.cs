// /Repositories/InMemoryTodoRepository.cs
using MvcTodoApp.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MvcTodoApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private static readonly ConcurrentDictionary<int, Todo> _todos = new ConcurrentDictionary<int, Todo>(new[]
        {
            new KeyValuePair<int, Todo>(1, new Todo { Id = 1, Title = "Einkaufen gehen" }),
            new KeyValuePair<int, Todo>(2, new Todo { Id = 2, Title = "Fitnessstudio" }),
            new KeyValuePair<int, Todo>(3, new Todo { Id = 3, Title = ".NET lernen" })
        });

        public IEnumerable<Todo> GetAll()
        {
            return _todos.Values.OrderBy(t => t.Id);
        }

        public Todo GetById(int id)
        {
            _todos.TryGetValue(id, out var todo);
            return todo;
        }

        public void AddNewTodoWithExistingTitle(string title)
        {
            var incrementedId = _todos.IsEmpty ? 1 : _todos.Keys.Max() + 1;
            var newTodoWithId = new Todo { Id = incrementedId, Title = title };
            _todos.TryAdd(newTodoWithId.Id, newTodoWithId);
        }

        public void Delete(int id)
        {
            _todos.TryRemove(id, out _);
        }
    }
}