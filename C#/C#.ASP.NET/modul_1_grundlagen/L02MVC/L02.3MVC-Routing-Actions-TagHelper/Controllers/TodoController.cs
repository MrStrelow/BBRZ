using Microsoft.AspNetCore.Mvc;
using MvcTodoApp.Models;
using MvcTodoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MvcTodoApp.Controllers;

public class TodoController : Controller
{
    private readonly TodoDbContext _context;

    // Der DbContext wird über den Konstruktor "injiziert" (Dependency Injection).
    // ASP.NET Core kümmert sich darum, uns die richtige Instanz zu geben -
    // konfiguriert in Program.cs
    public TodoController(TodoDbContext context)
    {
        _context = context;
    }


    // GET: /Todo?query=lernen&sortBy=alpha&limit=5
    [HttpGet]
    public async Task<IActionResult> Index(string? query, string? sortBy, int? limit)
    {
        IQueryable<Todo> todos = _context.Todos; //autocast from dbset to IQueryable<Todo>

        if (!string.IsNullOrEmpty(query))
        {
            todos = todos.Where(t => t.Title.Contains(query, StringComparison.OrdinalIgnoreCase));
        }

        // ViewBag wird genutzt, um den Suchbegriff in der View wieder anzuzeigen.
        ViewBag.CurrentQuery = query;

        // sortieren
        if (sortBy == "desc")
        {
            todos = todos.OrderByDescending(t => t.IsDone).ThenBy(t => t.Title);
            // ViewBag sind Daten ohne Model, was wir unserer View "dranhängen"
            ViewBag.SortBy = "desc"; // Wir merken es uns nicht clientseitig, der Server antwortet mit der Info, dass er es so sortiert hat.
        } 
        else if (sortBy == "asc")
        {
            todos = todos.OrderBy(t => t.IsDone).ThenBy(t => t.Title);
            ViewBag.SortBy = "asc"; // Wir merken es uns nicht clientseitig, der Server antwortet mit der Info, dass er es so sortiert hat.
        }

        // limitieren
        if (limit.HasValue && limit > 0)
        {
            todos = todos.Take(limit.Value);
            ViewBag.Limit = limit.Value; // Wir merken es uns nicht clientseitig, der Server antwortet mit der Info, dass er ein limit verwendet.

        }

        return View(await todos.ToListAsync());
    }

    // GET: /Todo/Details/5
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo is null)
            return NotFound();

        return View(todo);
    }

    // POST: /Todo/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    // Bind ist eine sicherheitsvorkehurng.
    // Wir wollen nur die angegebenen daten in unsere Properties des Todos einfügen.
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,IsDone,IsArchived")] Todo todo)
    {
        if (id != todo.Id)
            return BadRequest();

        if (ModelState.IsValid)
        {
            _context.Todos.Update(todo);
            return RedirectToAction(nameof(Details), new { id = todo.Id });
        }

        await _context.SaveChangesAsync();

        // Wenn das Model ungültig ist, zeige die Details-Seite erneut mit den Fehlern.
        return View("Details", todo);
    }

    // POST: /Todo/ToggleDone/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleDone(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null)
            return NotFound();

        // Den Status umkehren und updaten.
        var a = await _context.Todos.Remove(todo);
        var updatedTodo = todo with { IsDone = !todo.IsDone };
        _context.Todos.Update(updatedTodo); // TODO: mit den teilnehmer:innen den ereugen SQL code anschauen.

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // POST: /Todo/Archive/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Archive(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null)
        {
            return NotFound();
        }

        var updatedTodo = todo with { IsArchived = true };
        _context.Todos.Update(updatedTodo);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // GET: /Todo/Archived
    [HttpGet]
    public async Task<IActionResult> Archived()
    {
        var archivedTodos = _context.Todos.Where(todo => todo.IsArchived);
        return View(await archivedTodos.ToListAsync());
    }

    // POST: /Todo/Unarchive/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Unarchive(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null)
        {
            return NotFound();
        }

        var updatedTodo = todo with { IsArchived = false };
        _context.Todos.Update(updatedTodo);

        await _context.SaveChangesAsync();

        // Entscheide, wohin der User zurückgeleitet werden soll.
        // In diesem Fall zur Archiv-Übersicht.
        return RedirectToAction(nameof(Archived));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Description")] Todo todo)
    {
        if (ModelState.IsValid)
        {
            _context.Todos.Add(todo);
            return RedirectToAction(nameof(Index));
        }

        await _context.SaveChangesAsync();

        return View(todo);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null)
        {
            return NotFound();
        }

        await _context.SaveChangesAsync();
        return View(todo);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var toBeDeleted = await _context.Todos.FindAsync(id);
        if (toBeDeleted is null)
        {
            return NotFound();
        }

        _context.Todos.Remove(toBeDeleted);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}