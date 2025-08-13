var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var todos = new Dictionary<int, string>();
todos.TryAdd(1, "einkaufen");
todos.TryAdd(2, "pumpi");
todos.TryAdd(3, "modul 2 test schreiben");
todos.TryAdd(4, "modul 3 test schreiben");

// Lege Endpoints fest - Welche http requests erkenne ich?
// CRUD

// Create
app.MapPost("/", () => "Hello World!");

// Read
app.MapGet("/", () => "Hello World!");

// Update
app.MapPut("/", () => "Hello World!");

// Delete
app.MapDelete("/", () => "Hello World!");

app.Run();
