In folgendem ``Controller`` und ``View`` haben sich einige Fehler eingeschlichen. Finde und behebe diese. Erkläre warum es ein Fehler oder ein konzeptionell falscher Ansatz ist.

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

* Es wird der ``View`` ein ``Controller`` übergeben. Konzeptionell sollte ein ``Model`` oder ein ``ViewModel`` übergeben werden.
* Es wird auf einen ``DbContext`` zugegriffen. Konzeptionell darf die ``View`` nicht mit der ``Datenbank`` sprechen. Die ``View`` muss "flach" bleiben. Das bedeutet diese darf Daten aus dem ``Model`` oder ``ViewModel`` holen, aber keine eigenen Abfragen durchführen.

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

* *HttpPost* ist hier nicht das konzeptionell richtige ``Attribut``. Es fehlen dazu auch die "neuen" Daten als ``Parameter`` in  der ``Methode`` *Index*. welche wir erzeugen sollen, wenn wir die ``http-Methode`` *post* umsetzen wollen. Hier werden bereits bestehende Daten aus der ``Datenbank`` abgefragt. Es sollte daher das Attribut ``http-Get`` verwendet werden, um die Verarbeitung einer ``http-methode`` *get* zu signialisieren.