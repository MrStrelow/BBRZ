using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var todos = new Dictionary<int, Todo>();
todos.TryAdd(1, new Todo("einkaufen"));
todos.TryAdd(2, new Todo("pumpi"));
todos.TryAdd(3, new Todo("modul 2 test schreiben"));
todos.TryAdd(4, new Todo("modul 3 test schreiben"));

// Lege Endpoints fest - Welche http requests erkenne ich?
// CRUD

// Create
app.MapPost(
    "/todos",
    (Todo newTodo) => todos.TryAdd(todos.Keys.Max() + 1, newTodo)
);

// Read
app.MapGet(
    "/todos", // /todos?sort=desc&limit=3
    (string? sort, int? limit) => { // wichtig: ? nicht vergessen
        Console.WriteLine(sort); // wenn sort nicht null ist und sort = asc, dann antwort aufsteigend sortieren, wenn desc absteigend.
        Console.WriteLine(limit); // wenn limit nicht null ist, dann limitiere antwort auf limit viele todos.
        
        return todos;
    }
);

app.MapGet(
    "/todos/{id}",
    (int id) => todos.TryGetValue(id, out var result) ?
        Results.Ok(result) :
        Results.NotFound($"Kein todo mit ID: {id} gefunden") 
    );


// Update
app.MapPut("/todos", () => "Hello World!");

// Delete
app.MapDelete("/todos", () => "Hello World!");

app.Run();

//  records sind unveränderbar - immutable
public record Todo(string Title);
// public class Todo {
//     public string Title { get; set; }
// }