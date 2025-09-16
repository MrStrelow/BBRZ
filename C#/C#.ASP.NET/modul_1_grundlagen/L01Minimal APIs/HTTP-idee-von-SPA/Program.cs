using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;

// Ein einfacher Datenspeicher (fürs Beispiel, später wäre das eine Datenbank)
var todos = new ConcurrentDictionary<int, Todo>();
todos.TryAdd(1, new Todo("Einkaufen gehen"));
todos.TryAdd(2, new Todo("Fitnessstudio"));
todos.TryAdd(3, new Todo(".NET lernen"));

var builder = WebApplication.CreateBuilder(args);

// Dieser Befehl weist den Webserver explizit an, den "wwwroot"-Ordner
// als Stammverzeichnis für Webinhalte zu verwenden.
builder.WebHost.UseWebRoot("wwwroot");

var app = builder.Build();

// --- STATISCHE DATEIEN BEREITSTELLEN ---
// Muss nach app.Build() aufgerufen werden.
// Sorgt dafür, dass Anfragen an die Haupt-URL die index.html laden.
app.UseDefaultFiles();
// Stellt alle Dateien aus dem "wwwroot"-Ordner bereit (html, css, js).
app.UseStaticFiles();


// --- API-ENDPUNKTE (GEBEN NUR JSON ZURÜCK) ---

// GET: Alle To-Dos als JSON-Array abrufen
app.MapGet("/api/todos", () => todos.OrderBy(t => t.Key).Select(todo => new {id = todo.Key, title = todo.Value.Title }));

// POST: Ein neues To-Do erstellen
app.MapPost("/api/todos", ([FromBody] Todo newTodo) => {
    if (string.IsNullOrWhiteSpace(newTodo.Title))
    {
        return Results.BadRequest("Der Titel darf nicht leer sein.");
    }
    var newId = todos.IsEmpty ? 1 : todos.Keys.Max() + 1;
    todos.TryAdd(newId, newTodo);
    // Gibt das anonyme Objekt mit ID als JSON zurück
    return Results.Created($"/api/todos/{newId}", new { id = newId, title = newTodo.Title});
});

// PUT: Ein bestehendes To-Do aktualisieren
app.MapPut("/api/todos/{id}", (int id, [FromBody] Todo updatedTodo) => {
    if (!todos.ContainsKey(id)) return Results.NotFound();
    if (string.IsNullOrWhiteSpace(updatedTodo.Title)) return Results.BadRequest();

    todos[id] = updatedTodo;
    return Results.NoContent();
});

// DELETE: Ein To-Do löschen
app.MapDelete("/api/todos/{id}", (int id) => {
    Console.WriteLine(string.Join(" - ", todos.Values));
    if (todos.TryRemove(id, out _)) return Results.NoContent();
    return Results.NotFound();
});

// --- ENDE DER ENDPUNKTE ---

app.Run();

// Eine kleine Hilfsklasse für die Daten von POST- und PUT-Anfragen
public record Todo(string Title);
