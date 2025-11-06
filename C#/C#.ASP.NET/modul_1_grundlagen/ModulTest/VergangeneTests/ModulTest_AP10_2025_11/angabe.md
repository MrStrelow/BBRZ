# Modultest 1

Sie haben `180 Minuten` Zeit die Aufgaben zu lösen
* Sie können maximal 100 Punkte erreichen
* Es sind zur Prüfung zugelassen:
    * Taschenrechner (wenn erwünscht)
    * Transparente Wasserflasche
    * Papier, Geodreieck, Stifte, usw.
    * Am Computer sind alle Unterlagen sowie die Nutzung des Internets erlaubt.

Die Nutzung des Internets umfasst nicht
* Chatbots
* Veröffentlichung der Lösungen
* sonstige Kommunikation mit anderen Usern

Die Nutzung von allen anderen Dingen, muss vorher mit mir abgesprochen werden
(z.B. Nutzung von Ohropax), ansonsten wird dies als schummeln gewertet. 
Die Folge des Schummeln ist eine Bewertung mit 0 Punkten.

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 10:15 schicken)
* Viel Erfolg! :)

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., (Schulnotensystem)

---

##  [20 / 100 Punkte]

### Theorie [20 / 20 Teilpunkte]
1) Wann soll die ``http-Methode`` *get* und wann ``http-Methode`` *post* verwendet werden?
2) Wie kann die ``http-Methode`` *delete* als ``Request`` request an einen ``Server`` gesendet werden? 
3) Ist der **standardmäßige** Anwendugnsfall von javascript ``client-seitig`` oder ``server-seitig``?
4) Ist der **standardmäßige** Anwendugnsfall von ``asp.net`` ``client-seitig`` oder ``server-seitig``?
5) Wo werden bei einem ``Request`` der ``http-Methode`` *post* die ``Parameter`` übermittelt?
6) Wo werden bei einem ``Request`` der ``http-Methode`` *get* die ``Parameter`` übermittelt?
7) Was bedeutet der ``Serverstatus`` *200*, *300*, *400* und *500*? Wo kann ich diese finden?

---

## Model, View, Control, Services, ViewModels und DTOs [60 Punkte]
### Programmverständnis [15 / 80 Teilpunkte]
In folgendem ``Controller`` und ``View`` haben sich ein Fehler eingeschlichen. Finde und behebe diese. Erkläre warum es ein Fehler oder ein konzeptionell falscher Ansatz ist.

1) ``View``
```csharp
@model FruehstueckController

<div class="border rounded p-3 bg-light" style="max-height: 200px; overflow-y: auto;">
    <ul>
        @foreach (var order in DbContext.Orders.ToList())
        {
            foreach (var menu in order.Menus)
            {
                <li>@menu.Name (Menü)</li>
            }
            foreach (var dish in order.Dishes)
            {
                <li>@dish.Name (Gericht)</li>
            }
        }
    </ul>
</div>
```

2) ``Controller``
```csharp
[HttpPost]
public async IActionResult Index()
{
    ViewBag.Title = "Frühstücksbestellung";
    var view = new FruehstueckView();
    view.Menus = await _context.Menus.ToList();

    return View("Index", view);
}
```

---

### Programmieren [55 / 80 Teilpunkte]
Verwende die Vorlage (*[Vorlage_Aufgabe_02-02_Programmieren.zip](Vorlage_Aufgabe_2-02_Programmieren.zip)*) und führe folgende Schritte aus:
* Datenbank *Exam_112025* erstellen
* in der ``Package-Manager Console`` *dotnet clean* und dann *dotnet build Aufgabe_2* eingeben
* in der ``Package-Manager Console`` *Add-Migration First* und *Update-Database* eingeben 

Falls dies fehlschlägt, öffne die ``Developer-Powershell``
* gib cd Aufgabe_2 ein
* gib *dotnet ef migrations add First* ein. (Falls dieser Befehlt nicht funktioniert, gib davor *dotnet tool install --global dotnet-ef* ein und wiederhole.)
* gib *dotnet ef database update* ein

Überprüfe im ``SQL-Object-Explorer``, ob folgendes vorhanden ist

![alt](sql-obj-explorer.png)

Vervollständige das Programm in den angegebenen Ebenen durch folgende ``Klassen``:
* ``View``: Erstelle ein ``cshtml`` mit Namen *Details* welches im Ordner *Dish* liegt. Implementiere dort folgendes Verhalten:
    1) Lies aus dem vom ``Controller`` *DishController* übermittelten ``ViewModel`` *DishViewModel* die benötigten ``Eigenschaften`` für die Darstellung des ``cshtml`` *Details* aus. Verwende dazu *@model DishViewModel*.  
    2) Es soll der ``ModelState`` verwendet werden um bei fehlerhaften ``http-Requests`` den User darüber zu informieren. Verwende dazu die ``Tag-helper`` *asp-validation-summary* oder *asp-validation-for*. 
    3) Die Logik der ``Server-Seitigen`` ``Validierung`` ist im ``DishViewModel`` durch ``Attribute`` und/oder der ``Methode`` *Validate* umzusetzen. Die ``Methode`` *Validate* ist von dem ``Interface`` *IValidatableObject* zu implementieren. 
    5) In der ``View`` soll durch einen Mausklick auf ein ``html-Element`` *Selection* (mit Dishes befüllt) die ``Action`` *Index* mit der ``http-Methode`` *get* aufgerufen werden.
    ![alt]()
* ``DishController``: Dieser beinhaltet eine ``Methode`` *Index* und eine ``Methode`` *Create*. 
    * *Index*: 
        1) Diese nimmt die ``http-Methode`` *get* für einen spezielles ``Model`` *Dish* entgegen. Diese ``Action`` gibt ein ``ViewModel`` *DishViewModel* mit der ``Eigenschaft`` *Id* des ``Model`` *Dish* von der ``View`` an den ``Controller`` weiter. Das passiert durch einen Klick auf ein *Dish* in der List aller *Dishes* auf der "Hauptseite. Das Verhalten der Hauptseite ist bereits in der Vorlage implementiert. Es muss dort nichts verändert werden.
        2) Dieser nimmt einen ``request-Parameter`` *verbose* entgegen, welcher *true* oder *false* sein kann. 
            * Wenn *false*, wird ein ``ViewModel`` *DishViewModel* der ``View`` gegeben welches die ``Eigenschaften`` *Name* und *Price* eines ``Models`` *Dish* beinhaltet. 
            * Wenn *true*, wird ein ``ViewModel`` *DishViewModel der ``View`` gegeben welches die ``Eigenschaften`` *Name*, *Price*, *Preperationstep* und *Ingredients* eines ``Models`` *Dish* beinhaltet. Entsprechende Fehlermeldungen sollen mit den ``Attributen`` an die ``View`` mithilfe des *ModelStates* weitergegeben werden.
    * *Create*: 
        2) Diese nimmt die ``http-Methode`` *post* entgegen. Als ``Parameter`` wird ein ``ViewModel`` *DishViewModel* empfangen. Wandle dieses mithilfe von der ``Methode`` *ToDto* zu einem ``DTO`` *DishDto* um. Verwende den ``Service`` *DishService* mit der ``Methode`` *CreateDish* welches ein ``DTO`` *DishDto* als ``Parameter`` entgegenimmt. Leite dann mit einem *Redirect()* an die ``Action`` *Index* weiter. 
* ``DishViewModel``: Die im *DishController* implementierte ``Action`` *Index* bekommt das *DishViewModel* als ``Parameter`` übermittelt. Innerhlab des ``ViewModel`` *DishViewModel* soll ein ``Attribut`` verwendet werden um die Gültigkeit der ``Eigenschaft`` *Id* sicherzustellen. Prüfe hier auf *Range(1, int.MaxValue, ...)* und verwende *Required(...)*. Implementiere zudem eine ``Methode`` *ToDto* welche aus einem ``ViewModel`` *DishViewModel* ein ``DTO`` *DishDto* macht.
* ``DishDto``: Dieses soll die ``Eigenschaften`` *Name* besitzen. Es wird für die Kommunikation mit dem ``Service`` *DishService* verwendet.
* ``DishService``: Der ``Parameter`` der ``Methode`` *CreateDish* ist ein ``DTO`` *DishDto*. Erstelle ein neues ``Model`` *Dish* und belege die ``Eigenschaften`` *Ingredients* und *PreparationStep*. Wähle einfachheitshalber die ersten aus der Datenbank mit *await _dbContext.Ingredients.FirstOrDefaultAsync();* aus. Übernimm aus dem ``DTO`` *DishDto* die ``Eigenschaft`` *Name* und verwende den ``Datenbank-Context`` um ein neues ``Model`` in der Datenbank anzulegen.

>**Amerkung:** Die ``Klassen`` für ``Models`` und ``Data`` (Datenbank) sind bereits fertig implementiert. Diese sind nicht zu verändern.

>**Hinweis:** Nutze die Implementierungen in den bereits getätigten Klassen als Vorlage. Die Startklasse ist nicht zu ändern!

#### Erwarteter Output:
Bilder von View und Controller.

---

### Theorie [10 / 80 Teilpunkte]
1) Wie schaffen wir es im ``Controller`` und ``Services`` einen Zugriff auf den ``DbContext`` zu bekommen?
2) Was beschreibt ein ``ViewModel`` und was ein ``Model``? **Hinweis:** Was verwendet die ``Datenbank`` und was die ``View``?
3) Was sind ``Tag-Helper``? Ein Benutzer geht ins Kontextmenü (Rechtsklick) und navigiert auf der Websitezu zu *Quellcode anzeigen* (CTRL+u). Finden wir in dem angezeigten ``html-file`` ``Tag-Helper`` wie z.B. *asp-controller* und *asp-action*? 
4) Was ist eine ``Action`` in einem ``Controller``? Was hat diese mit ``http-Methoden`` wie z.B. *Post* zu tun?
5) Was erlaubt uns die ``Razor``-``Syntax`` *@* in einem ``cshtml``-file? Ein Benutzer geht ins Kontextmenü (Rechtsklick) und navigiert auf der Websitezu zu *Quellcode anzeigen* (CTRL+u). Finden wir in dem angezeigten ``html-file`` die ``Razor``-``Syntax`` *@* wie z.B. *@model*, *@for* und *@if*?  
```