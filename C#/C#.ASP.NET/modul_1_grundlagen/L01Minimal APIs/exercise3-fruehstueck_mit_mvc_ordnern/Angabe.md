# Angabe: Frühstücksrestaurant Webanwendung - neue Ordner einführen

## Übersicht
Es ist eine kleine Exercise, welche sich nur mit der Ordnerstruktur beschäftigt. Es ist das gleiche wie in [Exercise 1](../exercise1-fruehstueck_mit_minimal_api/Angabe.md) zu lösen. Verwende dazu die [Lösung](../exercise1-fruehstueck_mit_minimal_api/) aus Exercise 1.

## Ordner struktur von Model, View und Controller mit Datenbank
Erzeuge folgende Ordner
```
/FruehstuecksBestellungMVC
|-- /Controllers
|   |-- FruehstueckController.cs
|-- /Data
|   |-- RestaurantDbContext.cs
|-- /Models
|   |-- Bill.cs
|   |-- Customer.cs
|   |-- Dish.cs
|   |-- Menu.cs
|   |-- PreperationStep.cs
|   |-- Ingredient.cs
|   |-- SeedData.cs
|   |-- Table.cs
|   |-- Visit.cs
|-- /Views
|   |-- /Fruehstueck
|   |   |-- Index.cshtml
|-- appsettings.json
|-- Program.cs
```

Lagere die Vorhandenen Methoden in der ``Program.cs`` passend zu dem Konzept von ``Model``, ``View`` und ``Controller`` (``MVC``) aus. 

Verwende dazu diese Vorlage;

* **Program**: 
    ```csharp
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
    ```
    
* **Data**: Keine Vorlage notwendig.
* **Model**: Keine Vorlage notwendig.
* **View**: 
    ```csharp
    using System.Globalization;
    using System.Text;

    namespace View.Restaurant;
    public class Index
    {
        public string Html { get; private set; }

        public Index(
            string title,
            List<Customer> customers,
            List<Menu> menus,
            List<Table> tables,
            List<Dish> dishes,
            List<Bill> bills
        )
        {
            // TODO
        }
    }
    ```

* **Controller**: 
    ```csharp
    using System.Text;

    public class RestaurantController
    {
        private readonly WebApplication _app;

        public RestaurantController(WebApplication app)
        {
            _app = app;
        }

        // http-methode: GET mit Ressource /Restaurant/Index
        // Generiert und liefert die Haupt-HTML-Seite mit dem Formular und der Rechnungsliste.
        public void RegisterIndexGet()
        {
            _app.MapGet(
                var view = new View.Restaurant.Index( // TODO)
                // TODO
            );
        }

        // POST /Restaurant/Index
        // Verarbeitet die Formulardaten und erstellt eine neue Bestellung.
        public void RegisterIndexPost()
        {
            _app.MapPost(
                // TODO
            ).DisableAntiforgery();
        }
    }
    ```