using MvcTodoApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Dependency Injection. Wir verwenden ITodoRepository im Controller und sagen hier es soll:
// * immer eine neue Instanz - Scoped, also immer new TodoRepository() wird aufgerufen.
// * der Typ soll TodoRepository sein, welches in der Ist Beziehung mit ITodoRepository sein muss.
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();

app.UseStaticFiles(); // Statische Dateien (CSS, JS, Bilder) aus wwwroot bereitstellen

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}");

app.Run();