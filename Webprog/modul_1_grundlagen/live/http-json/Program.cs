using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
    // die anfrage (query)
    // /todos?sort=desc&limit=3 oder
    // /todos?sort=desc oder
    // /todos?limit=3
    // soll in diesem endpoint funktioniern
    "/todos", 
    (string? sort, int? limit) => { // wichtig: ? nicht vergessen
        if (limit.HasValue)
        {
            var result = todos.Take(limit.Value);
            return Results.Ok(result);
        }

        if (sort != null)
        {
            if (sort == "desc")
            {
                var result = todos.OrderByDescending( t => t.Key );
                return Results.Ok(result);
            } 
            else if (sort == "asc")
            {
                var result = todos.OrderBy(t => t.Key);
                return Results.Ok(result);
            }
        }

        return Results.BadRequest();

        // wenn sort nicht null ist und sort = asc, dann antwort aufsteigend sortieren, wenn desc absteigend.
        // wenn limit nicht null ist, dann limitiere antwort auf limit viele todos.
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