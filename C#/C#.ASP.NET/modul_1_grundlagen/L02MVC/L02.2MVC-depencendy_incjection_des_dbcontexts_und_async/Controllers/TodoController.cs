using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcTodoApp.Data;
using MvcTodoApp.Models;
using System.Linq;

namespace MvcTodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoDbContext _context;

        // Der DbContext wird �ber den Konstruktor "injiziert" (Dependency Injection).
        // ASP.NET Core k�mmert sich darum, uns die richtige Instanz zu geben -
        // konfiguriert in Program.cs
        public TodoController(TodoDbContext context)
        {
            _context = context;
        }

        // Endpoints - HTTP - Methoden

        /// GET-Methode f�r /Todo/ oder /Todo/Index
        /// Dass es z.B. auf /Todo h�hrt, wird in Program.cs mit MapControllerRoute und 
        /// in der Index.cshtml mit asp-controller="Todo" asp-action="Details" festgelegt.
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allTodos = await _context.Todos.ToListAsync();
            return View(allTodos);
        }

        /// GET-Methode f�r /Todo/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo is null) 
                return NotFound(); 

            return View(todo);
        }

        /// POST-Methode f�r /Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                await _context.Todos.AddAsync(new Todo { Title = title });
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        /// DELETE-Methode f�r /Todo/Delete/{id}
        /// Wenn wir einen wirkliche http-delete methode schicken wollen, 
        /// m�ssen wir javascript im browser verwenden und keinen form tag.
        [HttpDelete] 
        public async Task<IActionResult> Delete(int id)
        {
            var todoToDelete = await _context.Todos.FindAsync(id);

            if (todoToDelete is null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todoToDelete);

            await _context.SaveChangesAsync();

            // Gib HTTP 204 No Content zur�ck.
            return NoContent(); // oder einfach Ok()
        }
    }
}