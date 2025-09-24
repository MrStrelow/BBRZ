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
        // --------- ungewünschte Zustände ---------
        // Guard Clause - ein limit ohne sortBy macht keinen Sinn für uns.
        // Wir wollen nicht irgendwelche daten aus der Datenbank mit einem limit unsortiert zurückgeben.
        if (limit.HasValue && string.IsNullOrEmpty(sortBy))
            // kann mit javascript in der view sichergestellt werden.
            return BadRequest("Der Parameter 'sortBy' ist erforderlich, wenn ein 'limit' gesetzt wird.");

        // Guard Clause: sort by muss asc oder desc als text beinhalten.
        if (!(sortBy == "desc" || sortBy == "asc" || sortBy is null))
            return BadRequest("Unbekannter sortBy parameter. 'desc' und 'asc' ist möglich.");

        // --------- gewünschte Zustände ---------
        IQueryable<Todo> todos = _context.Todos.Where(todo => !todo.IsArchived); 

        if (!string.IsNullOrEmpty(query))
        {
            todos = todos.Where(t => t.Title.ToLower().Contains(query));
            todos = todos.Where(t => t.Title.ToLower().Contains(query));
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
    public async Task<IActionResult> Edit(int id, Todo todo)
    {
        if (id != todo.Id)
            return BadRequest();

        var todoInDatabase = await _context.Todos.FindAsync(id);

        // Werte welche nicht im formular übertragen werden, werden aus der Datenbankgeholt.
        todo.CreatedAt = todoInDatabase.CreatedAt;
        todo.IsArchived = todoInDatabase.IsArchived;
        todo.IsDone = todoInDatabase.IsDone;

        // Werte welche im formular übertragen werden, werden in der Datenbank aktualisiert.
        await _context.SaveChangesAsync();

        // wir verwenden die route zurück zu details aber mit der id des zu bearbeitenden objektes
        return RedirectToAction(nameof(Details), new { id = todo.Id });
    }

    // POST: /Todo/ToggleDone/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleDone(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null)
            return NotFound();

        todo.IsDone = !todo.IsDone;
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

        todo.IsArchived = true;
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

        todo.IsArchived = false;
        await _context.SaveChangesAsync();

        // Entscheide, wohin der User zurückgeleitet werden soll.
        // In diesem Fall zur Archiv-Übersicht.
        return RedirectToAction(nameof(Archived));
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View("Create");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    // nur diese 3 properties werden übermittelt, der rest wird ignoriert, falls diese gesendet werden.
    public async Task<IActionResult> Create(Todo todo)
    {
        todo.IsArchived = false;
        todo.CreatedAt = DateTime.Now;
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteFromDatabase(int id)
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