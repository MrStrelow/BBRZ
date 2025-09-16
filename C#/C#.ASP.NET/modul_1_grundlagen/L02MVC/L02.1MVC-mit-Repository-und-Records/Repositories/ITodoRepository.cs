using MvcTodoApp.Models;
using System.Collections.Generic;

namespace MvcTodoApp.Repositories;

public interface ITodoRepository
{
    IEnumerable<Todo> GetAll();
    Todo GetById(int id);
    void Delete(int id);
    void AddNewTodoWithExistingTitle(string title);
}