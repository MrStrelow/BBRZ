using Microsoft.AspNetCore.Mvc;
using MVCTodoApp.Models;
using MVCTodoApp.Repositories;
using System.Diagnostics;

namespace MVCTodoApp.Controllers;

public class TodoController : Controller
{
    private readonly ITodoRepository _todoRepository;

    public TodoController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    // Endpoints - Http - Methoden
    // Get-Methode für /TODO... aber wir definieren hier nicht das genaue routing.
    [HttpGet]
    public IActionResult Index()
    {
        var todos = _todoRepository.GetAll();
        return View(todos);
    }
}
