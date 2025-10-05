using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Initialisiert unserer Dictionary mit Testdaten beim Start.
RestaurantDbContext.Initialize();

// Erstelle einen Controller
var controller = new RestaurantController(app);

// ... und registriere die http-get und -post methoden.
controller.RegisterIndexPost();
controller.RegisterIndexGet();

app.Run();