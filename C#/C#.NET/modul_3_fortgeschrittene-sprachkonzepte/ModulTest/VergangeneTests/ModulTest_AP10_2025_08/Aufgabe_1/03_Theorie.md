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

2) Erkläre den Unterschied zwischen folgenden ``Ausdrücken``:
```csharp
Console.WriteLine(string.Join(" ~ ", kunden.Where(t => t.Punkte >= 180)));
```
vs.

```csharp
public static bool HatGenugPunkte(Kunde k)
{
    return k.Punkte >= 180;
}

Console.WriteLine(string.Join(" ~ ", kunden.Where(HatGenugPunkte));
```

**Antwort:** Es wird im 1. Codesnippet eine ``anonyme Methode``, welche als ``Lambda`` Ausdruck umgesetzt wird, und im 2. Codesnippet eine "normale" ``Methode`` verwendet. Die Ergebnisse des Programms sind die gleichen.