* Finde die Fehler in diesem Code und markiere diese. 
* Erkläre wieso diese Fehler zu einer nicht gültigen bzw. konzeptionell falschen ``Property``(Eigenschaft) führen. Falls dir konzeptionelle Probleme auffallen, merke diese an.  

```csharp
// Fehler - modifier für property selbst (links) darf nicht einschränkender als jene bei den get und set sein.
private string Name { get; protected set; }

// Fehler - 
private int Id { private get; private set; }

// Korrekt
public int TäglicherUmsatzMitKommazahlen
{
    set
    {
        if (value > 2_000_000)
        {
            throw new ArgumentException("Der Umsatz ist nicht glaubwürdig");
        }
        field = value;
    }
    get;
}

// Korrekt 
private int _täglicherUmsatzMitKommazahlen;
public int TäglicherUmsatzMitKommazahlen
{
    set
    {
        if (value > 2_000_000)
        {
            throw new ArgumentException("Der Umsatz ist nicht glaubwürdig");
        }
        _täglicherUmsatzMitKommazahlen = value;
    }
    get => _täglicherUmsatzMitKommazahlen;
}
```