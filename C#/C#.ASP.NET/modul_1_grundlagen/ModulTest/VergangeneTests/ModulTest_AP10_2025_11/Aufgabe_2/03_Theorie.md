1) Wie schaffen wir es im ``Controller`` und ``Services`` einen Zugriff auf den ``DbContext`` zu bekommen?
    * Mithilfe der sogenannten ```Dependency-Injection``. Wir konfigurieren das in der ``Main`` *Programm.cs*. In den ``Services`` und ``Controller`` schreiben wir dann einen ``Konstruktor`` welcher ein ``Objekt`` vom ``Typ`` *DbContext* entgegen nimmt.
2) Was ist die Zuständigkeit eines ``ViewModel`` und was ist jene eines ``Model``? **Hinweis:** Was verwendet die ``Datenbank`` und was die ``View``?
    * Die ``Eigenschaften`` und ``Methoden`` in einem ``ViewModel`` sind auf die ``Zuständigkeiten`` der ``View`` angepasst. Das ``Model`` ist auf die ``Zuständigkeiten`` der ``Datenbank`` angepasst.
3) Was sind ``Tag-Helper``? Ein Benutzer geht ins Kontextmenü (Rechtsklick) und navigiert auf der Websitezu zu *Quellcode anzeigen* (CTRL+u). Finden wir in dem angezeigten ``html-file`` ``Tag-Helper`` wie z.B. *asp-controller* und *asp-action*? 
    * ``Tag-Helper`` sind spezielle ``Tags`` in ``cshtml`` (``Razor``) files. Sie erlauben uns mehr bzw. kürzere Aufrufe als reine ``html-tags``. Z.B muss nicht direkt eine ``URL`` in
        ```html
        <a href="/Dish/Index/1">
            Wiener Fr&#xFC;hst&#xFC;ck
        </a>
        ```
    angegeben werden, sondern es reicht
        ```html
        <a asp-controller="Dish" asp-action="Index" asp-route-id="@dish.Id">
            @dish.Name
        </a>
        ```
    zu schreiben. Wir trennen dadurch ``URLs`` von dem ``Routing`` in unserer ``View``.
    * Nein, da die ``Tag-Helper`` nicht korrekter ``html`` Code ist und nur in ``Razor`` (*cshtml*) verstanden wird. ``Razor`` erzeugt dann ein ``html`` file, welches ohne dies ``Tag-Helper`` auskommt.
4) Was ist eine ``Action`` in einem ``Controller``? Was hat diese mit ``http-Methoden`` wie z.B. *Post* zu tun?
    * Eine ``Action`` ist eine ``Methode`` in einem ``Controller``. Diese soll auf ``http-Requests`` reagieren und eine ``Response`` an den Client senden. Das passiert über *View()* oder *RedirectToAction()*.
    * Eine ``http-Methode`` *post*, soll eine entsprechende ``Action`` im ``Controller`` haben. Die ``Action`` soll nur für diese ``http-Methode`` verwendet werden.
5) Was erlaubt uns die ``Razor``-``Syntax`` *@* in einem ``cshtml``-file? Ein Benutzer geht ins Kontextmenü (Rechtsklick) und navigiert auf der Websitezu zu *Quellcode anzeigen* (CTRL+u). Finden wir in dem angezeigten ``html-file`` die ``Razor``-``Syntax`` *@* wie z.B. *@model*, *@for* und *@if*?
    * *@* erlaubt uns ``C#`` Code in der ``View`` (*cshtml*) aufzurufen. 
        * Aufrufe von ``Kontrollstrukturen`` wie *if* und *for*. 
        * ``Variablen`` können am Beginn mit 
            ```csharp
            @{
                int counter = 0;
                bool isCurrentlyVerbose = Model.Ingredients != null && Model.Ingredients.Any();
            }
            ```
            ``definiert`` und ``initialisiert`` werden.
        * Durch *@model* kann z.B. ein *DishViewModel* vom ``Controller`` übergeben werden.