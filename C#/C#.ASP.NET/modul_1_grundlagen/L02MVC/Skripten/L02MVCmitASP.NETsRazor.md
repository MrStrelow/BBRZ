# Vertiefung: Das ASP.NET Core MVC Framework mit Razor

Aufbauend auf unserem bisherigen Wissen über Web-Grundlagen und die manuell erstellten MVC- und SPA-Strukturen, tauchen wir nun in das **ASP.NET Core MVC Framework** ein. Dieses Framework nimmt uns viel Arbeit ab, die wir zuvor manuell erledigt haben (wie das Erstellen von HTML mit einem `StringBuilder`) und bietet eine robuste, standardisierte Struktur für den Bau komplexer Webanwendungen.

### Was ist Dependency Injection (DI)?

Bevor wir ins Framework einsteigen, müssen wir ein zentrales Konzept von ASP.NET Core verstehen: Dependency Injection (DI). DI ist ein Entwurfsmuster, bei dem eine Klasse ihre Abhängigkeiten (also andere Objekte, die sie für ihre Arbeit benötigt) von einer externen Quelle erhält, anstatt sie selbst zu erstellen.

* **Ohne DI:** Ein Controller müsste seine Services selbst instanziieren: `var meinService = new MeinService();`. Das führt zu eng gekoppelten Klassen, die schwer zu testen und zu warten sind.
* **Mit DI:** Der Controller deklariert im Konstruktor, was er braucht. Das Framework kümmert sich darum, eine Instanz bereitzustellen.

```csharp
public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;

    // Der Controller sagt, er braucht einen IRestaurantService.
    // Das Framework "injiziert" automatisch eine passende Instanz.
    public RestaurantController(IReastaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    // ... Actions ...
}
```
ASP.NET Core hat einen eingebauten DI-Container. In der `Program.cs`-Datei werden Services registriert (z.B. `builder.Services.AddScoped<IRestaurantService, RestaurantService>();`), und das Framework weiß dann, wie es Abhängigkeiten auflösen muss.

### Die Brücke zur Datenbank: Entity Framework Core in MVC

In unseren bisherigen Beispielen haben wir eine statische Klasse (`RestaurantDbContext`) als In-Memory-Datenbank verwendet. In echten Anwendungen nutzen wir einen **Object-Relational Mapper (ORM)** wie **Entity Framework Core (EF Core)**. EF Core übersetzt unsere C#-Klassen (Models) in Datenbanktabellen und ermöglicht uns, Datenbankabfragen mit C# (über LINQ) statt mit SQL zu schreiben.

#### Dependency Injection des EF Core DbContext

Anstatt einer statischen Klasse erstellen wir mit EF Core eine Klasse, die von `DbContext` erbt. Diese Klasse ist unsere Schnittstelle zur Datenbank. Damit unsere Controller und Services sie nutzen können, registrieren wir sie im DI-Container in der `Program.cs`.

```csharp
// In Program.cs
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RestaurantDbContext>(options =>
    options.UseSqlServer(connectionString)); // oder UseSqlite, etc.
```
Jetzt kann jede Klasse, die den `RestaurantDbContext` benötigt, ihn einfach über den Konstruktor anfordern:

```csharp
public class RestaurantService : IRestaurantService
{
    private readonly RestaurantDbContext _context;

    // Der DbContext wird vom DI-Container injiziert.
    public RestaurantService(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<List<Dish>> GetAllDishesAsync()
    {
        // Wir können nun direkt auf die Datenbank zugreifen.
        return await _context.Dishes.ToListAsync();
    }
}
```

#### Das Zusammenspiel: Models, Entities und die Datenbank

Der `/Models`-Ordner in einer MVC-Anwendung bekommt jetzt eine klar definierte Aufgabe: Er enthält die **Entities**. Eine Entity ist eine C#-Klasse, die direkt einer Tabelle in der Datenbank entspricht. EF Core verwendet Konventionen, um diese Klassen zu mappen:
* Eine Klasse `Dish` wird zur Tabelle `Dishes`.
* Eine Eigenschaft `public int Id { get; set; }` wird zum Primärschlüssel.
* Andere Eigenschaften (`string Name`, `decimal Price`) werden zu Spalten in der Tabelle.
* Beziehungen (z.B. `public ICollection<Dish> Dishes { get; set; }` in der `Menu`-Klasse) werden zu Fremdschlüsselbeziehungen in der Datenbank.

Die Models (Entities) sind also **ausschließlich für die Repräsentation der Datenbankstruktur und -beziehungen zuständig**. Sie enthalten die Logik, die direkt mit den Daten zu tun hat.

### Der Controller und seine Actions

Im MVC-Framework ist ein Controller eine Klasse, die von `Microsoft.AspNetCore.Mvc.Controller` erbt. Seine Aufgabe ist es, HTTP-Anfragen zu empfangen, die Benutzereingaben zu verarbeiten, mit dem Model zu interagieren (oft über einen Service) und eine Antwort zu generieren.

**Actions** sind öffentliche Methoden innerhalb eines Controllers, die auf Anfragen reagieren. Das Framework mappt eine URL anhand von Konventionen auf eine bestimmte Action.
* `GET /Restaurant/Index` ruft die `Index()`-Action im `RestaurantController` auf.
* `GET /Restaurant/Details/5` ruft die `Details(int id)`-Action auf und übergibt `5` als Parameter.

Actions geben einen Typ zurück, der `IActionResult` implementiert. Dies sind die Framework-Äquivalente zu den `Results`-Typen aus den Minimal APIs:
* `return View(model);` -> Sendet eine gerenderte HTML-Seite zurück (ähnlich `Results.Content(html, "text/html")`).
* `return RedirectToAction("Index");` -> Sendet einen 302-Redirect an den Browser (ähnlich `Results.Redirect()`).
* `return NotFound();` -> Sendet eine 404-Antwort.
* `return Ok(data);` -> Sendet eine 200-Antwort mit JSON-Daten (für APIs).

### Routing in ASP.NET Core MVC

Routing ist der Prozess, der eine eingehende URL analysiert und entscheidet, welcher Controller und welche Action-Methode dafür zuständig ist.

* **Konventionsbasiertes Routing:** Dies ist der klassische Ansatz. In `Program.cs` wird eine Vorlage definiert, z. B. `app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");`. Eine URL wie `/Products/Details/5` passt auf dieses Muster: `controller` ist "Products", `action` ist "Details" und `id` ist "5".
* **Post-Redirect-Get (PRG) Pattern:** Dies ist ein wichtiges Konzept zur Vermeidung von doppelten Formular-Einreichungen.
    1.  **POST:** Der Benutzer sendet ein Formular ab. Der Server verarbeitet die Daten (speichert sie z.B. in der Datenbank).
    2.  **Redirect:** Nach erfolgreicher Verarbeitung sendet der Server **kein HTML**, sondern eine HTTP 302 Redirect-Antwort an den Browser. Diese Antwort enthält die URL einer neuen Seite (z.B. die Bestätigungsseite). In MVC wird dies mit `return RedirectToAction("Success");` erreicht.
    3.  **GET:** Der Browser empfängt die Redirect-Antwort und sendet automatisch eine neue `GET`-Anfrage an die angegebene URL.
    * **Vorteil:** Wenn der Benutzer nun die Seite aktualisiert (F5 drückt), wird nur die harmlose `GET`-Anfrage wiederholt, nicht die `POST`-Anfrage, die die Daten erstellt hat.

### Die View mit Razor und Tag Helpers

Anstatt HTML mühsam in einem `StringBuilder` zusammenzusetzen, verwenden wir die **Razor-Syntax**. Razor ist eine Template-Engine, die es uns erlaubt, C#-Code direkt in HTML-Dateien (`.cshtml`) einzubetten. Das `@`-Zeichen markiert den Beginn von C#-Code.

```csharp
@* Datei: Views/Restaurant/Index.cshtml *@
@model RestaurantViewModel

<h1>@Model.Title</h1>

<h2>Bisherige Rechnungen</h2>
<ul>
    @foreach (var bill in Model.Bills)
    {
        <li>Rechnung #@bill.Id - Betrag: @bill.Amount.ToString("C")</li>
    }
</ul>
```
**Tag Helpers** sind dabei eine enorme Hilfe. Es sind server-seitige Komponenten, die wie normale HTML-Tags aussehen, aber vom Framework verarbeitet werden, um HTML zu generieren. Man erkennt sie meist am `asp-` Präfix.

* **Formulare und Links:**
    ```html
    <a asp-controller="Restaurant" asp-action="Details" asp-route-id="@bill.Id">Details</a>
    @* Generiert: <a href="/Restaurant/Details/123">Details</a> *@
    ```
* **Model-Bindung in Formularen:**
    ```html
    <form asp-action="Create" method="post">
        <label asp-for="CustomerName"></label>
        <input asp-for="CustomerName" class="form-control" />
        <span asp-validation-for="CustomerName" class="text-danger"></span>
    </form>
    @* asp-for generiert <label for="CustomerName">...</label> und <input id="CustomerName" name="CustomerName" ... /> *@
    @* asp-validation-for zeigt automatisch Validierungsfehler für dieses Feld an. *@
    ```

### Die klare Trennung: Model vs. ViewModel im Detail

Mit EF Core wird die Trennung zwischen Model und ViewModel noch wichtiger und klarer:

* **Model (Entity):**
    * **Zweck:** Repräsentiert 1:1 eine Tabelle in der Datenbank.
    * **Ort:** `/Models`-Ordner.
    * **Inhalt:** Eigenschaften, die den Spalten der Tabelle entsprechen. Enthält Konfigurationen oder Annotations für EF Core (z.B. `[Key]`, `[MaxLength(100)]`).
    * **Verwendung:** Wird **nur** in der Datenzugriffsschicht (DbContext, Services, Repositories) verwendet. **Es sollte niemals direkt an eine View übergeben werden.**

* **ViewModel:**
    * **Zweck:** Dient als **Datencontainer und Schnittstelle speziell für eine View**. Es formt die Daten genau so, wie die View sie benötigt.
    * **Ort:** Oft in einem eigenen Ordner, z.B. `/ViewModels`.
    * **Inhalt:**
        * Nur die für die Anzeige notwendigen Daten (kann Daten aus mehreren Models kombinieren).
        * **Data Annotations** für die UI-Validierung (`[Required]`, `[StringLength]`, etc.).
        * Anzeige-spezifische Logik (z.B. eine Methode, die einen formatierten String zurückgibt).
    * **Verwendung:** Wird vom Controller erstellt, an die View übergeben und von der View zurück an den Controller gesendet. Es ist die Brücke zwischen der Benutzeroberfläche und der Anwendungslogik.

Der Datenfluss ist somit klar definiert:
**Datenbank <-> Model (Entity) <-> Service/DbContext <-> Controller <-> ViewModel <-> View**

### Die Rolle von Services in MVC

Controller-Actions sollten "dünn" sein. Komplexe Geschäftslogik (Berechnungen, externe API-Aufrufe, mehrstufige Datenbankoperationen) gehört nicht in den Controller, sondern in eine separate **Service-Schicht**.

Der Datenfluss ist dann: **Controller -> Service -> DbContext/Repository**.
Der Controller orchestriert nur den Aufruf:
1.  Empfängt die HTTP-Anfrage und das ViewModel.
2.  Ruft die entsprechende Methode im Service auf.
3.  Der Service führt die Logik aus (mithilfe des `DbContext`) und gibt ein Ergebnis zurück.
4.  Der Controller wandelt das Ergebnis in ein `IActionResult` um.

### Sicherheit: CSRF und der AntiForgeryToken

Das `[ValidateAntiForgeryToken]`-Attribut schützt vor **Cross-Site Request Forgery (CSRF)**-Angriffen.
* **Was ist ein CSRF-Angriff?** Ein Angreifer bringt den Browser eines authentifizierten Benutzers dazu, unbemerkt eine Anfrage an eine andere Webseite zu senden, auf der der Benutzer angemeldet ist (z.B. `POST /Bank/Transfer?amount=1000`). Da der Browser die Cookies des Benutzers mitsendet, hält die Bank die Anfrage für legitim.
* **Wie funktioniert der Schutz?**
    1.  ASP.NET bettet in jedes Formular ein verstecktes, einzigartiges und zufälliges Token ein (mit `@Html.AntiForgeryToken()` oder automatisch durch Tag Helper).
    2.  Dieses Token wird auch in einem Cookie gespeichert.
    3.  Beim Absenden des Formulars werden beide Tokens an den Server gesendet.
    4.  Das `[ValidateAntiForgeryToken]`-Attribut prüft, ob beide Tokens vorhanden sind und übereinstimmen. Ein Angreifer kann das Token aus dem Formular nicht kennen, daher schlägt die Validierung fehl.
* **Was, wenn man es ausschaltet?** Für APIs, die von externen Programmen (nicht von Browser-Formularen) genutzt werden, ist dieser Schutz oft hinderlich. Schaltet man ihn aus (wie mit `.DisableAntiforgery()` in unseren Minimal API Beispielen), kann man `POST`-Anfragen direkt von Tools wie einer `.http`-Datei senden. Diese Tools simulieren keinen Browser und können das Token-Verfahren nicht ohne Weiteres nachbilden.

### Fehlerkommunikation mit dem Client: Exceptions vs. Result-Patterns

Wenn auf dem Server etwas schiefgeht, muss dies dem Client mitgeteilt werden.
* **Exceptions:** Eine nicht abgefangene Exception führt serverseitig zu einem Absturz der Anfrage und clientseitig zu einer generischen `500 Internal Server Error`-Antwort. Das ist nicht benutzerfreundlich.
* **Result-Pattern (für den Client):** Anstatt sich auf Exceptions zu verlassen, kommuniziert der Server Fehler kontrolliert.
    * **Für MVC-Views:** Das "Result" ist das erneute Anzeigen der View mit den Fehlern im `ModelState`. Der Client erhält einen `200 OK`-Status, aber der HTML-Body enthält die Fehlerinformationen, die der Benutzer lesen kann.
    * **Für APIs:** Statt eines `500`-Fehlers sendet der Controller einen `400 Bad Request` oder `404 Not Found` mit einem strukturierten JSON-Objekt, das die Fehler beschreibt. z.B.: `{ "success": false, "errors": ["Der Name darf nicht leer sein."] }`. Dies ermöglicht es einem SPA-Frontend, die Fehler gezielt zu verarbeiten und anzuzeigen.

### Serverseitige Validierung und die Anzeige in der View

#### Validierungsfehler in der View: Warum kein Redirect?

Dies ist ein entscheidender Punkt für die Benutzerfreundlichkeit bei der Formularverarbeitung. Betrachten wir den Fehlerfall in einer POST-Action:

```csharp
[HttpPost]
public IActionResult Create(FruehstueckViewModel viewModel)
{
    if (!ModelState.IsValid)
    {
        // FALSCH: return RedirectToAction("Create");
        // RICHTIG:
        return View(viewModel); 
    }
    // ...
}
```
**Warum `return View(viewModel);` und nicht `RedirectToAction()`?**

1.  **`return View(viewModel);`**: Diese Anweisung nimmt das **aktuelle `viewModel`-Objekt**, das alle (auch die falschen) Eingaben des Benutzers enthält, sowie das `ModelState`-Objekt mit den dazugehörigen Fehlermeldungen, und rendert die `Create.cshtml`-View **erneut**. Das Ergebnis ist eine HTML-Seite, auf der der Benutzer seine ursprünglichen Eingaben sieht und daneben die Fehlermeldungen (z.B. "Dieses Feld wird benötigt."), angezeigt durch den `asp-validation-for`-Tag Helper.
2.  **`return RedirectToAction("Create");`**: Ein Redirect ist eine `302`-Antwort, die den Browser anweist, eine **völlig neue `GET`-Anfrage** an `/Controller/Create` zu senden. Bei dieser neuen Anfrage gehen alle Kontextinformationen des fehlgeschlagenen `POST`-Versuchs verloren:
    * Das `viewModel` mit den Benutzereingaben ist weg.
    * Das `ModelState` mit den Validierungsfehlern ist weg.
    * Der Benutzer sieht wieder ein **leeres Formular**, ohne Hinweis darauf, was falsch war.

**Fazit:** Um Benutzereingaben zu erhalten und kontextbezogene Fehlermeldungen anzuzeigen, muss bei einem Validierungsfehler die View direkt aus der POST-Action heraus neu gerendert werden.