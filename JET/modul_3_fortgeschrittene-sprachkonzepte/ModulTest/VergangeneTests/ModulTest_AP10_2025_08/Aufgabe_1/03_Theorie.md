1) Begründe warum der ``Typ`` des ``Parameters`` *filterBedingung* hier ``Func<Buch, bool>`` oder ``Action<Buch>`` ist? Ersetze dazu den ``...`` mit ``Func<Buch, bool>`` oder ``Action<Buch>``.

>**Hinweis**: Diese ``Typen`` können verwendet werden, um eine ``Methode`` als ``Variable`` zu speichern. Die ``Typparameter`` sind dabei ``Func<ParameterDerMethode, RückgabeDerMethode>`` und ``Action<ParameterDerMethode>``.

```csharp
static List<Buch> FiltereBücher(List<Buch> bücher, ... filterBedingung)
{
    var gefilterteListe = new List<Buch>();

    foreach (var buch in bücher)
    {
        if (filterBedingung(buch))
        {
            gefilterteListe.Add(buch);
        }
    }

    return gefilterteListe;
}
```

**Antwort:** Da hier die ``Methode`` *filterBedingung* in einer ``Bedingten Anweisung`` *if* verwendet wird, müssen wir hier einen ``Wert`` *bool* erzeugen. Das bedeutet, die ``Methode`` welche ich aufrufe braucht einen ``Rückgabewert``. Es ist deshalb der ``Typ`` *Func<Buch, bool>* zu verwenden.

2) Markiere in folgendem Code den *Beginn* und das *Ende* des ``Lambda`` Ausdrucks. 
```csharp
Console.WriteLine(string.Join(" ~ ", kunden.Where(t => t.Punkte >= 180)));
```

**Antwort:** Er beginnt bei dem ``Parameter`` *t* und endet nach dem ``Ausdruck`` *t.Punkte >= 180*.

3) Eine ``Methode`` mit ``Rückgabe`` besitzt eine ``Methodensignatur``. Diese beinhaltet:
    * einen ``Rückgabewert``/``Rückgabetyp``
    * den *Namen* der ``Methode`` und
    * einen oder mehrere ``Parameter``.

Ein Beispiel dafür ist ``double berechneKürzesteDistanz(Graph g)``

Was besitzt ein ``Lambda`` Ausdruck nicht, was eine ``Methode`` haben muss? 

**Antwort:** Der *Name* der ``Methode``. Ein ``Lambda`` Ausdruck ist eine Art eine ``Anonyme Methode`` darzustellen. Wenn wir das Wort ``Anonym`` verwenden, fehlt immer *etwas* was beim Normalen vorhanden ist..

4) Ein ``Objekt`` hat als ``Typ`` eine ``Klasse``. Durch dessen ``Klasse`` besitzt das ``Objekt`` ``Mitglieder``. Diese beinhalten:
    * ``Felder (Fields)``/``Eigenschaften (Properties)`` und
    * ``Methoden``

Ein Beispiel dafür ist ``new Kunde { Name = "Manuela", Alter = 36}.berechneUmsatz();``.

Was besitzt ein ``Anonymes Objekt`` nicht, was ein ``Objekt`` haben muss? Wie kann ein ``Anonymes Objekt`` bei einem ``LINQ`` Ausdruck verwendet werden?

**Hinweis:** Ein *Anonymes Objekt* wird auch *Anonymer Typ* genannt.

**Antwort:** 
* Der *Typ* des ``Objekts`` und die *Methoden* des ``Objekts``. Wenn wir das Wort ``Anonym`` verwenden, fehlt immer *etwas* was beim Normalen vorhanden ist.
* Bei einem ``LINQ`` Ausdruck welcher eine ``Select`` ``Methode`` verwendet.