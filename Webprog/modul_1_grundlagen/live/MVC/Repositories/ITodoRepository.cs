using MVCTodoApp.Models;

namespace MVCTodoApp.Repositories;

public interface ITodoRepository
{
    // C.R.U.D.

    // Create:
    void Add(Todo todo);

    // Read:
    IEnumerable<Todo> GetAll();
    Todo GetById(int id);

    // Udpate:
    // später :)

    // Delete:
    void Delete(int id);
}
