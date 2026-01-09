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

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 15 minuten nach Ende des Tests zu schicken)
* Viel Erfolg! :)

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., (Schulnotensystem)

---

## Vorbereitung (bevor die Prüfung startet)
* **Wie öffne ich die Vorlage?**
    1) Entpacke das [Zib-Archiv](Vorlage_WebProgModulTest1_122025.zip). Dieses beinhaltet eine Vorlage für die Geamte Prüfung.
    2) Drücke doppelt auf die **.sln** oder **.slnx** Datei. Diese wird dadurch mit ``Visual Studio`` geöffnet. Falls nicht siehe dem README File innerhalb von [Zib-Archivs](Vorlage_WebProgModulTest1_122025.zip)
    3) Damit das ``Projekt`` *Aufgabe_2* fehlerfrei startet, muss eine ``Datenbank`` mit Namen *TemporaryExamDb* erstellt werden. Das ist mit dem *View->SQL-Server-Object-Explorer* in ``Visual Studio`` (oder mit dem ``SQL Server Management Studio``) möglich. Falls keine Rechte dazu besessen werden, siehe weiter unten. 
    (Es kann jeder Name verwendet werden, jedoch muss die ``Datenbank`` welche in *appsettings.json* verwendet wird, am ``SQL-Server`` existieren.) 
    4) Führe folgende Schritte aus:
        * Gib in der ``Developer PowerShell`` *cd Aufgabe_2* ein. Wir wechseln den Ordner in den Ordner des Projekts.
        * Gib in der ``Developer PowerShell`` *dotnet clean* und dann *dotnet build Aufgabe_2* ein. Es dürfen keine Fehler entstanden sein.
        * Gib in der ``Developer PowerShell`` *dotnet tool install --global dotnet-ef* ein.
        * Gib in der ``Developer PowerShell`` *dotnet ef database update* ein.
        * Überprüfe im ``SQL-Object-Explorer``, ob folgendes vorhanden ist: 
        
            ![alt](sql-obj-explorer.png)
    5) Führe das ``Projekt`` *Aufgabe_2* aus. Es soll eine Website sichtbar sein, welche vom Benutzer ohne Fehler bedient werden kann.

* **Die Verbindung zur ``Datenbank`` mit  ``EF-Core`` funktioniert nicht.**
    Es muss folgendes Installiert sein:
    1) Öffne den ``Task Manager``, gehe zu ``Dienste`` und suche nach ``SQL Server Agent (SQLExpress)``. Sollte das nicht der Fall sein, dann rufe [diesen](https://go.microsoft.com/fwlink/p/?linkid=2216019&clcid=0x409&culture=en-us&country=us) Installer auf (Falls nicht möglich suche nach SQL Server Express in Google).
    2) Installiere den SQL Server und verwende folgenden Connection String ``"Server=localhost\\SQLEXPRESS; Database=TemporaryExamDb; Trusted_Connection=True; TrustServerCertificate=True;"``

    Falls dein User keine Rechte hat um eine ``Datenbank`` anzulegen, rufe folgende Befehle auf:
    1) Öffne nach Abschluss der Installation den ``Terminal`` und gib ``sqlcmd -S localhost\SQLEXPRESS`` ein.
    2) Gib dort 
        ```sql
        CREATE LOGIN [DOMAIN\USERNAME] FROM WINDOWS;
        GO
        ``` 
        ein
    3) Danach gib 
        ```sql
        ALTER SERVER ROLE sysadmin ADD MEMBER [DOMAIN\USERNAME];
        GO
        ```
        ein.
    4) Es soll nun möglich sein eine Datenbank anzulegen (Adminrechte) und sich mit dem oben agegebene Connection string ohne passwort zu verbinden.
    
---

## **Aufgabe_1:** http und html [20 / 100 Punkte]

### Theorie [20 / 20 Teilpunkte]
1) Wann soll die ``http-Methode`` *get* und wann ``http-Methode`` *post* verwendet werden?
2) Wo werden bei einem ``Request`` der ``http-Methode`` *post* die ``Parameter`` übermittelt?
3) Wie werden bei einem ``Request`` der ``http-Methode`` *get* die ``Parameter`` übermittelt? 
4) Welche Symbole trennen mehrere ``Parameter`` und wie wird der Beginn dieser ``Parameter`` gekennzeichnet?

---

## **Aufgabe_2:** Model, View, Control, Services, ViewModels und DTOs [80 Punkte]
### Programmverständnis [15 / 80 Teilpunkte]
In folgendem ``Controller`` und ``View`` haben sich ein Fehler eingeschlichen. Finde und behebe diese. Erkläre warum es ein Fehler oder ein konzeptionell falscher Ansatz ist.

1) ``View``
```csharp
@model FruehstuecksModel

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
[HttpDelete]
public async IActionResult Index()
{
    ViewBag.Title = "Frühstücksbestellung";
    var view = FruehstuecksService.CreateView();
    view.Menus = await _context.Menus.ToList();

    return Service("Index", view);
}
```

---

### Programmieren [55 / 80 Teilpunkte]
Im ``Projekt`` *Aufgabe_2* befindet sich funktionierender ``Code``. Damit dieses fehlerfrei startet muss eine ``Datenbank`` mit Namen *TemporaryExamDb* erstellt und befüllt werden. Siehe [Vorbereitung](#vorbereitung-bevor-die-prüfung-startet). (Es kann jeder Name verwendet werden, jedoch muss die ``Datenbank`` welche in *appsettings.json* verwendet wird, am ``SQL-Server`` existieren.)

Vervollständige das Programm in den angegebenen Ebenen durch folgende ``Klassen``:
* ``TableController``: Dieser beinhaltet eine ``Methode`` *Details* und eine ``Methode`` *Create*. 
    * *Details*: 
        1) Diese nimmt die ``http-Methode`` *get* für einen spezielles ``Model`` *Table* entgegen. Diese ``Action`` gibt ein ``ViewModel`` *TableViewModel* mit der ``Eigenschaft`` *Id*, *TableNumber* und *Beliebtheit* des ``Model`` *Table* von der ``View`` an den ``Controller`` weiter. Entsprechende Fehlermeldungen sollen mit den ``Attributen`` an die ``View`` mithilfe des *ModelStates* weitergegeben werden. Der Aufruf der ``Action`` *Details* wird durch einen Klick auf ein *Table* in der List aller *Tables* auf der "Hauptseite aufgerufen. **Das Verhalten der Hauptseite Index.cshtml (Statt der Dropdown Selection soll eine Liste verwendet werden, wie bei den Dishes und es müssen Links einfügen mit ``<a asp-controller="..." asp-action="...">ein link</a>``).**
    
* ``TableViewModel``: Die im *TableController* implementierte ``Action`` *Details* bekommt das *TableViewModel* als ``Parameter`` übermittelt. Innerhlab des ``ViewModel`` *TableViewModel* soll ein ``Attribut`` verwendet werden um die Gültigkeit der ``Eigenschaft`` *Id* sicherzustellen. Prüfe hier auf *Range(1, int.MaxValue, ...)* und verwende *Required(...)*. Implementiere zudem eine ``Methode`` *ToDto* welche aus einem ``ViewModel`` *TableViewModel* ein ``DTO`` *TableDto* macht.

* ``TableDto``: Dieses soll die ``Eigenschaften`` *TableNumber* und *Beliebtheit*  besitzen. Es wird für die Kommunikation mit dem ``Service`` *TableService* verwendet.

* ``TableService``: Der ``Parameter`` der ``Methode`` *CreateTable* ist ein ``DTO`` *TableDto*. Erstelle ein neues ``Model`` *Table* und belege die ``Eigenschaften`` *TableNumber* und *Beliebtheit*. Frage die Datenbank ab und zähle wie oft ein spezieller Tisch (gleiche id) gebucht wurde. Verwende ``LINQ`` um die ``Eigenschaft`` *Beliebtheit* als Summe der *Visits* der *Tables* zu berechnen. *Visits* ist eine ``Eigenschaft`` des ``Models`` *Table*.

* ``View``: Verwende aus der **Vorlage** das ``cshtml`` mit Namen *Details* welches im Ordner *Dish* liegt, sowie das ``cshtml`` mit Namen *Create* welches im Ordner *Menu* liegt. Dieser Code ist auskommentiert, kommentiere diesen ein um fortzufahren. **Passe diesen für die View der Tables an**. Implementiere zudem im ``cshtml`` mit Namen *Index* welches im Ordner *Fruehstueck* liegt,den aufruf der ``http-Requests`` *get* *Table*. 

>**Amerkung:** Die ``Klassen`` für ``Models`` und ``Data`` (Datenbank) sind bereits fertig implementiert. Diese sind nicht zu verändern.

>**Hinweis:** Nutze die Implementierungen in den bereits getätigten Klassen als Vorlage. Die Startklasse ist nicht zu ändern!

---

### Theorie [10 / 80 Teilpunkte]
1) Was ist ``Dependency Injection`` und was tun wir in Webprogrammieren damit?
2) Beschreibe den Unterschied zwicshen einem ``Service`` und einem ``Controller``? 