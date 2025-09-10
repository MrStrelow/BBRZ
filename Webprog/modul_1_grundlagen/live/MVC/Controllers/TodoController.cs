using Microsoft.AspNetCore.Mvc;
using MVCTodoApp.Models;
using System.Diagnostics;

namespace MVCTodoApp.Controllers;

public class TodoController : Controller
{
    private readonly ITodoRepository todoRepository;

    public TodoController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
