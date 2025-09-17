using MvcTodoApp.Models;
using System.Collections.Generic;

namespace MvcTodoApp.Repositories;

public interface ITodoRepository
{
    IEnumerable<Todo> GetArchived();
    IEnumerable<Todo> GetAll();
    Todo GetById(int id);
    void Delete(int id);
    void Add(Todo todo);
    void Update(Todo todo);
}