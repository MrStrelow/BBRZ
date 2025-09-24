using Microsoft.AspNetCore.Mvc;
using MvcTodoApp.Models;
using MvcTodoApp.Repositories;
using System.Linq;

namespace MvcTodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        // Das Repository wird �ber den Konstruktor "injiziert" (Dependency Injection).
        // ASP.NET Core k�mmert sich darum, uns die richtige Instanz zu geben -
        // konfiguriert in Program.cs mit
        // builder.Services.AddSingleton<ITodoRepository, TodoRepository>();.
        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        // Endpoints - HTTP - Methoden

        /// GET-Methode f�r /Todo/ oder /Todo/Index
        /// Dass es z.B. auf /Todo h�hrt, wird in Program.cs mit MapControllerRoute und 
        /// in der Index.cshtml mit asp-controller="Todo" asp-action="Details" festgelegt.
        [HttpGet]
        public IActionResult Index()
        {
            var allTodos = _todoRepository.GetAll().ToList();
            return View(allTodos);
        }

        /// GET-Methode f�r /Todo/Details/{id}
        [HttpGet]
        public IActionResult Details(int id)
        {
            var todo = _todoRepository.GetById(id);
            if (todo is null) { return NotFound(); }

            return View(todo);
        }

        /// POST-Methode f�r /Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                _todoRepository.AddNewTodoWithExistingTitle(title);
            }

            return RedirectToAction("Index");
        }

        /// DELETE-Methode f�r /Todo/Delete/{id}
        /// Wenn wir einen wirkliche http-delete methode schicken wollen, 
        /// m�ssen wir javascript im browser verwenden und keinen form tag.
        [HttpDelete] 
        public IActionResult Delete(int id)
        {
            var todoToDelete = _todoRepository.GetById(id);
            if (todoToDelete is null)
            {
                return NotFound();
            }

            _todoRepository.Delete(id);

            return Ok();
        }
    }
}