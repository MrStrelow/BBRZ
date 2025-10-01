using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcTodoApp.Data;

namespace MVCTodoApp.Controllers;

public class TodoController : Controller
{
    private readonly TodoDbContext _context;
    public TodoController(TodoDbContext context)
    {
        _context = context;
    }

    [HttpGet] // Attribut
    public async Task<IActionResult> Index()
    {
        var todos = await _context.Todos.ToListAsync();
        return View(todos);
    }
}
