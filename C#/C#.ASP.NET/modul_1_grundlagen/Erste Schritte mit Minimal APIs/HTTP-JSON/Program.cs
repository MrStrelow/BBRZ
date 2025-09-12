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

    // Guard Clause für einen ungültigen Sortier-Parameter (optional, aber robust)
    if (sort != null && sort.ToLowerInvariant() != "asc" && sort.ToLowerInvariant() != "desc")
    {
        return Results.BadRequest("Ungültiger 'sort'-Parameter. Nur 'asc' oder 'desc' sind erlaubt.");
    }

    // Guard Clause für ein ungültiges Limit (optional, aber robust)
    if (limit.HasValue && limit.Value <= 0)
    {
        return Results.BadRequest("Der 'limit'-Parameter muss größer als 0 sein.");
    }

    // Die Logik bleibt dieselbe wie oben, aber die Eingaben sind nun validiert.
    IEnumerable<KeyValuePair<int, string>> query = todos;

    query = sort?.ToLowerInvariant() == "desc"
        ? query.OrderByDescending(t => t.Key)
        : query.OrderBy(t => t.Key);

    if (limit.HasValue)
    {
        query = query.Take(limit.Value);
    }

    return Results.Ok(query);
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
