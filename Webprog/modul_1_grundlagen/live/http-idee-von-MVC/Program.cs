using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// Das ist das Model.
var todos = new Dictionary<int, Todo>();
todos.TryAdd(1, new Todo("einkaufen"));
todos.TryAdd(2, new Todo("pumpi"));
todos.TryAdd(3, new Todo("modul 2 test schreiben"));
todos.TryAdd(4, new Todo("modul 3 test schreiben"))

// Das ist der Controller - http endpoints und verwenden von Objekten aus Model und View.
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
        IEnumerable<KeyValuePair<int, Todo>> result = todos;
        
        if (sort != null)
        {
            if (sort == "desc")
            {
                result = result.OrderByDescending( t => t.Key );
            } 
            else if (sort == "asc")
            {
                result = result.OrderBy(t => t.Key);
            }
        }

        if (limit.HasValue)
        {
            result = result.Take(limit.Value);
        }

        // das ist neu!
        var html = GenerateHtml(new ConcurrentDictionary<int, Todo>(result));
        return Results.Content(html, "text/html", Encoding.UTF8);

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


string GenerateHtml(ConcurrentDictionary<int, Todo> currentTodos)
{
    var htmlBuilder = new StringBuilder();

    // HTML-Grundgerüst
    htmlBuilder.Append("<!DOCTYPE html>");
    htmlBuilder.Append("<html lang='de'>");
    htmlBuilder.Append("<head>");
    htmlBuilder.Append("<meta charset='UTF-8'>");
    htmlBuilder.Append("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
    htmlBuilder.Append("<title>Meine To-Do Liste</title>");
    htmlBuilder.Append(@"
        <style>
            body { font-family: sans-serif; background-color: #f4f4f9; color: #333; max-width: 800px; margin: 2rem auto; padding: 1rem; }
            h1 { color: #4a4a4a; }
            ul { list-style-type: none; padding: 0; }
            li { background-color: #fff; border: 1px solid #ddd; margin-bottom: 8px; padding: 12px; display: flex; justify-content: space-between; align-items: center; border-radius: 4px; }
            li a { color: #333; text-decoration: none; flex-grow: 1; }
            .actions { display: flex; gap: 10px; }
            button.delete { background-color: #dc3545; color: white; border: none; padding: 8px 12px; border-radius: 4px; cursor: pointer; }
            form { display: flex; gap: 10px; margin-top: 2rem; }
            input[type='text'] { flex-grow: 1; padding: 10px; border: 1px solid #ccc; border-radius: 4px; }
            input[type='submit'] { background-color: #007bff; color: white; border: none; padding: 10px 20px; border-radius: 4px; cursor: pointer; }
        </style>
    ");
    htmlBuilder.Append("</head>");
    htmlBuilder.Append("<body>");

    htmlBuilder.Append("<h1>Meine To-Do Liste</h1>");

    // Liste der To-Dos generieren
    htmlBuilder.Append("<ul>");
    if (currentTodos.IsEmpty)
    {
        htmlBuilder.Append("<li>Keine Aufgaben mehr, sehr gut!</li>");
    }
    else
    {
        foreach (var todo in currentTodos.OrderBy(t => t.Key))
        {
            htmlBuilder.Append($"<li id='todo-{todo.Key}'>");
            htmlBuilder.Append($"<a href='/todos/{todo.Key}'>{todo.Value.Title}</a>");
            htmlBuilder.Append($"<div class='actions'><button type='button' class='delete' onclick='deleteTodo({todo.Key})'>Delete</button></div>");
            htmlBuilder.Append("</li>");
        }
    }
    htmlBuilder.Append("</ul>");

    // Formular zum Hinzufügen neuer To-Dos
    htmlBuilder.Append("<h2>Neue Aufgabe hinzufügen</h2>");
    htmlBuilder.Append("<form action='/todos' method='post'>");
    // Das Token-Feld wurde hier entfernt
    htmlBuilder.Append("<input type='text' name='title' placeholder='Was muss getan werden?' required />");
    htmlBuilder.Append("<input type='submit' value='Hinzufügen' />");
    htmlBuilder.Append("</form>");

    // Vereinfachtes JavaScript ohne Anti-Forgery-Header
    htmlBuilder.Append(@"
        <script>
            function deleteTodo(id) {
                if (!confirm('Sind Sie sicher, dass Sie diese Aufgabe löschen möchten?')) {
                    return;
                }

                fetch(`/todos/delete/${id}`, {
                    method: 'DELETE'
                })
                .then(response => {
                    if (response.ok) {
                        // Seite neu laden, um die aktualisierte Liste anzuzeigen
                        window.location.reload();
                    } else {
                        alert('Fehler beim Löschen der Aufgabe.');
                    }
                })
                .catch(error => console.error('Fehler:', error));
            }
        </script>
    ");

    htmlBuilder.Append("</body>");
    htmlBuilder.Append("</html>");

    return htmlBuilder.ToString();
}

//  records sind unveränderbar - immutable
public record Todo(string Title);
// public class Todo {
//     public string Title { get; set; }
// }