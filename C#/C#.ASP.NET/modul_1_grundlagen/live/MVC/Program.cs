using MVCTodoApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ITodoRepository, TodoRepositoryInMemory>(); // new TodoController(new TodoRepositoryInMemory());

var app = builder.Build();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}");


app.Run();
