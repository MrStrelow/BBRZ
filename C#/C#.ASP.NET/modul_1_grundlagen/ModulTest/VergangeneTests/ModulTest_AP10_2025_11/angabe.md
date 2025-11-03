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

##  [40 / 100 Punkte]

### Programmverständnis [20 / 40 Teilpunkte]

```
http response header und request header
beschreibe den ablauf wie das routing ist
```

1) Finde die Fehler in diesem Code und markiere diese.
2) Erkläre wieso diese Fehler zu einer nicht gültigen bzw. konzeptionell falschen `Guard Clause` führen. 

---

### Theorie [20 / 35 Teilpunkte]
1) http get ist für dies und post für das
2) http delete kann nicht als form übergeben werden. wie geht das dann?
3) javascript ist client seitig und mvc .net ist server seitig
4) parameter in post ist in der url oder in get
5) 200 ok und 400 und 500 nicht ok

---

## Model, View, Control, Services, ViewModels und DTOs [60 Punkte]
### Programmverständnis [20 / 60 Teilpunkte]
In folgendem ``Controller`` und ``View`` haben sich ein Fehler eingeschlichen. Finde und behebe diese. Erkläre warum es ein Fehler oder ein konzeptionell falscher Ansatz ist.

```csharp
es fehlt der parameter.
es wird kein viewmodel der view übergeben sondern ein array.
im cshtml wird kein @model angewandt sondern direkt aus der datenbank gelesen.
``` 

---

### Programmieren [30 / 60 Teilpunkte]
Verwende die Vorlage (*[Vorlage_Aufgabe_02-02_Programmieren.zip](Vorlage_Aufgabe_2-02_Programmieren.zip)*) und vervollständige das Programm in den angegebenen Ebenen durch folgende ``Klassen``:
* ``View``: Erstelle ein ``cshtml`` mit Namen *Details* welches im Ordner *Dish* liegt. Implementiere dort folgendes Verhalten:
    1) Lies aus dem vom ``Controller`` *DishController* übermittelten ``ViewModel`` *DishViewModel* die benötigten ``Eigenschaften`` für die Darstellung des ``cshtml`` *Details* aus. Verwende dazu *@model DishViewModel*.  
    2) Es soll der ``ModelState`` verwendet werden um bei fehlerhaften ``http-Requests`` den User darüber zu informieren. Verwende dazu die ``Tag-helper`` *asp-validation-summary* oder *asp-validation-for*. 
    3) Die Logik der ``Server-Seitigen`` ``Validierung`` ist im ``DishViewModel`` durch ``Attribute`` und/oder der ``Methode`` *Validate* umzusetzen. Die ``Methode`` *Validate* ist von dem ``Interface`` *IValidatableObject* zu implementieren. 
    4) Verwende *bootstrap* nach belieben. Siehe [Bild](#erwarteter-output) **Achte jedoch auf die Zeit! Der Punkt des Designs ist für diese Prüfung der am wenigsten relevante.**
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

Die Klassen sind bereits erstellt und die dort stehenden TODOs sind zu implementieren.

>**Amerkung:** Die ``Klassen`` für ``Models`` und ``Data`` (Datenbank) sind bereits fertig implementiert. Diese sind nicht zu verändern.

>**Hinweis:** Nutze die Implementierungen in den bereits getätigten Klassen als Vorlage. Die Startklasse ist nicht zu ändern! Alles wo ein TODO: steht ist anzupassen.

#### Erwarteter Output:
Bilder von View und Controller.

---

### Theorie [10 / 60 Teilpunkte]
1) Wie schaffen wir es im ``Controller`` und ``Services`` einen Zugriff auf den ``DbContext`` zu bekommen?
2) Was beschreibt ein ``ViewModel`` und was ein ``Model``? **Hinweis:** Was verwendet die ``Datenbank`` und was die ``View``?
3) Was sind ``Tag-Helper``? Ein Benutzer geht ins Kontextmenü (Rechtsklick) und navigiert auf der Websitezu zu *Quellcode anzeigen* (CTRL+u). Finden wir in dem angezeigten ``html-file`` ``Tag-Helper`` wie z.B. *asp-controller* und *asp-action*? 
4) Was ist eine ``Action`` in einem ``Controller``? Was hat diese mit ``http-Methoden`` wie z.B. *Post* zu tun?
5) Was erlaubt uns die ``Razor``-``Syntax`` *@* in einem ``cshtml``-file? Ein Benutzer geht ins Kontextmenü (Rechtsklick) und navigiert auf der Websitezu zu *Quellcode anzeigen* (CTRL+u). Finden wir in dem angezeigten ``html-file`` die ``Razor``-``Syntax`` *@* wie z.B. *@model*, *@for* und *@if*?  
```