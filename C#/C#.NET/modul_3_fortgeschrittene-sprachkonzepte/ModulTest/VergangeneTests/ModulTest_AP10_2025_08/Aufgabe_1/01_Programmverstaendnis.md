1)
```csharp
var gans = personen.Filter(person => person.Name == "Gans");
```
* Falsch
* Der ``LINQ`` Ausdruck Filter existiert nicht. Es sollte ``Where`` heißen was ein Zeilenfilter bzw. elementwise filter ist. (In der Fachsprache ist es eine Restriktion oder sehr verwirrend, Selektion.)
>**Korrekt wäre:** (nicht gefragt, aber angenehmer zum Lernen) 
```csharp
var gans = personen.Where(person => person.Name == "Gans");
```

2)
```csharp
int grenze = 3;
bool sindAlleGross = personen.All(p => p.Groesse > grenze);
```
* Richtig

3)
```csharp
var nachAlterSortiert = personen.OrderBy(person.Alter);
```
* Falsch
* ``LINQ`` Ausdrücke benötigen (zu 99%) einen ``Delegaten`` als ``Argument``. Ein ``Delegat`` ist eine ``Variable`` welche eine ``Methode`` beinhaltet. Wir verwenden hier z.B. eine ``annonyme Methode``, welche hier mit einem ``Lambda`` Ausdruck umgesetzt wird.

>**Korrekt wäre:** (nicht gefragt, aber angenehmer zum Lernen)
```csharp
var nachAlterSortiert = personen.OrderBy(person => person.Alter);
```

4)
```csharp
var nachEssenGruppiert = personen.GroupBy(p => p.LieblingsEssen);
```
* Richtig

