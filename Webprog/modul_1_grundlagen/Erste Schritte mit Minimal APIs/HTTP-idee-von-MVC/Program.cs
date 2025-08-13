using System.Collections.Concurrent;
using System.Text;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

// Ein einfacher Datenspeicher (fürs Beispiel, später wäre das eine Datenbank)
var todos = new ConcurrentDictionary<int, string>();
todos.TryAdd(1, "Einkaufen gehen");
todos.TryAdd(2, "Fitnessstudio");
todos.TryAdd(3, ".NET lernen");

var builder = WebApplication.CreateBuilder(args);

// 1. Anti-Forgery-Dienste zum Service-Container hinzufügen
builder.Services.AddAntiforgery();

var app = builder.Build();

// 2. Anti-Forgery-Middleware zur Pipeline hinzufügen.
app.UseAntiforgery();


// --- HTTP-ENDPUNKTE, DIE HTML ZURÜCKGEBEN ---

// GET: Die Hauptseite mit allen To-Dos als HTML-Seite abrufen
app.MapGet("/", (HttpContext context, IAntiforgery antiforgery) => {
    string htmlContent = GenerateHtml(todos, context, antiforgery);
    return Results.Content(htmlContent, "text/html", Encoding.UTF8);
});

// GET-Endpunkt, um ein einzelnes To-Do anzuzeigen
app.MapGet("/todos/{id}", (int id) => {
    if (todos.TryGetValue(id, out var todo))
    {
        // Einfache HTML-Seite für das einzelne To-Do zurückgeben
        var html = $@"
            <!DOCTYPE html>
            <html lang='de'>
            <head><title>Detail</title>
                <style>
                    body {{ font-family: sans-serif; background-color: #f4f4f9; color: #333; max-width: 800px; margin: 2rem auto; padding: 1rem; }}
                    h1 {{ color: #4a4a4a; }}
                    a {{ color: #007bff; }}
                </style>
            </head>
            <body>
                <h1>To-Do Detail</h1>
                <p><strong>ID:</strong> {id}</p>
                <p><strong>Aufgabe:</strong> {todo}</p>
                <a href='/'>Zurück zur Liste</a>
            </body>
            </html>";
        return Results.Content(html, "text/html", Encoding.UTF8);
    }

    return Results.NotFound("Kein To-Do mit dieser ID gefunden.");
});


// POST: Ein neues To-Do aus dem HTML-Formular erstellen
app.MapPost("/todos", (HttpContext context, IAntiforgery antiforgery, [FromForm] string title) => {
    if (!string.IsNullOrWhiteSpace(title))
    {
        var newId = todos.IsEmpty ? 1 : todos.Keys.Max() + 1;
        todos.TryAdd(newId, title);
    }

    // HINWEIS: Für Debugging-Zwecke wird die Seite neu generiert statt umgeleitet.
    // In einer echten Anwendung ist das Post-Redirect-Get Muster (Results.Redirect("/"))
    // die bessere Vorgehensweise, um das erneute Senden von Formularen beim Neuladen zu verhindern.
    string htmlContent = GenerateHtml(todos, context, antiforgery);
    return Results.Content(htmlContent, "text/html", Encoding.UTF8);
});

// DELETE: Ein To-Do löschen. Reagiert nun auf die korrekte HTTP-Methode.
app.MapDelete("/todos/delete/{id}", (int id) => {
    if (todos.TryRemove(id, out _))
    {
        // API-konforme Antwort für JavaScript: Erfolg ohne Inhalt.
        return Results.Ok();
    }
    return Results.NotFound();
});


// --- ENDE DER ENDPUNKTE ---

app.Run();


// --- HILFSFUNKTION ZUR HTML-GENERIERUNG ---

string GenerateHtml(ConcurrentDictionary<int, string> currentTodos, HttpContext httpContext, IAntiforgery antiforgery)
{
    // Ein Anti-Forgery-Token für diese Anfrage generieren.
    var token = antiforgery.GetAndStoreTokens(httpContext);

    var htmlBuilder = new StringBuilder();

    // HTML-Grundgerüst
    htmlBuilder.Append("<!DOCTYPE html>");
    htmlBuilder.Append("<html lang='de'>");
    htmlBuilder.Append("<head>");
    htmlBuilder.Append("<meta charset='UTF-8'>");
    htmlBuilder.Append("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
    htmlBuilder.Append("<title>Meine To-Do Liste</title>");
    // Das Token wird in einem Meta-Tag gespeichert, damit JavaScript darauf zugreifen kann.
    htmlBuilder.Append($"<meta name='{token.HeaderName}' content='{token.RequestToken}'>");
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
            // Jedes Listenelement bekommt eine eindeutige ID
            htmlBuilder.Append($"<li id='todo-{todo.Key}'>");
            htmlBuilder.Append($"<a href='/todos/{todo.Key}'>{todo.Value}</a>");
            // Der Button ruft nun eine JavaScript-Funktion auf, statt ein Formular abzusenden.
            htmlBuilder.Append($"<div class='actions'><button type='button' class='delete' onclick='deleteTodo({todo.Key})'>Delete</button></div>");
            htmlBuilder.Append("</li>");
        }
    }
    htmlBuilder.Append("</ul>");

    // Formular zum Hinzufügen neuer To-Dos
    htmlBuilder.Append("<h2>Neue Aufgabe hinzufügen</h2>");
    htmlBuilder.Append("<form action='/todos' method='post'>");
    // Das versteckte Token-Feld wird für das POST-Formular weiterhin benötigt.
    htmlBuilder.Append($"<input name='{token.FormFieldName}' type='hidden' value='{token.RequestToken}' />");
    htmlBuilder.Append("<input type='text' name='title' placeholder='Was muss getan werden?' required />");
    htmlBuilder.Append("<input type='submit' value='Hinzufügen' />");
    htmlBuilder.Append("</form>");

    // JavaScript zum Senden des DELETE-Requests inkl. Anti-Forgery-Token
    htmlBuilder.Append(@"
        <script>
            function deleteTodo(id) {
                if (!confirm('Sind Sie sicher, dass Sie diese Aufgabe löschen möchten?')) {
                    return;
                }

                const meta = document.querySelector('meta[name^=""RequestVerificationToken""]');
                if (!meta) {
                    alert('Sicherheits-Token nicht gefunden. Bitte laden Sie die Seite neu.');
                    return;
                }
                const tokenHeaderName = meta.getAttribute('name');
                const tokenValue = meta.getAttribute('content');

                fetch(`/todos/delete/${id}`, {
                    method: 'DELETE',
                    headers: {
                        [tokenHeaderName]: tokenValue
                    }
                })
                .then(response => {
                    if (response.ok) {
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
