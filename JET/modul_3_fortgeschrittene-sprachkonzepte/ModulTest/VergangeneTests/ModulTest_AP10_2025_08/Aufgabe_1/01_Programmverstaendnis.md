```csharp
var gans = personen.Filter(person => person.Name == "Gans");
```
* Falsch
* Der ``LINQ`` Ausdruck Filter existiert nicht. Es sollte ``Where`` heißen was ein Zeilenfilter bzw. elementwise filter ist. (In der Fachsprache ist es eine Restriktion oder sehr verwirrend, Selektion.)

```csharp
var nachAlterSortiert = personen.OrderBy(person.Alter);
```
* Falsch
* ``LINQ`` Ausdrücke benötigen (zu 99%) einen ``Delegaten`` als ``Argument``. Ein ``Delegat`` ist eine ``Variable`` welche eine ``Methode`` beinhaltet. Wir verwenden hier z.B. eine ``annonyme Methode``, welche hier mit einem ``Lambda`` Ausdruck umgesetzt wird.

```csharp
var strudelFans = personen
    .Select(person => person.Name)
    .Where(person => person.LieblingsEssen == "Strudel");
```
* Falsch
* Wir verwenden, anders als in ``SQL``, den ``LINQ`` Ausdruck ``Select`` nicht immer als erstes, sondern eher in der Mitte oder am Schluss. ``Select`` stellt hier einen Spaltenfilter oder eine variablewise filter dar. (In der Fachsprache ist es die Projektion.) Da wir nach dem ``Select`` in unserem Beispiel nur mehr eine ``Liste`` von ``Strings`` übrig haben, weiß der Compiler nicht was er mit der ``Eigenschaft`` *LieblingsEssen* tun soll. Ein ``String`` hat diese nicht.

```csharp
Person essenMitDuplikateSortiertNachAlter = personen.Select(p => new { p.LieblingsEssen, p.Alter}).OrderBy(p => p.Groesse);
```
* Falsch
* 
  1) Der ``LINQ`` Ausdruck verwendet ein ``Select`` und erzeugt hier ein ``annonymes Objekt`` mit den ``Eigenschaften`` *p.LieblingsEssen* und *p.Alter*. Es kann danach nicht mehr nach Größe sortiert werden, denn diese ``Eigenschaft`` existiert nicht im dem neuen ``Objekt``. Dieses ist keine ``Person`` mehr.
  2) Die Rückgabe ist durch ``OrderBy`` eine ``Liste`` von ``Personen``, nicht nur eine ``Person``. (Für die sehr genauen Leser:innen, es ist ein ``IOrderedEnumerable``, welches ein ``IEnumerable`` ist. Das ist eine ``Basisklasse`` von ``List``). 

```csharp
int grenze = ... // TODO selber einfügen.
bool sindAlleGross = personen.All(p => p.Groesse > grenze);
```
* Richtig

```csharp
var nachEssenGruppiert = personen.GroupBy(p => p.LieblingsEssen);
```
* Richtig

```csharp
var größtePersonWelcheJuengerAls30Ist = personen.OrderBy(p => p.Groesse).FirstOrDefault(p => p.Alter < 30);
```
* Richtig

```csharp
double durchschnittsgroesse = personen.Average(p => p.Groesse);
```
* Richtig

```csharp
int alterDerAeltestenPerson = personen.Max(p => p.Alter);
```
* Richtig

