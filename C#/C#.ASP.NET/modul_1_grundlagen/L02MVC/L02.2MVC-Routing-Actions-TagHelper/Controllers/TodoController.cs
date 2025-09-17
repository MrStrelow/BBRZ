using Microsoft.AspNetCore.Mvc;
using MvcTodoApp.Models;
using MvcTodoApp.Repositories;

namespace MvcTodoApp.Controllers;

public class TodoController : Controller
{
    private readonly ITodoRepository _todoRepository;

    public TodoController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    // GET: /Todo?query=lernen&sortBy=alpha&limit=5
    public IActionResult Index(string? query, string? sortBy, int? limit)
    {
        var todos = _todoRepository.GetAll();

        // 1. Suche anwenden
        if (!string.IsNullOrEmpty(query))
        {
            todos = todos.Where(t => t.Title.Contains(query, StringComparison.OrdinalIgnoreCase));

            // ViewBag wird genutzt, um den Suchbegriff in der View wieder anzuzeigen.
            ViewBag.CurrentQuery = query;
        }

        // 2. Sortierung anwenden
        if (sortBy == "desc")
        {
            todos = todos.OrderByDescending(t => t.IsDone).ThenBy(t => t.Title);
            ViewBag.SortByAlpha = true; // TODO: why?
        } 
        else if (sortBy == "asc")
        {
            todos = todos.OrderBy(t => t.IsDone).ThenBy(t => t.Title);
        }

        // 3. Limitierung anwenden
        if (limit.HasValue && limit > 0)
        {
            todos = todos.Take(limit.Value);
            ViewBag.Limit = limit.Value; // TODO: why?
        }

        return View(todos.ToList());
    }

    // GET: /Todo/Details/5
    public IActionResult Details(int id)
    {
        var todo = _todoRepository.GetById(id);

        if (todo is null)
        {
            return NotFound();
        }

        return View(todo);
    }

    // POST: /Todo/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,Title,Description,IsDone,IsArchived")] Todo todo)
    {
        if (id != todo.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            _todoRepository.Update(todo);
            return RedirectToAction(nameof(Details), new { id = todo.Id });
        }

        // Wenn das Model ungültig ist, zeige die Details-Seite erneut mit den Fehlern.
        return View("Details", todo);
    }

    // POST: /Todo/ToggleDone/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ToggleDone(int id)
    {
        var todo = _todoRepository.GetById(id);
        if (todo is null)
        {
            return NotFound();
        }

        // Den Status umkehren und updaten.
        var updatedTodo = todo with { IsDone = !todo.IsDone };
        _todoRepository.Update(updatedTodo);

        return RedirectToAction(nameof(Index));
    }

    // POST: /Todo/Archive/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Archive(int id)
    {
        var todo = _todoRepository.GetById(id);
        if (todo == null)
        {
            return NotFound();
        }

        var updatedTodo = todo with { IsArchived = true };
        _todoRepository.Update(updatedTodo);

        return RedirectToAction(nameof(Index));
    }

    // GET: /Todo/Archived
    public IActionResult Archived()
    {
        var archivedTodos = _todoRepository.GetArchived();
        return View(archivedTodos);
    }

    // POST: /Todo/Unarchive/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Unarchive(int id)
    {
        var todo = _todoRepository.GetById(id);
        if (todo == null)
        {
            return NotFound();
        }

        var updatedTodo = todo with { IsArchived = false };
        _todoRepository.Update(updatedTodo);

        // Entscheide, wohin der User zurückgeleitet werden soll.
        // In diesem Fall zur Archiv-Übersicht.
        return RedirectToAction(nameof(Archived));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Title,Description")] Todo todo)
    {
        if (ModelState.IsValid)
        {
            _todoRepository.Add(todo);
            return RedirectToAction(nameof(Index));
        }
        return View(todo);
    }

    public IActionResult Delete(int id)
    {
        var todo = _todoRepository.GetById(id);
        if (todo == null)
        {
            return NotFound();
        }
        return View(todo);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _todoRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}