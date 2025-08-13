using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;

// Ein einfacher Datenspeicher (fürs Beispiel, später wäre das eine Datenbank)
var todos = new ConcurrentDictionary<int, string>();
todos.TryAdd(1, "Einkaufen gehen");
todos.TryAdd(2, "Fitnessstudio");
todos.TryAdd(3, ".NET lernen");

var builder = WebApplication.CreateBuilder(args);

// HINWEIS: Die Swagger/OpenAPI-Dienste wurden entfernt.
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// HINWEIS: Die Swagger UI wurde entfernt.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();


// --- HIER SIND UNSERE HTTP-ENDPUNKTE ---

// GET: Ein spezifisches To-Do anhand seiner ID abrufen
app.MapGet("/todos/{id}", (int id) =>
    todos.TryGetValue(id, out var todo)
        ? Results.Ok(todo)
        : Results.NotFound($"Kein To-Do mit ID {id} gefunden."));

//// GET: Alle To-Dos abrufen
//app.MapGet("/todos", () => todos.OrderBy(t => t.Key));
// wir tauschen das mit den unteren code aus. dieser hat keine parameter, der untere schon!
// beides gleichzeitig führt zu einem fehler!

// GET /todos -> Gibt alle To-Dos zurück
// GET /todos?sort=desc -> Gibt alle To-Dos absteigend sortiert zurück
// GET /todos?limit=5 -> Gibt nur die ersten 5 To-Dos zurück
app.MapGet("/todos", (string? sort, int? limit) => {
    // 'sort' und 'limit' sind hier die Query-Parameter.
    // Sie werden automatisch aus der URL (z.B. /todos?sort=desc) ausgelesen.

    IEnumerable<KeyValuePair<int, string>> result = todos;

    // TODO: es ist wichtig ?sort=desc und nicht ?sort="desc" einzugeben!
    if (sort == "desc")
    {
        result = result.OrderByDescending(t => t.Key);
    }
    else
    {
        result = result.OrderBy(t => t.Key);
    }

    if (limit.HasValue)
    {
        result = result.Take(limit.Value);
    }

    return Results.Ok(result);
});

// POST: Ein neues To-Do erstellen
app.MapPost("/todos", (Todo newTodo) => {
    if (string.IsNullOrWhiteSpace(newTodo.Title))
    {
        return Results.BadRequest("Der Titel darf nicht leer sein.");
    }
    var newId = todos.IsEmpty ? 1 : todos.Keys.Max() + 1;
    todos.TryAdd(newId, newTodo.Title);
    return Results.Created($"/todos/{newId}", new { id = newId, title = newTodo.Title });
});

// PUT: Ein bestehendes To-Do aktualisieren
app.MapPut("/todos/{id}", (int id, Todo updatedTodo) => {
    if (!todos.ContainsKey(id))
    {
        return Results.NotFound();
    }
    if (string.IsNullOrWhiteSpace(updatedTodo.Title))
    {
        return Results.BadRequest("Der Titel darf nicht leer sein.");
    }
    todos[id] = updatedTodo.Title;
    return Results.NoContent(); // Erfolg, kein Inhalt wird zurückgegeben
});

// DELETE: Ein To-Do löschen
app.MapDelete("/todos/{id}", (int id) => {
    if (todos.TryRemove(id, out _))
    {
        return Results.NoContent(); // Erfolg, kein Inhalt wird zurückgegeben
    }
    return Results.NotFound();
});

// --- ENDE DER ENDPUNKTE ---

app.Run();

// Eine kleine Hilfsklasse für die Daten von POST- und PUT-Anfragen
public record Todo(string Title);
